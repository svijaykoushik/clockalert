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
        AudioPlayer player;
        TimeKeeper keeper;
        public Form1()
        {
            player = new AudioPlayer();
            keeper = new TimeKeeper();
            InitializeComponent();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            //.Text = DateTime.Now.Second.ToString();
            if (keeper.isItTime())
            {
                try
                {
                    player.play();
                }
                catch (Exception ex)
                {
                    clock.Stop();
                    MessageBox.Show(ErrorLog.logError(ex),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clock.Start();
        }
    }
}
