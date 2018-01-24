namespace CRG08.VO
{
    public class ProdutoCiclo
    {
        public int idProdutoCiclo { set; get; }
        public Produto produto { set; get; }
        public string volume { set; get; }
        public Unidade unidade { set; get; }
        public EmpresaCiclo empresa { set; get; }
        public Ciclos ciclo { set; get; }
        public string Descricao { get; set; }
    }
}
