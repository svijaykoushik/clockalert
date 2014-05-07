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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clock_Alert
{
    public partial class Form1 : Form
    {
        private bool isPlaying;
        private int selectedSound;

        public Form1()
        {
            InitializeComponent();
            isPlaying = false;
        }

        /// <summary>
        /// Loads the  stored settings from disk into the form.
        /// </summary>
        private void loadSettings()
        {
            checkBox1.Checked = Properties.Settings.Default.StartWhenWindowsStarts;
            //checkBox2.Checked = Properties.Settings.Default.ClickToTalk;
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
        }

        /// <summary>
        /// Saves the settings to the disk.
        /// </summary>
        private void saveSettings()
        {
            Properties.Settings.Default.ClickToTalk = checkBox2.Checked;
            //Properties.Settings.Default.StartWhenWindowsStarts = checkBox1.Checked;
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
            this.Enabled=false;
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
            this.Enabled = true;    
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveSettings();
            Application.Restart();
        }
    }
}
