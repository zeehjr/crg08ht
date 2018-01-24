using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRG08.VO
{
    public class ItemListaSecagem
    {
        public int Id { get; set; }
        public int NumeroLeituras { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public byte[] Endereco { get; set; }

        public DateTime Data => new DateTime(Ano, Mes, Dia, Hora, Minuto, Segundo);
    }
}
