using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanCache
{
    internal class Scan
    {
        public static async Task Disks(Form1 form)
        {
            await Logs.Register("Verificando informações de discos");

            int id = 0;
            foreach (var disk in form.Discos.Take(4))
            {
                long total = disk.TotalSize;
                long free = disk.TotalFreeSpace;
                (string type, double size) realfree = await Ferramentas.FormatFileSize(free);
                (string type, double size) realtotal = await Ferramentas.FormatFileSize(total);
                int percentual = (int)((realfree.size / realtotal.size) * 100);

                var progressbar = new CircularProgressBar.CircularProgressBar
                {
                    Name = "progressdisk" + id,
                    AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner,
                    AnimationSpeed = 5000,
                    BackColor = Color.Transparent,
                    OuterWidth = 8,
                    OuterColor = Color.LightGray,
                    OuterMargin = -8,
                    ProgressWidth = 8,
                    ProgressColor = Color.SlateBlue,
                    Location = new Point(13 + (200 * id), 530),
                    Size = new Size(52, 52),
                    StartAngle = 180,
                    Value = 100 - percentual,

                    Text = $"{100 - percentual}%",
                    SubscriptText = "",
                    SuperscriptText = "",
                    TextMargin = new Padding(2, 2, 0, 0),
                    ForeColor = Color.SlateBlue,
                    Font = new Font("Arial", 7.0f, FontStyle.Bold),
                };

                var lbltitle = new Label
                {
                    Name = "titledisk" + id,
                    Font = new Font("Arial", 9.75f, FontStyle.Bold),
                    ForeColor = Color.DimGray,
                    AutoSize = true,
                    Size = new Size(79, 17),
                    Location = new Point(69 + (200 * id), 539),
                    Text = "Disco " + disk.Name.Replace("\\", string.Empty)
                };

                var lbldesc = new Label
                {
                    Name = "descdisk" + id,
                    Font = new Font("Arial Narrow", 9.75f, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Size = new Size(100, 17),
                    Location = new Point(69 + (200 * id), 558),
                    Text = $"{(int)realfree.size}{realfree.type}/{(int)realtotal.size}{realtotal.type}"
                };

                form.Controls.Add(progressbar);
                form.Controls.Add(lbltitle);
                form.Controls.Add(lbldesc);

                form.ControlsAdded.Add((form, progressbar));
                form.ControlsAdded.Add((form, lbltitle));
                form.ControlsAdded.Add((form, lbldesc));

                id++;
                await Task.Delay(20);
            }
        }

        public static async Task Browsers(Form1 form)
        {
            await Logs.Register("Verificando informações caches de Browsers");

            form.browsersarea.Controls.Clear();

            int id = 0;
            foreach (var browser in form.Browsers)
            {
                (string type, double size) Cache = await Ferramentas.FormatFileSize(await Ferramentas.GetDirectorySize(await Ferramentas.GetBrowserCachePath(browser)));
                if (Cache.type == "B") continue;

                var browserpanel = new TableLayoutPanel
                {
                    Name = "browserpanel" + id,
                    BackColor = Color.Transparent,
                    Size = new Size(114, 95),
                    Margin = new Padding(3, 3, 6, 3),
                    ColumnCount = 1,
                    RowCount = 3,
                };
                browserpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                browserpanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
                browserpanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
                browserpanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

                var pic = new PictureBox
                {
                    Name = "browserpic" + id,
                    Parent = form.mainpanel,
                    Size = new Size(53, 53),
                    SizeMode = PictureBoxSizeMode.Zoom,
                };

                var lbl = new Label
                {
                    Name = "browserlbl" + id,
                    AutoSize = false,
                    Font = new Font("Arial Narrow", 8.25f, FontStyle.Bold),
                    Size = new Size(114, 18),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.DimGray,
                };

                var sizelbl = new Label
                {
                    Name = "browsersize" + id,
                    AutoSize = false,
                    Tag = 15,
                    Font = new Font("Arial Narrow", 8.25f, FontStyle.Bold),
                    Size = new Size(81, 19),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.SlateBlue,
                    ForeColor = Color.White,
                    Text = $"{Cache.size} {Cache.type}"
                };

                string cachepath = await Ferramentas.GetBrowserCachePath(browser);

                form.browserssize += await Ferramentas.GetDirectorySize(cachepath);
                form.filescount += await Ferramentas.GetDirectoryFiles(cachepath);

                switch (browser.Name.ToLower())
                {
                    case "google":
                        pic.Image = Properties.Resources.chrome;
                        lbl.Text = "Google Chrome";
                        break;
                    case "edge":
                        pic.Image = Properties.Resources.edge;
                        lbl.Text = "Microsoft Edge";
                        break;
                    case "internet explorer":
                        pic.Image = Properties.Resources.explorer;
                        lbl.Text = "Internet Explorer";
                        break;
                    case "mozilla":
                        pic.Image = Properties.Resources.firefox;
                        lbl.Text = "Mozilla Firefox";
                        break;
                    case "opera stable":
                        pic.Image = Properties.Resources.opera;
                        lbl.Text = "Opera";
                        break;
                    case "opera gx stable":
                        pic.Image = Properties.Resources.operagx;
                        lbl.Text = "Opera GX";
                        break;
                    case "bravesoftware":
                        pic.Image = Properties.Resources.brave;
                        lbl.Text = "Brave";
                        break;
                    case "duckduckgo":
                        pic.Image = Properties.Resources.duckduckgo;
                        lbl.Text = "DuckDuckGo";
                        break;
                }


                pic.Anchor = AnchorStyles.None;
                browserpanel.Controls.Add(pic);
                lbl.Anchor = AnchorStyles.None;
                browserpanel.Controls.Add(lbl);
                sizelbl.Anchor = AnchorStyles.None;
                browserpanel.Controls.Add(sizelbl);
                form.browsersarea.Controls.Add(browserpanel);

                form.ControlsAdded.Add((form.mainpanel, browserpanel));
                id++;
                await Task.Delay(25);
            }
            form.ResizeBorders();
        }

        public static async Task Doubles(Form1 form)
        {
            if (form.duplicatedpanel.Visible)
                return;

            await Logs.Register("Verificando arquivos duplicados do sistema");
            form.DuplicatedCache.Text = "Buscando";
            form.scandoublesbtn.Enabled = false;
            await Task.Delay(50);
            form.duplicatedpanel.Location = new Point(97, form.DuplicatedCache.Location.Y);
            form.duplicatedpanel.Visible = true;
            form.DuplicatedFiles = await Ferramentas.FindDuplicateFiles(form);
            foreach (var categoria in form.DuplicatedFiles)
            {
                switch (categoria.Key)
                {
                    case "Documentos":
                        form.doccachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                    case "Imagens":
                        form.imgcachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                    case "Vídeos":
                        form.vidcachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                    case "Outros":
                        form.otherscachelbl.Text = categoria.Value.Values.Count.ToString();
                        break;
                }
                await Task.Delay(10);
            }

            form.scandoublesbtn.Visible = true;
            form.scandoublesbtn.Enabled = true;
            form.scandoublesbtn.Location = new Point(242, form.duplicatedtitle.Location.Y - 1);
            form.duplicatedpanel.Visible = false;
            form.DuplicatedCache.Text = form.DuplicatedFiles.Sum(x => x.Value.Count).ToString();
        }

        public static async Task UpdateForm(Form1 form)
        {
            await Task.Delay(1);
            long sumSOCache = form.SystemCache + form.UserCache + form.PrefetchCache + form.RecycleCache;
            long sumtotal = form.SystemCache + form.UserCache + form.PrefetchCache + form.RecycleCache + form.browserssize;

            (string tipo, double size) realSOCache = await Ferramentas.FormatFileSize(sumSOCache);
            (string tipo, double size) realTotalCache = await Ferramentas.FormatFileSize(sumtotal);

            (string tipo, double size) realSysCache = await Ferramentas.FormatFileSize(form.SystemCache);
            (string tipo, double size) realUserCache = await Ferramentas.FormatFileSize(form.UserCache);
            (string tipo, double size) realPrefetchCache = await Ferramentas.FormatFileSize(form.PrefetchCache);
            (string tipo, double size) realBrowsersCache = await Ferramentas.FormatFileSize(form.browserssize);

            if (realTotalCache.size > 0.1)
            {
                form.cleantitle.Text = $"{realTotalCache.size} {realTotalCache.tipo}";
                form.cleandescription.Text = $"A verificação encontrou {form.filescount} arquivos desnecessários em seu computador";
                form.cleandescription.Visible = true;
                form.cleanbtn.Visible = true;
                form.cleanbtn.Enabled = true;
                form.scanbtn.Visible = true;
                form.scanbtn.Enabled = true;
            }
            else
            {
                form.cleantitle.Text = $"LIMPO!";
                form.cleandescription.Text = "Não foram encontrados arquivos para limpar em seu computador";
                form.cleandescription.Visible = true;
                form.scanbtn.Visible = true;
                form.cleanbtn.Enabled = true;
                form.scanbtn.Enabled = true;
            }

            form.browsersloadpanel.Visible = false;

            form.WindowsCache.Text = $"{realSOCache.size} {realSOCache.tipo}";
            form.BrowsersCache.Text = $"{realBrowsersCache.size} {realBrowsersCache.tipo}";
            form.loadingbar.Visible = false;

            form.cleanbtn1.Visible = true;
            form.cleanbtn1.Enabled = true;
            form.cleanbtn2.Visible = true;
            form.cleanbtn2.Enabled = true;
            form.cleanbtn1.Location = new Point(232, form.syscachetitle.Location.Y - 1);
            form.cleanbtn2.Location = new Point(265, form.browserstitle.Location.Y - 1);

            if (!form.duplicatedpanel.Visible)
            {
                form.scandoublesbtn.Visible = true;
                form.scandoublesbtn.Enabled = true;
                form.scandoublesbtn.Location = new Point(242, form.duplicatedtitle.Location.Y - 1);
            }

            form.SystemCachelbl.Text = $"{realSysCache.size} {realSysCache.tipo}";
            form.UserCachelbl.Text = $"{realUserCache.size} {realUserCache.tipo}";
            form.PrefetchCachelbl.Text = $"{realPrefetchCache.size} {realPrefetchCache.tipo}";
            form.DuplicatedCache.Text = form.DuplicatedFiles.Sum(x => x.Value.Count).ToString();
        }
    }
}
