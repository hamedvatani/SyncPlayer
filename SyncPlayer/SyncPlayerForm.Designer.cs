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
            this.AlignToEndButton = new System.Windows.Forms.Button();
            this.AlignToBeginButton = new System.Windows.Forms.Button();
            this.TotalScrollBar = new SyncPlayer.MyScrollBar();
            this.SuspendLayout();
            // 
            // AlignToEndButton
            // 
            this.AlignToEndButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AlignToEndButton.Location = new System.Drawing.Point(747, 127);
            this.AlignToEndButton.Name = "AlignToEndButton";
            this.AlignToEndButton.Size = new System.Drawing.Size(25, 25);
            this.AlignToEndButton.TabIndex = 15;
            this.AlignToEndButton.Text = ">|";
            this.AlignToEndButton.UseVisualStyleBackColor = true;
            // 
            // AlignToBeginButton
            // 
            this.AlignToBeginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AlignToBeginButton.Location = new System.Drawing.Point(716, 127);
            this.AlignToBeginButton.Name = "AlignToBeginButton";
            this.AlignToBeginButton.Size = new System.Drawing.Size(25, 25);
            this.AlignToBeginButton.TabIndex = 14;
            this.AlignToBeginButton.Text = "|<";
            this.AlignToBeginButton.UseVisualStyleBackColor = true;
            // 
            // TotalScrollBar
            // 
            this.TotalScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalScrollBar.Location = new System.Drawing.Point(9, 127);
            this.TotalScrollBar.Name = "TotalScrollBar";
            this.TotalScrollBar.Size = new System.Drawing.Size(704, 25);
            this.TotalScrollBar.TabIndex = 16;
            // 
            // SyncPlayerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 161);
            this.Controls.Add(this.TotalScrollBar);
            this.Controls.Add(this.AlignToEndButton);
            this.Controls.Add(this.AlignToBeginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 200);
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
    }
}