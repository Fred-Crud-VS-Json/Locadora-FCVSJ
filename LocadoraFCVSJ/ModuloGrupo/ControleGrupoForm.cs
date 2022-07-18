using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;

namespace LocadoraFCVSJ.ModuloGrupo
{
    public partial class ControleGrupoForm : KryptonForm
    {
        private readonly ControladorGrupo _controladorGrupo;

        public ControleGrupoForm(ControladorGrupo controladorGrupo)
        {
            InitializeComponent();
            _controladorGrupo = controladorGrupo;
        }

        public void AtualizarGrid(List<Grupo> grupos)
        {
            GridGrupos.Rows.Clear();

            grupos.ForEach(x =>
            {
                GridGrupos.Rows.Add(x.Nome);
            });

            LblRegistros.Text = _controladorGrupo._servicoGrupo.SelecionarTodos().Value.Count + " grupo(s)";

            GridGrupos.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridGrupos.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridGrupos;
        }

        private void ControleGrupoForm_Load(object sender, EventArgs e)
        {
            GridGrupos.ClearSelection();
        }

        private void ControleGrupoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelaPrincipal.Instancia.WindowState = FormWindowState.Normal;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            GridGrupos.ClearSelection();
            _controladorGrupo.Inserir();
        }

        private void GridGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    _controladorGrupo.Editar();
                    GridGrupos.ClearSelection();
                    break;

                case 3:
                    _controladorGrupo.Excluir();
                    break;
            }
        }

        private void GridGrupos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image editarImg = Properties.Resources.edit_blue_30px;
            Image excluirImg = Properties.Resources.close_blue_30px;

            if (e.RowIndex < 0)
                return;

            switch (e.ColumnIndex)
            {
                case 1:
                    e.ConfigurarImagem(editarImg);
                    break;

                case 3:
                    e.ConfigurarImagem(excluirImg);
                    break;
            }
        }

        private void GridGrupos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridGrupos.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (e.ColumnIndex)
            {
                case 1:
                    cell.ToolTipText = "Editar Registro";
                    break;

                case 2:
                    cell.ToolTipText = "";
                    break;

                case 3:
                    cell.ToolTipText = "Excluir Registro";
                    break;
            }
        }

    }
}