namespace SyncPlayer
{
    partial class AudioVisualPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WaveFormPanel = new System.Windows.Forms.Panel();
            this.SilenceBeforeLabel = new System.Windows.Forms.Label();
            this.AudioLabel = new System.Windows.Forms.Label();
            this.SilenceAfterLabel = new System.Windows.Forms.Label();
            this.TotalScrollBar = new SyncPlayer.MyScrollBar();
            this.CurrentSilenceAfterLabel = new System.Windows.Forms.Label();
            this.CurrentAudioLabel = new System.Windows.Forms.Label();
            this.CurrentSilenceBeforeLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WaveFormPanel
            // 
            this.WaveFormPanel.Location = new System.Drawing.Point(22, 6);
            this.WaveFormPanel.Name = "WaveFormPanel";
            this.WaveFormPanel.Size = new System.Drawing.Size(42, 34);
            this.WaveFormPanel.TabIndex = 0;
            this.WaveFormPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WaveFormPanel_Paint);
            // 
            // SilenceBeforeLabel
            // 
            this.SilenceBeforeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SilenceBeforeLabel.Location = new System.Drawing.Point(108, 0);
            this.SilenceBeforeLabel.Name = "SilenceBeforeLabel";
            this.SilenceBeforeLabel.Size = new System.Drawing.Size(50, 20);
            this.SilenceBeforeLabel.TabIndex = 2;
            this.SilenceBeforeLabel.Text = "00:00";
            this.SilenceBeforeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AudioLabel
            // 
            this.AudioLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioLabel.Location = new System.Drawing.Point(169, 0);
            this.AudioLabel.Name = "AudioLabel";
            this.AudioLabel.Size = new System.Drawing.Size(50, 20);
            this.AudioLabel.TabIndex = 3;
            this.AudioLabel.Text = "00:00";
            this.AudioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SilenceAfterLabel
            // 
            this.SilenceAfterLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SilenceAfterLabel.Location = new System.Drawing.Point(230, 0);
            this.SilenceAfterLabel.Name = "SilenceAfterLabel";
            this.SilenceAfterLabel.Size = new System.Drawing.Size(50, 20);
            this.SilenceAfterLabel.TabIndex = 4;
            this.SilenceAfterLabel.Text = "00:00";
            this.SilenceAfterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalScrollBar
            // 
            this.TotalScrollBar.Location = new System.Drawing.Point(108, 40);
            this.TotalScrollBar.Name = "TotalScrollBar";
            this.TotalScrollBar.Size = new System.Drawing.Size(177, 17);
            this.TotalScrollBar.TabIndex = 5;
            // 
            // CurrentSilenceAfterLabel
            // 
            this.CurrentSilenceAfterLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentSilenceAfterLabel.Location = new System.Drawing.Point(230, 20);
            this.CurrentSilenceAfterLabel.Name = "CurrentSilenceAfterLabel";
            this.CurrentSilenceAfterLabel.Size = new System.Drawing.Size(50, 20);
            this.CurrentSilenceAfterLabel.TabIndex = 8;
            this.CurrentSilenceAfterLabel.Text = "00:00";
            this.CurrentSilenceAfterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentAudioLabel
            // 
            this.CurrentAudioLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentAudioLabel.Location = new System.Drawing.Point(169, 20);
            this.CurrentAudioLabel.Name = "CurrentAudioLabel";
            this.CurrentAudioLabel.Size = new System.Drawing.Size(50, 20);
            this.CurrentAudioLabel.TabIndex = 7;
            this.CurrentAudioLabel.Text = "00:00";
            this.CurrentAudioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentSilenceBeforeLabel
            // 
            this.CurrentSilenceBeforeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentSilenceBeforeLabel.Location = new System.Drawing.Point(108, 20);
            this.CurrentSilenceBeforeLabel.Name = "CurrentSilenceBeforeLabel";
            this.CurrentSilenceBeforeLabel.Size = new System.Drawing.Size(50, 20);
            this.CurrentSilenceBeforeLabel.TabIndex = 6;
            this.CurrentSilenceBeforeLabel.Text = "00:00";
            this.CurrentSilenceBeforeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileNameLabel.Location = new System.Drawing.Point(286, 0);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(50, 20);
            this.FileNameLabel.TabIndex = 9;
            this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AudioVisualPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.CurrentSilenceAfterLabel);
            this.Controls.Add(this.CurrentAudioLabel);
            this.Controls.Add(this.CurrentSilenceBeforeLabel);
            this.Controls.Add(this.TotalScrollBar);
            this.Controls.Add(this.SilenceAfterLabel);
            this.Controls.Add(this.AudioLabel);
            this.Controls.Add(this.SilenceBeforeLabel);
            this.Controls.Add(this.WaveFormPanel);
            this.MinimumSize = new System.Drawing.Size(100, 80);
            this.Name = "AudioVisualPlayer";
            this.Size = new System.Drawing.Size(550, 80);
            this.Load += new System.EventHandler(this.AudioVisualPlayer_Load);
            this.Resize += new System.EventHandler(this.AudioVisualPlayer_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WaveFormPanel;
        private System.Windows.Forms.Label SilenceBeforeLabel;
        private System.Windows.Forms.Label AudioLabel;
        private System.Windows.Forms.Label SilenceAfterLabel;
        private MyScrollBar TotalScrollBar;
        private System.Windows.Forms.Label CurrentSilenceAfterLabel;
        private System.Windows.Forms.Label CurrentAudioLabel;
        private System.Windows.Forms.Label CurrentSilenceBeforeLabel;
        private System.Windows.Forms.Label FileNameLabel;
    }
}
