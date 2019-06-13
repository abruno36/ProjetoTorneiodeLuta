using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TorneioLutas.Models.Torneio
{
    public class LutadorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> ArtesMarciais { get; set; }
        public double Lutas { get; set; }
        public int Derrotas { get; set; }
        public int Vitorias { get; set; }
        public double PercentualVitorias
        {
            get { return (int)(Vitorias / (double)Lutas * 100); }

        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LutadorId { get; set; }

        public bool Selecionado { get; set; }

        public IEnumerable<LutadorModel> Lutadores { get; set; }
    }

}