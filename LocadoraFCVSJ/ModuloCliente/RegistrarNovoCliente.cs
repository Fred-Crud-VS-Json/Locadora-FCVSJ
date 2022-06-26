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

            List<EstadosUF> estadosUF = Enum.GetValues(typeof(EstadosUF)).Cast<EstadosUF>().ToList();

            estadosUF.ForEach(x => CbxUf.Items.Add(x));
        }

        public Cliente Cliente
        {
            get { return cliente; }

            set
            {
                cliente = value;

                TxbNome.Text = cliente.Nome;
                MtxbCpf.Text = Convert.ToString(cliente.CPF);
                MtxbCnpj.Text = Convert.ToString(cliente.CNPJ);
                TxbCnh.Text = Convert.ToString(cliente.CNH);
                MtxbTelefone.Text = Convert.ToString(cliente.Telefone);
                TxbEmail.Text = cliente.Email;
                TxbCidade.Text = cliente.Cidade;
                MtxbCep.Text = Convert.ToString(cliente.CEP);
                TxbNumero.Text = Convert.ToString(cliente.Numero);
                TxbBairro.Text = cliente.Bairro;
                CbxUf.SelectedItem = cliente.UF;
                TxbComplemento.Text = cliente.Complemento;
                TxbRua.Text = cliente.Rua;
            }
        }
        public Func<Cliente, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                TxbNome.Text = cliente.Nome;
                MtxbCpf.Text = Convert.ToString(cliente.CPF);
                MtxbCnpj.Text = Convert.ToString(cliente.CNPJ);
                TxbCnh.Text = Convert.ToString(cliente.CNH);
                MtxbTelefone.Text = Convert.ToString(cliente.Telefone);
                TxbEmail.Text = cliente.Email;
                TxbCidade.Text = cliente.Cidade;
                MtxbCep.Text = Convert.ToString(cliente.CEP);
                TxbNumero.Text = Convert.ToString(cliente.Numero);
                TxbBairro.Text = cliente.Bairro;
                CbxUf.SelectedItem = cliente.UF;
                TxbComplemento.Text = cliente.Complemento;
                TxbRua.Text = cliente.Rua;


                ValidationResult resultado = SalvarRegistro(cliente);

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("O campo 'CPF', 'CNH', 'NUMERO', 'CNPJ', 'TELEFONE' E 'CEP' devem conter apenas números.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }
    }
}