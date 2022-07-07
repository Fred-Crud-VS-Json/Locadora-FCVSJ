using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.ModuloPlanoDeCobranca.Controles;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca
{
    public partial class RegistrarNovoPlanoDeCobrancaForm : KryptonForm
    {
        private PlanoDeCobranca planoDeCobranca;

        private readonly PlanoDiarioControl planoDiarioControl;
        private readonly PlanoLivreControl planoLivreControl;
        private readonly PlanoControladoControl planoControladoControl;

        public RegistrarNovoPlanoDeCobrancaForm()
        {
            InitializeComponent();

            planoDiarioControl = new(this);
            planoLivreControl = new();
            planoControladoControl = new();
        }

        public PlanoDeCobranca PlanoDeCobranca
        {
            get { return planoDeCobranca; }

            set
            {
                planoDeCobranca = value;

                CbxGrupo.SelectedItem = planoDeCobranca.Grupo;

                planoDiarioControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoDiario_ValorDiario.ToString("F2");
                planoDiarioControl.TxbValorKm.Text = PlanoDeCobranca.PlanoDiario_ValorKm.ToString("F2");
               
                planoLivreControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoLivre_ValorDiario.ToString("F2");

                planoControladoControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoControlado_ValorDiario.ToString("F2");
                planoControladoControl.TxbValorKm.Text = PlanoDeCobranca.PlanoControlado_ValorKm.ToString("F2");
                planoControladoControl.TxbLimiteKm.Text = PlanoDeCobranca.PlanoControlado_LimiteKm.ToString();
            }
        }

        public Func<PlanoDeCobranca, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            PlanoDeCobranca.PlanoDiario_ValorDiario = Convert.ToDecimal(planoDiarioControl.TxbValorDiario.Text);
            PlanoDeCobranca.PlanoDiario_ValorKm = Convert.ToDecimal(planoDiarioControl.TxbValorKm.Text);

            PlanoDeCobranca.PlanoLivre_ValorDiario = Convert.ToDecimal(planoLivreControl.TxbValorDiario.Text);

            PlanoDeCobranca.PlanoControlado_ValorDiario = Convert.ToDecimal(planoControladoControl.TxbValorDiario.Text);
            PlanoDeCobranca.PlanoControlado_ValorKm = Convert.ToDecimal(planoControladoControl.TxbValorKm.Text);
            PlanoDeCobranca.PlanoControlado_LimiteKm = Convert.ToInt32(planoControladoControl.TxbLimiteKm.Text);

            ValidationResult resultado = SalvarRegistro(planoDeCobranca);

            if (resultado.IsValid == false)
            {
                MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;
            }
        }

        private void BtnDiario_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnLivre, BtnControlado, BtnDiario);
            ConfigurarPanel(planoDiarioControl);
        }

        private void BtnLivre_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnDiario, BtnControlado, BtnLivre);
            ConfigurarPanel(planoLivreControl);
        }

        private void BtnControlado_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnLivre, BtnDiario, BtnControlado);
            ConfigurarPanel(planoControladoControl);
        }

        private void ConfigurarBackgroundBotoes(KryptonButton btn1, KryptonButton btn2, KryptonButton btn3)
        {
            btn1.StateCommon.Back.Color1 = Color.FromArgb(0, 152, 74);
            btn1.StateCommon.Back.Color2 = Color.FromArgb(0, 152, 74);
            btn1.StateCommon.Border.Color1 = Color.FromArgb(0, 152, 74);
            btn1.StateCommon.Border.Color2 = Color.FromArgb(0, 152, 74);

            btn2.StateCommon.Back.Color1 = Color.FromArgb(0, 152, 74);
            btn2.StateCommon.Back.Color2 = Color.FromArgb(0, 152, 74);
            btn2.StateCommon.Border.Color1 = Color.FromArgb(0, 152, 74);
            btn2.StateCommon.Border.Color2 = Color.FromArgb(0, 152, 74);

            btn3.StateCommon.Back.Color1 = Color.FromArgb(17, 92, 54);
            btn3.StateCommon.Back.Color2 = Color.FromArgb(17, 92, 54);
            btn3.StateCommon.Border.Color1 = Color.FromArgb(17, 92, 54);
            btn3.StateCommon.Border.Color2 = Color.FromArgb(17, 92, 54);
        }

        private void ConfigurarPanel(UserControl controle)
        {
            PnlConteudo.Controls.Clear();
            PnlConteudo.Controls.Add(controle);

            controle.Focus();
        }
    }
}