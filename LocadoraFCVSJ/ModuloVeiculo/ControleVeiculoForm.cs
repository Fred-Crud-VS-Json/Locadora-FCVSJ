using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado.Extensions;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public partial class ControleVeiculoForm : KryptonForm
    {
        private readonly ControladorVeiculo _controladorVeiculo;
        public ControleVeiculoForm(ControladorVeiculo controladorVeiculo)
        {
            InitializeComponent();
            _controladorVeiculo = controladorVeiculo;
        }

        public void AtualizarGrid(List<Veiculo> veiculos)
        {
            GridVeiculos.Rows.Clear();

            veiculos.ForEach(x =>
            {
                GridVeiculos.Rows.Add(x.Modelo, x.Marca, x.Placa, x.Cor);
            });

            LblRegistros.Text = _controladorVeiculo._servicoVeiculo.SelecionarTodos().Value.Count + " veículo(s)";

            GridVeiculos.ClearSelection();
        }

        public DataGridView ObterGrid()
        {
            return GridVeiculos;
        }

        public int ObterLinhaSelecionada()
        {
            return GridVeiculos.CurrentCell.RowIndex;
        }

        private void ControleVeiculoForm_Load(object sender, EventArgs e)
        {
            GridVeiculos.ClearSelection();
        }

        private void ControleVeiculoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelaPrincipal.Instancia.WindowState = FormWindowState.Normal;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorVeiculo.Inserir();
        }

        private void GridVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 4:
                    _controladorVeiculo.Editar();
                    GridVeiculos.ClearSelection();
                    break;

                case 6:
                    _controladorVeiculo.Excluir();
                    break;

                case 8:
                    Visualizar();
                    break;
            }
        }

        private void GridVeiculos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void GridVeiculos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridVeiculos.Rows[e.RowIndex].Cells[e.ColumnIndex];

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
            Veiculo? veiculo = _controladorVeiculo.ObterVeiculo();

            if (veiculo != null)
            {
                RegistrarVeiculoForm tela = new(_controladorVeiculo._servicoGrupo)
                {
                    Veiculo = veiculo
                };

                PrepararVisualizacao(tela);

                GridVeiculos.ClearSelection();

                tela.ShowDialog();
            }
        }

        private static void PrepararVisualizacao(RegistrarVeiculoForm tela)
        {
            tela.LblTitulo.Text = "Visualizando Registro";
            tela.PxbIcon.Image = Properties.Resources.search_more_50px;

            tela.CbxGrupo.Enabled = false;
            tela.TxbModelo.Enabled = false;
            tela.TxbMarca.Enabled = false;
            tela.TxbPlaca.Enabled = false;
            tela.TxbCor.Enabled = false;
            tela.CbxTipoCombustivel.Enabled = false;
            tela.TxbCapacidadeTanque.Enabled = false;
            tela.TxbAno.Enabled = false;
            tela.TxbKmPercorrido.Enabled = false;

            tela.BtnSelecionarImagem.Visible = false;
            tela.customPanel4.Visible = false;
            tela.BtnConcluir.Visible = false;
            tela.BtnVoltar.Location = tela.BtnConcluir.Location;
        }

    }
}