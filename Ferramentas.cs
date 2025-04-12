using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanCache
{
    internal class Ferramentas
    {
        public static async Task CheckDisks(Form1 form)
        {
            var disks = DriveInfo.GetDrives();

            foreach (DriveInfo info in disks)
            {
                if (info.IsReady)
                    form.Discos.Add(info);
                await Task.Delay(10);
            }
        }

        public static async Task CheckCachesSystem(Form1 form)
        {
            try
            {
                await Logs.Register("Verificando caches de Sistema");
                string tempuser = Environment.GetEnvironmentVariable("TEMP");
                string tempsystem = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp");
                string prefetch = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch");

                form.SystemCache = await GetDirectorySize(tempsystem);
                form.UserCache = await GetDirectorySize(tempuser);
                form.PrefetchCache =await GetDirectorySize(prefetch);

                form.filescount += await GetDirectoryFiles(tempsystem);
                form.filescount += await GetDirectoryFiles(tempuser);
                form.filescount += await GetDirectoryFiles(prefetch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static async Task CheckCachesBrowsers(Form1 form)
        {
            form.browsersloadpanel.Visible = true;
            string appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var dirinfo = new DirectoryInfo(appDataLocal);

            foreach (var browser in dirinfo.GetDirectories().ToList())
            {
                if (browser.Name.ToLower().Contains("opera software"))
                {
                    var info = browser.GetDirectories().Where(x => x.Name.ToLower() == "opera stable").ToList();
                    if (info.Count > 0)
                    {
                        form.Browsers.Add(new DirectoryInfo(info.FirstOrDefault().FullName));
                    }
                    info = browser.GetDirectories().Where(x => x.Name.ToLower() == "opera gx stable").ToList();
                    if (info.Count > 0)
                    {
                        form.Browsers.Add(new DirectoryInfo(info.FirstOrDefault().FullName));
                    }
                }
                else if (browser.Name.ToLower().Equals("microsoft"))
                {
                    var info = browser.GetDirectories().Where(x => x.Name == "Edge").ToList();

                    if (info.Count > 0)
                        form.Browsers.Add(new DirectoryInfo(info.FirstOrDefault().FullName));

                    info = browser.GetDirectories().Where(x => x.Name == "Internet Explorer").ToList();
                    if (info.Count > 0)
                        form.Browsers.Add(new DirectoryInfo(info.FirstOrDefault().FullName));
                }
                else if (browser.Name.ToLower().Contains("bravesoftware"))
                    form.Browsers.Add(browser);
                else if (browser.Name.ToLower().Contains("duckduckgo"))
                    form.Browsers.Add(browser);
                else if (browser.Name.ToLower().Contains("mozilla"))
                    form.Browsers.Add(browser);
                else if (browser.Name.ToLower().Equals("google") && browser.GetDirectories().Where(x => x.Name.Equals("Chrome")).ToList().Count > 0)
                    form.Browsers.Add(browser);
                await Task.Delay(20);
            }
        }

        public static async Task<string> GetBrowserCachePath(DirectoryInfo dirinfo)
        {
            await Task.Delay(1);
            switch (dirinfo.Name.ToLower())
            {
                case "opera stable":
                case "opera gx stable":
                    return Path.Combine(dirinfo.FullName, "Cache\\Cache_Data");
                case "edge":
                    return Path.Combine(dirinfo.FullName, "User Data\\Default\\Cache\\Cache_Data");
                case "internet explorer":
                    return Path.Combine(dirinfo.FullName, "CacheStorage");
                case "mozilla":
                    return Path.Combine(dirinfo.FullName, "Firefox\\Profiles\\Default\\cache");
                case "google":
                    return Path.Combine(dirinfo.FullName, "Chrome\\User Data\\Default\\Cache");
                case "bravesoftware":
                    return Path.Combine(dirinfo.FullName, "Brave-Browser\\User Data\\Default\\Cache");
                case "duckduckgo":
                    return Path.Combine(dirinfo.FullName, "Cache");
            }
            return null;
        }

        public static async Task<int> GetDirectoryFiles(string path)
        {
            try
            {
                await Task.Delay(1);

                int count = Directory.EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly).ToList().Count;

                foreach (var dir in Directory.GetDirectories(path))
                {
                    try
                    {
                        count += Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories).ToList().Count;
                    }
                    catch { }
                    await Task.Delay(20);
                }

                return count;
            }
            catch (UnauthorizedAccessException ex)
            {
                return -1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static async Task<long> GetDirectorySize(string path)
        {
            try
            {
                long size = Directory.EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly).Sum(x => new FileInfo(x).Length);

                foreach (var dir in Directory.GetDirectories(path))
                {
                    try
                    {
                        size += Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories).Sum(x => new FileInfo(x).Length);
                    }
                    catch { }
                    await Task.Delay(20);
                }
                
                return size;
            }
            catch (UnauthorizedAccessException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static async Task<Dictionary<string, Dictionary<string, List<string>>>> FindDuplicateFiles(Form1 form)
        {
            var directories = new List<string>
            {
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            };

            var CategorizedFiles = new Dictionary<string, Dictionary<string, List<string>>>()
            {
                { "Documentos", new Dictionary<string, List<string>>() },
                { "Imagens", new Dictionary<string, List<string>>() },
                { "Vídeos", new Dictionary<string, List<string>>() },
                { "Outros", new Dictionary<string, List<string>>() },
            };
            Dictionary<string, int> countfiles = new Dictionary<string, int>();

            foreach (var dir in directories)
                try
                {
                    if (Directory.Exists(dir))
                    {
                        countfiles.Add(dir, Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly).Where(x => !x.Contains(".exe") && !x.Contains(".dll")).ToList().Count);

                        foreach (var _dir in Directory.GetDirectories(dir))
                            try
                            {
                                if (Directory.Exists(_dir))
                                {
                                    countfiles[dir] += Directory.GetFiles(_dir, "*", SearchOption.AllDirectories).Where(x => !x.Contains(".exe") && !x.Contains(".dll")).ToList().Count;
                                }
                                await Task.Delay(75);
                            }
                            catch { }
                    }
                }
                catch { }

            await Task.Delay(75);

            int actualstep = 0;
            foreach (var dir in directories)
                try
                {
                    if (!Directory.Exists(dir)) continue;
                    actualstep++;
                    form.searchlbl.Text = $"Buscando ({actualstep} de {directories.Count})";
                    int actualfile = 0;

                    foreach (var file in Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly).Where(x => !x.Contains(".exe") && !x.Contains(".dll")))
                    {
                        try
                        {
                            string category = await GetFileCategory(file);
                            string hash = await ComputeFileHash(file);

                            if (!CategorizedFiles.ContainsKey(category))
                                CategorizedFiles.Add(category, new Dictionary<string, List<string>>());

                            if (!CategorizedFiles[category].ContainsKey(hash))
                                CategorizedFiles[category].Add(hash, new List<string>());

                            CategorizedFiles[category][hash].Add(file);
                        }
                        catch { }
                        actualfile++;
                        form.duplicatedprogress.Value = (int)(((float)actualfile / countfiles[dir]) * 100);
                        await Task.Delay(75);
                    }

                    foreach (var _dir in Directory.GetDirectories(dir))
                        try
                        {
                            foreach (var file in Directory.GetFiles(_dir, "*", SearchOption.AllDirectories).Where(x => !x.Contains(".exe") && !x.Contains(".dll")))
                            {
                                try
                                {
                                    string category = await GetFileCategory(file);
                                    string hash = await ComputeFileHash(file);

                                    if (!CategorizedFiles.ContainsKey(category))
                                        CategorizedFiles.Add(category, new Dictionary<string, List<string>>());

                                    if (!CategorizedFiles[category].ContainsKey(hash))
                                        CategorizedFiles[category].Add(hash, new List<string>());

                                    CategorizedFiles[category][hash].Add(file);
                                }
                                catch { }
                                actualfile++;
                                form.duplicatedprogress.Value = (int)(((float)actualfile / countfiles[dir]) * 100);
                                await Task.Delay(75);
                            }
                        }
                        catch { }
                }
                catch { }

            return CategorizedFiles
                .ToDictionary(cat => cat.Key, cat => cat.Value.Where(x => x.Value.Count > 1)
                .ToDictionary(x => x.Key, x => x.Value));
        }

        private static async Task<string> GetFileCategory(string filepath)
        {
            await Task.Delay(1);
            string extension = Path.GetExtension(filepath).ToLower();

            string[] photoExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
            string[] videoExtensions = { ".mp4", ".avi", ".mov", ".wmv", ".mkv" };
            string[] documentExtensions = { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".txt" };

            if (photoExtensions.Contains(extension)) return "Imagens";
            if (videoExtensions.Contains(extension)) return "Vídeos";
            if (documentExtensions.Contains(extension)) return "Documentos";

            return "Outros";
        }

        static async Task<string> ComputeFileHash(string filePath)
        {
            await Task.Delay(1);
            using (var sha256 = SHA256.Create())
            using (var stream = System.IO.File.OpenRead(filePath))
            {
                byte[] hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static async Task WindowsLoginStart(bool add = true)
        {
            await Task.Delay(1);
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            if (add)
            {
                string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string shortcutPath = Path.Combine(startupFolderPath, "Clean Cache.lnk");
                var shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = appPath;
                shortcut.Save();
            }
            else
            {
                string shortcutName = "Clean Cache.lnk";
                string shortcutPath = Path.Combine(startupFolderPath, shortcutName);

                if (System.IO.File.Exists(shortcutPath))
                    System.IO.File.Delete(shortcutPath);
            }
        }

        public static async Task<(string, double)> FormatFileSize(long bytes)
        {
            await Task.Delay(1);
            const long KB = 1024;
            const long MB = KB * 1024;
            const long GB = MB * 1024;

            if (bytes >= GB)
                return ("GB", Math.Round(bytes / (double)GB, 2));
            if (bytes >= MB)
                return ("MB", Math.Round(bytes / (double)MB, 2));
            if (bytes >= KB)
                return ("KB", Math.Round(bytes / (double)KB, 2));

            return ("B", bytes);
        }


        public static async Task<string> API(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    try
                    {
                        using (HttpResponseMessage responseMessage = await client.GetAsync(url, cts.Token))
                        {
                            using (HttpContent content = responseMessage.Content)
                            {
                                responseMessage.EnsureSuccessStatusCode();
                                return await content.ReadAsStringAsync();
                            }
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        return "Time out exceded";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
