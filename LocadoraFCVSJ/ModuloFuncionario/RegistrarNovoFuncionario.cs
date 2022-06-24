using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;

namespace LocadoraFCVSJ.ModuloFuncionario
{
    public partial class RegistrarNovoFuncionario : KryptonForm
    {
        private Funcionario funcionario;

        public RegistrarNovoFuncionario()
        {
            InitializeComponent();

            List<NivelAcessoEnum> niveisDeAcesso = Enum.GetValues(typeof(NivelAcessoEnum)).Cast<NivelAcessoEnum>().ToList();

            niveisDeAcesso.ForEach(x => CbxNivelAcesso.Items.Add(x));
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }

            set
            {
                funcionario = value;

                TxbNome.Text = funcionario.Nome;
                TxbUsuario.Text = funcionario.Login;
                TxbSenha.Text = funcionario.Senha;
                TxbSalario.Text = Convert.ToString(funcionario.Salario);
                MtxbDataAdmissao.Text = Convert.ToString(funcionario.DataAdmissao);
                CbxNivelAcesso.SelectedItem = funcionario.NivelAcesso;
            }
        }

        public Func<Funcionario, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            funcionario.Nome = TxbNome.Text;
            funcionario.Login = TxbUsuario.Text;
            funcionario.Senha = TxbSenha.Text;
            funcionario.Salario = Convert.ToDecimal(TxbSalario);
            funcionario.DataAdmissao = Convert.ToDateTime(MtxbDataAdmissao);
            funcionario.NivelAcesso = (NivelAcessoEnum)CbxNivelAcesso.SelectedItem;

            ValidationResult resultado = SalvarRegistro(funcionario);

            if (resultado.IsValid == false)
            {
                MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;
            }
        }
    }
}