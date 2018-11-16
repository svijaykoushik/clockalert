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
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.startHour = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.startMin = new System.Windows.Forms.NumericUpDown();
            this.endMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.endHour = new System.Windows.Forms.NumericUpDown();
            this.startTT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.endTT = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHour)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Image = global::Clock_Alert.Properties.Resources.play;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // startHour
            // 
            resources.ApplyResources(this.startHour, "startHour");
            this.startHour.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.startHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startHour.Name = "startHour";
            this.startHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // startMin
            // 
            resources.ApplyResources(this.startMin, "startMin");
            this.startMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startMin.Name = "startMin";
            // 
            // endMin
            // 
            resources.ApplyResources(this.endMin, "endMin");
            this.endMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.endMin.Name = "endMin";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // endHour
            // 
            resources.ApplyResources(this.endHour, "endHour");
            this.endHour.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.endHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endHour.Name = "endHour";
            this.endHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // startTT
            // 
            this.startTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startTT.FormattingEnabled = true;
            this.startTT.Items.AddRange(new object[] {
            resources.GetString("startTT.Items"),
            resources.GetString("startTT.Items1")});
            resources.ApplyResources(this.startTT, "startTT");
            this.startTT.Name = "startTT";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // endTT
            // 
            this.endTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endTT.FormattingEnabled = true;
            this.endTT.Items.AddRange(new object[] {
            resources.GetString("endTT.Items"),
            resources.GetString("endTT.Items1")});
            resources.ApplyResources(this.endTT, "endTT");
            this.endTT.Name = "endTT";
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            resources.ApplyResources(this.checkBox4, "checkBox4");
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.button2;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.endTT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startTT);
            this.Controls.Add(this.endMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.endHour);
            this.Controls.Add(this.startMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startHour);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown startHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown startMin;
        private System.Windows.Forms.NumericUpDown endMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown endHour;
        private System.Windows.Forms.ComboBox startTT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox endTT;
        private System.Windows.Forms.CheckBox checkBox3;
        /*private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;*/
        private System.Windows.Forms.CheckBox checkBox4;
    }
}