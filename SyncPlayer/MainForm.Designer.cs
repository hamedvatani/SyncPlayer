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
            this.button1 = new System.Windows.Forms.Button();
            this.AudioPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ArrowPanel = new System.Windows.Forms.Panel();
            this.AlignToBeginButton = new System.Windows.Forms.Button();
            this.AlignToEndButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(441, 358);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AudioPanel
            // 
            this.AudioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioPanel.Location = new System.Drawing.Point(9, 10);
            this.AudioPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AudioPanel.Name = "AudioPanel";
            this.AudioPanel.Size = new System.Drawing.Size(561, 210);
            this.AudioPanel.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(380, 358);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ArrowPanel
            // 
            this.ArrowPanel.Location = new System.Drawing.Point(38, 222);
            this.ArrowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ArrowPanel.Name = "ArrowPanel";
            this.ArrowPanel.Size = new System.Drawing.Size(15, 16);
            this.ArrowPanel.TabIndex = 5;
            // 
            // AlignToBeginButton
            // 
            this.AlignToBeginButton.Location = new System.Drawing.Point(514, 351);
            this.AlignToBeginButton.Name = "AlignToBeginButton";
            this.AlignToBeginButton.Size = new System.Drawing.Size(25, 25);
            this.AlignToBeginButton.TabIndex = 10;
            this.AlignToBeginButton.Text = "|<";
            this.AlignToBeginButton.UseVisualStyleBackColor = true;
            // 
            // AlignToEndButton
            // 
            this.AlignToEndButton.Location = new System.Drawing.Point(545, 351);
            this.AlignToEndButton.Name = "AlignToEndButton";
            this.AlignToEndButton.Size = new System.Drawing.Size(25, 25);
            this.AlignToEndButton.TabIndex = 11;
            this.AlignToEndButton.Text = ">|";
            this.AlignToEndButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 388);
            this.Controls.Add(this.AlignToEndButton);
            this.Controls.Add(this.AlignToBeginButton);
            this.Controls.Add(this.ArrowPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AudioPanel);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel AudioPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel ArrowPanel;
        private System.Windows.Forms.Button AlignToBeginButton;
        private System.Windows.Forms.Button AlignToEndButton;
    }
}