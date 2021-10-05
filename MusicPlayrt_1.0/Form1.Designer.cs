
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
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTimeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(12, 382);
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
            this.PausePlay.Location = new System.Drawing.Point(117, 382);
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
            this.Stop.Location = new System.Drawing.Point(233, 382);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(73, 46);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // AlbumCover
            // 
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
            this.MusicTimeTrackBar.MouseEnter += new System.EventHandler(this.MusicTimeTrackBar_MouseEnter);
            this.MusicTimeTrackBar.MouseLeave += new System.EventHandler(this.MusicTimeTrackBar_MouseLeave);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 450);
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
    }
}

