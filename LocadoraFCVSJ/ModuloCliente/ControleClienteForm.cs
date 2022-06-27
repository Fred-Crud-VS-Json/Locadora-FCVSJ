using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using System.Text;

namespace LocadoraFCVSJ.ModuloCliente
{
    public partial class ControleClienteForm : KryptonForm
    {
        private readonly ControladorCliente _controladorCliente;

        public ControleClienteForm(ControladorCliente controladorCliente)
        {
            InitializeComponent();
            _controladorCliente = controladorCliente;
        }

        public void AtualizarGrid(List<Cliente> grupos)
        {
            GridClientes.Rows.Clear();

            grupos.ForEach(x =>
            {
                GridClientes.Rows.Add(x.Id, x.Nome, x.CPF, x.CNH, x.Email, x.Telefone);
            });

            GridClientes.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridClientes.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridClientes;
        }

        private void ControleClienteForm_Load(object sender, EventArgs e)
        {
            GridClientes.ClearSelection();
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorCliente.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _controladorCliente.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            _controladorCliente.Excluir();
        }

        private void GridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                Cliente? cliente = _controladorCliente.ObterCliente();

                StringBuilder sb = new();

                if (cliente != null) {
                    sb.AppendLine($"CEP: {cliente.CEP}");
                    sb.AppendLine($"UF: {cliente.UF}");
                    sb.AppendLine($"Cidade: {cliente.Cidade}");
                    sb.AppendLine($"Bairro: {cliente.Bairro}");
                    sb.AppendLine($"Número: {cliente.Numero}");
                    sb.AppendLine($"Rua: {cliente.Rua}");
                    sb.AppendLine($"Complemento: {cliente.Complemento}");
                }

                MessageBox.Show(sb.ToString(), "Visualizando Endereço", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GridClientes.ClearSelection();
            }
        }

        private void GridClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void GridClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridClientes.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == 8)
                cell.ToolTipText = "Visualizar Endereço";
        }
    }
}