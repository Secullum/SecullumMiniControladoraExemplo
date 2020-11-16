using System;
using System.Windows.Forms;

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
            PopularCombo();
        }

        private void AcionarRele_Click(object sender, EventArgs e)
        {
            conexao.Enviar(ObterEnumReleSelecionado(), Conexao.CodigoAcionamentoRele.Acionar);
        }

        private void DesligarRele_Click(object sender, EventArgs e)
        {
            conexao.Enviar(ObterEnumReleSelecionado(), Conexao.CodigoAcionamentoRele.Desligar);
        }

        private void AcionarRelePorTempo_Click(object sender, EventArgs e)
        {
            if (txtTempo.Text != "")
            {
                var tempo = Convert.ToInt32(txtTempo.Text);
                conexao.Enviar(ObterEnumReleSelecionado(), Conexao.CodigoAcionamentoRele.AcionarPorTempo, tempo);
            }
        }

        private void ValidacaoApenasNumero_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Conectar_Click(object sender, EventArgs e)
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
                SetarMensagem("Erro ao conectar, verifique o IP e Porta informados!");
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            conexao.FecharConexao();
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

        private Conexao.RelesEnum ObterEnumReleSelecionado()
        {
            var propriedade = comboReles.SelectedItem.GetType().GetProperty("Value");
            var valorSelecionado = propriedade.GetValue(comboReles.SelectedItem, null).ToString();
            Enum.TryParse(valorSelecionado, out Conexao.RelesEnum releSelecionado);

            return releSelecionado;
        }

        private void PopularCombo()
        {
            comboReles.Items.Add(new { Text = "Relé 1", Value = Conexao.RelesEnum.ReleUm });
            comboReles.Items.Add(new { Text = "Relé 2", Value = Conexao.RelesEnum.ReleDois });
            comboReles.DisplayMember = "Text";
            comboReles.ValueMember = "Value";
            comboReles.SelectedIndex = 0;
        }
    }
}