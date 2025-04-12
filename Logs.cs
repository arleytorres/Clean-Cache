using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace CleanCache
{
    internal class Logs
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static string localdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");

        public static async Task Register(string log)
        {
            string localpath = Path.Combine(localdata, "Clean Cash");
            Directory.CreateDirectory(localpath);

            string logspath = Path.Combine(localpath, "Logs");
            Directory.CreateDirectory(logspath);

            var actualdate = DateTime.Now;
            string logfile = Path.Combine(logspath, $"log-{actualdate:dd-MM-yyyy}.txt");

            await _semaphore.WaitAsync();
            try
            {
                using (var wr = File.AppendText(logfile))
                {
                    await wr.WriteLineAsync($"[{actualdate.ToShortTimeString()}] {log}");
                    await wr.FlushAsync();
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
