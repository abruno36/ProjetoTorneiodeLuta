using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestTorneioLutas
{
    public class Lutador
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> ArtesMarciais { get; set; }
        public int Lutas { get; set; }
        public int Derrotas { get; set; }
        public int Vitorias { get; set; }
        public int PercentualVitorias
        {
            get { return (int)(Vitorias / (double)Lutas * 100); }

        }
    }
}
