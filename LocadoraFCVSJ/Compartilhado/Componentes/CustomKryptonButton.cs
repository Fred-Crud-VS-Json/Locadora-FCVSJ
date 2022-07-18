using Krypton.Toolkit;

namespace LocadoraFCVSJ.Compartilhado.Componentes
{
    public class CustomKryptonButton : KryptonButton
    {
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor.Current = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor.Current = Cursors.Hand;
        }
    }
}