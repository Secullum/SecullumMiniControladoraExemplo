using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SecullumMiniControladora.Conexao;

namespace SecullumMiniControladora
{
    public partial class frmExemplo : Form
    {
        Conexao conexao;

        public frmExemplo()
        {
            InitializeComponent();          
        }

        private void frmExemplo_Load(object sender, EventArgs e)
        {
            conexao = new Conexao();
            conexao.GerarLog += GerarLog;
            comboReles.DataSource = Enum.GetValues(typeof(Conexao.RelesEnum));
        }

        private void btnAcionarRele_Click(object sender, EventArgs e)
        {
            var releSelecionado = (Conexao.RelesEnum)comboReles.SelectedItem;
            conexao.Enviar(releSelecionado, Conexao.CodigoAcionamentoRele.Acionar);
        }

        private void btnDesligar_Click(object sender, EventArgs e)
        {
            var releSelecionado = (Conexao.RelesEnum)comboReles.SelectedItem;
            conexao.Enviar(releSelecionado, Conexao.CodigoAcionamentoRele.Desligar);
        }

        private void btnAcionarPorTempo_Click(object sender, EventArgs e)
        {
            var releSelecionado = (Conexao.RelesEnum)comboReles.SelectedItem;
            conexao.Enviar(releSelecionado, Conexao.CodigoAcionamentoRele.AcionarPorTempo);
        }

        private void txtPorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.FecharConexao();
                var ip = this.textIP.Text;
                var porta = Convert.ToInt32(this.txtPorta.Text);
                conexao.CriarConexao(ip, porta);
            }
            catch (Exception)
            {
                SetarMensagem("Erro ao se conectar, verifique o IP e porta informados!");
            }         
        }

        private void GerarLog(string mensagem)
        {
            this.Invoke(new Action(() => SetarMensagem(mensagem)));
        }

        private void SetarMensagem(string message)
        {
            rtxLog.AppendText(message + Environment.NewLine);
            rtxLog.ScrollToCaret();
        }
    }
}
