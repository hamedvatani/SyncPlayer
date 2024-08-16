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
            this.StartTogetherButton = new System.Windows.Forms.Button();
            this.EndTogetherButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ArrowPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(684, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AudioPanel
            // 
            this.AudioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioPanel.Location = new System.Drawing.Point(12, 12);
            this.AudioPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AudioPanel.Name = "AudioPanel";
            this.AudioPanel.Size = new System.Drawing.Size(747, 258);
            this.AudioPanel.TabIndex = 1;
            // 
            // StartTogetherButton
            // 
            this.StartTogetherButton.Location = new System.Drawing.Point(12, 375);
            this.StartTogetherButton.Name = "StartTogetherButton";
            this.StartTogetherButton.Size = new System.Drawing.Size(123, 34);
            this.StartTogetherButton.TabIndex = 2;
            this.StartTogetherButton.Text = "Start Together";
            this.StartTogetherButton.UseVisualStyleBackColor = true;
            // 
            // EndTogetherButton
            // 
            this.EndTogetherButton.Location = new System.Drawing.Point(141, 375);
            this.EndTogetherButton.Name = "EndTogetherButton";
            this.EndTogetherButton.Size = new System.Drawing.Size(123, 34);
            this.EndTogetherButton.TabIndex = 3;
            this.EndTogetherButton.Text = "End Together";
            this.EndTogetherButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(603, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ArrowPanel
            // 
            this.ArrowPanel.Location = new System.Drawing.Point(51, 273);
            this.ArrowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ArrowPanel.Name = "ArrowPanel";
            this.ArrowPanel.Size = new System.Drawing.Size(20, 20);
            this.ArrowPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 421);
            this.Controls.Add(this.ArrowPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EndTogetherButton);
            this.Controls.Add(this.StartTogetherButton);
            this.Controls.Add(this.AudioPanel);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel AudioPanel;
        private System.Windows.Forms.Button StartTogetherButton;
        private System.Windows.Forms.Button EndTogetherButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel ArrowPanel;
    }
}