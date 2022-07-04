using FluentAssertions;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModeloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDeDadosTest
    {
        private Veiculo? veiculo;
        private Grupo? grupo;
        private readonly RepositorioVeiculo repositorioVeiculo;
        private readonly RepositorioGrupo repositorioGrupo;

        public RepositorioVeiculoEmBancoDeDadosTest()
        {
            BdUtil.ExecutarSql("DELETE FROM [TBGrupo]; DBCC CHECKIDENT (TBGrupo, RESEED, 0)");
            BdUtil.ExecutarSql("DELETE FROM [TBVeiculo]; DBCC CHECKIDENT (TBVeiculo, RESEED, 0)");
            repositorioGrupo = new();
            repositorioVeiculo = new();
        }

        [TestMethod]
        public void Deve_inserir_novo_Veiculo()
        {
            veiculo = NovoVeiculo();

            //action
            repositorioVeiculo.Inserir(veiculo);

            //assert
            Veiculo? veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculo.Should().Be(veiculoEncontrado);
        }

        private Veiculo NovoVeiculo()
        {
            Grupo grupo = new Grupo();
            grupo.Nome = "Grupo A - Carro economico";

            return new Veiculo
            {
                GrupoVeiculo = grupo,
                Modelo = "Teste",
                Marca = "Ford",
                Placa = "ASD2345",
                Cor = "Preto",
                TipoCombustivel = (Dominio.Compartilhado.TipoCombustivel?)1,
                CapacidadeTanque = 200,
                Ano = 2020,
                KmPercorrido = 0,
                Detalhes = "4 Portas"
            };
        }
    }
}
