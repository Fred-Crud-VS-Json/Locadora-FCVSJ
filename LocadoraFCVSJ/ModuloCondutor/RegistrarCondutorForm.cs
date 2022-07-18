using FluentResults;
using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using System.Globalization;
using System.Text;

namespace LocadoraFCVSJ.ModuloCondutor
{
    public partial class RegistrarCondutorForm : KryptonForm
    {
        private Condutor condutor;

        public RegistrarCondutorForm(ServicoCondutor servicoCondutor)
        {
            InitializeComponent();

            servicoCondutor.SelecionarTodosOsClientes().ForEach(x => CbxCliente.Items.Add(x));

            List<UF> estadosUF = Enum.GetValues(typeof(UF)).Cast<UF>().ToList();

            estadosUF.ForEach(x => CbxUf.Items.Add(x));
        }

        public Condutor Condutor
        { 
            get { return condutor; }

            set
             {
                condutor = value;

                CbxCliente.SelectedItem = condutor.Cliente;

                Cliente cliente = condutor.Cliente;
                                                   
                if (cliente != null)
                {
                    if (!condutor.Nome.Equals(cliente.Nome))
                        ChbxClienteCondutor.Checked = false;
                    else
                        ChbxClienteCondutor.Checked = true;
                }

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
                MtxbCnh.Text = condutor.CNH;

                if (condutor.ValidadeCnh != DateTime.MinValue)
                    MtxbValidadeCnh.Text = Convert.ToString(condutor.ValidadeCnh);

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

        public Func<Condutor, Result<Condutor>> SalvarRegistro { get; set; }

        private void BtnConcluir_Click(object sender, EventArgs e)
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
                condutor.CNH = MtxbCnh.Text;
                condutor.ValidadeCnh = DateTime.ParseExact(MtxbValidadeCnh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Cliente cliente = (Cliente)CbxCliente.SelectedItem;

                if (cliente != null)
                    condutor.Cliente = cliente;

                if (ChbxPessoaJuridica.Checked == true)
                    condutor.CNPJ = MtxbCnpj.Text;
                else
                    condutor.CNPJ = null;

                if (condutor.Cliente == null)
                {
                    MessageBox.Show("Para concluir o cadastro de condutor ele deve estar relacionado a algum cliente.", "Locadora FCVSJ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }

                Result<Condutor> resultado = SalvarRegistro(condutor);

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
                MessageBox.Show("O campo 'Data' deve conter apenas números.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }

        private void CbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChbxClienteCondutor.Checked == true)
                LimparCampos();

            Cliente cliente = (Cliente)CbxCliente.SelectedItem;

            if (ChbxClienteCondutor.Checked == true)
                PreencherDadosClienteCondutor(cliente);
        }

        private void ChbxClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (CbxCliente.SelectedItem == null)
                ChbxClienteCondutor.Checked = false;

            Cliente cliente = (Cliente)CbxCliente.SelectedItem;

            if (ChbxClienteCondutor.Checked == true)
            {
                PreencherDadosClienteCondutor(cliente);
                DesabilitarCamposParaClienteCondutor();
            }
            else
            {
                LimparCampos();
                HabilitarCampos();

                ChbxPessoaJuridica.Enabled = true;
                MtxbCnpj.Enabled = false;
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
                condutor.CNPJ = null;
                MtxbCnpj.Clear();
                MtxbCnpj.Enabled = false;
            }
        }

        private void PreencherDadosClienteCondutor(Cliente cliente)
        {
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
            MtxbCnh.Text = cliente.CNH;

            if (condutor.ValidadeCnh != DateTime.MinValue)
                MtxbValidadeCnh.Text = Convert.ToString(condutor.ValidadeCnh);

            if (!string.IsNullOrEmpty(cliente.CNPJ))
            {
                ChbxPessoaJuridica.Checked = true;
                MtxbCnpj.Text = cliente.CNPJ;
                ChbxPessoaJuridica.Enabled = false;
                MtxbCnpj.Enabled = false;
            }
        }

        private void DesabilitarCamposParaClienteCondutor()
        {
            TxbNome.Enabled = false;
            MtxbCpf.Enabled = false;
            MtxbCep.Enabled = false;
            CbxUf.Enabled = false;
            TxbCidade.Enabled = false;
            TxbBairro.Enabled = false;
            TxbNumero.Enabled = false;
            TxbRua.Enabled = false;
            TxbComplemento.Enabled = false;
            MtxbTelefone.Enabled = false;
            TxbEmail.Enabled = false;
            MtxbCnh.Enabled = false;
            MtxbValidadeCnh.Enabled = true;
            ChbxPessoaJuridica.Enabled = false;
            MtxbCnpj.Enabled = false;
        }

        private void HabilitarCampos()
        {
            TxbNome.Enabled = true;
            MtxbCpf.Enabled = true;
            MtxbCep.Enabled = true;
            CbxUf.Enabled = true;
            TxbCidade.Enabled = true;
            TxbBairro.Enabled = true;
            TxbNumero.Enabled = true;
            TxbRua.Enabled = true;
            TxbComplemento.Enabled = true;
            MtxbTelefone.Enabled = true;
            TxbEmail.Enabled = true;
            MtxbCnh.Enabled = true;
            MtxbValidadeCnh.Enabled = true;
            ChbxPessoaJuridica.Enabled = true;
            MtxbCnpj.Enabled = true;
        }

        private void LimparCampos()
        {
            TxbNome.Clear();
            MtxbCpf.Clear();
            MtxbCep.Clear();
            TxbCidade.Clear();
            TxbBairro.Clear();
            TxbNumero.Clear();
            TxbRua.Clear();
            TxbComplemento.Clear();
            MtxbTelefone.Clear();
            TxbEmail.Clear();
            MtxbCnh.Clear();
            ChbxPessoaJuridica.Checked = false;
            MtxbCnpj.Clear();
        }

    }
}