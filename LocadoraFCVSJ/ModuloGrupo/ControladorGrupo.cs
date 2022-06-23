using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;

namespace LocadoraFCVSJ.ModuloGrupo
{
    public class ControladorGrupo : ControladorBase
    {
        private readonly RepositorioGrupo _repositorioGrupo;

        public ControladorGrupo(RepositorioGrupo repositorioGrupo)
        {
            _repositorioGrupo = repositorioGrupo;
        }

        public override void Inserir()
        {
            RegistrarNovoGrupoForm tela = new()
            {
                Grupo = new(),
                SalvarRegistro = _repositorioGrupo.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                // TO-DO
            }
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterControle()
        {
            throw new NotImplementedException();
        }

        private void CarregarGrupos()
        {
            throw new NotImplementedException();
        }

        private Grupo? ObterGrupo()
        {
            throw new NotImplementedException();
        }
    }
}