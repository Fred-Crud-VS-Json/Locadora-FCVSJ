using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado;
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

        public void AtualizarGrid(List<Cliente> clientes)
        {
            GridClientes.Rows.Clear();

            clientes.ForEach(x => GridClientes.Rows.Add(x.Nome, x.CPF.FormatarParaCpf(), x.Email, x.Telefone.FormatarParaTelefone()));

            LblRegistros.Text = _controladorCliente._servicoCliente.SelecionarTodos().Value.Count + " cliente(s)";

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

        private void ControleClienteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelaPrincipal.Instancia.WindowState = FormWindowState.Normal;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            GridClientes.ClearSelection();

            _controladorCliente.Inserir();
        }

        private void GridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 4:
                    _controladorCliente.Editar();
                    GridClientes.ClearSelection();
                    break;

                case 6:
                    _controladorCliente.Excluir();
                    break;

                case 8:
                    Visualizar();
                    break;
            }
        }

        private void GridClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image editarImg = Properties.Resources.edit_blue_30px;
            Image excluirImg = Properties.Resources.close_blue_30px;
            Image visualizarImg = Properties.Resources.search_more_30px;

            if (e.RowIndex < 0)
                return;

            switch (e.ColumnIndex)
            {
                case 4:
                    e.ConfigurarImagem(editarImg);
                    break;

                case 6:
                    e.ConfigurarImagem(excluirImg);
                    break;

                case 8:
                    e.ConfigurarImagem(visualizarImg);
                    break;
            }

        }

        private void GridClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridClientes.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (e.ColumnIndex)
            {
                case 4:
                    cell.ToolTipText = "Editar Registro";
                    break;

                case 5:
                    cell.ToolTipText = "";
                    break;

                case 6:
                    cell.ToolTipText = "Excluir Registro";
                    break;

                case 7:
                    cell.ToolTipText = "";
                    break;

                case 8:
                    cell.ToolTipText = "Visualização Completa";
                    break;
            }
        }

        private void Visualizar()
        {
            Cliente? cliente = _controladorCliente.ObterCliente();

            if (cliente != null)
            {
                RegistrarClienteForm tela = new()
                {
                    Cliente = cliente
                };

                PrepararVisualizacao(tela);

                GridClientes.ClearSelection();

                tela.ShowDialog();
            }
        }

        private static void PrepararVisualizacao(RegistrarClienteForm tela)
        {
            tela.LblTitulo.Text = "Visualizando Registro";
            tela.PxbIcon.Image = Properties.Resources.search_more_50px;

            tela.TxbNome.Enabled = false;
            tela.MtxbCpf.Enabled = false;
            tela.MtbxCnh.Enabled = false;
            tela.MtxbCep.Enabled = false;
            tela.CbxUf.Enabled = false;
            tela.TxbCidade.Enabled = false;
            tela.TxbRua.Enabled = false;
            tela.TxbNumero.Enabled = false;
            tela.TxbBairro.Enabled = false;
            tela.TxbComplemento.Enabled = false;
            tela.MtxbTelefone.Enabled = false;
            tela.TxbEmail.Enabled = false;
            tela.ChbxPessoaJuridica.Enabled = false;
            tela.MtxbCnpj.Enabled = false;

            tela.BtnConcluir.Visible = false;
            tela.BtnVoltar.Location = tela.BtnConcluir.Location;
        }
    }
}