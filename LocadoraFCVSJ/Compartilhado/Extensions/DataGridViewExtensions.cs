namespace LocadoraFCVSJ.Compartilhado.Extensions
{
    public static class DataGridViewExtensions
    {
        public static void ConfigurarImagem(this DataGridViewCellPaintingEventArgs e, Image image)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            var w = image.Width;
            var h = image.Height;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
            e.Handled = true;
        }
    }
}