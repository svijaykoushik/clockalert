using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clock_Alert
{
    public partial class PropertiesDialog : Form
    {
        //private FileHandler fileHandle;
        private bool isPlaying;
        private int selectedSound;

        public PropertiesDialog()
        {
            InitializeComponent();
            //fileHandle = new FileHandler();
            isPlaying = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void loadSettings()
        {
            checkBox1.Checked = Properties.Settings.Default.StartWhenWindowsStarts;
            checkBox2.Checked = Properties.Settings.Default.ClickToTalk;
            selectedSound = Properties.Settings.Default.CurrentSound;
            switch (selectedSound)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
                case 4:
                    radioButton4.Checked = true;
                    break;
                default:
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        break;
                    }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            settingsChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AudioPlayer player;
            if (isPlaying)
            {
                isPlaying = false;
                button1.Image = Properties.Resources.pause;
            }
            else
            {
                isPlaying = true;
                button1.Image = Properties.Resources.play;
                if (radioButton1.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound);
                    button1.Image = Properties.Resources.pause;
                    player.play();
                    button1.Image = Properties.Resources.play;
                }
                else if (radioButton2.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound2);
                    button1.Image = Properties.Resources.pause;
                    player.play();
                    button1.Image = Properties.Resources.play;
                }
                else if (radioButton3.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound3);
                    button1.Image = Properties.Resources.pause;
                    player.play();
                    button1.Image = Properties.Resources.play;
                }
                else if (radioButton4.Checked)
                {
                    player = new AudioPlayer(Properties.Resources.sound4);
                    button1.Image = Properties.Resources.pause;
                    player.play();
                    button1.Image = Properties.Resources.play;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//Application.Restart();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.ClickToTalk = checkBox2.Checked;
            Properties.Settings.Default.StartWhenWindowsStarts = checkBox1.Checked;
            if (radioButton1.Checked)
                Properties.Settings.Default.CurrentSound = 1;
            else if (radioButton2.Checked)
                Properties.Settings.Default.CurrentSound = 2;
            else if (radioButton3.Checked)
                Properties.Settings.Default.CurrentSound = 3;
            else if (radioButton4.Checked)
                Properties.Settings.Default.CurrentSound = 4;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
                
        }

        private void settingsChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
