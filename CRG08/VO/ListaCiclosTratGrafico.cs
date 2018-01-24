using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRG08.VO
{
    public class ListaCiclosTratGrafico
    {
        public int idLeiturasTrat { get; set; }
        public int NL { get; set; }
        public int NLT { get; set; }
        public string horario { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double T3 { get; set; }
        public double T4 { get; set; }
        public bool demarca_tratamento = false;
    }
}
