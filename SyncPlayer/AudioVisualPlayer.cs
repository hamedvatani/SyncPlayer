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

        [Category("WaveFormPanel")]
        public int WaveFormMargin
        {
            get => _waveFormMargin;
            set
            {
                if (_waveFormMargin != value)
                {
                    _waveFormMargin = value;
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
                {
                    _audioFileReader = new AudioFileReader(_filename);
                    _waveOut.Init(_audioFileReader);
                }

                AudioFileChanged();
                ScrollChanged();
                WaveFormPanel_Paint(null, null);
            }
        }

        [Category("Audio")]
        public int SilenceBefore
        {
            get => _silenceBefore;
            set
            {
                if (_silenceBefore != value)
                {
                    _silenceBefore = value;
                    AudioFileChanged();
                    ScrollChanged();
                    WaveFormPanel_Paint(null, null);
                }
            }
        }

        [Category("Audio")]
        public int SilenceAfter
        {
            get => _silenceAfter;
            set
            {
                if (_silenceAfter != value)
                {
                    _silenceAfter = value;
                    AudioFileChanged();
                    ScrollChanged();
                    WaveFormPanel_Paint(null, null);
                }
            }
        }

        public int AudioTime => (int)(_audioFileReader?.TotalTime.TotalSeconds ?? 0);
        public int CurrentAudioTime => (int)(_audioFileReader?.CurrentTime.TotalSeconds ?? 0);
        public bool IsPlaying => _isPlaying;

        private bool _showTopLine;
        private bool _showBottomLine;
        private int _waveFormMargin;
        private string _filename;
        private int _silenceBefore;
        private int _silenceAfter;
        private AudioFileReader _audioFileReader;
        private int _currentTime;
        private int _startAt;
        private DateTime _startTime;
        private bool _isPlaying;
        private readonly WaveOut _waveOut = new WaveOut();
        public AudioVisualPlayer()
        {
            InitializeComponent();
        }

        public void PlayAt(int seconds)
        {
            if (_audioFileReader == null)
                return;

            _startAt = seconds;
            _startTime = DateTime.Now;
            if (seconds > _silenceBefore && seconds < _silenceBefore + AudioTime)
                _audioFileReader.CurrentTime = TimeSpan.FromSeconds(seconds - _silenceBefore);
            else
                _audioFileReader.CurrentTime = TimeSpan.Zero;
            _isPlaying = true;
        }

        public void Stop()
        {
            _isPlaying = false;
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
                _waveOut.Stop();
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
            g.DrawLine(new Pen(Color.Black),
                0, 0,
                0, WaveFormPanel.Height);
            g.DrawLine(new Pen(Color.Black),
                WaveFormPanel.Width - 1, 0,
                WaveFormPanel.Width - 1, WaveFormPanel.Height);
            if (_showTopLine)
                g.DrawLine(new Pen(Color.Black),
                    0, 0,
                    WaveFormPanel.Width, 0);
            if (_showBottomLine)
                g.DrawLine(new Pen(Color.Black),
                    0, WaveFormPanel.Height - 1,
                    WaveFormPanel.Width - 1, WaveFormPanel.Height - 1);

            var totalTime = _silenceBefore + AudioTime + _silenceAfter;
            if (_silenceBefore < 0 ||
                AudioTime <= 0 ||
                _silenceAfter < 0 ||
                totalTime <= 0)
                return;

            double ratio = WaveFormPanel.Width;
            ratio /= totalTime;
            var x1 = (int)(_silenceBefore * ratio);
            var x2 = (int)((_silenceBefore + AudioTime) * ratio);

            g.DrawLine(new Pen(Color.Black),
                0, Height / 2,
                x1, Height / 2);
            g.FillRectangle(new SolidBrush(Color.DodgerBlue),
                x1, _waveFormMargin,
                x2 - x1, Height - 2 * _waveFormMargin);
            g.DrawLine(new Pen(Color.Black),
                x2, Height / 2,
                WaveFormPanel.Width, Height / 2);

            var x = (int)(_currentTime * ratio);
            g.FillRectangle(new SolidBrush(Color.OrangeRed),
                x, 0,
                2, Height);
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

        private void ScrollChanged()
        {
            TotalScrollBar.Value = 0;
            TotalScrollBar.Maximum = _silenceBefore + _silenceAfter;
            TotalScrollBar.Value = _silenceBefore;
        }

        private string ToStr(TimeSpan ts)
        {
            return $"{(int)ts.TotalMinutes}:{ts:ss}";
        }

        private void TotalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            _silenceBefore = TotalScrollBar.Value;
            _silenceAfter = TotalScrollBar.Maximum - TotalScrollBar.Value;
            AudioFileChanged();
            WaveFormPanel_Paint(null, null);
        }

        private void JobTimer_Tick(object sender, EventArgs e)
        {
            if (!IsPlaying)
                return;

            var elapsed = (int)(DateTime.Now - _startTime).TotalSeconds + _startAt;
            SetCurrentTime(elapsed);
            if (elapsed > _silenceBefore && elapsed < _silenceBefore + AudioTime)
            {
                if (_waveOut != null && _waveOut.PlaybackState != PlaybackState.Playing)
                    _waveOut.Play();
            }
            else
            {
                if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
                    _waveOut.Stop();
            }
        }

        private void SetCurrentTime(int currentTime)
        {
            if (_audioFileReader == null)
                return;

            _currentTime = currentTime;
            if (currentTime < 0)
            {
                CurrentSilenceBeforeLabel.Text = ToStr(TimeSpan.Zero);
                CurrentAudioLabel.Text = ToStr(TimeSpan.Zero);
                CurrentSilenceAfterLabel.Text = ToStr(TimeSpan.Zero);
            }
            else if (currentTime < _silenceBefore)
            {
                CurrentSilenceBeforeLabel.Text = ToStr(TimeSpan.FromSeconds(_currentTime));
                CurrentAudioLabel.Text = ToStr(TimeSpan.Zero);
                CurrentSilenceAfterLabel.Text = ToStr(TimeSpan.Zero);
            }
            else if (currentTime < _silenceBefore + AudioTime)
            {
                CurrentSilenceBeforeLabel.Text = ToStr(TimeSpan.FromSeconds(_silenceBefore));
                CurrentAudioLabel.Text = ToStr(TimeSpan.FromSeconds(CurrentAudioTime));
                CurrentSilenceAfterLabel.Text = ToStr(TimeSpan.Zero);
            }
            else if (currentTime < _silenceBefore + AudioTime + _silenceAfter)
            {
                CurrentSilenceBeforeLabel.Text = ToStr(TimeSpan.FromSeconds(_silenceBefore));
                CurrentAudioLabel.Text = ToStr(TimeSpan.FromSeconds(AudioTime));
                CurrentSilenceAfterLabel.Text = ToStr(TimeSpan.FromSeconds(_currentTime - AudioTime - _silenceBefore));
            }
            else
            {
                CurrentSilenceBeforeLabel.Text = ToStr(TimeSpan.FromSeconds(_silenceBefore));
                CurrentAudioLabel.Text = ToStr(TimeSpan.FromSeconds(AudioTime));
                CurrentSilenceAfterLabel.Text = ToStr(TimeSpan.FromSeconds(_silenceAfter));
            }

            WaveFormPanel_Paint(null, null);
        }
    }
}