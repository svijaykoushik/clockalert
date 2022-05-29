namespace ClockAlert
{
    partial class CrashReporterUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrashReporterUI));
            this.displayText = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.dontSendButton = new System.Windows.Forms.Button();
            this.dumpLocation = new System.Windows.Forms.Label();
            this.logURLText = new System.Windows.Forms.TextBox();
            this.copyLocationButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // displayText
            // 
            this.displayText.ForeColor = System.Drawing.Color.Black;
            this.displayText.Location = new System.Drawing.Point(67, 32);
            this.displayText.Name = "displayText";
            this.displayText.Size = new System.Drawing.Size(142, 22);
            this.displayText.TabIndex = 6;
            this.displayText.Text = "Clock alert has crashed";
            // 
            // sendButton
            // 
            this.sendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.sendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.sendButton.Location = new System.Drawing.Point(197, 213);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Ok";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // dontSendButton
            // 
            this.dontSendButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dontSendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.dontSendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.dontSendButton.Location = new System.Drawing.Point(103, 213);
            this.dontSendButton.Name = "dontSendButton";
            this.dontSendButton.Size = new System.Drawing.Size(75, 23);
            this.dontSendButton.TabIndex = 4;
            this.dontSendButton.Text = "Restart";
            this.dontSendButton.UseVisualStyleBackColor = true;
            this.dontSendButton.Click += new System.EventHandler(this.dontSendButton_Click);
            // 
            // dumpLocation
            // 
            this.dumpLocation.Location = new System.Drawing.Point(12, 72);
            this.dumpLocation.Name = "dumpLocation";
            this.dumpLocation.Size = new System.Drawing.Size(100, 23);
            this.dumpLocation.TabIndex = 3;
            this.dumpLocation.Text = "Error log location";
            // 
            // logURLText
            // 
            this.logURLText.BackColor = System.Drawing.SystemColors.Control;
            this.logURLText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logURLText.Location = new System.Drawing.Point(118, 72);
            this.logURLText.Name = "logURLText";
            this.logURLText.ReadOnly = true;
            this.logURLText.Size = new System.Drawing.Size(100, 13);
            this.logURLText.TabIndex = 2;
            // 
            // copyLocationButton
            // 
            this.copyLocationButton.Location = new System.Drawing.Point(120, 91);
            this.copyLocationButton.Name = "copyLocationButton";
            this.copyLocationButton.Size = new System.Drawing.Size(98, 23);
            this.copyLocationButton.TabIndex = 1;
            this.copyLocationButton.Text = "Copy location";
            this.copyLocationButton.UseVisualStyleBackColor = true;
            this.copyLocationButton.Click += new System.EventHandler(this.copyLocationButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.Location = new System.Drawing.Point(58, 9);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(142, 23);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = resources.GetString("messageLabel.Text");
            // 
            // CrashReporterUI
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.dontSendButton;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.copyLocationButton);
            this.Controls.Add(this.logURLText);
            this.Controls.Add(this.dumpLocation);
            this.Controls.Add(this.dontSendButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.displayText);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrashReporterUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Clock Alert Crash Reporter";
            this.Load += new System.EventHandler(this.CrashReporterUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button dontSendButton;
        private System.Windows.Forms.Label dumpLocation;
        private System.Windows.Forms.TextBox logURLText;
        private System.Windows.Forms.Button copyLocationButton;
        private System.Windows.Forms.Label messageLabel;
    }
}