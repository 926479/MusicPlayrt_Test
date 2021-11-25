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

        private bool TrackBarSlid = false;
        private bool RandomSong = false;

        public int TreeviewClicks = 0;

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
                    Library.Nodes.Add(wav);
                    foreach (string m in s1)
                    {
                        string wav_1 = m.Substring(m.LastIndexOf("\\") + 1, m.Length - m.LastIndexOf("\\") - 1);
                        TreeNode node = new TreeNode(wav_1) { Tag = m };
                        wav.Nodes.Add(node);
                    }
                    TreeNode flac = new TreeNode("flac");
                    Library.Nodes.Add(flac);
                    foreach (string m in s2)
                    {
                        string flac_1 = m.Substring(m.LastIndexOf("\\") + 1, m.Length - m.LastIndexOf("\\") - 1);
                        TreeNode node = new TreeNode(flac_1) { Tag = m };
                        flac.Nodes.Add(node);
                    }
                    TreeNode mp3 = new TreeNode("mp3");
                    Library.Nodes.Add(mp3);
                    foreach(string m in s3)
                    {
                        string mp3_1 = m.Substring(m.LastIndexOf("\\") + 1, m.Length - m.LastIndexOf("\\") - 1);
                        TreeNode node = new TreeNode(mp3_1) { Tag = m };
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


        private void MusicTimeTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            TrackBarSlid = true;
        }
        
        

        private void MusicTimeTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            Timer1.Enabled = false;
            try
            {
                music.CurrentTime = TimeSpan.FromSeconds(MusicTimeTrackBar.Value);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Timer1.Enabled = true;
            TrackBarSlid = false;
        }


        private void UpdataUI()
        {
            if (music.TotalTime - music.CurrentTime < TimeSpan.FromMilliseconds(100))
            {
                output.Stop();
                DisposeWave();
                if (PlayList.Items.Count - PlayList.SelectedIndex > 0)
                {
                    PlaySong(PlayList.SelectedIndex + 1);
                }
            }
            else
            {
                var nowTime = music.CurrentTime;
                if(!TrackBarSlid)
                    MusicTimeTrackBar.Value = (int)nowTime.TotalSeconds;
                MusicCurrentTime.Text = nowTime.ToString(@"hh\:mm\:ss");
            }
        }

        private void DisposeWave()
        {
            Timer1.Enabled = false;
            PausePlay.Enabled = false;
            Previous.Enabled = false;
            Next.Enabled = false;
            Stop.Enabled = false;
            MusicTimeTrackBar.Maximum = 0;
            MusicTimeTrackBar.Value = 0;
            MusicTimeTrackBar.Enabled = false;
            MusicDurationTime.Text = "00:00:00";
            MusicCurrentTime.Text = "00:00:00";
            Title.Text = "Title";
            Artist.Text = "Artist";
            Album.Text = "Album";
            AlbumCover.Image = null;
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

        private void RandomSequential_Click(object sender, EventArgs e)
        {
            if (RandomSequential.Text == "Random")
            {
                RandomSequential.Text = "Sequential";
                RandomSong = false;
            }
            else if (RandomSequential.Text == "Sequential")
            {
                RandomSequential.Text = "Random";
                RandomSong = true;
            }

        }

        private void Library_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("2");
            
        }

        private void Library_MouseDown(object sender, MouseEventArgs e)
        {
            TreeviewClicks = e.Clicks;
            
        }

        private void Library_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = (TreeviewClicks > 1);
        }

        private void Library_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = TreeviewClicks > 1;
            Library.CollapseAll();
        }

        private void Library_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode treeNode = Library.SelectedNode;
            if (treeNode != null && treeNode.Nodes.Count != 0)
            {
                if (TreeviewClicks == 1)
                {
                    treeNode.Toggle();
                }
                
            }
            //label1.Text =Convert.ToString(e.Node.Tag);
        }
        

        private void Library_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            PlayList.Items.Clear();
            TreeNode songs = e.Node;
            if (songs.Nodes.Count == 0)
            {
                //TreeNode[] songfile = new TreeNode[songs.Parent.Nodes.Count];
                //songs.Parent.Nodes.CopyTo(songfile, 0);
                //foreach(TreeNode song in songfile)
                //{
                PlayList.Items.Add(songs.Text);
                
                //}
                PlaySong(0);
            }
            else
            {
                if (RandomSong == false)
                {
                    foreach (TreeNode song in songs.Nodes)
                    {
                        PlayList.Items.Add(song.Text);
                    }
                }
                else
                {
                    TreeNode[] songfile = new TreeNode[songs.Parent.Nodes.Count];
                    songs.Parent.Nodes.CopyTo(songfile, 0);
                    foreach(TreeNode song in songfile)
                    {
                        PlayList.Items.Add(song.Text);
                        
                    }
                }
                PlaySong(0);
            }
            
        }

        

        private void PlayList_DoubleClick(object sender, EventArgs e)
        {
            PlaySong(PlayList.SelectedIndex);
            //label1.Text = PlayList.Items[PlayList.SelectedIndex].ToString();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            PlaySong(PlayList.SelectedIndex + 1);
            PausePlay.Text = "Pause";
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            PlaySong(PlayList.SelectedIndex - 1);
            PausePlay.Text = "Pause";
        }

        private string Search(TreeNode treeNode, string title)
        {
            Queue<TreeNode> Nodes = new Queue<TreeNode>();
            Nodes.Enqueue(treeNode);
            while (Nodes.Count > 0)
            {
                treeNode = Nodes.Dequeue();

                //System.Diagnostics.Debug.WriteLine(treeNode.Text);
                if (treeNode.Tag != null)
                    if (treeNode.Text == title)
                        return treeNode.Tag.ToString();

                foreach (TreeNode n in treeNode.Nodes)
                {
                    Nodes.Enqueue(n);
                }
                
            }
            return "1";
        }

        private string GetFullPath(string title)
        {
         
            foreach(TreeNode treeNode in Library.Nodes)
            {
                string path = Search(treeNode, title);
                //System.Diagnostics.Debug.WriteLine(path);
                if (path != "1")
                    return path;
            }

            return "0";
           


        }

        private void PlaySong(int num)
        {
            //MessageBox.Show(Convert.ToString(num));
            if (num > PlayList.Items.Count - 1)
            {
                PlayList.ClearSelected();
                DisposeWave();
            }
            else if (num < 0)
            {
                  DisposeWave();
            }
            else
            {
                PlayList.SetSelected(num, true);
                string song = PlayList.SelectedItem.ToString();
                if (GetFullPath(song) != "0")
                {
                    string openfile = GetFullPath(song);
                    DisposeWave();
                    music = new NAudio.Wave.AudioFileReader(openfile);
                    var Tfile = TagLib.File.Create(System.IO.Path.GetFullPath(openfile));
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
                    output = new NAudio.Wave.WaveOutEvent();
                    output.Init(music);
                    var duration = music.TotalTime;
                    MusicTimeTrackBar.Maximum = (int)duration.TotalSeconds;
                    MusicDurationTime.Text = duration.ToString(@"hh\:mm\:ss");

                    output.Play();
                    MusicTimeTrackBar.Enabled = true;
                    Timer1.Enabled = true;
                    PausePlay.Enabled = true;
                    Previous.Enabled = true;
                    Next.Enabled = true;
                    Stop.Enabled = true;
                }
                //System.Diagnostics.Debug.WriteLine(song, (GetFullPath(song)));


            }

        }

        
    }
}
