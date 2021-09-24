using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayrt_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NAudio.Wave.BlockAlignReductionStream music = null;
        private NAudio.Wave.DirectSoundOut output   = null;

        private void ReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Audio file (*.mp3;*.wav)|*.mp3;*.wav";
            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DisposeWave();
            if (open.FileName.EndsWith(".mp3"))
            {
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(open.FileName));
                music = new NAudio.Wave.BlockAlignReductionStream(pcm);
            }
            else if (open.FileName.EndsWith(".wav"))
            {
                NAudio.Wave.WaveStream pcm = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));
                music = new NAudio.Wave.BlockAlignReductionStream(pcm);
            }
            else throw new InvalidOperationException("Not a correct audio file type.");

            output = new NAudio.Wave.DirectSoundOut();
            output.Init(music);
            var duration = music.TotalTime;
            MusicTimeTrackBar.Maximum = (int)duration.TotalMilliseconds;
            MusicDurationTime.Text = duration.ToString(@"hh\:mm\:ss");
            output.Play();
            PausePlay.Enabled = true;
            Stop.Enabled = true;
        }

        private void PausePlay_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    output.Pause();
                }
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                {
                    output.Play();
                }
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                output.Stop();
                PausePlay.Enabled = false;
                Stop.Enabled = false;
                MusicDurationTime.Text = "00:00:00";
            }
        }

        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    output.Stop();
                }
                output.Dispose();
                output = null;
            }
            if (music != null)
            {
                music.Dispose();
                music = null;
            }
        }
    }
}
