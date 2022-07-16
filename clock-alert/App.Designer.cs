using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ClockAlert
{
    partial class App
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponents()
        {
            //ComponentResourceManager _resource = new ComponentResourceManager(typeof(App));
            this.components = new System.ComponentModel.Container();
            this.ico = new NotifyIcon();
            this.menu = new ContextMenuStrip();
            this.settings = new ToolStripMenuItem();
            this.turnoff = new ToolStripMenuItem();
            this.close = new ToolStripMenuItem();
            this.chkUpdate = new ToolStripMenuItem();
            this.about = new ToolStripMenuItem();
            this.clock = new Timer(this.components);


            // ico properties
            this.ico.Icon = Properties.Resources.trayIcon;
            ico.Text = resource.GetString("icoText");
            this.ico.Visible = true;
            this.ico.ContextMenuStrip = menu;
            this.ico.MouseClick += new MouseEventHandler(Ico_MouseClick);

            // about properties.
            about.Text = resource.GetString("aboutText");
            about.Name = "about";
            about.Click += new EventHandler(About_Click);
            menu.Items.Add(about);

            // chkUpdate property
            chkUpdate.Text = resource.GetString("chkUpdateText");
            chkUpdate.Click += new EventHandler(ChkUpdate_Click);
            menu.Items.Add(chkUpdate);

            // settings properties
            settings.Text = resource.GetString("settingsText");
            settings.Click += new EventHandler(Settings_Click);
            settings.AutoSize = true;
            menu.Items.Add(settings);

            //turnoff properties
            turnoff.Text = resource.GetString("turnoffText");
            turnoff.Click += new EventHandler(Turnoff_Click);
            turnoff.AutoSize = true;
            menu.Items.Add(turnoff);

            //clock properties
            clock.Interval = 1000;
            clock.Tick += new EventHandler(Clock_Tick);

            //close properties
            close.Text = resource.GetString("closeText");
            close.AutoSize = true;
            close.Click += new EventHandler(Close_Click);
            menu.Items.Add(close);

            // settings changed event handler
            Properties.Settings.Default.SettingsSaving += OnBeforeSettingsSaved;
        }

        private System.ComponentModel.IContainer components = null;
        private NotifyIcon ico;
        private ContextMenuStrip menu;
        private ToolStripMenuItem settings, turnoff, close, chkUpdate, about;
        private Timer clock;

    }
}
