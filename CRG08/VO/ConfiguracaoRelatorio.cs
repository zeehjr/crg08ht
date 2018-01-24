using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRG08.VO
{
    public class ConfiguracaoRelatorio
    {
        public ConfiguracaoRelatorio(int lAntes, int lTrat, int lDepois)
        {
            LeiturasAntes = lAntes;
            LeiturasTrat = lTrat;
            LeiturasDepois = lDepois;
        }
        public int LeiturasAntes { get; set; }
        public int LeiturasTrat { get; set; }

        public int LeiturasDepois { get; set; }
    }
}
