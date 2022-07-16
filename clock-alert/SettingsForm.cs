using ClockAlert.Modules;
using System;
using System.Windows.Forms;

namespace ClockAlert
{
    public partial class SettingsForm : Form
    {
        private bool isPlaying;
        private AudioPlayer player;

        private bool PlayerStatus { 
            get { 
                return isPlaying;
            }
            set
            {
                isPlaying = value;
                if (value)
                {
                    button1.Image = Properties.Resources.stop;
                }
                else
                {
                    button1.Image= Properties.Resources.play;
                    if(soundTimer != null)
                    {
                        soundTimer.Stop();
                    }
                }
            } 
        }
        public SettingsForm()
        {
            InitializeComponent();
            PlayerStatus = false;
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
            Properties.Settings.Default.StartHour = (int) startHour.Value;
            Properties.Settings.Default.StartMin = (int) startMin.Value;
            Properties.Settings.Default.StartTT = startTT.SelectedIndex;
            Properties.Settings.Default.EndHour = (int) endHour.Value;
            Properties.Settings.Default.EndMin = (int) endMin.Value;
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
            if (PlayerStatus == false)
            {
                if (radioButton1.Checked)
                {
                    PlaySelectedSound(Properties.Resources.sound);
                }
                else if (radioButton2.Checked)
                {
                    PlaySelectedSound(Properties.Resources.sound2);
                }
                else if (radioButton3.Checked)
                {
                    PlaySelectedSound(Properties.Resources.sound3);
                }
                else if (radioButton4.Checked)
                {
                    PlaySelectedSound(Properties.Resources.sound4);
                }
            }
            else
            {
                PlayerStatus = false;
                player.Stop();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((startHour.Value == endHour.Value) && (startMin.Value == endMin.Value) && (startTT.Text == endTT.Text))
            {
                System.Resources.ResourceManager appResourceManager = new System.Resources.ResourceManager(typeof(App));
                MessageBox.Show(appResourceManager.GetString("invalidTimeIntervalMsg"), appResourceManager.GetString("invalidTimeIntervalTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            saveSettings();
            this.Close();
        }

        private void enableIntervalControls()
        {
            startHour.Enabled = true;
            startMin.Enabled = true;
            startTT.Enabled = true;

            endHour.Enabled = true;
            endMin.Enabled = true;
            endTT.Enabled = true;
        }

        private void disableIntervalControls()
        {
            startHour.Enabled = false;
            startMin.Enabled = false;
            startTT.Enabled = false;

            endHour.Enabled = false;
            endMin.Enabled = false;
            endTT.Enabled = false;
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
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            button1.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                disableAlertTone();
            else
                enableAlertTone();
        }

        private void soundTimer_Tick(object sender, EventArgs e)
        {
            PlayerStatus = false;
            soundTimer.Stop();
        }

        private void PlaySelectedSound(System.IO.UnmanagedMemoryStream sound)
        {
            player = new AudioPlayer(sound);
            soundTimer.Interval = player.GetDuration() * 1000;
            PlayerStatus = true;
            player.PlayAsync();
            soundTimer.Start();
        }
    }
}
