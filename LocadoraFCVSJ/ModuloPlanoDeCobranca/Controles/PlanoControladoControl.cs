using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca.Controles
{
    public partial class PlanoControladoControl : UserControl
    {
        private readonly RegistrarNovoPlanoDeCobrancaForm _telaRegistro;

        public PlanoControladoControl(RegistrarNovoPlanoDeCobrancaForm telaRegistro)
        {
            InitializeComponent();
            _telaRegistro = telaRegistro;
        }

        private void BtnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                PlanoDeCobranca planoDeCobranca = _telaRegistro.PlanoDeCobranca;

                planoDeCobranca.PlanoControlado_ValorDiario = Convert.ToDecimal(TxbValorDiario.Text);
                planoDeCobranca.PlanoControlado_ValorKm = Convert.ToDecimal(TxbValorKm.Text);
                planoDeCobranca.PlanoControlado_LimiteKm = Convert.ToInt32(TxbLimiteKm.Text);

                ValidadorPlanoControlado validador = new();

                ValidationResult resultado = validador.Validate(planoDeCobranca);

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    _telaRegistro.DialogResult = DialogResult.None;
                }
                else
                {
                    MessageBox.Show("Cadastro de Plano Controlado realizado com sucesso!", "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _telaRegistro.ChbxPlanoControlado.Checked = true;
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
            TxbLimiteKm.Clear();
            _telaRegistro.ChbxPlanoControlado.Checked = false;
        }
    }
}