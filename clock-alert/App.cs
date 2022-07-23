using ClockAlert.Modules;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ClockAlert
{
    public partial class App:ApplicationContext
    {

        private readonly ComponentResourceManager resource;
        private bool state, clickToTalk, alertIntrvl, tellTime;
        private int selectedSound;
        private string start, end;
        private readonly TimeKeeper keeper;
        private AudioPlayer player;
        private readonly TimeTeller teller;
        public App()
        {

            // Initialize modules
            this.player = new AudioPlayer();
            this.keeper = new TimeKeeper();
            this.teller = new TimeTeller();
            resource = new ComponentResourceManager(typeof(App));

            this.LoadSettings();
            if (tellTime == false)
            {
                this.LoadSound();
            }
            this.InitializeComponents();
            clock.Start();
            state = true;
        }

        void About_Click(object sender, EventArgs e)
        {
            AboutClockAlert aboutWindow = new AboutClockAlert();
            aboutWindow.Show();
        }

        void ChkUpdate_Click(object sender, EventArgs e)
        {
            AppUpdate updater = new AppUpdate();
            updater.checkForUpdate();
        }

        void Ico_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (clickToTalk)
                {
                    teller.Talk(resource.GetString("speakText") + DateTime.Now.ToString("hh:mm tt"));
                }
            }
        }


        void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Clock_Tick(object sender, EventArgs e)
        {
            if (alertIntrvl)
            {
                if (keeper.IsBetween(DateTime.Now, Convert.ToDateTime(start), Convert.ToDateTime(end)))
                {
                    if (keeper.IsItTime())
                    {
                        try
                        {
                            clock.Stop();
                            if (tellTime == false)
                                player.PlayAsync();
                            else
                                teller.Talk("The time is " + DateTime.Now.ToString("hh:mm tt"));
                            clock.Start();
                        }
                        catch (Exception ex)
                        {
                            clock.Stop();
                           /* MessageBox.Show(ErrorLog.logError(ex), "Error - Clock Alert", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);*/
                            CrashReporterUI reportWindow = new CrashReporterUI(ex);
                            reportWindow.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                if (keeper.IsItTime())
                {
                    try
                    {
                        clock.Stop();
                        if (tellTime == false)
                            player.PlayAsync();
                        else
                            teller.Talk("The time is " + DateTime.Now.ToString("hh:mm tt"));
                        clock.Start();
                    }
                    catch (Exception ex)
                    {
                        clock.Stop();
                        /*MessageBox.Show(ErrorLog.logError(ex), "Error - Clock Alert", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);*/
                        CrashReporterUI reportWindow = new CrashReporterUI(ex);
                        reportWindow.ShowDialog();
                    }
                }
            }
        }

        void Turnoff_Click(object sender, EventArgs e)
        {
            if (state == true)
            {
                clock.Stop();
                turnoff.Text = resource.GetString("clockOn");
                state = false;
            }
            else
            {
                clock.Start();
                turnoff.Text = resource.GetString("clockOff");
                state = true;
            }
        }

        void Settings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.TopMost = true;
            settings.ShowDialog();
        }

        /// <summary>
        /// Loads the application settings form disk.
        /// </summary>
        void LoadSettings()
        {
            //MessageBox.Show(Properties.Settings.Default.TellTime.ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.SelectedLanguage);
            selectedSound = Properties.Settings.Default.CurrentSound;
            clickToTalk = Properties.Settings.Default.ClickToTalk;
            alertIntrvl = Properties.Settings.Default.AlertInterval;
            start = Properties.Settings.Default.StartHour + ":" + Properties.Settings.Default.StartMin + " " + ((Properties.Settings.Default.StartTT == 0) ? "AM" : "PM");
            end = Properties.Settings.Default.EndHour + ":" + Properties.Settings.Default.EndMin + " " + ((Properties.Settings.Default.EndTT == 0) ? "AM" : "PM");
            tellTime = Properties.Settings.Default.TellTime;
        }

        /// <summary>
        /// Loads the sound for playing the alert tone.
        /// </summary>
        void LoadSound()
        {
            if (selectedSound == 1)
            {
                player = new AudioPlayer(Properties.Resources.sound);
            }
            else if (selectedSound == 2)
            {
                player = new AudioPlayer(Properties.Resources.sound2);
            }
            else if (selectedSound == 3)
            {
                player = new AudioPlayer(Properties.Resources.sound3);
            }
            else if (selectedSound == 4)
            {
                player = new AudioPlayer(Properties.Resources.sound4);
            }
        }

        public void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            ico.Visible = false;

            Application.Exit();
        }

        public void ShowAlreadyRunningNotification()
        {
            ico.BalloonTipText = resource.GetString("appIsRunningBaloonText");
            ico.BalloonTipTitle = resource.GetString("appIsRunningBaloonTitle");
            ico.ShowBalloonTip(4000);
        }

        private void OnBeforeSettingsSaved(object sender, CancelEventArgs e)
        {
            LoadSettings();
        }
    }
}
