using FluentResults;
using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using System.Globalization;
using System.Text;

namespace LocadoraFCVSJ.ModuloTaxa
{
    public partial class RegistrarNovaTaxaForm : KryptonForm
    {
        private Taxa taxa;

        public RegistrarNovaTaxaForm()
        {
            InitializeComponent();

            List<TipoCalculoTaxa> tiposDeCalculoDeTaxa = Enum.GetValues(typeof(TipoCalculoTaxa)).Cast<TipoCalculoTaxa>().ToList();

            tiposDeCalculoDeTaxa.ForEach(x => CbxTipoCalculoTaxa.Items.Add(x));
        }

        public Taxa Taxa
        {
            get { return taxa; }

            set
            {
                taxa = value;

                TxbNome.Text = taxa.Nome;
                TxbValor.Text = taxa.Valor.ToString("F2");
                CbxTipoCalculoTaxa.SelectedItem = taxa.TipoCalculoTaxa;
            }
        }

        public Func<Taxa, Result<Taxa>> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                taxa.Nome = TxbNome.Text;
                taxa.Valor = Convert.ToDecimal(TxbValor.Text);

                if (CbxTipoCalculoTaxa.SelectedItem != null)
                    taxa.TipoCalculoTaxa = (TipoCalculoTaxa)CbxTipoCalculoTaxa.SelectedItem;

                Result<Taxa> resultado = SalvarRegistro(taxa);

                if (resultado.IsFailed)
                {
                    StringBuilder erros = new();

                    foreach (Error erro in resultado.Errors)
                        erros.AppendLine(erro.Message);

                    MessageBox.Show(erros.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("O campo 'Valor' deve conter apenas números.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
                TxbValor.Clear();
            }
        }
    }
}