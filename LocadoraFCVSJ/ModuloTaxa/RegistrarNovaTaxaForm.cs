using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using System.Globalization;

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
        public Func<Taxa, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                taxa.Nome = TxbNome.Text;
                taxa.Valor = Convert.ToDecimal(TxbValor.Text);
                taxa.TipoCalculoTaxa = (TipoCalculoTaxa)CbxTipoCalculoTaxa.SelectedItem;

                ValidationResult resultado = SalvarRegistro(taxa);

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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