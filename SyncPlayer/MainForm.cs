using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;

namespace SyncPlayer
{
    public partial class MainForm : Form
    {
        public class AudioFile
        {
            public string FilePath { get; set; }
            public string Filename => Path.GetFileName(FilePath);
            public AudioFileReader AudioFileReader { get; set; }
            public TimeSpan SilenceBefore { get; set; }
            public TimeSpan SilenceAfter { get; set; }
            public HScrollBar HScrollBar { get; set; }
        }

        private readonly List<Label> _labels = new List<Label>();
        private readonly List<HScrollBar> _hScrollBars = new List<HScrollBar>();
        private readonly List<AudioFile> _audioFiles = new List<AudioFile>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowGraphics(bool init = true)
        {
            var audioHeight = 50;
            var curveHeight = 30;

            var g = AudioPanel.CreateGraphics();

            if (init)
            {
                AudioPanel.Height = _audioFiles.Count * audioHeight;
                ArrowPanel.Top = AudioPanel.Top + AudioPanel.Height;
                ArrowPanel.Left = AudioPanel.Left - 7;

                TotalScrollBar.Top = Top = ArrowPanel.Top + ArrowPanel.Height + 5;
                TotalScrollBar.Left = AudioPanel.Left;
                TotalScrollBar.Width = AudioPanel.Width;
                TotalScrollBar.Value = 0;
                TotalScrollBar.Maximum = (int)_audioFiles
                    .Max(x => x.AudioFileReader.TotalTime + x.SilenceBefore + x.SilenceAfter)
                    .TotalSeconds;

                AlignToEndButton.Top = TotalScrollBar.Top + TotalScrollBar.Height + 5;
                AlignToEndButton.Left = AudioPanel.Left + AudioPanel.Width - AlignToEndButton.Width;
                AlignToBeginButton.Top = AlignToEndButton.Top;
                AlignToBeginButton.Left = AlignToEndButton.Left - 30;

                foreach (var label in _labels)
                    Controls.Remove(label);
                _labels.Clear();

                foreach (var hScrollBar in _hScrollBars)
                {
                    hScrollBar.Scroll -= HScrollBar_Scroll;
                    Controls.Remove(hScrollBar);
                }

                _hScrollBars.Clear();

                var maxLabelSize = new Size(0, 0);
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

                    var hScrollBar = new HScrollBar
                    {
                        Top = label.Top,
                        Left = label.Left + label.Width + 10,
                        Width = 150,
                        Height = 17,
                        Value = 0,
                        Maximum = (int)(_audioFiles[i].SilenceBefore += _audioFiles[i].SilenceAfter).TotalSeconds,
                        Tag = _audioFiles[i]
                    };

                    hScrollBar.Value = (int)_audioFiles[i].SilenceBefore.TotalSeconds;
                    hScrollBar.Scroll += HScrollBar_Scroll;
                    _audioFiles[i].HScrollBar = hScrollBar;
                    Controls.Add(hScrollBar);
                    _hScrollBars.Add(hScrollBar);
                }

                Height = TotalScrollBar.Top
                         + TotalScrollBar.Height
                         + 5
                         + _audioFiles.Count * (maxLabelSize.Height + 10)
                         + 17
                         + 30;
            }

            g.Clear(Color.White);
            var maxLength = TimeSpan.Zero;
            for (int i = 0; i < _audioFiles.Count; i++)
            {
                var l = _audioFiles[i].AudioFileReader.TotalTime +
                        _audioFiles[i].SilenceBefore +
                        _audioFiles[i].SilenceAfter;
                if (l > maxLength)
                    maxLength = l;
            }

            for (int i = 0; i < _audioFiles.Count; i++)
            {
                var offsetY = audioHeight * i + audioHeight / 2;
                var x1 = _audioFiles[i].SilenceBefore.TotalSeconds * AudioPanel.Width / maxLength.TotalSeconds;
                g.DrawLine(new Pen(Color.Black),
                    0, offsetY,
                    (int)x1, offsetY);
                var x2 = x1 + _audioFiles[i].AudioFileReader.TotalTime.TotalSeconds *
                    AudioPanel.Width /
                    maxLength.TotalSeconds;
                g.FillRectangle(new SolidBrush(Color.Blue),
                    (int)x1, offsetY - curveHeight / 2,
                    (int)x2 - (int)x1, curveHeight);
                g.DrawLine(new Pen(Color.Black),
                    (int)x2, offsetY,
                    AudioPanel.Width, offsetY);
            }

            g = ArrowPanel.CreateGraphics();
            g.FillPolygon(new SolidBrush(Color.Red),
                new[]
                {
                    new Point(8, 0),
                    new Point(0, 13),
                    new Point(15, 13),
                });
        }

        private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (sender is HScrollBar hScrollBar && hScrollBar.Tag is AudioFile audioFile)
            {
                var sb = TimeSpan.FromSeconds(hScrollBar.Value);
                var sa = audioFile.SilenceBefore + audioFile.SilenceAfter - sb;
                audioFile.SilenceBefore = sb;
                audioFile.SilenceAfter = sa;
                ShowGraphics(false);
            }
        }

        private void AddFiles(string[] filenames)
        {
            foreach (var audioFile in _audioFiles)
                audioFile.AudioFileReader.Close();
            _audioFiles.Clear();
            foreach (var filename in filenames)
                _audioFiles.Add(new AudioFile
                {
                    FilePath = filename,
                    AudioFileReader = new AudioFileReader(filename),
                    SilenceAfter = TimeSpan.Zero
                });
            var maxLength = _audioFiles.Max(x => x.AudioFileReader.TotalTime);
            foreach (var audioFile in _audioFiles)
                audioFile.SilenceBefore = maxLength - audioFile.AudioFileReader.TotalTime;
            ShowGraphics();
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
            ShowGraphics(false);
        }

        private void AlignToBeginButton_Click(object sender, EventArgs e)
        {
            foreach (var audioFile in _audioFiles)
            {
                var sb = TimeSpan.Zero;
                var sa = audioFile.SilenceBefore + audioFile.SilenceAfter - sb;
                audioFile.SilenceBefore = sb;
                audioFile.SilenceAfter = sa;
                audioFile.HScrollBar.Value = (int)audioFile.SilenceBefore.TotalSeconds;
            }

            ShowGraphics(false);
        }

        private void AlignToEndButton_Click(object sender, EventArgs e)
        {
            foreach (var audioFile in _audioFiles)
            {
                var sa = TimeSpan.Zero;
                var sb = audioFile.SilenceBefore + audioFile.SilenceAfter - sa;
                audioFile.SilenceBefore = sb;
                audioFile.SilenceAfter = sa;
                audioFile.HScrollBar.Value = (int)audioFile.SilenceBefore.TotalSeconds;
            }

            ShowGraphics(false);
        }
    }
}