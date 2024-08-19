using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace SyncPlayer
{
    public partial class SyncPlayerForm : Form
    {
        private int _startAt;
        private DateTime _startTime;
        private bool _isPlaying;
        private bool _scrollChanging;
        private int _totalLength;

        public SyncPlayerForm()
        {
            InitializeComponent();
        }

        public void AddFiles(params string[] filenames)
        {
            var count = 0;
            AudioVisualPlayer lastPlayer = null;
            foreach (var control in Controls)
                if (control is AudioVisualPlayer player)
                {
                    lastPlayer = player;
                    count++;
                }

            if (lastPlayer != null)
                lastPlayer.ShowBottomLine = false;

            for (int i = 0; i < filenames.Length; i++)
            {
                var player = new AudioVisualPlayer { Filename = filenames[i] };
                player.WaveFormMargin = 20;
                if (i == 0 && count == 0)
                    player.ShowTopLine = true;
                if (i == filenames.Length - 1)
                    player.ShowBottomLine = true;
                player.Top = 9 + 80 * (i + count);
                player.Left = 9;
                player.Width = Width - 48;
                player.Height = 80;
                player.SilenceScroll += Player_SilenceScroll;
                player.EndOfPlay += Player_EndOfPlay;
                Controls.Add(player);
            }

            Height = (filenames.Length + count) * 80 + 100;

            _totalLength = 0;
            foreach (var control in Controls)
                if (control is AudioVisualPlayer player &&
                    _totalLength < player.AudioTime)
                    _totalLength = player.AudioTime;

            TotalScrollBar.Value = 0;
            TotalScrollBar.Maximum = _totalLength;

            foreach (var control in Controls)
                if (control is AudioVisualPlayer player)
                {
                    player.SilenceBefore = _totalLength - player.AudioTime;
                    player.SilenceAfter = 0;
                }

            PlayAt(0);
        }

        private void PlayAt(int seconds)
        {
            foreach (Control control in Controls)
                if (control is AudioVisualPlayer player)
                    player.PlayAt(seconds);
            _startAt = seconds;
            _startTime = DateTime.Now;
            _isPlaying = true;
        }

        private void Stop()
        {
            foreach (Control control in Controls)
                if (control is AudioVisualPlayer player)
                    player.Stop();
            _isPlaying = false;
        }

        private void Player_SilenceScroll(object sender, EventArgs e)
        {
            Stop();
            PlayAt(0);
        }

        private void Player_EndOfPlay(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
                if (control is AudioVisualPlayer player)
                    if (player.IsPlaying)
                        return;
            Stop();
        }

        private void SyncPlayerForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void SyncPlayerForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                e.Data.GetData(DataFormats.FileDrop) is string[] filenames)
                AddFiles(filenames);
        }

        private void JobTimer_Tick(object sender, EventArgs e)
        {
            if (!_isPlaying || _scrollChanging)
                return;

            var elapsed = (int)(DateTime.Now - _startTime).TotalSeconds + _startAt;
            TotalScrollBar.Value = elapsed;
            foreach (var control in Controls)
                if (control is AudioVisualPlayer player)
                    player.ShowIndicator(elapsed);
        }

        private void TotalScrollBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            _scrollChanging = true;
        }

        private void TotalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                _scrollChanging = false;
                Stop();
                PlayAt(TotalScrollBar.Value);
            }
            else
                foreach (var control in Controls)
                    if (control is AudioVisualPlayer player)
                        player.ShowIndicator(TotalScrollBar.Value);
        }

        private void AlignToBeginButton_Click(object sender, EventArgs e)
        {
            Stop();
            foreach (var control in Controls)
                if (control is AudioVisualPlayer player)
                {
                    player.SilenceBefore = 0;
                    player.SilenceAfter = _totalLength - player.AudioTime;
                }
            PlayAt(0);
        }

        private void AlignToEndButton_Click(object sender, EventArgs e)
        {
            Stop();
            foreach (var control in Controls)
                if (control is AudioVisualPlayer player)
                {
                    player.SilenceBefore = _totalLength - player.AudioTime;
                    player.SilenceAfter = 0;
                }
            PlayAt(0);
        }
    }
}
