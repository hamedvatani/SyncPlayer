namespace SyncPlayer
{
    partial class MainForm
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
            this.AudioPanel = new System.Windows.Forms.Panel();
            this.ArrowPanel = new System.Windows.Forms.Panel();
            this.AlignToBeginButton = new System.Windows.Forms.Button();
            this.AlignToEndButton = new System.Windows.Forms.Button();
            this.PlayBackTimer = new System.Windows.Forms.Timer(this.components);
            this.TotalScrollBar = new SyncPlayer.MyScrollBar();
            this.SuspendLayout();
            // 
            // AudioPanel
            // 
            this.AudioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioPanel.Location = new System.Drawing.Point(9, 10);
            this.AudioPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AudioPanel.Name = "AudioPanel";
            this.AudioPanel.Size = new System.Drawing.Size(561, 102);
            this.AudioPanel.TabIndex = 1;
            // 
            // ArrowPanel
            // 
            this.ArrowPanel.Location = new System.Drawing.Point(9, 112);
            this.ArrowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ArrowPanel.Name = "ArrowPanel";
            this.ArrowPanel.Size = new System.Drawing.Size(15, 16);
            this.ArrowPanel.TabIndex = 5;
            // 
            // AlignToBeginButton
            // 
            this.AlignToBeginButton.Location = new System.Drawing.Point(514, 167);
            this.AlignToBeginButton.Name = "AlignToBeginButton";
            this.AlignToBeginButton.Size = new System.Drawing.Size(25, 25);
            this.AlignToBeginButton.TabIndex = 10;
            this.AlignToBeginButton.Text = "|<";
            this.AlignToBeginButton.UseVisualStyleBackColor = true;
            this.AlignToBeginButton.Click += new System.EventHandler(this.AlignToBeginButton_Click);
            // 
            // AlignToEndButton
            // 
            this.AlignToEndButton.Location = new System.Drawing.Point(545, 167);
            this.AlignToEndButton.Name = "AlignToEndButton";
            this.AlignToEndButton.Size = new System.Drawing.Size(25, 25);
            this.AlignToEndButton.TabIndex = 11;
            this.AlignToEndButton.Text = ">|";
            this.AlignToEndButton.UseVisualStyleBackColor = true;
            this.AlignToEndButton.Click += new System.EventHandler(this.AlignToEndButton_Click);
            // 
            // PlayBackTimer
            // 
            this.PlayBackTimer.Tick += new System.EventHandler(this.PlayBackTimer_Tick);
            // 
            // TotalScrollBar
            // 
            this.TotalScrollBar.Location = new System.Drawing.Point(9, 140);
            this.TotalScrollBar.Name = "TotalScrollBar";
            this.TotalScrollBar.Size = new System.Drawing.Size(561, 17);
            this.TotalScrollBar.TabIndex = 13;
            this.TotalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TotalScrollBar_Scroll);
            this.TotalScrollBar.ValueChanged += new System.EventHandler(this.TotalScrollBar_ValueChanged);
            this.TotalScrollBar.MouseCaptureChanged += new System.EventHandler(this.TotalScrollBar_MouseCaptureChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 207);
            this.Controls.Add(this.TotalScrollBar);
            this.Controls.Add(this.AlignToEndButton);
            this.Controls.Add(this.AlignToBeginButton);
            this.Controls.Add(this.ArrowPanel);
            this.Controls.Add(this.AudioPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel AudioPanel;
        private System.Windows.Forms.Panel ArrowPanel;
        private System.Windows.Forms.Button AlignToBeginButton;
        private System.Windows.Forms.Button AlignToEndButton;
        private MyScrollBar TotalScrollBar;
        private System.Windows.Forms.Timer PlayBackTimer;
    }
}