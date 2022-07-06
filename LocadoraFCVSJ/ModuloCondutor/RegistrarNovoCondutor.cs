using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using System.Globalization;

namespace LocadoraFCVSJ.ModuloCondutor
{
    public partial class RegistrarNovoCondutor : KryptonForm
    {
        private Condutor condutor;
        public RegistrarNovoCondutor()
        {
            InitializeComponent();

            List<UF> estadosUF = Enum.GetValues(typeof(UF)).Cast<UF>().ToList();

            estadosUF.ForEach(x => CbxUf.Items.Add(x));
        }

        public Condutor Condutor
        {
            get { return condutor; }

            set
            {
                condutor = value;

                TxbNome.Text = condutor.Nome;
                MtxbCpf.Text = condutor.CPF;
                MtxbCep.Text = condutor.CEP;
                CbxUf.SelectedItem = condutor.UF;
                TxbCidade.Text = condutor.Cidade;
                TxbBairro.Text = condutor.Bairro;
                TxbNumero.Text = condutor.Numero;
                TxbRua.Text = condutor.Rua;
                TxbComplemento.Text = condutor.Complemento;
                MtxbTelefone.Text = condutor.Telefone;
                TxbEmail.Text = condutor.Email;
                TxbCnh.Text = condutor.CNH;
                MtbxValidadeCnh.Text = Convert.ToString(condutor.DataVencimento);

                if (!string.IsNullOrEmpty(condutor.CNPJ))
                {
                    ChbxPessoaJuridica.Checked = true;
                    MtxbCnpj.Enabled = true;
                    MtxbCnpj.Text = condutor.CNPJ;
                }
                else
                {
                    ChbxPessoaJuridica.Checked = false;
                    condutor.CNPJ = null;
                }
            }
        }
        public Func<Condutor, ValidationResult> SalvarRegistro { get; set; }

        private void ChbxPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbxPessoaJuridica.Checked == true)
            {
                MtxbCnpj.Enabled = true;
            }
            else
            {
                condutor.CNPJ = null;
                MtxbCnpj.Clear();
                MtxbCnpj.Enabled = false;
            }
        }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                condutor.Nome = TxbNome.Text;
                condutor.CPF = MtxbCpf.Text;
                condutor.CEP = MtxbCep.Text;

                if (CbxUf.SelectedItem != null)
                    condutor.UF = (UF)CbxUf.SelectedItem;

                condutor.Cidade = TxbCidade.Text;
                condutor.Bairro = TxbBairro.Text;
                condutor.Numero = TxbNumero.Text;
                condutor.Rua = TxbRua.Text;
                condutor.Complemento = TxbComplemento.Text;
                condutor.Telefone = MtxbTelefone.Text;
                condutor.Email = TxbEmail.Text;
                condutor.CNH = TxbCnh.Text;
                condutor.DataVencimento = DateTime.ParseExact(MtbxValidadeCnh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (ChbxPessoaJuridica.Checked == true)
                    condutor.CNPJ = MtxbCnpj.Text;
                else
                    condutor.CNPJ = null;

                ValidationResult resultado = SalvarRegistro(condutor);

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("O campo 'NUMERO' deve conter apenas números.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }
    }
}