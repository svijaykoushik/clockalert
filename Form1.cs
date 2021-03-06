﻿/***********************************************************************************
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Clock_Alert
{
    public partial class SettingsForm : Form
    {
        //private bool isPlaying;
        private int selectedSound;

        public SettingsForm()
        {
            InitializeComponent();
            //isPlaying = false;
        }

        /// <summary>
        /// Loads the  stored settings from disk into the form.
        /// </summary>
        private void loadSettings()
        {
            checkBox3.Checked = Properties.Settings.Default.AlertInterval;
            startHour.Value = Properties.Settings.Default.StartHour;
            startMin.Value = Properties.Settings.Default.StartMin;
            startTT.SelectedIndex = Properties.Settings.Default.StartTT;
            endHour.Value = Properties.Settings.Default.EndHour;
            endMin.Value = Properties.Settings.Default.EndMin;
            endTT.SelectedIndex = Properties.Settings.Default.EndTT;
            checkBox1.Checked = Properties.Settings.Default.ClickToTalk;
            selectedSound = Properties.Settings.Default.CurrentSound;
            int currentSound = Properties.Settings.Default.CurrentSound;
            if (currentSound == 1)
            {
                radioButton1.Checked = true;
            }
            else if (currentSound == 2)
            {
                radioButton2.Checked = true;
            }
            else if (currentSound == 3)
            {
                radioButton3.Checked = true;
            }
            else if (currentSound == 4)
            {
                radioButton4.Checked = true;
            }
            checkBox4.Checked = Properties.Settings.Default.TellTime;
            if (!checkBox3.Checked)
                disableIntervalControls();
        }

        /// <summary>
        /// Saves the settings to the disk.
        /// </summary>
        private void saveSettings()
        {
            Properties.Settings.Default.ClickToTalk = checkBox1.Checked;
            Properties.Settings.Default.AlertInterval = checkBox3.Checked;
            Properties.Settings.Default.StartHour = startHour.Value;
            Properties.Settings.Default.StartMin = startMin.Value;
            Properties.Settings.Default.StartTT = startTT.SelectedIndex;
            Properties.Settings.Default.EndHour = endHour.Value;
            Properties.Settings.Default.EndMin = endMin.Value;
            Properties.Settings.Default.EndTT = endTT.SelectedIndex;
            Properties.Settings.Default.TellTime = checkBox4.Checked;
            if (radioButton1.Checked)
                Properties.Settings.Default.CurrentSound = 1;
            else if (radioButton2.Checked)
                Properties.Settings.Default.CurrentSound = 2;
            else if (radioButton3.Checked)
                Properties.Settings.Default.CurrentSound = 3;
            else if (radioButton4.Checked)
                Properties.Settings.Default.CurrentSound = 4;
            Properties.Settings.Default.Save();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AudioPlayer player;
            button1.Enabled=false;
            this.Cursor = Cursors.WaitCursor;
                if (radioButton1.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound);
                    player.play();
                }
                else if (radioButton2.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound2);
                    player.play();
                }
                else if (radioButton3.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound3);
                    player.play();
                }
                else if (radioButton4.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound4);
                    player.play();
                }
            button1.Enabled = true;    
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((startHour.Value == endHour.Value) && (startMin.Value == endMin.Value) && (startTT.Text == endTT.Text))
            {
                MessageBox.Show(Contents.invalidTimeIntervalMsg, Contents.invalidTimeIntervalTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            saveSettings();            
            Application.Restart();
            //Application.Exit();
            this.Close();
        }

        private void enableIntervalControls()
        {
            startHour.Enabled=true;
            startMin.Enabled=true;
            startTT.Enabled=true;

            endHour.Enabled=true;
            endMin.Enabled=true;
            endTT.Enabled=true;
        }

        private void disableIntervalControls()
        {
            startHour.Enabled=false;
            startMin.Enabled=false;
            startTT.Enabled=false;

            endHour.Enabled=false;
            endMin.Enabled=false;
            endTT.Enabled=false;
        }

        
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                enableIntervalControls();
            }
            else
            {
                disableIntervalControls();
            }
        }

        private void enableAlertTone()
        {
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            button1.Enabled = true;
        }
        private void disableAlertTone()
        {
            radioButton1.Enabled=false;
            radioButton2.Enabled=false;
            radioButton3.Enabled=false;
            radioButton4.Enabled=false;
            button1.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                disableAlertTone();
            else
                enableAlertTone();
        }
    }
}