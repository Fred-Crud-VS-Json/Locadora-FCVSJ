using FluentAssertions;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaTestes
    {
        private Taxa? taxa;
        private readonly RepositorioTaxa repositorioTaxa;

        public RepositorioTaxaTestes()
        {
            BdUtil.ExecutarSql("DELETE FROM [TBTaxa]");

            repositorioTaxa = new();
        }

        [TestMethod]
        public void Deve_Inserir_Taxa()
        {
            // arrange
            taxa = NovaTaxa();

            // action
            repositorioTaxa.Inserir(taxa);

            // assert
            Taxa? taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_Editar_Taxa()
        {
            // arrange
            taxa = NovaTaxa();

            repositorioTaxa.Inserir(taxa);

            // action
            taxa.Nome = "Outra Taxa";

            repositorioTaxa.Editar(taxa);

            // assert
            Taxa? taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_Excluir_Taxa()
        {
            // arrange
            taxa = NovaTaxa();

            repositorioTaxa.Inserir(taxa);

            // action
            repositorioTaxa.Excluir(taxa);

            // assert
            Taxa? taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            taxaEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Taxa_Por_Id()
        {
            // arrange
            taxa = NovaTaxa();

            repositorioTaxa.Inserir(taxa);

            // action
            Taxa? taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            // assert
            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_As_Taxas()
        {
            // arrange
            taxa = NovaTaxa();

            Taxa taxa2 = new()
            {
                Nome = "Outra super taxa",
                Valor = 37.61m,
                TipoCalculoTaxa = TipoCalculoTaxa.Diaria
            };

            repositorioTaxa.Inserir(taxa);
            repositorioTaxa.Inserir(taxa2);

            // action
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();

            // assert
            taxas.Count.Should().Be(2);
            taxas.Should().Contain(taxa);
            taxas.Should().Contain(taxa2);
        }

        private Taxa NovaTaxa()
        {
            return new Taxa
            {
                Nome = "Taxa Top",
                Valor = 25.00m,
                TipoCalculoTaxa = TipoCalculoTaxa.Fixa
            };
        }

    }
}