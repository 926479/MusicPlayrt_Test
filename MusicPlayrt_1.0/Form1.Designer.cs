
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
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(34, 304);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(100, 62);
            this.ReadFile.TabIndex = 0;
            this.ReadFile.Text = "read file";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // PausePlay
            // 
            this.PausePlay.Enabled = false;
            this.PausePlay.Location = new System.Drawing.Point(159, 304);
            this.PausePlay.Name = "PausePlay";
            this.PausePlay.Size = new System.Drawing.Size(100, 62);
            this.PausePlay.TabIndex = 1;
            this.PausePlay.Text = "pause/play";
            this.PausePlay.UseVisualStyleBackColor = true;
            this.PausePlay.Click += new System.EventHandler(this.PausePlay_Click);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(291, 304);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 62);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 450);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.PausePlay);
            this.Controls.Add(this.ReadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Button PausePlay;
        private System.Windows.Forms.Button Stop;
    }
}

