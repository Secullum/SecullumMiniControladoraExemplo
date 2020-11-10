using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecullumMiniControladora
{
    public class Conexao
    {
        TcpClient client;
        bool parar;
        List<byte> bytesEnviar = new List<byte>();

        public delegate void GerarResposta(string message);
        public event GerarResposta GerarLog;

        public enum RelesEnum
        {
            RELE1 = 001,
            RELE2 = 002
        }

        public enum CodigoAcionamentoRele
        {
            ACIONAR = 101,
            ACIONARPORTEMPO = 100,
            DESLIGAR = 102
        }

        public enum CodigoMensagemPlacaSeculum
        {
            SUCESSO = 1,
            ERROOPERACAO = 2,
            TROCAESTADOSENSOR = 200
        }

        public void CriarConexao(string ip, int porta)
        {
            client = new TcpClient();
            client.Connect(ip, porta);
            parar = false;
            var task = new Task(() => Comunicacao());
            task.Start();
            GerarLog("Conectado");
        }

        public void FecharConexao()
        {
            if (client != null && client.Connected)
            {
                client.Close();
                parar = true;
                GerarLog("Desconectado");
            }
        }

        public void Enviar(RelesEnum rele, CodigoAcionamentoRele acaoRele)
        {
            var dados = MontarMensagemBase();
            dados.Add((Byte)acaoRele);
            dados.Add((Byte)rele);

            if (acaoRele == CodigoAcionamentoRele.ACIONARPORTEMPO)
            {

                dados.Add((Byte)(3000 / 256));
                dados.Add((Byte)(3000 % 256));
            }

            dados.Add((Byte)100);

            bytesEnviar = dados;
        }

        private void Comunicacao()
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    while (!parar)
                    {
                        if (stream.DataAvailable)
                        {
                            byte[] buffer = new byte[8192];
                            stream.Read(buffer);
                            ProcessarMensagemPlaca(buffer);
                        }

                        if (bytesEnviar.Count != 0)
                        {
                            stream.Write(bytesEnviar.ToArray());
                            bytesEnviar = new List<byte>();
                        }
                    }
                }
            }
            catch (Exception)
            {
                GerarLog("Erro na comunicação");
            }
        }

        private List<byte> MontarMensagemBase()
        {
            var dados = new List<byte> { 019, 099 };
            dados.Add((Byte)(dados.Count() / 256));
            dados.Add((Byte)(dados.Count() % 256));
            return dados;
        }

        private void ProcessarMensagemPlaca(byte[] dados)
        {
            var resultadoRequisicao = (int)dados[4];
            string mensagem;

            if (resultadoRequisicao == (int)CodigoMensagemPlacaSeculum.TROCAESTADOSENSOR)
            {
                mensagem = ObterMensagemEstadoSensores(dados);
            }
            else if (resultadoRequisicao == (int)CodigoMensagemPlacaSeculum.ERROOPERACAO)
            {
                mensagem = "Erro na operação";
            }
            else
            {
                mensagem = "Operação realizada com sucesso";
            }

            GerarLog(mensagem);
        }

        private string ObterMensagemEstadoSensores(byte[] dados)
        {
            string releUm = dados[6] == 1 ? "ligado" : "desligado";
            var resposta = $"O sensor {dados[5]} encontra-se {releUm}";

            return resposta;
        }

    }
}
