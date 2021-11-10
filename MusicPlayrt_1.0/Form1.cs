using System;
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
        private NAudio.Wave.AudioFileReader music = null;
        private NAudio.Wave.WaveOutEvent output = null;

        private bool TrackbarSlid = false;

        string SetPath;
       

        public Form1()
        {
            InitializeComponent();
            DisposeWave();
        }

       

        private void ReadFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SetPath = dialog.SelectedPath;
                try
                {
                    var s1 = Directory.EnumerateFiles(SetPath, "*.wav", SearchOption.AllDirectories);
                    var s2 = Directory.EnumerateFiles(SetPath, "*.flac", SearchOption.AllDirectories);
                    var s3 = Directory.EnumerateFiles(SetPath, "*.mp3", SearchOption.AllDirectories);
                    TreeNode wav = new TreeNode("wav");
                    TreeView1.Nodes.Add(wav);
                    foreach (string m in s1)
                    {
                        string wav_1 = m.Substring(m.LastIndexOf("\\") + 1, m.Length - m.LastIndexOf("\\") - 1);
                        TreeNode node = new TreeNode(wav_1);
                        wav.Nodes.Add(node);
                    }
                    TreeNode flac = new TreeNode("flac");
                    TreeView1.Nodes.Add(flac);
                    foreach (string m in s2)
                    {
                        string flac_1 = m.Substring(m.LastIndexOf("\\") + 1, m.Length - m.LastIndexOf("\\") - 1);
                        TreeNode node = new TreeNode(flac_1);
                        flac.Nodes.Add(node);
                    }
                    TreeNode mp3 = new TreeNode("mp3");
                    TreeView1.Nodes.Add(mp3);
                    foreach(string m in s3)
                    {
                        string mp3_1 = m.Substring(m.LastIndexOf("\\") + 1, m.Length - m.LastIndexOf("\\") - 1);
                        TreeNode node = new TreeNode(mp3_1);
                        mp3.Nodes.Add(node);
                    }
                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
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


        private void MusicTimeTrackBar_MouseEnter(object sender, EventArgs e)
        {
            TrackbarSlid = true;
        }

        
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

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var open = Directory.GetFiles(SetPath, e.Node.Text, SearchOption.AllDirectories);
            foreach(string OpenFileName in open)
            {
                DisposeWave();
                music = new NAudio.Wave.AudioFileReader(OpenFileName);
                var Tfile = TagLib.File.Create(System.IO.Path.GetFullPath(OpenFileName));
                if (Tfile.Tag.Title != null)
                    Title.Text = Tfile.Tag.Title;
                else
                    Title.Text = "??????";
                if (Tfile.Tag.Album != null)
                    Album.Text = Tfile.Tag.Album;
                else
                    Album.Text = "??????";
                if (Tfile.Tag.FirstAlbumArtist != null)
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
            }
            


            output = new NAudio.Wave.WaveOutEvent();
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
    }
}
