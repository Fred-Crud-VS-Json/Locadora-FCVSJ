using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloGrupo;

namespace LocadoraFCVSJ.ModuloGrupo
{
    public partial class ControleGrupoForm : KryptonForm
    {
        private readonly ControladorGrupo _controladorGrupo;

        public ControleGrupoForm(ControladorGrupo controladorGrupo)
        {
            InitializeComponent();
            _controladorGrupo = controladorGrupo;   
        }

        public void AtualizarGrid(List<Grupo> grupos)
        {
            GridGrupos.Rows.Clear();

            grupos.ForEach(x =>
            {
                GridGrupos.Rows.Add(x.Id, x.Nome);
            });

            GridGrupos.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridGrupos.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridGrupos;
        }

        private void ControleGrupoForm_Load(object sender, EventArgs e)
        {
            GridGrupos.ClearSelection();
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorGrupo.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _controladorGrupo.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            _controladorGrupo.Excluir();
        }
    }
}