namespace Clock_Alert
{
    partial class PropertiesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alert tone";
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Clock_Alert.Properties.Resources.play;
            this.button1.Location = new System.Drawing.Point(302, 93);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 137);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(399, 364);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(140, 167);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(5);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(86, 25);
            this.radioButton3.TabIndex = 13;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Sound 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(140, 205);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(5);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(86, 25);
            this.radioButton4.TabIndex = 14;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Sound 4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Clock_Alert.Properties.Settings.Default, "CustomChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton2.Location = new System.Drawing.Point(140, 130);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 25);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "Sound 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Clock_Alert.Properties.Settings.Default, "DefaultChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton1.Location = new System.Drawing.Point(140, 93);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 25);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Sound 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.settingsChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::Clock_Alert.Properties.Settings.Default.ClickToTalk;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Clock_Alert.Properties.Settings.Default, "ClickToTalk", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Location = new System.Drawing.Point(42, 279);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(112, 25);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Click to Talk";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.settingsChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::Clock_Alert.Properties.Settings.Default.StartWhenWindowsStarts;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Clock_Alert.Properties.Settings.Default, "StartWhenWindowsStarts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(42, 339);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(286, 25);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Start clock alert when windows starts";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(536, 442);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Settings - Clock Alert";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;

    }
}

