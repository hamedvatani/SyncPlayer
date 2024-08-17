using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using NAudio.Wave;

namespace SyncPlayer
{
    public partial class MainForm : Form
    {
        private List<Label> _labels = new List<Label>();
        private List<HScrollBar> _hScrollBars = new List<HScrollBar>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadAudioFiles(params string[] filenames)
        {
            var readers = new List<AudioFileReader>();
            foreach (var filename in filenames)
                readers.Add(new AudioFileReader(filename));


        }

        private void ShowGraphics(string[] names, TimeSpan[] lengths, TimeSpan[] silencesBefore, TimeSpan[] silencesAfter)
        {
            var audioHeight = 50;
            var curveHeight = 30;

            var g = AudioPanel.CreateGraphics();
            
            AudioPanel.Height = names.Length * audioHeight;
            ArrowPanel.Top = AudioPanel.Top + AudioPanel.Height;
            ArrowPanel.Left = AudioPanel.Left - 7;
            
            foreach (var label in _labels)
                Controls.Remove(label);
            _labels.Clear();

            foreach (var hScrollBar in _hScrollBars)
                Controls.Remove(hScrollBar);
            _hScrollBars.Clear();

            var maxLabelSize = new Size(0, 0);
            foreach (var name in names)
            {
                var size = g.MeasureString(name + " :", Font);
                if (maxLabelSize.Width < size.Width)
                    maxLabelSize.Width = (int)size.Width;
                if (maxLabelSize.Height < size.Height)
                    maxLabelSize.Height = (int)size.Height;
            }

            for (int i = 0; i < names.Length; i++)
            {
                var text = names[i] + " :";
                var size = g.MeasureString(text, Font);
                var label = new Label
                {
                    Top = ArrowPanel.Top + ArrowPanel.Height + 5 + i * (maxLabelSize.Height + 10),
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
                    Height = 17
                };
                Controls.Add(hScrollBar);
                _hScrollBars.Add(hScrollBar);
            }

            AlignToEndButton.Top = ArrowPanel.Top + ArrowPanel.Height + 5;
            AlignToEndButton.Left = AudioPanel.Left + AudioPanel.Width - AlignToEndButton.Width;
            AlignToBeginButton.Top = AlignToEndButton.Top;
            AlignToBeginButton.Left = AlignToEndButton.Left - 30;

            Height = ArrowPanel.Top
                     + ArrowPanel.Height
                     + 5
                     + names.Length * (maxLabelSize.Height + 10)
                     + 17
                     + 30;

            g.Clear(Color.White);
            var maxLength = TimeSpan.Zero;
            for (int i = 0; i < names.Length; i++)
            {
                var l = lengths[i] + silencesBefore[i] + silencesAfter[i];
                if (l > maxLength)
                    maxLength = l;
            }
            for (int i = 0; i < names.Length; i++)
            {
                var offsetY = audioHeight * i + audioHeight / 2;
                var x1 = silencesBefore[i].TotalSeconds * AudioPanel.Width / maxLength.TotalSeconds;
                g.DrawLine(new Pen(Color.Black),
                    0, offsetY,
                    (int)x1, offsetY);
                var x2 = x1 + lengths[i].TotalSeconds * AudioPanel.Width / maxLength.TotalSeconds;
                g.FillRectangle(new SolidBrush(Color.Blue),
                    (int)x1, offsetY - curveHeight / 2,
                    (int)x2 - (int)x1, curveHeight);g.DrawLine(new Pen(Color.Black),
                    (int)x2, offsetY,
                    AudioPanel.Width, offsetY);
            }

            g = ArrowPanel.CreateGraphics();
            g.FillPolygon(new SolidBrush(Color.Red),
                new Point[]
                {
                    new Point(8, 0),
                    new Point(0, 13),
                    new Point(15, 13),
                });
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var g = AudioPanel.CreateGraphics();
            ShowGraphics(new string[] { "My First File", "File 2" },
                new TimeSpan[] { TimeSpan.FromMinutes(4), TimeSpan.FromMinutes(5) },
                new TimeSpan[] { TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30) },
                new TimeSpan[] { TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(10) });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var r = new Random();
            ArrowPanel.Left = AudioPanel.Left - 7 + r.Next(0, AudioPanel.Width);
        }
    }
}
