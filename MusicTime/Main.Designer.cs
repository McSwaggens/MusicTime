namespace MusicTime
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MusicTime_Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoadingAnimation = new System.Windows.Forms.PictureBox();
            this.SearchBox = new MusicTime.Components.TextEntry();
            this.controlBar = new MusicTime.Components.ControlBar();
            this.SearchCollection = new MusicTime.Components.SongListPanel();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // MusicTime_Title
            // 
            this.MusicTime_Title.AutoSize = true;
            this.MusicTime_Title.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicTime_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MusicTime_Title.Location = new System.Drawing.Point(535, 330);
            this.MusicTime_Title.Name = "MusicTime_Title";
            this.MusicTime_Title.Size = new System.Drawing.Size(125, 30);
            this.MusicTime_Title.TabIndex = 1;
            this.MusicTime_Title.Text = "MusicTime";
            this.MusicTime_Title.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(23)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(61, 660);
            this.panel1.TabIndex = 5;
            // 
            // LoadingAnimation
            // 
            this.LoadingAnimation.Image = ((System.Drawing.Image)(resources.GetObject("LoadingAnimation.Image")));
            this.LoadingAnimation.Location = new System.Drawing.Point(561, 363);
            this.LoadingAnimation.Name = "LoadingAnimation";
            this.LoadingAnimation.Size = new System.Drawing.Size(44, 43);
            this.LoadingAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadingAnimation.TabIndex = 2;
            this.LoadingAnimation.TabStop = false;
            this.LoadingAnimation.Visible = false;
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.Transparent;
            this.SearchBox.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(42)))), ((int)(((byte)(88)))));
            this.SearchBox.DefaultText = "Search Music";
            this.SearchBox.DefaultTextColor = System.Drawing.Color.White;
            this.SearchBox.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.ForeColor = System.Drawing.Color.White;
            this.SearchBox.Image = ((System.Drawing.Image)(resources.GetObject("SearchBox.Image")));
            this.SearchBox.Location = new System.Drawing.Point(311, 7);
            this.SearchBox.MaxLength = 32767;
            this.SearchBox.Multiline = false;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Opacity = 1F;
            this.SearchBox.ReadOnly = false;
            this.SearchBox.Size = new System.Drawing.Size(490, 45);
            this.SearchBox.TabIndex = 3;
            this.SearchBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.SearchBox.UseSystemPasswordChar = false;
            // 
            // controlBar
            // 
            this.controlBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(23)))));
            this.controlBar.Location = new System.Drawing.Point(-2, 643);
            this.controlBar.Name = "controlBar";
            this.controlBar.Size = new System.Drawing.Size(1188, 54);
            this.controlBar.TabIndex = 0;
            this.controlBar.Text = "controlBar1";
            // 
            // SearchCollection
            // 
            this.SearchCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCollection.AutoScroll = true;
            this.SearchCollection.Location = new System.Drawing.Point(70, 58);
            this.SearchCollection.Name = "SearchCollection";
            this.SearchCollection.Size = new System.Drawing.Size(1102, 579);
            this.SearchCollection.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(17)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(1184, 701);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.LoadingAnimation);
            this.Controls.Add(this.MusicTime_Title);
            this.Controls.Add(this.controlBar);
            this.Controls.Add(this.SearchCollection);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(740, 700);
            this.Name = "Main";
            this.Text = "Music Time";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.ControlBar controlBar;
        private System.Windows.Forms.Label MusicTime_Title;
        private System.Windows.Forms.PictureBox LoadingAnimation;
        private Components.TextEntry SearchBox;
        private Components.SongListPanel SearchCollection;
        private System.Windows.Forms.Panel panel1;
    }
}

