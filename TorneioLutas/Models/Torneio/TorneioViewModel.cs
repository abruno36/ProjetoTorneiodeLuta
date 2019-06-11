using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorneioLutas.Models.Torneio
{
    public class TorneioViewModel
    {
        public IList<LutadorModel> Lutadores { get; set; }
        public IList<LutadorModel> LutadoresSelecionados { get; set; }
        public LutadorASelecionadar LutadorASelecionadar { get; set; }
    }

    public class LutadorASelecionadar
    {
        public string[] LutadoresId { get; set; }
    }

}