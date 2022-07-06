using Krypton.Toolkit;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public partial class ControleVeiculoForm : KryptonForm
    {
        public ControleVeiculoForm()
        {
            InitializeComponent();
        }

        private void GridVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridVeiculos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image someImage = Properties.Resources.search_more_25px;

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 8)
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

        private void GridVeiculos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridVeiculos.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == 5)
                cell.ToolTipText = "Visualização Completa";
        }
    }
}