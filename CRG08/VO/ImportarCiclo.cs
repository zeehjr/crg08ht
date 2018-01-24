using System.Collections.Generic;

namespace CRG08.VO
{
    public class ImportarCiclo
    {
        public Ciclos ciclo { get; set; }
        public List<LeiturasCiclo> leiturasCiclo { get; set; }
        public List<LeiturasTrat> leiturasTratamento { get; set; }
        public List<ProdutoCiclo> produtosCiclo { set; get; } 
    }
}
