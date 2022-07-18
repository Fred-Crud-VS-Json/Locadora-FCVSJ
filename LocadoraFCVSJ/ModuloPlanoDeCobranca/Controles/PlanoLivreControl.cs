using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca.Controles
{
    public partial class PlanoLivreControl : UserControl
    {
        private readonly RegistrarPlanoDeCobrancaForm _telaRegistro;

        public PlanoLivreControl(RegistrarPlanoDeCobrancaForm telaRegistro)
        {
            InitializeComponent();
            _telaRegistro = telaRegistro;
        }

        private void BtnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                PlanoDeCobranca planoDeCobranca = _telaRegistro.PlanoDeCobranca;

                planoDeCobranca.PlanoLivre_ValorDiario = Convert.ToDecimal(TxbValorDiario.Text);

                ValidadorPlanoLivre validador = new();

                ValidationResult resultado = validador.Validate(planoDeCobranca);

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    _telaRegistro.DialogResult = DialogResult.None;
                }
                else
                {
                    MessageBox.Show("Cadastro de Plano Livre realizado com sucesso!", "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }
}