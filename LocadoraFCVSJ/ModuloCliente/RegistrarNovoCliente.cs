using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;

namespace LocadoraFCVSJ.ModuloCliente
{
    public partial class RegistrarNovoCliente : KryptonForm
    {
        private Cliente cliente;
        public RegistrarNovoCliente()
        {
            InitializeComponent();

            List<UF> estadosUF = Enum.GetValues(typeof(UF)).Cast<UF>().ToList();

            estadosUF.ForEach(x => CbxUf.Items.Add(x));
        }

        public Cliente Cliente
        {
            get { return cliente; }

            set
            {
                cliente = value;

                TxbNome.Text = cliente.Nome;
                MtxbCpf.Text = cliente.CPF;
                MtxbCep.Text = cliente.CEP;
                CbxUf.SelectedItem = cliente.UF;
                TxbCidade.Text = cliente.Cidade;
                TxbBairro.Text = cliente.Bairro;
                TxbNumero.Text = cliente.Numero;
                TxbRua.Text = cliente.Rua;
                TxbComplemento.Text = cliente.Complemento;
                MtxbTelefone.Text = cliente.Telefone;
                TxbEmail.Text = cliente.Email;
                TxbCnh.Text = cliente.CNH;

                if (cliente.CNPJ != String.Empty)
                    ChbxPessoaJuridica.Checked = true;
                    MtxbCnpj.Enabled = true;
                    MtxbCnpj.Text = cliente.CNPJ;
            }
        }
        public Func<Cliente, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.Nome = TxbNome.Text;
                cliente.CPF = MtxbCpf.Text;
                cliente.CEP = MtxbCep.Text;

                if (CbxUf.SelectedItem != null)
                    cliente.UF = (UF)CbxUf.SelectedItem;

                cliente.Cidade = TxbCidade.Text;
                cliente.Bairro = TxbBairro.Text;
                cliente.Numero = TxbNumero.Text;
                cliente.Rua = TxbRua.Text;
                cliente.Complemento = TxbComplemento.Text;
                cliente.Telefone = MtxbTelefone.Text;
                cliente.Email = TxbEmail.Text;
                cliente.CNH = TxbCnh.Text;

                if (ChbxPessoaJuridica.Checked == true)
                    cliente.CNPJ = MtxbCnpj.Text;
                else
                    cliente.CNPJ = null;

                ValidationResult resultado = SalvarRegistro(cliente);

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

        private void ChbxPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbxPessoaJuridica.Checked == true)
            {
                MtxbCnpj.Enabled = true;
            }
            else
            {
                cliente.CNPJ = null;
                MtxbCnpj.Clear();
                MtxbCnpj.Enabled = false;
            }
        }
    }
}