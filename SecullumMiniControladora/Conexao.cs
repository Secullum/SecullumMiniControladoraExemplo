using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SecullumMiniControladora
{
    public class Conexao
    {
        TcpClient m_client;
        bool m_parar;
        List<byte> m_bytesEnviar = new List<byte>();

        public delegate void GerarResposta(string message);
        public event GerarResposta GerarLog;

        public enum RelesEnum
        {
            ReleUm = 001,
            ReleDois = 002
        }

        public enum CodigoAcionamentoRele
        {
            Acionar = 101,
            AcionarPorTempo = 100,
            Desligar = 102
        }

        public enum CodigoMensagemPlacaSeculum
        {
            Sucesso = 1,
            ErroOperacao = 2,
            TrocaEstadoSensor = 200
        }

        public void CriarConexao(string ip, int porta)
        {
            m_client = new TcpClient();
            m_client.Connect(ip, porta);
            m_parar = false;
            var task = new Task(() => MonitorarComunicacao());
            task.Start();
            GerarLog("Conectado");
        }

        public void FecharConexao()
        {
            if (m_client != null && m_client.Connected)
            {
                m_client.Close();
                m_parar = true;
                GerarLog("Desconectado");
            }
        }

        public void Enviar(RelesEnum rele, CodigoAcionamentoRele acaoRele, int tempo = 0)
        {
            var dados = MontarMensagemBase();
            dados.Add((Byte)acaoRele);
            dados.Add((Byte)rele);

            if (acaoRele == CodigoAcionamentoRele.AcionarPorTempo)
            {
                var tempoLigado = tempo * 1000;
                dados.Add((Byte)(tempoLigado / 256));
                dados.Add((Byte)(tempoLigado % 256));
            }

            dados.Add((Byte)100);

            m_bytesEnviar = dados;
        }

        private void MonitorarComunicacao()
        {
            try
            {
                using (NetworkStream stream = m_client.GetStream())
                {
                    while (!m_parar)
                    {
                        if (stream.DataAvailable)
                        {
                            byte[] buffer = new byte[8192];
                            stream.Read(buffer);
                            ProcessarMensagemPlaca(buffer);
                        }

                        if (m_bytesEnviar.Count != 0)
                        {
                            stream.Write(m_bytesEnviar.ToArray());
                            m_bytesEnviar = new List<byte>();
                        }
                    }
                }
            }
            catch (Exception)
            {
                FecharConexao();
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

            if (resultadoRequisicao == (int)CodigoMensagemPlacaSeculum.TrocaEstadoSensor)
            {
                mensagem = ObterMensagemEstadoSensores(dados);
            }
            else if (resultadoRequisicao == (int)CodigoMensagemPlacaSeculum.ErroOperacao)
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
            string estadoSensor = dados[6] == 1 ? "ligado" : "desligado";
            var resposta = $"Sensor {dados[5]} {estadoSensor}";

            return resposta;
        }
    }
}
