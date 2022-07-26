using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado.Extensions;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;

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
                GridFuncionarios.Rows.Add(x.Nome, x.Usuario, "R$ " + x.Salario.ToString("F2"), x.DataAdmissao.ToString("dd/MM/yyyy"), x.NivelAcesso);
            });

            LblRegistros.Text = _controladorFuncionario._servicoFuncionario.SelecionarTodos().Value.Count + " grupo(s)";

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

        private void ControleFuncionarioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelaPrincipal.Instancia.WindowState = FormWindowState.Normal;
        }

        private void GridFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5:
                    _controladorFuncionario.Editar();
                    GridFuncionarios.ClearSelection();
                    break;

                case 7:
                    _controladorFuncionario.Excluir();
                    break;
            }
        }

        private void GridFuncionarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image editarImg = Properties.Resources.edit_blue_30px;
            Image excluirImg = Properties.Resources.close_blue_30px;

            if (e.RowIndex < 0)
                return;

            switch (e.ColumnIndex)
            {
                case 5:
                    e.ConfigurarImagem(editarImg);
                    break;

                case 7:
                    e.ConfigurarImagem(excluirImg);
                    break;
            }
        }

        private void GridFuncionarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridFuncionarios.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (e.ColumnIndex)
            {
                case 5:
                    cell.ToolTipText = "Editar Registro";
                    break;

                case 6:
                    cell.ToolTipText = "";
                    break;

                case 7:
                    cell.ToolTipText = "Excluir Registro";
                    break;
            }
        }
    }
}