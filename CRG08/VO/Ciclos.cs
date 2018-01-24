using System;
using System.Collections.Generic;

namespace CRG08.VO
{
    public class Ciclos
    {
        public int id { set; get; }
        public int crg { set; get; }
        public int nTrat { set; get; }
        public int nl { set; get; }
        public int baseTempo { set; get; }
        public int nlt { set; get; }
        public DateTime dataColeta { set; get; }
        public string descricao { set; get; }
        public DateTime dataInicio { set; get; }
        public DateTime dataFim { set; get; }
        public int NLIniTrat { set; get; }
        public DateTime dataIniTrat { set; get; }
        public float temperaturaControle { set; get; }
        public float temperaturaTrat { set; get; }
        public int tempoTrat { set; get; }
        public string responsavel { set; get; }
        public string operador { set; get; }
        public int situacao { set; get; }
        public string numSerie { set; get; }
        public string versaoEquip { set; get; }
        public int histerese { set; get; }
        public int tControl { set; get; }
        public int nlAntesTrat { set; get; }
        public int nlPostTrat { set; get; }
        public int sensor { set; get; }
        public string CA { set; get; }
        public int tipoCRG { set; get; }
        public bool IsMetrosCubicos { get; set; }
        public bool IsVolumeMaiorQue60 { get; set; }
        public string VolumeFixo { get; set; }
        public bool PossuiProdutoFixo { get; set; }
    }
}
