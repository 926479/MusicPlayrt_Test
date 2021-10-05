﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MusicPlayrt_1._0
{
    public partial class Form1 : Form
    {
        private NAudio.Wave.BlockAlignReductionStream music = null;
        private NAudio.Wave.DirectSoundOut output = null;

        private bool TrackbarSlid = false;
       

        public Form1()
        {
            InitializeComponent();
            DisposeWave();
        }
       
        private void ReadFile_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "*.mp3;*.wav | *.mp3;*.wav";
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
            
            var Tfile = TagLib.File.Create(System.IO.Path.GetFullPath(open.FileName));
            if (Tfile.Tag.Title != null)
                Title.Text = Tfile.Tag.Title;
            else
                Title.Text = "??????";
            if(Tfile.Tag.Album != null)
                Album.Text = Tfile.Tag.Album;
            else
                Album.Text = "??????";
            if(Tfile.Tag.FirstAlbumArtist != null)
                Artist.Text = Tfile.Tag.FirstAlbumArtist;
            else
                Artist.Text = "??????";
            try
            {
                var AlbumImage = Tfile.Tag.Pictures[0].Data.Data;
                AlbumCover.Image = Image.FromStream(new MemoryStream(AlbumImage));
            }
            catch
            {
                AlbumCover.Image = null;
            }
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(music);
            var duration = music.TotalTime;
            MusicTimeTrackBar.Maximum = (int)duration.TotalSeconds;
            MusicDurationTime.Text = duration.ToString(@"hh\:mm\:ss");
            
            output.Play();
            MusicTimeTrackBar.Enabled = true;
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
            if (music != null)
                UpdataUI();
            Timer1.Enabled = true;
        }


        /*
        private void MusicTimeTrackBar_Scroll(object sender, EventArgs e)
        {
            TrackbarSlid = true;
            try
            {
                music.CurrentTime = TimeSpan.FromMilliseconds(MusicTimeTrackBar.Value);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        private void MusicTimeTrackBar_MouseEnter(object sender, EventArgs e)
        {
            TrackbarSlid = true;
        }

        /*
        private void MusicTimeTrackBar_MouseHover(object sender, System.EventArgs e)
        {
            TrackbarSlid = true;
          //  Artist.Text = sender.GetType().ToString( TimeSpan.FromSeconds (MusicTimeTrackBar.Value));
//            MusicCurrentTime.Text = TimeSpan.FromMilliseconds(MusicTimeTrackBar.Value).ToString(@"hh:\mm:\ss");
        }
        */
        private void MusicTimeTrackBar_MouseLeave(object sender, EventArgs e)
        {
            TrackbarSlid = false;
        }

        private void MusicTimeTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            Timer1.Enabled = false;
            try
            {
                music.CurrentTime = TimeSpan.FromSeconds(MusicTimeTrackBar.Value);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TrackbarSlid = false;
            Timer1.Enabled = true;
        }

        private void UpdataUI()
        {
            if (music.TotalTime - music.CurrentTime < TimeSpan.FromMilliseconds(100))
            {
                output.Stop();
                DisposeWave();
            }
            else if (!TrackbarSlid)
            {
                var nowTime = music.CurrentTime;
                MusicTimeTrackBar.Value = (int)nowTime.TotalSeconds;
                MusicCurrentTime.Text = nowTime.ToString(@"hh\:mm\:ss");
            }
        }

        private void DisposeWave()
        {
            Timer1.Enabled = false;
            PausePlay.Enabled = false;
            Stop.Enabled = false;
            MusicTimeTrackBar.Maximum = 0;
            MusicTimeTrackBar.Value = 0;
            MusicTimeTrackBar.Enabled = false;
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
