using FluentAssertions;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado.Utils;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModeloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoTestes
    {
        private Veiculo? veiculo;
        private Veiculo? veiculo2;
        private Grupo? grupo;
        private readonly RepositorioVeiculoSql repositorioVeiculo;
        private readonly RepositorioGrupoSql repositorioGrupo;

        public RepositorioVeiculoTestes()
        {
            SqlUtil.ExecutarSql("DELETE FROM [TBCondutor]");
            SqlUtil.ExecutarSql("DELETE FROM [TBCliente]");
            SqlUtil.ExecutarSql("DELETE FROM [TBVeiculo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBPlanoDeCobranca]");
            SqlUtil.ExecutarSql("DELETE FROM [TBGrupo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBTaxa]");
            SqlUtil.ExecutarSql("DELETE FROM [TBFuncionario]");

            repositorioGrupo = new();
            repositorioVeiculo = new();
        }

        [TestMethod]
        public void Deve_inserir_novo_Veiculo()
        {
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();

            repositorioGrupo.Inserir(grupo);

            //action
            repositorioVeiculo.Inserir(veiculo);

            //assert
            Veiculo? veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_editar_Veiculo()
        {
            // arrange 
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();

            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            veiculo.Modelo = "Teste";
            veiculo.Marca = "Ford";
            veiculo.Placa = "ASD2345";
            veiculo.Cor = "Preto";
            veiculo.TipoCombustivel = TipoCombustivel.Elétrico;
            veiculo.CapacidadeTanque = 200;
            veiculo.Ano = 2020;
            veiculo.KmPercorrido = 0;

            repositorioVeiculo.Editar(veiculo);

            Veiculo? veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
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
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_Selecionar_todos_veiculos()
        {
            grupo = NovoGrupo();
            repositorioGrupo.Inserir(grupo);

            veiculo = NovoVeiculo();
            repositorioVeiculo.Inserir(veiculo);

            veiculo2 = NovoVeiculo2();
            repositorioVeiculo.Inserir(veiculo2);

            //assert
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();

            //assert
            veiculos.Count.Should().Be(2);
            veiculos.Should().Contain(veiculo);
            veiculos.Should().Contain(veiculo2);
        }

        private Veiculo NovoVeiculo()
        {
            return new()
            {
                Modelo = "Teste",
                Marca = "Ford",
                Placa = "ASD2345",
                Cor = "Preto",
                TipoCombustivel = TipoCombustivel.Elétrico,
                CapacidadeTanque = 200,
                Ano = 2020,
                KmPercorrido = 0,
                Foto = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 },
                Grupo = grupo
            };
        }

        private Veiculo NovoVeiculo2()
        {
            return new()
            {
                Modelo = "Teste2",
                Marca = "Volkswagen",
                Placa = "PLG2945",
                Cor = "Brando",
                TipoCombustivel = TipoCombustivel.Gasolina,
                CapacidadeTanque = 400,
                Ano = 2010,
                KmPercorrido = 100,
                Foto = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 },
                Grupo = grupo
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