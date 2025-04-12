using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanCache
{
    public partial class configs : Form
    {
        public configs()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            foreach (Control control in Controls)
            {
                if (control.Tag != null && int.TryParse(control.Tag.ToString(), out int tag)) control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, tag, tag));
                foreach (Control control2 in control.Controls)
                {
                    if (control2.Tag != null && int.TryParse(control2.Tag.ToString(), out tag)) control2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control2.Width, control2.Height, tag, tag));
                    foreach (Control control3 in control2.Controls)
                    {
                        if (control3.Tag != null && int.TryParse(control3.Tag.ToString(), out tag)) control3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control3.Width, control3.Height, tag, tag));
                    }
                }
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void configs_Load(object sender, EventArgs e)
        {
            comboopc.Text = config.Configuracoes.AutoScan;
            configopc1.Tag = config.Configuracoes.StartsWithSystem ? "ON" : "OFF";
            configopc2.Tag = config.Configuracoes.StartsMinimized ? "ON" : "OFF";
            configopc3.Tag = config.Configuracoes.AutoClear ? "ON" : "OFF";

            configopc1.Image = configopc1.Tag.ToString().Equals("ON") ? Properties.Resources.on_button : Properties.Resources.off_button;
            configopc2.Image = configopc2.Tag.ToString().Equals("ON") ? Properties.Resources.on_button : Properties.Resources.off_button;
            configopc3.Image = configopc3.Tag.ToString().Equals("ON") ? Properties.Resources.on_button : Properties.Resources.off_button;
        }

        private void ButtonsClick(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Name.ToLower())
                {
                    case "logsbtn":
                        string localdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow\\Clean Cash\\Logs");
                        if (Directory.Exists(localdata))
                        {
                            Process.Start("explorer.exe", localdata);
                            Close();
                        }
                        break;
                    case "minbtn":
                        WindowState = FormWindowState.Minimized;
                        break;
                    case "closebtn":
                        Close();
                        break;
                }
            }
            else if (sender is PictureBox pic)
            {
                pic.Image = pic.Tag.ToString().Equals("OFF") ? Properties.Resources.on_button : Properties.Resources.off_button;
                pic.Tag = pic.Tag.ToString().Equals("OFF") ? "ON" : "OFF";

                switch (pic.Name.ToLower())
                {
                    case "configopc1":
                        config.Configuracoes.StartsWithSystem = pic.Tag.ToString().Equals("ON");
                        Ferramentas.WindowsLoginStart(config.Configuracoes.StartsWithSystem);
                        break;
                    case "configopc2":
                        config.Configuracoes.StartsMinimized = pic.Tag.ToString().Equals("ON");
                        break;
                    case "configopc3":
                        config.Configuracoes.AutoClear = pic.Tag.ToString().Equals("ON");
                        break;
                }
            }
        }

        private void VarreduraConfigChanged(object sender, EventArgs e)
        {
            config.Configuracoes.AutoScan = comboopc.Text;
        }

        private bool Moving = false;
        private int posX = 0;
        private int posY = 0;

        private void menubar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Moving) return;
            this.SetDesktopLocation((MousePosition.X - posX), (MousePosition.Y - posY));
        }

        private void menubar_MouseUp(object sender, MouseEventArgs e)
        {
            Moving = false;
        }

        private void menubar_MouseDown(object sender, MouseEventArgs e)
        {
            if (MousePosition.X <= this.Location.X || MousePosition.X >= (this.Location.X + this.Size.Width)) return;
            if (MousePosition.Y <= this.Location.Y || MousePosition.Y > (this.Location.Y + 30)) return;
            posX = MousePosition.X - this.Location.X;
            posY = MousePosition.Y - this.Location.Y;
            Moving = true;
        }
    }
}
