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
        private NAudio.Wave.BlockAlignReductionStream music = null;
        private NAudio.Wave.DirectSoundOut output = null;
       

        public Form1()
        {
            InitializeComponent();
            DisposeWave();
        }
       
        private void ReadFile_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
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
            Timer1.Enabled = true;
            PausePlay.Enabled = true;
            Stop.Enabled = true;
        }

        private void PausePlay_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    PausePlay.Text = "Play";
                    Timer1.Enabled = false;
                    output.Pause();
                }
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                {
                    PausePlay.Text = "Pause";
                    Timer1.Enabled = true;
                    output.Play();
                }
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            DisposeWave();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;

            var nowTime = music.CurrentTime;
            MusicCurrentTime.Text = nowTime.ToString(@"hh\:mm\:ss");
            MusicTimeTrackBar.Value = (int)nowTime.TotalMilliseconds;

            Timer1.Enabled = true;
        }
        

        private void DisposeWave()
        {
            Timer1.Enabled = false;
            PausePlay.Enabled = false;
            Stop.Enabled = false;
            MusicTimeTrackBar.Maximum = 0;
            MusicDurationTime.Text = "00:00:00";
            MusicCurrentTime.Text = "00:00:00";
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
