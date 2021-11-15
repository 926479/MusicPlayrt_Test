
namespace MusicPlayrt_1._0
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ReadFile = new System.Windows.Forms.Button();
            this.PausePlay = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.AlbumCover = new System.Windows.Forms.PictureBox();
            this.MusicTimeTrackBar = new System.Windows.Forms.TrackBar();
            this.MusicCurrentTime = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.Album = new System.Windows.Forms.Label();
            this.Artist = new System.Windows.Forms.Label();
            this.MusicDurationTime = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Library = new System.Windows.Forms.TreeView();
            this.PlayList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Previous = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTimeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(368, 383);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(73, 46);
            this.ReadFile.TabIndex = 0;
            this.ReadFile.Text = "read file";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // PausePlay
            // 
            this.PausePlay.Enabled = false;
            this.PausePlay.Location = new System.Drawing.Point(86, 383);
            this.PausePlay.Name = "PausePlay";
            this.PausePlay.Size = new System.Drawing.Size(73, 46);
            this.PausePlay.TabIndex = 1;
            this.PausePlay.Text = "Pause";
            this.PausePlay.UseVisualStyleBackColor = true;
            this.PausePlay.Click += new System.EventHandler(this.PausePlay_Click);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(238, 383);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(73, 46);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // AlbumCover
            // 
            this.AlbumCover.BackColor = System.Drawing.SystemColors.Desktop;
            this.AlbumCover.Location = new System.Drawing.Point(12, 12);
            this.AlbumCover.Name = "AlbumCover";
            this.AlbumCover.Size = new System.Drawing.Size(294, 287);
            this.AlbumCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AlbumCover.TabIndex = 3;
            this.AlbumCover.TabStop = false;
            // 
            // MusicTimeTrackBar
            // 
            this.MusicTimeTrackBar.AutoSize = false;
            this.MusicTimeTrackBar.Location = new System.Drawing.Point(66, 361);
            this.MusicTimeTrackBar.Name = "MusicTimeTrackBar";
            this.MusicTimeTrackBar.Size = new System.Drawing.Size(188, 18);
            this.MusicTimeTrackBar.TabIndex = 4;
            this.MusicTimeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MusicTimeTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MusicTimeTrackBar_MouseDown);
            this.MusicTimeTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MusicTimeTrackBar_MouseUp);
            // 
            // MusicCurrentTime
            // 
            this.MusicCurrentTime.Location = new System.Drawing.Point(12, 361);
            this.MusicCurrentTime.Name = "MusicCurrentTime";
            this.MusicCurrentTime.Size = new System.Drawing.Size(48, 18);
            this.MusicCurrentTime.TabIndex = 5;
            this.MusicCurrentTime.Text = "00:00:00";
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(12, 306);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(296, 22);
            this.Title.TabIndex = 6;
            this.Title.Text = "Title";
            // 
            // Album
            // 
            this.Album.Location = new System.Drawing.Point(12, 324);
            this.Album.Name = "Album";
            this.Album.Size = new System.Drawing.Size(296, 22);
            this.Album.TabIndex = 7;
            this.Album.Text = "Album";
            // 
            // Artist
            // 
            this.Artist.Location = new System.Drawing.Point(12, 339);
            this.Artist.Name = "Artist";
            this.Artist.Size = new System.Drawing.Size(296, 22);
            this.Artist.TabIndex = 8;
            this.Artist.Text = "Artist";
            // 
            // MusicDurationTime
            // 
            this.MusicDurationTime.Location = new System.Drawing.Point(258, 361);
            this.MusicDurationTime.Name = "MusicDurationTime";
            this.MusicDurationTime.Size = new System.Drawing.Size(48, 18);
            this.MusicDurationTime.TabIndex = 9;
            this.MusicDurationTime.Text = "00:00:00";
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Library
            // 
            this.Library.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Library.Location = new System.Drawing.Point(319, 32);
            this.Library.Name = "Library";
            this.Library.Size = new System.Drawing.Size(258, 346);
            this.Library.TabIndex = 10;
            this.Library.DoubleClick += new System.EventHandler(this.Library_DoubleClick);
            // 
            // PlayList
            // 
            this.PlayList.FormattingEnabled = true;
            this.PlayList.ItemHeight = 12;
            this.PlayList.Location = new System.Drawing.Point(594, 36);
            this.PlayList.Name = "PlayList";
            this.PlayList.Size = new System.Drawing.Size(235, 340);
            this.PlayList.TabIndex = 11;
            this.PlayList.DoubleClick += new System.EventHandler(this.PlayList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "Library";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(695, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "PlayList";
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(13, 382);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(67, 48);
            this.Previous.TabIndex = 14;
            this.Previous.Text = "Previous";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(165, 382);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(67, 48);
            this.Next.TabIndex = 15;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(851, 450);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayList);
            this.Controls.Add(this.Library);
            this.Controls.Add(this.MusicDurationTime);
            this.Controls.Add(this.Artist);
            this.Controls.Add(this.Album);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.MusicCurrentTime);
            this.Controls.Add(this.MusicTimeTrackBar);
            this.Controls.Add(this.AlbumCover);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.PausePlay);
            this.Controls.Add(this.ReadFile);
            this.Name = "Form1";
            this.Text = "MusicPlayr";
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTimeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Button PausePlay;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.PictureBox AlbumCover;
        private System.Windows.Forms.TrackBar MusicTimeTrackBar;
        private System.Windows.Forms.Label MusicCurrentTime;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Album;
        private System.Windows.Forms.Label Artist;
        private System.Windows.Forms.Label MusicDurationTime;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.TreeView Library;
        private System.Windows.Forms.ListBox PlayList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Next;
    }
}

