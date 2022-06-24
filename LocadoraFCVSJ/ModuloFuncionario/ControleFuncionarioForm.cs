using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using System.Globalization;

namespace LocadoraFCVSJ.ModuloFuncionario
{
    public partial class ControleFuncionarioForm : KryptonForm
    {
        private readonly ControladorFuncionario _controladorFuncionario;

        public ControleFuncionarioForm(ControladorFuncionario controladorFuncionario)
        {
            InitializeComponent();
            _controladorFuncionario = controladorFuncionario;
        }

        public void AtualizarGrid(List<Funcionario> grupos)
        {
            GridFuncionarios.Rows.Clear();

            grupos.ForEach(x =>
            {
                GridFuncionarios.Rows.Add(x.Id, x.Nome, x.Usuario, "R$ " + x.Salario.ToString("F2", CultureInfo.InvariantCulture), x.DataAdmissao.ToString("dd/MM/yyyy"), x.NivelAcesso);
            });

            GridFuncionarios.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridFuncionarios.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridFuncionarios;
        }

        private void ControleFuncionarioForm_Load(object sender, EventArgs e)
        {
            GridFuncionarios.ClearSelection();
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorFuncionario.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _controladorFuncionario.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            _controladorFuncionario.Excluir();
        }
    }
}