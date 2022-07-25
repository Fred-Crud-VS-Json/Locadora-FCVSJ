using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;

namespace LocadoraFCVSJ.ModuloCondutor
{
    public partial class ControleCondutorForm : KryptonForm
    {
        private readonly ControladorCondutor _controladorCondutor;

        public ControleCondutorForm(ControladorCondutor controladorCondutor)
        {
            InitializeComponent();
            _controladorCondutor = controladorCondutor;
        }

        public void AtualizarGrid(List<Condutor> condutores)
        {
            GridCondutores.Rows.Clear();

            int z = 0;

            condutores.ForEach(x =>
            {

                GridCondutores.Rows.Add(x.Nome, x.CPF.FormatarParaCpf(), x.Email, x.Telefone.FormatarParaTelefone());

                z++;

                for (int i = z; i <= GridCondutores.Rows.Count; i++)
                {
                    string nome = (string)GridCondutores.Rows[i - 1].Cells[0].Value;

                    if (x.Cliente.Nome.Equals(nome))
                        GridCondutores.Rows[i - 1].Cells[4].Value = "Cliente Condutor";
                    else
                        GridCondutores.Rows[i - 1].Cells[4].Value = x.Cliente.Nome;
                }

            });

            LblRegistros.Text = _controladorCondutor._servicoCondutor.SelecionarTodos().Value.Count + " condutor(es)";

            GridCondutores.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridCondutores.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridCondutores;
        }

        private void ControleClienteForm_Load(object sender, EventArgs e)
        {
            GridCondutores.ClearSelection();
        }

        private void ControleCondutorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelaPrincipal.Instancia.WindowState = FormWindowState.Normal;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorCondutor.Inserir();
        }

        private void GridCondutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5:
                    _controladorCondutor.Editar();
                    GridCondutores.ClearSelection();
                    break;

                case 7:
                    _controladorCondutor.Excluir();
                    break;

                case 9:
                    Visualizar();
                    break;
            }
        }

        private void GridCondutores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image editarImg = Properties.Resources.edit_blue_30px;
            Image excluirImg = Properties.Resources.close_blue_30px;
            Image visualizarImg = Properties.Resources.search_more_30px;

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

                case 9:
                    e.ConfigurarImagem(visualizarImg);
                    break;
            }
        }

        private void GridCondutores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridCondutores.Rows[e.RowIndex].Cells[e.ColumnIndex];

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

                case 8:
                    cell.ToolTipText = "";
                    break;

                case 9:
                    cell.ToolTipText = "Visualização Completa";
                    break;
            }
        }

        private void Visualizar()
        {
            Condutor? condutor = _controladorCondutor.ObterCondutor();

            if (condutor != null)
            {
                RegistrarCondutorForm tela = new(_controladorCondutor._servicoCondutor)
                {
                    Condutor = condutor
                };

                PrepararVisualizacao(tela, condutor);

                GridCondutores.ClearSelection();

                tela.ShowDialog();
            }
        }

        private static void PrepararVisualizacao(RegistrarCondutorForm tela, Condutor condutor)
        {
            tela.LblTitulo.Text = "Visualizando Registro";
            tela.PxbIcon.Image = Properties.Resources.search_more_50px;

            Cliente? cliente = (Cliente)tela.CbxCliente.SelectedItem;

            if (!condutor.Nome.Equals(cliente.Nome))
            {
                tela.Label14.Text = "Condutor de";
                tela.ChbxClienteCondutor.Visible = false;
            }

            tela.CbxCliente.Enabled = false;
            tela.ChbxClienteCondutor.Enabled = false;
            tela.TxbNome.Enabled = false;
            tela.MtxbCpf.Enabled = false;
            tela.MtxbCnh.Enabled = false;
            tela.MtxbCep.Enabled = false;
            tela.CbxUf.Enabled = false;
            tela.TxbCidade.Enabled = false;
            tela.TxbRua.Enabled = false;
            tela.TxbNumero.Enabled = false;
            tela.TxbBairro.Enabled = false;
            tela.TxbComplemento.Enabled = false;
            tela.MtxbTelefone.Enabled = false;
            tela.TxbEmail.Enabled = false;
            tela.MtxbValidadeCnh.Enabled = false;
            tela.ChbxPessoaJuridica.Enabled = false;
            tela.MtxbCnpj.Enabled = false;

            tela.BtnConcluir.Visible = false;
            tela.BtnVoltar.Location = tela.BtnConcluir.Location;
        }
    }
}