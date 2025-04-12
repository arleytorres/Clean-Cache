using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanCache
{
    public partial class Form2 : Form
    {
        private string Tipo;
        Form1 form;
        List<Control> Controles = new List<Control>();
        List<Control> SelectedFiles = new List<Control>();

        public Form2(Form1 _form, string _tipo)
        {
            InitializeComponent();
            Tipo = _tipo;
            form = _form;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private async Task LoadFiles()
        {
            try
            {
                maintitle.Text = Tipo;

                await Task.Delay(250);
                int id = 0;
                int x = 0;
                int y = 0;
                foreach (var file in form.DuplicatedFiles[Tipo].Keys)
                {
                    Image preview = null;

                    if (Tipo == "Imagens")
                        using (var stream = new FileStream(form.DuplicatedFiles[Tipo][file][0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            preview = Image.FromStream(stream).Clone() as Image;

                    var pic = new PictureBox
                    {
                        Name = "picfile" + id,
                        Parent = listpanel,
                        Image = Tipo.Equals("Documentos") ? Properties.Resources.paper : Tipo.Equals("Imagens") ? preview ?? Properties.Resources.image__1_ : Tipo.Equals("Vídeos") ? Properties.Resources.video_player : Properties.Resources.folder,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(55, 55),
                        Location = new Point(37 + (105 * x), 21 + (110 * y) + listpanel.AutoScrollPosition.Y),
                        Tag = file,
                        Cursor = Cursors.Hand,
                    };
                    pic.Click += FilesClick;
                    pic.DoubleClick += FilesDoubleClick;

                    var lbl = new Label
                    {
                        Name = "namefile" + id,
                        Parent = listpanel,
                        AutoSize = true,
                        MinimumSize = new Size(85, 17),
                        MaximumSize = new Size(85, 40),
                        Location = new Point(24 + (105 * x), 78 + (110 * y) + listpanel.AutoScrollPosition.Y),
                        ForeColor = Color.DimGray,
                        Font = new Font("Arial Narrow", 8.25f, FontStyle.Bold),
                        TextAlign = ContentAlignment.TopCenter,
                        UseCompatibleTextRendering = true,
                        Text = Path.GetFileName(form.DuplicatedFiles[Tipo][file][0]),
                        Tag = file,
                        Cursor = Cursors.Hand,
                    };
                    lbl.Click += FilesClick;
                    lbl.DoubleClick += FilesDoubleClick;

                    var check = new CheckBox
                    {
                        Name = "checkfile" + id,
                        Parent = pic,
                        Tag = file,
                        AutoSize = true,
                        BackColor = Color.White,
                        ForeColor = Color.Indigo,
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(0, 0),
                    };

                    check.CheckedChanged += CheckedDoublesFile;
                    Controles.Add(pic);
                    Controles.Add(lbl);
                    Controles.Add(check);

                    id++;
                    y += x == 5 ? 1 : 0;
                    x = x < 5 ? x + 1 : 0;
                    await Task.Delay(60);
                }
            }
            catch { }
        }

        private void SelectAllFiles(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            bool state = check.Checked;

            foreach (var control in listpanel.Controls)
                if (control is PictureBox pic)
                    if (pic.Controls.Cast<Control>().ToList()[0] is CheckBox _check)
                        _check.Checked = state;
        }

        private void CheckedDoublesFile(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked)
                SelectedFiles.Add(check);
            else
                if (SelectedFiles.Contains(check))
                    SelectedFiles.Remove(check);

            if (SelectedFiles.Count > 0)
            {
                selectedchecks.Visible = true;
                selectedchecks.Text = SelectedFiles.Count + " Selecionado(s)";
                cleanallbtn.Visible = true;

                selectedchecks.CheckedChanged -= SelectAllFiles;
                if (SelectedFiles.Count == form.DuplicatedFiles[Tipo].Keys.Count)
                    selectedchecks.Checked = true;
                else
                    selectedchecks.Checked = false;
                selectedchecks.CheckedChanged += SelectAllFiles;
            }
            else
            {
                selectedchecks.Visible = false;
                cleanallbtn.Visible = false;
            }
        }

        private void listpanel_Click(object sender, EventArgs e)
        {
            foreach (var control in listpanel.Controls)
            {
                if (control is PictureBox pic && pic.BackColor == Color.Thistle)
                    pic.BackColor = Color.Transparent;
                else if (control is Label lbl && lbl.BackColor == Color.Thistle)
                    lbl.BackColor = Color.Transparent;
            }
        }

        private void FilesClick(object sender, EventArgs e)
        {
            foreach (var control in listpanel.Controls)
            {
                if (control is PictureBox _pic && _pic.BackColor == Color.Thistle)
                    _pic.BackColor = Color.Transparent;
                else if (control is Label lbl && lbl.BackColor == Color.Thistle)
                    lbl.BackColor = Color.Transparent;
            }

            if (sender is PictureBox pic)
            {
                pic.BackColor = Color.Thistle;
                foreach (var control in listpanel.Controls)
                {
                    if (control is Label lbl && lbl.Name.Equals("namefile" + pic.Name.Replace("picfile", string.Empty)))
                        lbl.BackColor = Color.Thistle;
                }
            }
            else if (sender is Label lbl)
            {
                lbl.BackColor = Color.Thistle;

                foreach (var control in listpanel.Controls)
                {
                    if (control is PictureBox _pic && _pic.Name.Equals("picfile" + lbl.Name.Replace("namefile", string.Empty)))
                        _pic.BackColor = Color.Thistle;
                }
            }
        }

        private void FilesDoubleClick(object sender, EventArgs e)
        {
            string tag = null;
            if (sender is PictureBox pic)
                tag = pic.Tag.ToString();
            else if (sender is Label lbl)
                tag = lbl.Tag.ToString();

            var _form = new Form3(form, Tipo, tag);
            _form.FormClosing += Form3Closing;
            _form.ShowDialog();
        }

        private void Form3Closing(object sender, FormClosingEventArgs e)
        {
            UpdateList();
        }

        private void ButtonsClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name.ToLower())
            {
                case "cleanallbtn":
                    opcwindow.Visible = !opcwindow.Visible;
                    break;
                case "deleteclonesbtn":
                    ClearFiles();
                    opcwindow.Visible = false;
                    break;
                case "deleteallbtn":
                    ClearFiles(true);
                    opcwindow.Visible = false;
                    break;
                case "closebtn":
                    Close();
                    break;
            }
        }

        private void UpdateList()
        {
            selectedchecks.Checked = false;
            selectedchecks.Visible = false;
            opcwindow.Visible = false;

            foreach (var control in Controles.ToList())
            {
                if (control is PictureBox pic)
                    listpanel.Controls.Remove(pic);
                if (control is Label lbl && lbl.Name != "maintitle")
                    listpanel.Controls.Remove(lbl);
            }

            Controles.Clear();
            LoadFiles();
        }

        private async Task ClearFiles(bool all = false)
        {
            int deletedcount = 0;
            foreach (var control in listpanel.Controls)
                if (control is PictureBox pic)
                    if (pic.Controls.Cast<Control>().ToList()[0] is CheckBox _check && _check.Checked)
                    {
                        try
                        {
                            var files = form.DuplicatedFiles[Tipo][pic.Tag.ToString()];
                            if (!all) files.Remove(files[0]);
                            files.ForEach(x => File.Delete(x));
                            deletedcount += files.Count;
                            form.DuplicatedFiles[Tipo].Remove(pic.Tag.ToString());
                        }
                        catch { }
                    }

            UpdateList();
            MessageBox.Show($"{deletedcount} arquivos foram deletados!");
        }


        private bool Moving = false;
        private int posX = 0;
        private int posY = 0;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Moving) return;
            this.SetDesktopLocation((MousePosition.X - posX), (MousePosition.Y - posY));
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Moving = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MousePosition.X <= this.Location.X || MousePosition.X >= (this.Location.X + this.Size.Width)) return;
            if (MousePosition.Y <= this.Location.Y || MousePosition.Y > (this.Location.Y + 30)) return;
            posX = MousePosition.X - this.Location.X;
            posY = MousePosition.Y - this.Location.Y;
            Moving = true;
        }
    }
}
