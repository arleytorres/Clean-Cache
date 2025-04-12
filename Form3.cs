using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CleanCache
{
    public partial class Form3 : Form
    {
        Form1 form;
        string Tag = null;
        string Tipo = null;

        public Form3(Form1 _form, string _tipo, string _tag)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            form = _form;
            Tag = _tag;
            Tipo = _tipo;

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

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (string file in form.DuplicatedFiles[Tipo][Tag])
                fileslist.Items.Add(Path.GetFileName(file));
        }

        private void ButtonsClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch(btn.Name.ToLower())
            {
                case "deleteonly":
                    {
                        if (fileslist.SelectedIndex == -1)
                            return;

                        var file = form.DuplicatedFiles[Tipo][Tag][fileslist.SelectedIndex];
                        try
                        {
                            File.Delete(file);
                            MessageBox.Show($"Arquivo: {form.DuplicatedFiles[Tipo][Tag][fileslist.SelectedIndex]} removido!");
                            form.DuplicatedFiles[Tipo][Tag].Remove(form.DuplicatedFiles[Tipo][Tag][fileslist.SelectedIndex]);
                            fileslist.Items.Remove(fileslist.Items[fileslist.SelectedIndex]);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }

                        if (form.DuplicatedFiles[Tipo][Tag].Count <= 1)
                        {
                            form.DuplicatedFiles[Tipo].Remove(Tag);
                            Close();
                        }
                    }
                    break;
                case "deleteall":
                    {
                        int count = 0;
                        foreach (var file in form.DuplicatedFiles[Tipo][Tag].ToList())
                        {
                            try
                            {
                                File.Delete(file);
                                form.DuplicatedFiles[Tipo][Tag].Remove(file);
                                count++;
                            }
                            catch { }
                        }

                        if (form.DuplicatedFiles[Tipo][Tag].Count <= 1)
                            form.DuplicatedFiles[Tipo].Remove(Tag);

                        MessageBox.Show($"{count} arquivos foram removidos!");
                        Close();
                    }
                    break;
                case "closebtn":
                    Close();
                    break;
            }
        }

        private void FilesListChanged(object sender, EventArgs e)
        {
            var info = new FileInfo(form.DuplicatedFiles[Tipo][Tag][fileslist.SelectedIndex]);
            desclbl.Text = $"Nome do Arquivo:\n\nTipo: {info.Extension}\nLocal: {info.FullName.Replace(info.Name, string.Empty)}\nTamanho: {Ferramentas.FormatFileSize(info.Length)} ({(info.Length)} bytes)";
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
