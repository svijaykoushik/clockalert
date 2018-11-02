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
        //Modules
        AudioPlayer player;
        TimeKeeper keeper;
        TimeTeller teller;
        FileHandler handle;
        //Local class variables
        bool state;
        int selectedSound;
        public Startup()
        {            
            player = new AudioPlayer();
            keeper = new TimeKeeper();
            teller = new TimeTeller();
            handle = new FileHandler();
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
            ico.Icon=Properties.Resources.trayIcon;
            ico.Text="A clock that rings every hour";
            ico.Visible=true;
            ico.ContextMenuStrip = menu;
            ico.MouseClick += new MouseEventHandler(ico_MouseClick);

            //about properties.
            about.Text = "About Clock alert";
            about.Click += new EventHandler(about_Click);
            menu.Items.Add(about);

            //chkUpdate property
            chkUpdate.Text = "Check for updates";
            chkUpdate.Click += new EventHandler(chkUpdate_Click);
            menu.Items.Add(chkUpdate);

            // settings properties
            settings.Text="Settings";
            settings.Click += new EventHandler(settings_Click);
            menu.Items.Add(settings);

            //turnoff properties
            turnoff.Text = "Turn off";
            turnoff.Click += new EventHandler(turnoff_Click);
            menu.Items.Add(turnoff);

            //clock properties
            clock.Interval = 1000;
            clock.Tick += new EventHandler(clock_Tick);

            //close properties
            close.Text = "Close";
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
                teller.talk("It's " + DateTime.Now.ToString("hh:mm tt"));
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
            loadSettings();
            loadSound();
            initializeComponents();
            clock.Start();
            state = true;
        }

        void clock_Tick(object sender, EventArgs e)
        {
            if (keeper.isItTime())
            {
                try
                {
                    clock.Stop();
                    player.play();
                    clock.Start();
                }
                catch (Exception ex)
                {
                    clock.Stop();
                    //MessageBox.Show(ErrorLog.logError(ex), "Error - Clock Alert", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    CrashReporterUI reportWindow= new CrashReporterUI(ex);
                    reportWindow.ShowDialog();
                }
            }
        }

        void turnoff_Click(object sender, EventArgs e)
        {
            if (state == true)
            {
                clock.Stop();
                turnoff.Text = "Turn On";
            }
            else
            {
                clock.Start();
                turnoff.Text = "Turn Off";
            }
        }

        void settings_Click(object sender, EventArgs e)
        {
            Form1 settings = new Form1();
            settings.TopMost = true;
            settings.Show();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the application settings form disk.
        /// </summary>
        void loadSettings()
        {
            selectedSound = Properties.Settings.Default.CurrentSound;
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
