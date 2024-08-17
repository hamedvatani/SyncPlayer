using NAudio.Wave;
using System.IO;
using System.Timers;

namespace SyncPlayer
{
    public class AudioFile
    {
        public string FilePath { get; set; }
        public string Filename => Path.GetFileName(FilePath);
        public int TotalTime => (int)_audioFileReader.TotalTime.TotalSeconds;
        public int SilenceBefore { get; set; }
        public int SilenceAfter { get; set; }
        public MyScrollBar ScrollBar { get; set; }

        private readonly AudioFileReader _audioFileReader;
        private WaveOut _waveOut;
        private Timer _timer;

        public AudioFile(AudioFileReader audioFileReader)
        {
            _audioFileReader = audioFileReader;

            _waveOut = new WaveOut();
            _waveOut.Init(_audioFileReader);
            _waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
        }

        public void Close()
        {
            _audioFileReader.Close();
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            _waveOut.Stop();
        }
    }
}