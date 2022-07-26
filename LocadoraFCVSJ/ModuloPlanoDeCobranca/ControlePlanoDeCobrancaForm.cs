using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado.Extensions;
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
                GridPlanos.Rows.Add(x.Grupo.Nome);
            });

            LblRegistros.Text = _controladorPlanoDeCobranca._servicoPlanoDeCobranca.SelecionarTodos().Value.Count + "/" + _controladorPlanoDeCobranca._servicoGrupo.SelecionarTodos().Value.Count + " planos(s)";

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

        private void ControlePlanoDeCobrancaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelaPrincipal.Instancia.WindowState = FormWindowState.Normal;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorPlanoDeCobranca.Inserir();
        }

        private void GridPlanos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    _controladorPlanoDeCobranca.Editar();
                    GridPlanos.ClearSelection();
                    break;

                case 3:
                    _controladorPlanoDeCobranca.Excluir();
                    break;

                case 5:
                    Visualizar();
                    break;
            }
        }

        private void GridPlanos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image editarImg = Properties.Resources.edit_blue_30px;
            Image excluirImg = Properties.Resources.close_blue_30px;
            Image visualizarImg = Properties.Resources.search_more_30px;

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

                case 5:
                    e.ConfigurarImagem(visualizarImg);
                    break;
            }
        }

        private void GridPlanos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridPlanos.Rows[e.RowIndex].Cells[e.ColumnIndex];

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

                case 4:
                    cell.ToolTipText = "";
                    break;

                case 5:
                    cell.ToolTipText = "Visualização Completa";
                    break;
            }
        }

        private void Visualizar()
        {
            PlanoDeCobranca? cliente = _controladorPlanoDeCobranca.ObterPlanoDeCobranca();

            if (cliente != null)
            {
                RegistrarPlanoDeCobrancaForm tela = new(_controladorPlanoDeCobranca._servicoPlanoDeCobranca, _controladorPlanoDeCobranca._servicoGrupo)
                {
                    PlanoDeCobranca = cliente
                };

                PrepararVisualizacao(tela);

                GridPlanos.ClearSelection();

                tela.ShowDialog();
            }
        }

        private static void PrepararVisualizacao(RegistrarPlanoDeCobrancaForm tela)
        {
            tela.LblTitulo.Text = "Visualizando Registro";
            tela.PxbIcon.Image = Properties.Resources.search_more_50px;

            tela.CbxGrupo.Enabled = false;

            tela.planoDiarioControl.TxbValorDiario.Enabled = false;
            tela.planoDiarioControl.TxbValorKm.Enabled = false;
            tela.planoDiarioControl.BtnConcluir.Visible = false;
            tela.planoDiarioControl.BtnLimpar.Visible = false;

            tela.planoLivreControl.TxbValorDiario.Enabled = false;
            tela.planoLivreControl.BtnConcluir.Visible = false;
            tela.planoLivreControl.BtnLimpar.Visible = false;

            tela.planoControladoControl.TxbValorDiario.Enabled = false;
            tela.planoControladoControl.TxbValorKm.Enabled = false;
            tela.planoControladoControl.TxbLimiteKm.Enabled = false;
            tela.planoControladoControl.BtnConcluir.Visible = false;
            tela.planoControladoControl.BtnLimpar.Visible = false;

            tela.BtnConcluir.Visible = false;
            tela.BtnVoltar.Location = tela.BtnConcluir.Location;
        }
    }
}