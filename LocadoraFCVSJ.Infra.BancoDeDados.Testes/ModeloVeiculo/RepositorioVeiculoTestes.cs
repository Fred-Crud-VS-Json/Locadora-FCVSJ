using FluentAssertions;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModeloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoTestes
    {
        private Veiculo? veiculo;
        private Grupo? grupo;
        private readonly RepositorioVeiculo repositorioVeiculo;
        private readonly RepositorioGrupo repositorioGrupo;

        public RepositorioVeiculoTestes()
        {
            BdUtil.ExecutarSql("DELETE FROM [TBVeiculo]; DBCC CHECKIDENT (TBVeiculo, RESEED, 0)");
            BdUtil.ExecutarSql("DELETE FROM [TBGrupo]; DBCC CHECKIDENT (TBGrupo, RESEED, 0)");

            repositorioGrupo = new();
            repositorioVeiculo = new();
        }

        [TestMethod]
        public void Deve_inserir_novo_Veiculo()
        {
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();

            //action
            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            //assert
            Veiculo? veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculo.Should().Be(veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_Veiculo()
        {
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();

            //action
            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            //assert
            Veiculo? veiculoAtualizado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            veiculoAtualizado.GrupoVeiculo = grupo;
            veiculoAtualizado.Modelo = "Teste";
            veiculoAtualizado.Marca = "Ford";
            veiculoAtualizado.Placa = "ASD2345";
            veiculoAtualizado.Cor = "Preto";
            veiculoAtualizado.TipoCombustivel = TipoCombustivel.Elétrico;
            veiculoAtualizado.CapacidadeTanque = 200;
            veiculoAtualizado.Ano = 2020;
            veiculoAtualizado.KmPercorrido = 0;

            repositorioVeiculo.Inserir(veiculoAtualizado);

            Veiculo? veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculo.Should().Be(veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_Veiculo()
        {
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();

            //action
            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            //assert
            Veiculo? veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            repositorioVeiculo.Excluir(veiculo);

            veiculoEncontrado.Should().NotBeNull();
            veiculo.Should().Be(veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_todos_veiculos()
        {
            grupo = NovoGrupo();
            repositorioGrupo.Inserir(grupo);

            veiculo = NovoVeiculo();
            repositorioVeiculo.Inserir(veiculo);

            veiculo = NovoVeiculo2();
            repositorioVeiculo.Inserir(veiculo);

            //assert
            var veiculos = repositorioVeiculo.SelecionarTodos();

            //assert
            Assert.AreEqual(2, veiculos.Count);

            Assert.AreEqual("Teste", veiculos[0].Modelo);
            Assert.AreEqual("Teste2", veiculos[1].Modelo);
        }

        private Veiculo NovoVeiculo()
        {
            return new()
            {
                GrupoVeiculo = grupo,
                Modelo = "Teste",
                Marca = "Ford",
                Placa = "ASD2345",
                Cor = "Preto",
                TipoCombustivel = TipoCombustivel.Elétrico,
                CapacidadeTanque = 200,
                Ano = 2020,
                KmPercorrido = 0,
                Foto = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 }
            };
        }

        private Veiculo NovoVeiculo2()
        {
            return new()
            {
                GrupoVeiculo = grupo,
                Modelo = "Teste2",
                Marca = "Volkswagen",
                Placa = "PLG2945",
                Cor = "Brando",
                TipoCombustivel = TipoCombustivel.Gasolina,
                CapacidadeTanque = 400,
                Ano = 2010,
                KmPercorrido = 100,
                Foto = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 }
            };
        }

        private Grupo NovoGrupo()
        {
            return new()
            {
                Nome = "Grupo a"
            };
        }
    }
}
