using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

namespace SyncPlayer
{
    public partial class MainForm : Form
    {
        private readonly List<Label> _labels = new List<Label>();
        private readonly List<MyScrollBar> _scrollBars = new List<MyScrollBar>();
        private readonly List<AudioFile> _audioFiles = new List<AudioFile>();
        private int _startAt;
        private DateTime _startTime;
        private int _maxLength;
        private bool _scrollChanging;

        private const int AudioHeight = 50;
        private const int CurveHeight = 30;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetLayout()
        {
            if (_audioFiles.Count == 0)
                return;

            AudioPanel.Height = _audioFiles.Count * AudioHeight;

            ArrowPanel.Top = AudioPanel.Top + AudioPanel.Height;
            ArrowPanel.Left = AudioPanel.Left - 7;

            TotalScrollBar.Top = Top = ArrowPanel.Top + ArrowPanel.Height + 5;
            TotalScrollBar.Left = AudioPanel.Left;
            TotalScrollBar.Width = AudioPanel.Width;
            TotalScrollBar.Value = 0;
            TotalScrollBar.Maximum = _audioFiles.Max(x => x.TotalTime + x.SilenceBefore + x.SilenceAfter);

            AlignToEndButton.Top = TotalScrollBar.Top + TotalScrollBar.Height + 5;
            AlignToEndButton.Left = AudioPanel.Left + AudioPanel.Width - AlignToEndButton.Width;
            AlignToBeginButton.Top = AlignToEndButton.Top;
            AlignToBeginButton.Left = AlignToEndButton.Left - 30;

            foreach (var label in _labels)
                Controls.Remove(label);
            _labels.Clear();

            foreach (var scrollBar in _scrollBars)
            {
                scrollBar.Scroll -= ScrollBar_Scroll;
                Controls.Remove(scrollBar);
            }

            _scrollBars.Clear();

            var maxLabelSize = new Size(0, 0);
            var g = CreateGraphics();
            foreach (var audioFile in _audioFiles)
            {
                var size = g.MeasureString(audioFile.Filename + " :", Font);
                if (maxLabelSize.Width < size.Width)
                    maxLabelSize.Width = (int)size.Width;
                if (maxLabelSize.Height < size.Height)
                    maxLabelSize.Height = (int)size.Height;
            }

            for (int i = 0; i < _audioFiles.Count; i++)
            {
                var text = _audioFiles[i].Filename + " :";
                var size = g.MeasureString(text, Font);
                var label = new Label
                {
                    Top = TotalScrollBar.Top + TotalScrollBar.Height + 5 + i * (maxLabelSize.Height + 10),
                    Left = AudioPanel.Left + maxLabelSize.Width - (int)size.Width,
                    Width = (int)size.Width + 10,
                    Height = (int)size.Height,
                    Text = text,
                    TextAlign = ContentAlignment.MiddleRight
                };
                Controls.Add(label);
                _labels.Add(label);

                var scrollBar = new MyScrollBar
                {
                    Top = label.Top,
                    Left = label.Left + label.Width + 10,
                    Width = 150,
                    Height = 17,
                    Value = 0,
                    Maximum = _audioFiles[i].SilenceBefore + _audioFiles[i].SilenceAfter,
                    Tag = _audioFiles[i]
                };

                scrollBar.Value = _audioFiles[i].SilenceBefore;
                scrollBar.Scroll += ScrollBar_Scroll;
                _audioFiles[i].ScrollBar = scrollBar;
                Controls.Add(scrollBar);
                _scrollBars.Add(scrollBar);
            }

            Height = TotalScrollBar.Top
                     + TotalScrollBar.Height
                     + 5
                     + _audioFiles.Count * (maxLabelSize.Height + 10)
                     + 17
                     + 30;

            g = ArrowPanel.CreateGraphics();
            g.FillPolygon(new SolidBrush(Color.Red),
                new[]
                {
                    new Point(8, 0),
                    new Point(0, 13),
                    new Point(15, 13),
                });
        }

