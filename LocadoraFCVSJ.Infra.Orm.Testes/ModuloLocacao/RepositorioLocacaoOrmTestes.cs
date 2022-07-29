using FluentAssertions;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado.Enums;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloLocacao;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado.Utils;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using LocadoraFCVSJ.Infra.Orm.ModuloCliente;
using LocadoraFCVSJ.Infra.Orm.ModuloCondutor;
using LocadoraFCVSJ.Infra.Orm.ModuloGrupo;
using LocadoraFCVSJ.Infra.Orm.ModuloLocacao;
using LocadoraFCVSJ.Infra.Orm.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.Orm.ModuloTaxa;
using LocadoraFCVSJ.Infra.Orm.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.Orm.Testes.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoOrmTestes
    {
        private LocadoraOrmContext locadora;
        private Locacao locacao;
        private Locacao locacao2;
        private Condutor? condutor;
        private Condutor? condutor2;
        private Cliente? cliente;
        private Grupo? grupo;
        private Veiculo? veiculo;
        private PlanoDeCobranca? planoDeCobranca;
        private Taxa? taxa;

        private readonly RepositorioLocacaoOrm repositorioLocacao;
        private readonly RepositorioCondutorOrm repositorioCondutor;
        private readonly RepositorioClienteOrm repositorioCliente;
        private readonly RepositorioGrupoOrm repositorioGrupo;
        private readonly RepositorioVeiculoOrm repositorioVeiculo;
        private readonly RepositorioPlanoDeCobrancaOrm repositorioPlanoDeCobranca;
        private readonly RepositorioTaxaOrm repositorioTaxa;

        public RepositorioLocacaoOrmTestes()
        {
            SqlUtil.ExecutarSql("DELETE FROM [TBLocacaoOrm]");
            SqlUtil.ExecutarSql("DELETE FROM [TBClienteOrm]");
            SqlUtil.ExecutarSql("DELETE FROM [TBCondutorOrm]");            
            SqlUtil.ExecutarSql("DELETE FROM [TBVeiculoOrm]");
            SqlUtil.ExecutarSql("DELETE FROM [TBPlanoOrm]");
            SqlUtil.ExecutarSql("DELETE FROM [TBTaxaOrm]");
            SqlUtil.ExecutarSql("DELETE FROM [TBGrupoOrm]");           
            SqlUtil.ExecutarSql("DELETE FROM [TBFuncionarioOrm]");
            
            locadora = new("Data Source=(LocalDB)\\MSSqlLocalDB;Initial Catalog=DBLocadoraFCVSJ;Integrated Security=True;Pooling=False");

            repositorioCliente = new RepositorioClienteOrm(locadora);
            repositorioCondutor = new RepositorioCondutorOrm(locadora);
            repositorioGrupo = new RepositorioGrupoOrm(locadora);
            repositorioVeiculo = new RepositorioVeiculoOrm(locadora);
            repositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaOrm(locadora);
            repositorioTaxa = new RepositorioTaxaOrm(locadora);
            repositorioLocacao = new RepositorioLocacaoOrm(locadora);
        }

        [TestMethod]
        public void Deve_Inserir_Locacao()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();
            planoDeCobranca = NovoPlanoDeCobranca();
            taxa = NovaTaxa();
            locacao = NovaLocacao();

            
            repositorioCliente.Inserir(cliente);
            locadora.SaveChanges();
            repositorioCondutor.Inserir(condutor);
            locadora.SaveChanges();
            repositorioGrupo.Inserir(grupo);
            locadora.SaveChanges();
            repositorioVeiculo.Inserir(veiculo);
            locadora.SaveChanges();
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            locadora.SaveChanges();
            repositorioTaxa.Inserir(taxa);
            locadora.SaveChanges();
            repositorioLocacao.Inserir(locacao);
            locadora.SaveChanges();
            
            //assert
            Locacao? locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacao.Id);

            locacaoEncontrada.Should().NotBeNull();
            locacaoEncontrada.Should().Be(locacao);
        }

        [TestMethod]
        public void Deve_Editar_Locacao()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();
            planoDeCobranca = NovoPlanoDeCobranca();
            taxa = NovaTaxa();
            locacao = NovaLocacao();

            repositorioCliente.Inserir(cliente);
            locadora.SaveChanges();
            repositorioCondutor.Inserir(condutor);
            locadora.SaveChanges();
            repositorioGrupo.Inserir(grupo);
            locadora.SaveChanges();
            repositorioVeiculo.Inserir(veiculo);
            locadora.SaveChanges();
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            locadora.SaveChanges();
            repositorioTaxa.Inserir(taxa);
            locadora.SaveChanges();
            repositorioLocacao.Inserir(locacao);
            locadora.SaveChanges();

            locacao.PrecoEstimado = 500;

            repositorioLocacao.Editar(locacao);
            locadora.SaveChanges();
            //assert
            Locacao? locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacao.Id);

            locacaoEncontrada.Should().NotBeNull();
            locacaoEncontrada.Should().Be(locacao);
        }

        [TestMethod]
        public void Deve_Excluir_Locacao()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();
            planoDeCobranca = NovoPlanoDeCobranca();
            taxa = NovaTaxa();
            locacao = NovaLocacao();


            repositorioCliente.Inserir(cliente);
            locadora.SaveChanges();
            repositorioCondutor.Inserir(condutor);
            locadora.SaveChanges();
            repositorioGrupo.Inserir(grupo);
            locadora.SaveChanges();
            repositorioVeiculo.Inserir(veiculo);
            locadora.SaveChanges();
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            locadora.SaveChanges();
            repositorioTaxa.Inserir(taxa);
            locadora.SaveChanges();
            repositorioLocacao.Inserir(locacao);
            locadora.SaveChanges();

            repositorioLocacao.Excluir(locacao);
            locadora.SaveChanges();
            //assert
            Locacao? locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacao.Id);

            locacaoEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Locacao_porId()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();
            planoDeCobranca = NovoPlanoDeCobranca();
            taxa = NovaTaxa();
            locacao = NovaLocacao();

            repositorioCliente.Inserir(cliente);
            locadora.SaveChanges();
            repositorioCondutor.Inserir(condutor);
            locadora.SaveChanges();
            repositorioGrupo.Inserir(grupo);
            locadora.SaveChanges();
            repositorioVeiculo.Inserir(veiculo);
            locadora.SaveChanges();
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            locadora.SaveChanges();
            repositorioTaxa.Inserir(taxa);
            locadora.SaveChanges();
            repositorioLocacao.Inserir(locacao);
            locadora.SaveChanges();

            //assert
            Locacao? locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacao.Id);

            locacaoEncontrada.Should().NotBeNull();
            locacaoEncontrada.Should().Be(locacao);
        }

        [TestMethod]
        public void Deve_Selecionar_Todas_Locacoes()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();
            planoDeCobranca = NovoPlanoDeCobranca();
            taxa = NovaTaxa();
            locacao = NovaLocacao();

            repositorioCliente.Inserir(cliente);
            locadora.SaveChanges();
            repositorioCondutor.Inserir(condutor);
            locadora.SaveChanges();
            repositorioGrupo.Inserir(grupo);
            locadora.SaveChanges();
            repositorioVeiculo.Inserir(veiculo);
            locadora.SaveChanges();
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            locadora.SaveChanges();
            repositorioTaxa.Inserir(taxa);
            locadora.SaveChanges();
            repositorioLocacao.Inserir(locacao);
            locadora.SaveChanges();


            cliente = NovoCliente();
            condutor2 = NovoCondutor();
            grupo = NovoGrupo();
            veiculo = NovoVeiculo();
            planoDeCobranca = NovoPlanoDeCobranca();
            taxa = NovaTaxa();
            locacao2 = NovaLocacao2();

            repositorioCliente.Inserir(cliente);
            locadora.SaveChanges();
            repositorioCondutor.Inserir(condutor2);
            locadora.SaveChanges();
            repositorioGrupo.Inserir(grupo);
            locadora.SaveChanges();
            repositorioVeiculo.Inserir(veiculo);
            locadora.SaveChanges();
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            locadora.SaveChanges();
            repositorioTaxa.Inserir(taxa);
            locadora.SaveChanges();
            repositorioLocacao.Inserir(locacao2);
            locadora.SaveChanges();

            //action
            List<Locacao> locacoes = repositorioLocacao.SelecionarTodos();

            //assert
            locacoes.Count.Should().Be(2);
            locacoes.Should().Contain(locacao);
            locacoes.Should().Contain(locacao2);
        }



        private Locacao NovaLocacao()
        {
            return new Locacao
            {
                Cliente = cliente,
                Condutor = condutor,
                Grupo = grupo,
                Veiculo = veiculo,
                PlanoDeCobranca = planoDeCobranca,
                Taxa = taxa,
                DataLocacao = DateTime.Now.Date,
                DataDevolucao = DateTime.Now.AddDays(30).Date,
                PrecoEstimado = 200
            };
        }

        private Locacao NovaLocacao2()
        {
            return new Locacao
            {
                Cliente = cliente,
                Condutor = condutor2,
                Grupo = grupo,
                Veiculo = veiculo,
                PlanoDeCobranca = planoDeCobranca,
                Taxa = taxa,
                DataLocacao = DateTime.Now.Date,
                DataDevolucao = DateTime.Now.AddDays(30).Date,
                PrecoEstimado = 200
            };
        }

        private Condutor NovoCondutor()
        {
            return new Condutor
            {
                Nome = "Alan",
                CPF = "59643424718",
                CNPJ = "12345678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                ValidadeCnh = DateTime.Now.Date,
                Telefone = "12988754461",
                Email = "Alan@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SP,
                Complemento = "verde",
                Cliente = cliente
            };
        }

        private Condutor NovoCondutor2()
        {
            return new Condutor
            {
                Nome = "Pedro",
                CPF = "59643424718",
                CNPJ = "12345678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                ValidadeCnh = DateTime.Now.Date,
                Telefone = "12988754461",
                Email = "Alan@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SP,
                Complemento = "verde",
                Cliente = cliente
            };
        }

        private Cliente NovoCliente()
        {
            return new()
            {
                Nome = "Fulano",
                CPF = "59643424718",
                CNPJ = "12345678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                Telefone = "12988754461",
                Email = "Fulano@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SP,
                Complemento = "verde"
            };
        }

        private Grupo NovoGrupo()
        {
            return new()
            {
                Nome = "Grupo A - Compacto"
            };
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

        private Veiculo NovoVeiculo()
        {
            return new()
            {
                Modelo = "Teste",
                Marca = "Volkswagen",
                Placa = "PLG2945",
                Cor = "Brando",
                TipoCombustivel = TipoCombustivel.Diesel,
                CapacidadeTanque = 400,
                Ano = 2010,
                KmPercorrido = 100,
                Foto = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 },
                Grupo = grupo
            };
        }

        private PlanoDeCobranca NovoPlanoDeCobranca()
        {
            return new()
            {
                Grupo = grupo,
                PlanoDiario_ValorDiario = 5.50m,
                PlanoDiario_ValorKm = 2.50m,
                PlanoLivre_ValorDiario = 8.80m,
                PlanoControlado_ValorDiario = 4.30m,
                PlanoControlado_ValorKm = 2.00m,
                PlanoControlado_LimiteKm = 500
            };
        }
    }
}
