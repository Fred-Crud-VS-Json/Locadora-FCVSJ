using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloCliente;

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
                GridClientes.Rows.Add(x.Id, x.Nome, x.CPF, x.CEP, x.UF, x.Cidade, x.Rua, x.Numero, x.Bairro, x.Complemento, x.CNH, x.Email, x.Telefone);
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
    }
}