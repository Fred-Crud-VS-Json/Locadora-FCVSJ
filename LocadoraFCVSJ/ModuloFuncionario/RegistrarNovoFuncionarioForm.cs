using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using System.Globalization;
using System.Text;

namespace LocadoraFCVSJ.ModuloFuncionario
{
    public partial class RegistrarNovoFuncionarioForm : KryptonForm
    {
        private Funcionario funcionario;

        public RegistrarNovoFuncionarioForm()
        {
            InitializeComponent();

            List<NivelAcesso> niveisDeAcesso = Enum.GetValues(typeof(NivelAcesso)).Cast<NivelAcesso>().ToList();

            niveisDeAcesso.ForEach(x => CbxNivelAcesso.Items.Add(x));
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }

            set
            {
                funcionario = value;

                TxbNome.Text = funcionario.Nome;
                TxbUsuario.Text = funcionario.Usuario;
                TxbSenha.Text = funcionario.Senha;
                TxbSalario.Text = funcionario.Salario.ToString("F2");
                MtxbDataAdmissao.Text = Convert.ToString(funcionario.DataAdmissao);
                CbxNivelAcesso.SelectedItem = funcionario.NivelAcesso;
            }
        }

        public Func<Funcionario, Result<Funcionario>> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                funcionario.Nome = TxbNome.Text;
                funcionario.Usuario = TxbUsuario.Text;
                funcionario.Senha = TxbSenha.Text;
                funcionario.Salario = Convert.ToDecimal(TxbSalario.Text);
                funcionario.DataAdmissao = DateTime.ParseExact(MtxbDataAdmissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (CbxNivelAcesso.SelectedItem != null)
                    funcionario.NivelAcesso = (NivelAcesso)CbxNivelAcesso.SelectedItem;

                Result<Funcionario> resultado = SalvarRegistro(funcionario);

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
                MessageBox.Show("O campo 'Salário' ou 'Data de Admissão' possuem valores inválidos.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }
    }
}