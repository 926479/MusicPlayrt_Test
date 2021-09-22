
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
            this.ReadFile = new System.Windows.Forms.Button();
            this.PausePlay = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(34, 382);
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
            this.PausePlay.Location = new System.Drawing.Point(146, 382);
            this.PausePlay.Name = "PausePlay";
            this.PausePlay.Size = new System.Drawing.Size(73, 46);
            this.PausePlay.TabIndex = 1;
            this.PausePlay.Text = "pause/play";
            this.PausePlay.UseVisualStyleBackColor = true;
            this.PausePlay.Click += new System.EventHandler(this.PausePlay_Click);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(255, 382);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(73, 46);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 287);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(86, 358);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(242, 18);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Album";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Artist";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.PausePlay);
            this.Controls.Add(this.ReadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Button PausePlay;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

