using NAudio.Wave;
using System.IO;

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
        public bool PlayFlag { get; set; }

        private readonly AudioFileReader _audioFileReader;
        private readonly WaveOut _waveOut;

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

        public void Play()
        {
            if (_waveOut.PlaybackState != PlaybackState.Playing)
                _waveOut.Play();
        }

        public void Stop()
        {
            if (_waveOut.PlaybackState == PlaybackState.Playing)
                _waveOut.Stop();
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            _waveOut.Stop();
        }
    }
}