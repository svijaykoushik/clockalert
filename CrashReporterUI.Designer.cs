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
            this.displayText = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.dontSendButton = new System.Windows.Forms.Button();
            this.dumpLocation = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // displayText
            // 
            this.displayText.AutoSize = true;
            this.displayText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayText.ForeColor = System.Drawing.Color.Black;
            this.displayText.Location = new System.Drawing.Point(88, 46);
            this.displayText.Name = "displayText";
            this.displayText.Size = new System.Drawing.Size(226, 30);
            this.displayText.TabIndex = 0;
            this.displayText.Text = "Clock alert has crashed";
            // 
            // sendButton
            // 
            this.sendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.sendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(33, 131);
            this.sendButton.Margin = new System.Windows.Forms.Padding(0);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(114, 32);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send report";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // dontSendButton
            // 
            this.dontSendButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dontSendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.dontSendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.dontSendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dontSendButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dontSendButton.Location = new System.Drawing.Point(241, 131);
            this.dontSendButton.Margin = new System.Windows.Forms.Padding(0);
            this.dontSendButton.Name = "dontSendButton";
            this.dontSendButton.Size = new System.Drawing.Size(114, 32);
            this.dontSendButton.TabIndex = 3;
            this.dontSendButton.Text = "Dont send";
            this.dontSendButton.UseVisualStyleBackColor = true;
            this.dontSendButton.Click += new System.EventHandler(this.dontSendButton_Click);
            // 
            // dumpLocation
            // 
            this.dumpLocation.AutoSize = true;
            this.dumpLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dumpLocation.Location = new System.Drawing.Point(12, 95);
            this.dumpLocation.Name = "dumpLocation";
            this.dumpLocation.Size = new System.Drawing.Size(93, 17);
            this.dumpLocation.TabIndex = 5;
            this.dumpLocation.Text = "Dump location";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(111, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(244, 20);
            this.textBox1.TabIndex = 6;
            // 
            // CrashReporterUI
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.dontSendButton;
            this.ClientSize = new System.Drawing.Size(392, 196);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dumpLocation);
            this.Controls.Add(this.dontSendButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.displayText);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrashReporterUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TextBox textBox1;
    }
}