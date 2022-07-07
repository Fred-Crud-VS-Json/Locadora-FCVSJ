using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca
{
    public partial class ControlePlanoDeCobrancaForm : KryptonForm
    {
        private readonly ControladorPlanoDeCobranca _controladorPlanoDeCobranca;

        public ControlePlanoDeCobrancaForm(ControladorPlanoDeCobranca controladorPlanoDeCobranca)
        {
            InitializeComponent();
            _controladorPlanoDeCobranca = controladorPlanoDeCobranca;
        }

        public void AtualizarGrid(List<PlanoDeCobranca> planosDeCobrancas)
        {
            GridPlanos.Rows.Clear();

            planosDeCobrancas.ForEach(x =>
            {
                GridPlanos.Rows.Add(x.Id, x.Grupo.Nome);
            });

            GridPlanos.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridPlanos.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridPlanos;
        }

        private void ControlePlanoDeCobrancaForm_Load(object sender, EventArgs e)
        {
            GridPlanos.ClearSelection();
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorPlanoDeCobranca.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _controladorPlanoDeCobranca.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            _controladorPlanoDeCobranca.Excluir();
        }

        private void GridPlanos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridPlanos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image someImage = Properties.Resources.search_more_25px;

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 2)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = someImage.Width;
                var h = someImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void GridPlanos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridPlanos.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == 8)
                cell.ToolTipText = "Visualizar Informações do Plano";
        }
    }
}