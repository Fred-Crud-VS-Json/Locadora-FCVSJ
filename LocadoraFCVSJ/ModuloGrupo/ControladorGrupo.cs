using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;

namespace LocadoraFCVSJ.ModuloGrupo
{
    public class ControladorGrupo : ControladorBase
    {
        private readonly RepositorioGrupo _repositorioGrupo;
        private readonly ServicoGrupo _servicoGrupo;
        private readonly ControleGrupoForm controleGrupoForm;

        public ControladorGrupo(RepositorioGrupo repositorioGrupo, ServicoGrupo servicoGrupo)
        {
            _repositorioGrupo = repositorioGrupo;
            _servicoGrupo = servicoGrupo;
            controleGrupoForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoGrupoForm tela = new()
            {
                Grupo = new(),
                SalvarRegistro = _servicoGrupo.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Editar()
        {
            Grupo? grupoSelecionado = ObterGrupo();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo primeiro.", "Edição de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarNovoGrupoForm tela = new()
            {
                Grupo = grupoSelecionado,
                SalvarRegistro = _servicoGrupo.Editar
            };

            tela.label1.Text = "      Editando Registro";
            tela.label4.Text = "Insira o novo nome do grupo no campo abaixo";


            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Excluir()
        {
            Grupo? grupoSelecionado = ObterGrupo();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo primeiro.", "Exclusão de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Grupo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                _repositorioGrupo.Excluir(grupoSelecionado);

            CarregarGrupos();
        }

        public override KryptonForm ObterTela()
        {
            CarregarGrupos();

            return controleGrupoForm;
        }

        private void CarregarGrupos()
        {
            List<Grupo> grupos = _repositorioGrupo.SelecionarTodos();

            controleGrupoForm.AtualizarGrid(grupos);
        }

        private Grupo? ObterGrupo()
        {
            if (controleGrupoForm.ObterGrid().CurrentCell != null && controleGrupoForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleGrupoForm.ObterLinhaSelecionada();
                return _repositorioGrupo.SelecionarTodos().ElementAtOrDefault(index);
            }

            return null;
        }
    }
}