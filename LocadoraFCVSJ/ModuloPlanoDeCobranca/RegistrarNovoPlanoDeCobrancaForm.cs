using Krypton.Toolkit;
using LocadoraFCVSJ.ModuloPlanoDeCobranca.Controles;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca
{
    public partial class RegistrarNovoPlanoDeCobrancaForm : KryptonForm
    {
        public RegistrarNovoPlanoDeCobrancaForm()
        {
            InitializeComponent();
        }

        private void BtnDiario_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnLivre, BtnControlado, BtnDiario);
            ConfigurarPanel(new PlanoDiarioControl());
        }

        private void BtnLivre_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnDiario, BtnControlado, BtnLivre);
            ConfigurarPanel(new PlanoLivreControl());
        }

        private void BtnControlado_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnLivre, BtnDiario, BtnControlado);
            ConfigurarPanel(new PlanoControladoControl());
        }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {

        }

        private void ConfigurarBackgroundBotoes(KryptonButton btn1, KryptonButton btn2, KryptonButton btn3)
        {
            btn1.StateCommon.Back.Color1 = Color.FromArgb(0, 152, 74);
            btn1.StateCommon.Back.Color2 = Color.FromArgb(0, 152, 74);

            btn2.StateCommon.Back.Color1 = Color.FromArgb(0, 152, 74);
            btn2.StateCommon.Back.Color2 = Color.FromArgb(0, 152, 74);

            btn3.StateCommon.Back.Color1 = Color.FromArgb(17, 92, 54);
            btn3.StateCommon.Back.Color2 = Color.FromArgb(17, 92, 54);
        }

        private void ConfigurarPanel(UserControl controle)
        {
            PnlConteudo.Controls.Clear();
            PnlConteudo.Controls.Add(controle);

            controle.Focus();
        }
    }
}