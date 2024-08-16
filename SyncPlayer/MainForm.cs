using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using NAudio.Wave;

namespace SyncPlayer
{
    public partial class MainForm : Form
    {
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
            
            AudioPanel.Height = names.Length * audioHeight;
            StartTogetherButton.Top = AudioPanel.Top + AudioPanel.Height + 20;
            EndTogetherButton.Top = AudioPanel.Top + AudioPanel.Height + 20;
            Height = AudioPanel.Height + StartTogetherButton.Height + 80;
            ArrowPanel.Top = AudioPanel.Top + AudioPanel.Height;
            ArrowPanel.Left = AudioPanel.Left - 7;

            var g = AudioPanel.CreateGraphics();
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
            ShowGraphics(new string[] { "C1", "C2" },
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
