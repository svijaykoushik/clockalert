using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Clock_Alert
{
    class Startup: IDisposable
    {
        //Components
        NotifyIcon ico;
        ContextMenuStrip menu;
        ToolStripMenuItem settings,turnoff,close;
        Timer clock;
        //Modules
        AudioPlayer player;
        TimeKeeper keeper;
        //Local class variables
        bool state;
        public Startup()
        {
            player = new AudioPlayer();
            keeper = new TimeKeeper();
        }
        public void initializeComponents()
        {
            ico=new NotifyIcon();
            menu=new ContextMenuStrip();
            settings=new ToolStripMenuItem();
            turnoff=new ToolStripMenuItem();
            close = new ToolStripMenuItem();
            clock = new Timer();
            //Tray icon properties
            ico.Icon=Properties.Resources.trayIcon;
            ico.Text="A clock that rings every hour";
            ico.Visible=true;
            ico.ContextMenuStrip = menu;

            // settings properties
            settings.Text="Settings";
            settings.Click += new EventHandler(settings_Click);

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

        void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void startApp()
        {
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
                    MessageBox.Show(ErrorLog.logError(ex), "Clock alert - Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
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
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            ico.Dispose();
            clock.Dispose();
        }
    }
}