        private void DrawWaveForms()
        {
            if (_audioFiles.Count == 0)
                return;

            var g = AudioPanel.CreateGraphics();
            g.Clear(Color.White);
            var maxLength = _audioFiles.Max(x => x.SilenceBefore + x.TotalTime + x.SilenceAfter);
            _maxLength = maxLength;

            for (int i = 0; i < _audioFiles.Count; i++)
            {
                var offsetY = AudioHeight * i + AudioHeight / 2;
                var x1 = _audioFiles[i].SilenceBefore * AudioPanel.Width / maxLength;
                g.DrawLine(new Pen(Color.Black),
                    0, offsetY,
                    x1, offsetY);
                var x2 = x1 + _audioFiles[i].TotalTime * AudioPanel.Width / maxLength;
                g.FillRectangle(new SolidBrush(Color.Blue),
                    x1, offsetY - CurveHeight / 2,
                    x2 - x1, CurveHeight);
                g.DrawLine(new Pen(Color.Black),
                    x2, offsetY,
                    AudioPanel.Width, offsetY);
            }
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (sender is MyScrollBar scrollBar && scrollBar.Tag is AudioFile audioFile)
            {
                audioFile.SilenceBefore = scrollBar.Value;
                audioFile.SilenceAfter = scrollBar.Maximum - scrollBar.Value;
                DrawWaveForms();
            }
        }

        private void AddFiles(string[] filenames)
        {
            foreach (var audioFile in _audioFiles)
                audioFile.Close();
            _audioFiles.Clear();
            foreach (var filename in filenames)
                _audioFiles.Add(new AudioFile(new AudioFileReader(filename))
                {
                    FilePath = filename,
                    SilenceAfter = 0
                });

            var maxLength = _audioFiles.Max(x => x.TotalTime);
            foreach (var audioFile in _audioFiles)
                audioFile.SilenceBefore = maxLength - audioFile.TotalTime;
            SetLayout();
            DrawWaveForms();
            _startTime = DateTime.Now;
            _startAt = 0;
            PlayBackTimer.Start();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                e.Data.GetData(DataFormats.FileDrop) is string[] filenames)
                AddFiles(filenames);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            DrawWaveForms();
        }

        private void AlignToBeginButton_Click(object sender, EventArgs e)
        {
            foreach (var audioFile in _audioFiles)
            {
                var sum = audioFile.SilenceBefore + audioFile.SilenceAfter;
                audioFile.SilenceBefore = 0;
                audioFile.SilenceAfter = sum;
                audioFile.ScrollBar.Value = 0;
            }

            DrawWaveForms();
        }

        private void AlignToEndButton_Click(object sender, EventArgs e)
        {
            foreach (var audioFile in _audioFiles)
            {
                var sum = audioFile.SilenceBefore + audioFile.SilenceAfter;
                audioFile.SilenceBefore = sum;
                audioFile.SilenceAfter = 0;
                audioFile.ScrollBar.Value = sum;
            }

            DrawWaveForms();
        }

        private void PlayBackTimer_Tick(object sender, EventArgs e)
        {
            var elapsed = (int)(DateTime.Now - _startTime).TotalSeconds;
            elapsed += _startAt;
            var x = elapsed * AudioPanel.Width / _maxLength;

            if (!_scrollChanging)
            {
                ArrowPanel.Left = AudioPanel.Left + x - 7;
                TotalScrollBar.Value = elapsed;
            }

            foreach (var audioFile in _audioFiles)
            {
                if (_startAt + elapsed < audioFile.SilenceBefore)
                {
                    audioFile.Stop();
                    audioFile.PlayFlag = false;
                }
                else if (_startAt + elapsed < audioFile.SilenceBefore + audioFile.TotalTime)
                {
                    if (!audioFile.PlayFlag)
                    {
                        audioFile.PlayFlag = true;
                        audioFile.Play();
                    }
                }
                else
                {
                    audioFile.Stop();
                    audioFile.PlayFlag = false;
                }
            }
        }

        private void TotalScrollBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            _scrollChanging = true;
        }

        private void TotalScrollBar_ValueChanged(object sender, EventArgs e)
        {
        }

        private void TotalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                _scrollChanging = false;
                foreach (var audioFile in _audioFiles)
                {
                    audioFile.Stop();
                    audioFile.PlayFlag = false;
                }

                _startTime = DateTime.Now;
                _startAt = TotalScrollBar.Value;
            }

            var elapsed = TotalScrollBar.Value;
            var x = elapsed * AudioPanel.Width / _maxLength;
            ArrowPanel.Left = AudioPanel.Left + x - 7;
        }
    }
}