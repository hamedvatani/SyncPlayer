using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;

namespace SyncPlayer
{
    public partial class AudioVisualPlayer : UserControl
    {
        [Category("WaveFormPanel")]
        public bool ShowTopLine
        {
            get => _showTopLine;
            set
            {
                if (_showTopLine != value)
                {
                    _showTopLine = value;
                    WaveFormPanel_Paint(null, null);
                }
            }
        }

        [Category("WaveFormPanel")]
        public bool ShowBottomLine
        {
            get => _showBottomLine;
            set
            {
                if (_showBottomLine != value)
                {
                    _showBottomLine = value;
                    WaveFormPanel_Paint(null, null);
                }
            }
        }

        [Category("Audio")]
        public string Filename
        {
            get => _filename;
            set
            {
                _filename = value;
                if (File.Exists(_filename))
                    _audioFileReader = new AudioFileReader(_filename);
                AudioFileChanged();
            }
        }

        [Category("Audio")]
        public int SilenceBefore
        {
            get => _silenceBefore;
            set
            {
                _silenceBefore = value;
                AudioFileChanged();
            }
        }

        [Category("Audio")]
        public int SilenceAfter
        {
            get => _silenceAfter;
            set
            {
                _silenceAfter = value;
                AudioFileChanged();
            }
        }

        private int AudioTime => (int)(_audioFileReader?.TotalTime.TotalSeconds ?? 0);

        private bool _showTopLine;
        private bool _showBottomLine;
        private string _filename;
        private int _silenceBefore;
        private int _silenceAfter;
        private AudioFileReader _audioFileReader;

        public AudioVisualPlayer()
        {
            InitializeComponent();
        }

        private void AudioVisualPlayer_Load(object sender, EventArgs e)
        {
            AudioVisualPlayer_Resize(null, null);
        }

        private void AudioVisualPlayer_Resize(object sender, EventArgs e)
        {
            WaveFormPanel.Top = 0;
            WaveFormPanel.Left = 0;
            WaveFormPanel.Height = Height;
            WaveFormPanel.Width = Width - 155;

            FileNameLabel.Top = (Height - 80) / 2;
            FileNameLabel.Left = Width - 150;
            FileNameLabel.Height = 20;
            FileNameLabel.Width = 150;

            CurrentSilenceBeforeLabel.Top = 20 + (Height - 80) / 2;
            CurrentSilenceBeforeLabel.Left = Width - 150;
            CurrentSilenceBeforeLabel.Height = 20;
            CurrentSilenceBeforeLabel.Width = 50;

            SilenceBeforeLabel.Top = 40 + +(Height - 80) / 2;
            SilenceBeforeLabel.Left = Width - 150;
            SilenceBeforeLabel.Height = 20;
            SilenceBeforeLabel.Width = 50;

            CurrentAudioLabel.Top = 20 + (Height - 80) / 2;
            CurrentAudioLabel.Left = Width - 100;
            CurrentAudioLabel.Height = 20;
            CurrentAudioLabel.Width = 50;

            AudioLabel.Top = 40 + (Height - 80) / 2;
            AudioLabel.Left = Width - 100;
            AudioLabel.Height = 20;
            AudioLabel.Width = 50;

            CurrentSilenceAfterLabel.Top = 20 + (Height - 80) / 2;
            CurrentSilenceAfterLabel.Left = Width - 50;
            CurrentSilenceAfterLabel.Height = 20;
            CurrentSilenceAfterLabel.Width = 50;

            SilenceAfterLabel.Top = 40 + (Height - 80) / 2;
            SilenceAfterLabel.Left = Width - 50;
            SilenceAfterLabel.Height = 20;
            SilenceAfterLabel.Width = 50;

            TotalScrollBar.Top = 60 + (Height - 80) / 2;
            TotalScrollBar.Left = Width - 150;
            TotalScrollBar.Height = 17;
            TotalScrollBar.Width = 150;
        }

        private void WaveFormPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = WaveFormPanel.CreateGraphics();
            g.Clear(Color.White);
            g.DrawLine(new Pen(Color.Black)
                , 0, 0,
                0, WaveFormPanel.Height);
            g.DrawLine(new Pen(Color.Black)
                , WaveFormPanel.Width - 1, 0,
                WaveFormPanel.Width - 1, WaveFormPanel.Height);
            if (_showTopLine)
                g.DrawLine(new Pen(Color.Black)
                    , 0, 0,
                    WaveFormPanel.Width, 0);
            if (_showBottomLine)
                g.DrawLine(new Pen(Color.Black
                    ), 0, WaveFormPanel.Height - 1,
                    WaveFormPanel.Width - 1, WaveFormPanel.Height - 1);

            if (_silenceBefore < 0 ||
                AudioTime <= 0 ||
                _silenceAfter < 0 ||
                _silenceBefore + AudioTime + _silenceAfter <= 0)
                return;
        }

        private void AudioFileChanged()
        {
            FileNameLabel.Text = Path.GetFileName(_filename);
            CurrentSilenceBeforeLabel.Text = ToStr(TimeSpan.Zero);
            CurrentAudioLabel.Text = ToStr(TimeSpan.Zero);
            CurrentSilenceAfterLabel.Text = ToStr(TimeSpan.Zero);
            SilenceBeforeLabel.Text = ToStr(TimeSpan.FromSeconds(_silenceBefore));
            AudioLabel.Text = ToStr(TimeSpan.FromSeconds(AudioTime));
            SilenceAfterLabel.Text = ToStr(TimeSpan.FromSeconds(_silenceAfter));
        }

        private string ToStr(TimeSpan ts)
        {
            return $"{(int)ts.TotalMinutes}:{ts:ss}";
        }
    }
}