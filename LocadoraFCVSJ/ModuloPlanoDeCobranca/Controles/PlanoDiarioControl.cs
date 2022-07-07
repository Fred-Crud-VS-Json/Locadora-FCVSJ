using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca.Controles
{
    public partial class PlanoDiarioControl : UserControl
    {
        private readonly RegistrarNovoPlanoDeCobrancaForm _telaRegistro;

        public PlanoDiarioControl(RegistrarNovoPlanoDeCobrancaForm telaRegistro)
        {
            InitializeComponent();
            _telaRegistro = telaRegistro;
        }

        private void BtnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                PlanoDeCobranca planoDeCobranca = _telaRegistro.PlanoDeCobranca;

                planoDeCobranca.PlanoDiario_ValorDiario = Convert.ToDecimal(TxbValorDiario.Text);
                planoDeCobranca.PlanoDiario_ValorKm = Convert.ToDecimal(TxbValorKm.Text);

                ValidadorPlanoDiario validador = new();

                ValidationResult resultado = validador.Validate(planoDeCobranca);

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    _telaRegistro.DialogResult = DialogResult.None;
                }
                else
                {
                    MessageBox.Show("Cadastro de Plano Diário realizado com sucesso!", "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _telaRegistro.ChbxPlanoDiario.Checked = true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro ao registrar valores, verifique-os e tente novamente.", "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _telaRegistro.DialogResult = DialogResult.None;
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            TxbValorDiario.Clear();
            TxbValorKm.Clear();
        }
    }
}