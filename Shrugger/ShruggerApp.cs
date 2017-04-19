using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shrugger
{
    public partial class ShruggerApp : Form
    {
        private KeyHandler ghk;
        private Shrugger shrugger;
        public ShruggerApp()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            ghk = new KeyHandler(Keys.Oem3, Constants.MOD_CONTROL, this);
            ghk.Register();
            shrugger = new Shrugger();
            this.Resize += frmMain_Resize;
            this.WindowState = FormWindowState.Minimized;
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                shrugger.HandleHotKey();
            base.WndProc(ref m);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void ExitToolstripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
