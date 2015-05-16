/***********************************************************************************
This file is part of Clock Alert.

    Clock Alert is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation.

    Clock Alert is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Clock Alert.  If not, see <http://www.gnu.org/licenses/>.
*************************************************************************************/
namespace Clock_Alert
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // displayText
            // 
            resources.ApplyResources(this.displayText, "displayText");
            this.displayText.ForeColor = System.Drawing.Color.Black;
            this.displayText.Name = "displayText";
            // 
            // sendButton
            // 
            this.sendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.sendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.sendButton, "sendButton");
            this.sendButton.Name = "sendButton";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // dontSendButton
            // 
            this.dontSendButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dontSendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.dontSendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.dontSendButton, "dontSendButton");
            this.dontSendButton.Name = "dontSendButton";
            this.dontSendButton.UseVisualStyleBackColor = true;
            this.dontSendButton.Click += new System.EventHandler(this.dontSendButton_Click);
            // 
            // dumpLocation
            // 
            resources.ApplyResources(this.dumpLocation, "dumpLocation");
            this.dumpLocation.Name = "dumpLocation";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // CrashReporterUI
            // 
            this.AcceptButton = this.sendButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.dontSendButton;
            this.Controls.Add(this.textBox1);
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
            this.Load += new System.EventHandler(this.CrashReporterUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button dontSendButton;
        private System.Windows.Forms.Label dumpLocation;
        private System.Windows.Forms.TextBox textBox1;
    }
}