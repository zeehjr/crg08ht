namespace CRG08.VO
{
    public class Empresa
    {
        public int id { set; get; }
        public string Nome { set; get; }
        public string Endereco { set; get; }
        public string Cep { set; get; }
        public string Cidade { set; get; }
        public int UF { set; get; }
        public string Fone { set; get; }
        public string Fax { set; get; }
        public string CNPJ { set; get; }
        public string IE { set; get; }
        public string NCredenciamento { set; get; }
        public byte[] Logo { set; get; }
    }
}
