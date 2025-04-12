using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCache
{
    internal class config
    {
        public class Definicoes
        {
            public bool StartsWithSystem = false;
            public bool StartsMinimized = false;
            public bool AutoClear = false;
            public string AutoScan = "Diáriamente";
            public DateTime LastScan = DateTime.Now;
        }

        public static Definicoes Configuracoes = new Definicoes();
    }
}
