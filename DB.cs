using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CleanCache
{
    internal class DB
    {
        private static string localdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");

        public static void WriteData()
        {
            string localpath = Path.Combine(localdata, "Clean Cash");
            if (!Directory.Exists(localpath))
                Directory.CreateDirectory(localpath);

            if (!File.Exists(Path.Combine(localpath, "Configs.json")))
                File.Create(Path.Combine(localpath, "Configs.json")).Dispose();

            string dados = JsonConvert.SerializeObject(config.Configuracoes);

            var wr = new StreamWriter(Path.Combine(localpath, "Configs.json"));
            wr.WriteLine(dados);
            wr.Dispose();
        }

        public static async Task ReadData()
        {
            string localpath = Path.Combine(localdata, "Clean Cash");
            if (!Directory.Exists(localpath))
                return;

            string filepath = Path.Combine(localpath, "Configs.json");

            if (!File.Exists(filepath))
                return;

            string json = null;
            using (var rd = new StreamReader(filepath))
                json = await rd.ReadToEndAsync();

            try { if (json != null) config.Configuracoes = JsonConvert.DeserializeObject<config.Definicoes>(json); } catch { }
        }
    }
}
