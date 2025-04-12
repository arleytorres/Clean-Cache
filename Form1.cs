using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanCache
{
    public partial class Form1 : Form
    {
        // VARS
        public List<(Control parent, Control children)> ControlsAdded = new List<(Control, Control)>();
        public List<DirectoryInfo> Browsers = new List<DirectoryInfo>();
        public List<DriveInfo> Discos = new List<DriveInfo>();
        public Dictionary<string, Dictionary<string, List<string>>> DuplicatedFiles = new Dictionary<string, Dictionary<string, List<string>>>();
        public bool Scanning = false;
        public long SystemCache = 0;
        public long UserCache = 0;
        public long PrefetchCache = 0;
        public long RecycleCache = 0;
        public long browserssize = 0;
        public int filescount = 0;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        
        public Form1()
        {
            InitializeComponent();
            ResizeBorders();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            if (config.Configuracoes.StartsMinimized)
            {
                notifyIcon1.Visible = true;
                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;

                notifyIcon1.BalloonTipTitle = "Atenção!";
                notifyIcon1.BalloonTipText = "Você recebeu uma nova mensagem.";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(2000);
            }
        }


        private async void ButtonsClick(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Name.ToLower())
                {
                    case "scanbtn":
                        ResetInfo();
                        LoadInfo();
                        break;
                    case "cleanbtn":
                        Limpar();
                        break;
                    case "configbtn":
                        var form = new configs();
                        form.ShowDialog();
                        break;

                    case "cleanbtn1":
                        Limpar(1);
                        break;
                    case "cleanbtn2":
                        Limpar(2);
                        break;
                    case "scandoublesbtn":
                        await Scan.Doubles(this);
                        break;

                    case "minbtn":
                        WindowState = FormWindowState.Minimized;
                        break;
                    case "closebtn":
                        WindowState = FormWindowState.Minimized;
                        ShowInTaskbar = false;
                        notifyIcon1.Visible = true;
                        break;
                }
            }
            else if (sender is PictureBox pic)
            {
                switch (pic.Name.ToLower())
                {
                    case "docspic":
                        DuplicatedFilesWindows("Documentos");
                        break;
                    case "imgpic":
                        DuplicatedFilesWindows("Imagens");
                        break;
                    case "vidpic":
                        DuplicatedFilesWindows("Vídeos");
                        break;
                    case "outrospic":
                        DuplicatedFilesWindows("Outros");
                        break;
                }
            }
            else if (sender is Label lbl)
            {
                switch (lbl.Name.ToLower())
                {
                    case "docslbl":
                        DuplicatedFilesWindows("Documentos");
                        break;
                    case "imglbl":
                        DuplicatedFilesWindows("Imagens");
                        break;
                    case "vidlbl":
                        DuplicatedFilesWindows("Vídeos");
                        break;
                    case "outroslbl":
                        DuplicatedFilesWindows("Outros");
                        break;
                }
            }
            else if (sender is ToolStripMenuItem menu)
            {
                switch(menu.Name.ToLower())
                {
                    case "openmenubtn":
                        notifyIcon1.Visible = false;
                        ShowInTaskbar = true;
                        WindowState = FormWindowState.Normal;
                        break;
                    case "opcmenubtn":
                        notifyIcon1.Visible = false;
                        ShowInTaskbar = true;
                        WindowState = FormWindowState.Normal;
                        var form = new configs();
                        form.ShowDialog();
                        break;
                    case "closemenubtn":
                        notifyIcon1.Visible = false;
                        Close();
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private async Task LoadInfo()
        {
            await Logs.Register("\n==============================\nVerificação de arquivos iniciada\n==============================");
            await Task.Delay(50);
            Scanning = true;
            await Ferramentas.CheckCachesSystem(this);
            await Ferramentas.CheckDisks(this);
            await Ferramentas.CheckCachesBrowsers(this);
            await Scan.Disks(this);
            await Scan.Browsers(this);

            await Scan.UpdateForm(this);
            Scanning = false;
            await Logs.Register("\n------------------------------\nVerificação de arquivos finalizada\n------------------------------");
        }

        private void DuplicatedFilesWindows(string filetype)
        {
            var form = new Form2(this, filetype);
            form.FormClosing += Form2Closing;
            form.ShowDialog();
        }

        private void Form2Closing(object sender, FormClosingEventArgs e)
        {
            foreach (var categoria in DuplicatedFiles)
            {
                switch (categoria.Key)
                {
                    case "Documentos":
                        doccachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                    case "Imagens":
                        imgcachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                    case "Vídeos":
                        vidcachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                    case "Outros":
                        otherscachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                }
            }
        }

        public void ResizeBorders()
        {
            foreach (Control control in Controls)
            {
                if (control.Tag != null && int.TryParse(control.Tag.ToString(), out int tag)) control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, tag, tag));
                foreach (Control control2 in control.Controls)
                {
                    if (control2.Tag != null && int.TryParse(control2.Tag.ToString(), out tag)) control2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control2.Width, control2.Height, tag, tag));
                    foreach (Control control3 in control2.Controls)
                    {
                        if (control3.Tag != null && int.TryParse(control3.Tag.ToString(), out tag)) control3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control3.Width, control3.Height, tag, tag));
                        foreach (Control control4 in control3.Controls)
                        {
                            if (control4.Tag != null && int.TryParse(control4.Tag.ToString(), out tag)) control4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control4.Width, control4.Height, tag, tag));
                        }
                    }
                }
            }
        }

        private void ResetInfo()
        {
            cleantitle.Text = "VERIFICANDO...";
            loadingbar.Visible = true;
            cleandescription.Visible = false;
            scanbtn.Enabled = false;
            cleanbtn.Enabled = false;

            Discos = new List<DriveInfo>();
            Browsers = new List<DirectoryInfo>();
            SystemCache = 0;
            UserCache = 0;
            PrefetchCache = 0;
            RecycleCache = 0;
            browserssize = 0;
            filescount = 0;

            WindowsCache.Text = "Calculando";
            BrowsersCache.Text = "Calculando";

            SystemCachelbl.Text = "Calculando...";
            UserCachelbl.Text = "Calculando...";
            PrefetchCachelbl.Text = "Calculando...";

            foreach (var control in ControlsAdded)
                control.parent.Controls.Remove(control.children);

            ControlsAdded.Clear();
        }

        private async Task Limpar(int type = 0)
        {
            await Logs.Register("Limpeza de caches iniciada");
            cleantitle.Text = "LIMPANDO...";
            cleanbtn.Enabled = false;
            scanbtn.Enabled = false;

            scanbtn.Enabled = false;
            cleanbtn.Enabled = false;
            cleanbtn1.Enabled = false;
            cleanbtn2.Enabled = false;

            string tempuser = Environment.GetEnvironmentVariable("TEMP");
            string tempsystem = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp");
            string prefetch = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch");

            int DeleteCount = 0;

            if (type == 0 || type == 1)
            {
                #region TEMPUSER
                foreach (var file in new DirectoryInfo(tempuser).GetFiles("*", SearchOption.AllDirectories))
                    try
                    {
                        cleandescription.Text = "Deletando: " + file.FullName;
                        file.Delete();
                        DeleteCount++;
                        await Logs.Register("Cache de usuário deletado: " + file.FullName);
                        await Task.Delay(50);
                    }
                    catch 
                    { 
                        cleandescription.Text = "Não foi possível deletar o arquivo: " + file.Name;
                        await Logs.Register("Não foi possível deletar o cache: " + file.FullName);
                    }
                #endregion

                #region TEMPSYSTEM
                foreach (var file in new DirectoryInfo(tempsystem).GetFiles("*", SearchOption.AllDirectories))
                    try
                    {
                        cleandescription.Text = "Deletando: " + file.FullName;
                        file.Delete();
                        DeleteCount++;
                        await Logs.Register("Cache de sistema deletado: " + file.FullName);
                        await Task.Delay(50);
                    }
                    catch 
                    {
                        await Logs.Register("Não foi possível deletar o cache: " + file.FullName);
                        cleandescription.Text = "Não foi possível deletar o arquivo: " + file.Name; 
                    }
                #endregion

                #region PREFETCH
                foreach (var file in new DirectoryInfo(prefetch).GetFiles("*", SearchOption.AllDirectories))
                    try
                    {
                        cleandescription.Text = "Deletando: " + file.FullName;
                        file.Delete();
                        DeleteCount++;
                        await Logs.Register("Prefetch cache deletado: " + file.FullName);
                        await Task.Delay(50);
                    }
                    catch 
                    {
                        await Logs.Register("Não foi possível deletar o prefetch cache: " + file.FullName);
                        cleandescription.Text = "Não foi possível deletar o arquivo: " + file.Name; 
                    }
                #endregion
            }
            else if (type == 0 || type == 2)
            {
                foreach (var browser in Browsers)
                    try
                    {
                        foreach (var file in new DirectoryInfo(await Ferramentas.GetBrowserCachePath(browser)).GetFiles("*", SearchOption.AllDirectories))
                        {
                            try
                            {
                                cleandescription.Text = "Deletando: " + file.FullName;
                                file.Delete();
                                DeleteCount++;
                                //await Logs.Register("Cache de browser deletado: " + file.FullName);
                            }
                            catch 
                            {
                                //await Logs.Register("Não foi possível deletar o browser cache: " + file.FullName);
                                cleandescription.Text = "Não foi possível deletar o arquivo: " + file.Name; 
                            }
                            await Task.Delay(30);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }

            await Logs.Register($"Limpeza de caches finalizada, {DeleteCount} arquivos foram deletados");
            ResetInfo();
            LoadInfo();
            MessageBox.Show($"{DeleteCount} arquivos foram deletados", "SUCESSO", MessageBoxButtons.OK);
        }

        private void AutoScanTimerElapsed(object sender, EventArgs e)
        {
            switch (config.Configuracoes.AutoScan)
            {
                case "Diáriamente":
                    if ((DateTime.Now - config.Configuracoes.LastScan).TotalHours >= 24)
                    {
                        ResetInfo();
                        LoadInfo();
                        if (config.Configuracoes.AutoClear)
                            Limpar();
                    }
                    break;
                case "Semanalmente":
                    if ((DateTime.Now - config.Configuracoes.LastScan).TotalDays >= 7)
                    {
                        ResetInfo();
                        LoadInfo();
                        if (config.Configuracoes.AutoClear)
                            Limpar();
                    }
                    break;
                case "Mensalmente":
                    if ((DateTime.Now - config.Configuracoes.LastScan).TotalDays >= 30)
                    {
                        ResetInfo();
                        LoadInfo();
                        if (config.Configuracoes.AutoClear)
                            Limpar();
                    }
                    break;
            }
        }

        private void BalloonDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private bool Moving = false;
        private int posX = 0;
        private int posY = 0;

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (MousePosition.X <= this.Location.X || MousePosition.X >= (this.Location.X + this.Size.Width)) return;
            if (MousePosition.Y <= this.Location.Y || MousePosition.Y > (this.Location.Y + 25)) return;
            posX = MousePosition.X - this.Location.X;
            posY = MousePosition.Y - this.Location.Y;
            Moving = true;
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            Moving = false;
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (!Moving) return;
            this.SetDesktopLocation((MousePosition.X - posX), (MousePosition.Y - posY));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Scanning && MessageBox.Show("Uma verificação está em progresso.\nDeseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            DB.WriteData();
        }
    }
}
