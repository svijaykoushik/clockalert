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
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;

namespace Clock_Alert
{
    /// <summary>
    /// Defines the application properties and process
    /// </summary>
    class Startup: IDisposable
    {
        //Components
        NotifyIcon ico;
        ContextMenuStrip menu;
        ToolStripMenuItem settings,turnoff,close,chkUpdate,about;
        Timer clock;
        //private readonly ComponentResourceManager _resource;
        public CultureInfo currentCulture;
        //Modules
        AudioPlayer player;
        TimeKeeper keeper;
        TimeTeller teller;
        FileHandler handle;
        //Localization localization;
        //Local class variables
        bool state, clickToTalk, alertIntrvl, tellTime;
        int selectedSound;
        string start, end;
        public Startup()
        {            
            player = new AudioPlayer();
            keeper = new TimeKeeper();
            teller = new TimeTeller();
            handle = new FileHandler();
            //localization = new Localization();
            //_resource = new ComponentResourceManager(typeof(Startup));
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ta");
            //currentCulture = CultureInfo.CreateSpecificCulture("en");
        }
        /// <summary>
        /// Initializes the components for the application
        /// </summary>
        public void initializeComponents()
        {
            ico=new NotifyIcon();
            menu=new ContextMenuStrip();
            settings=new ToolStripMenuItem();
            turnoff=new ToolStripMenuItem();
            close = new ToolStripMenuItem();
            chkUpdate = new ToolStripMenuItem();
            about = new ToolStripMenuItem();
            clock = new Timer();
            
            //Tray icon properties
            //_resource.ApplyResources(this.ico, "ico");
            this.ico.Icon=Properties.Resources.trayIcon;
            ico.Text = Contents.icoText;//"A clock that rings every hour";
            this.ico.Visible=true;
            this.ico.ContextMenuStrip = menu;
            this.ico.MouseClick += new MouseEventHandler(ico_MouseClick);

            //about properties.
            //_resource.ApplyResources(this.about, "about");
            about.Text = Contents.aboutText;//"About Clock alert";
            about.Name = "about";
            about.Click += new EventHandler(about_Click);
            menu.Items.Add(about);

            //chkUpdate property
            //_resource.ApplyResources(this.chkUpdate, "chkUpdate");
            chkUpdate.Text = Contents.chkUpdateText;//"Check for updates";
            chkUpdate.Click += new EventHandler(chkUpdate_Click);
            menu.Items.Add(chkUpdate);

            // settings properties
            //_resource.ApplyResources(this.settings, "settings");
            settings.Text = Contents.settingsText;//"Settings";
            settings.AutoSize = true;
            settings.Click += new EventHandler(settings_Click);
            menu.Items.Add(settings);

            //turnoff properties
            //_resource.ApplyResources(this.turnoff, "turnoff");
            turnoff.Text = Contents.turnoffText;//"Turn off";
            turnoff.AutoSize = true;
            turnoff.Click += new EventHandler(turnoff_Click);
            menu.Items.Add(turnoff);

            //clock properties
            clock.Interval = 1000;
            clock.Tick += new EventHandler(clock_Tick);

            //close properties
            //_resource.ApplyResources(this.close, "close");
            close.Text = Contents.closeText;//"Close";
            close.AutoSize = true;
            close.Click += new EventHandler(close_Click);
                menu.Items.Add(close);

            
        }

        void about_Click(object sender, EventArgs e)
        {
            AboutClockAlert aboutWindow = new AboutClockAlert();
            aboutWindow.Show();
        }

        void chkUpdate_Click(object sender, EventArgs e)
        {
            AppUpdate updater = new AppUpdate();
            updater.checkForUpdate();
        }

        void ico_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (clickToTalk)
                {
                    teller.talk(Contents.speakText + DateTime.Now.ToString("hh:mm tt"));
                }
            }
        }


        void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Initializes the application
        /// </summary>
        public void startApp()
        {
            //localization.configure();
            loadSettings();
            if (tellTime == false)
            {
                loadSound();
            }
            initializeComponents();
            clock.Start();
            state = true;
        }

        void clock_Tick(object sender, EventArgs e)
        {
            if (alertIntrvl)
            {
                if (keeper.isBetween(DateTime.Now, Convert.ToDateTime(start), Convert.ToDateTime(end)))
                {
                    if (keeper.isItTime())
                    {
                        try
                        {
                            clock.Stop();
                            if (tellTime == false)
                                player.playAsynch();
                            else
                                teller.talk("The time is " + DateTime.Now.ToString("hh:mm tt"));
                            clock.Start();
                        }
                        catch (Exception ex)
                        {
                            clock.Stop();
                            //MessageBox.Show(ErrorLog.logError(ex), "Error - Clock Alert", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            CrashReporterUI reportWindow = new CrashReporterUI(ex);
                            reportWindow.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                if (keeper.isItTime())
                {
                    try
                    {
                        clock.Stop();
                        if (tellTime == false)
                            player.playAsynch();
                        else
                            teller.talk("The time is " + DateTime.Now.ToString("hh:mm tt"));
                        clock.Start();
                    }
                    catch (Exception ex)
                    {
                        clock.Stop();
                        //MessageBox.Show(ErrorLog.logError(ex), "Error - Clock Alert", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        CrashReporterUI reportWindow = new CrashReporterUI(ex);
                        reportWindow.ShowDialog();
                    }
                }
            }
        }

        void turnoff_Click(object sender, EventArgs e)
        {
            if (state == true)
            {
                clock.Stop();
                turnoff.Text = Contents.clockOn;//_resource.GetString("clock on");
                state = false;
            }
            else
            {
                clock.Start();
                turnoff.Text = Contents.clockOff;//_resource.GetString("clock off");
                state = true;
            }
        }

        void settings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.TopMost = true;
            settings.ShowDialog();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the application settings form disk.
        /// </summary>
        void loadSettings()
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
        void loadSound()
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

        /// <summary>
        /// Disposes the objects of this class.
        /// </summary>
        public void Dispose()
        {
            ico.Dispose();
            clock.Dispose();
        }
    }
}
