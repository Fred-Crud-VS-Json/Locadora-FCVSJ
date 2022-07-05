using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly IRepositorioVeiculo _repositorioVeiculo;
        private readonly ServicoVeiculo _servicoVeiculo;
        //private readonly ControleVeiculoForm controleVeiculoForm;

        public ControladorVeiculo(IRepositorioVeiculo repositorioVeiculo, ServicoVeiculo servicoVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
            _servicoVeiculo = servicoVeiculo;
            //controleVeiculoForm = new(this);
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override KryptonForm ObterTela()
        {
            throw new NotImplementedException();
        }
    }
}
