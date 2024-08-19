namespace SyncPlayer
{
    partial class SyncPlayerForm
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.AlignToEndButton = new System.Windows.Forms.Button();
            this.AlignToBeginButton = new System.Windows.Forms.Button();
            this.TotalScrollBar = new SyncPlayer.MyScrollBar();
            this.JobTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // AlignToEndButton
            // 
            this.AlignToEndButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AlignToEndButton.Location = new System.Drawing.Point(996, 156);
            this.AlignToEndButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AlignToEndButton.Name = "AlignToEndButton";
            this.AlignToEndButton.Size = new System.Drawing.Size(33, 31);
            this.AlignToEndButton.TabIndex = 15;
            this.AlignToEndButton.Text = ">|";
            this.AlignToEndButton.UseVisualStyleBackColor = true;
            this.AlignToEndButton.Click += new System.EventHandler(this.AlignToEndButton_Click);
            // 
            // AlignToBeginButton
            // 
            this.AlignToBeginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AlignToBeginButton.Location = new System.Drawing.Point(955, 156);
            this.AlignToBeginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AlignToBeginButton.Name = "AlignToBeginButton";
            this.AlignToBeginButton.Size = new System.Drawing.Size(33, 31);
            this.AlignToBeginButton.TabIndex = 14;
            this.AlignToBeginButton.Text = "|<";
            this.AlignToBeginButton.UseVisualStyleBackColor = true;
            this.AlignToBeginButton.Click += new System.EventHandler(this.AlignToBeginButton_Click);
            // 
            // TotalScrollBar
            // 
            this.TotalScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalScrollBar.Location = new System.Drawing.Point(12, 156);
            this.TotalScrollBar.Name = "TotalScrollBar";
            this.TotalScrollBar.Size = new System.Drawing.Size(939, 25);
            this.TotalScrollBar.TabIndex = 16;
            this.TotalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TotalScrollBar_Scroll);
            this.TotalScrollBar.MouseCaptureChanged += new System.EventHandler(this.TotalScrollBar_MouseCaptureChanged);
            // 
            // JobTimer
            // 
            this.JobTimer.Enabled = true;
            this.JobTimer.Tick += new System.EventHandler(this.JobTimer_Tick);
            // 
            // SyncPlayerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 198);
            this.Controls.Add(this.TotalScrollBar);
            this.Controls.Add(this.AlignToEndButton);
            this.Controls.Add(this.AlignToBeginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1061, 235);
            this.Name = "SyncPlayerForm";
            this.Text = "Sync Player";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SyncPlayerForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SyncPlayerForm_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private MyScrollBar TotalScrollBar;
        private System.Windows.Forms.Button AlignToEndButton;
        private System.Windows.Forms.Button AlignToBeginButton;
        private System.Windows.Forms.Timer JobTimer;
    }
}