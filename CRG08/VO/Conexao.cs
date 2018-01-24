using System.IO.Ports;

namespace CRG08.VO
{
    public class Conexao
    {
        public static bool done { get; set; }
        public static bool fecharConexao { get; set; }
        public static bool primeiraVez;
        public static byte[] buffer;
        public static byte[] bufferMedidor;
        public static byte[] bufferAuxiliar;
        public static byte[] configuracoesSetup;
        public static byte[] programaDeSecagem;
        public static byte[] vetorEstufa { get; set; }
        public static int[] posicaoAtualizadas { get; set; }
        public static int numeroDispositivo { set; get; }
        public static SerialPort srpComm { get; set; }
    }
}
