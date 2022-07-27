using Autofac;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using LocadoraFCVSJ.Infra.Orm.ModuloCliente;
using LocadoraFCVSJ.Infra.Orm.ModuloFuncionario;
using LocadoraFCVSJ.Infra.Orm.ModuloGrupo;
using LocadoraFCVSJ.Infra.Orm.ModuloTaxa;
using LocadoraFCVSJ.Infra.Orm.ModuloVeiculo;
using LocadoraFCVSJ.ModuloCliente;
using LocadoraFCVSJ.ModuloCondutor;
using LocadoraFCVSJ.ModuloFuncionario;
using LocadoraFCVSJ.ModuloGrupo;
using LocadoraFCVSJ.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.ModuloTaxa;
using LocadoraFCVSJ.ModuloVeiculo;

namespace LocadoraFCVSJ.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutoFac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutoFac()
        {
            ContainerBuilder builder = new();

            builder.RegisterType<LocadoraOrmContext>().As<IContextoPersistencia>().WithParameter("connectionString", "Data Source=(LocalDB)\\MSSqlLocalDB;Initial Catalog=DBLocadoraFCVSJ;Integrated Security=True;Pooling=False").InstancePerLifetimeScope();

            builder.RegisterType<RepositorioGrupoOrm>().As<IRepositorioGrupo>();
            builder.RegisterType<RepositorioTaxaOrm>().As<IRepositorioTaxa>();
            builder.RegisterType<RepositorioFuncionarioOrm>().As<IRepositorioFuncionario>();
            builder.RegisterType<RepositorioClienteOrm>().As<IRepositorioCliente>();
            builder.RegisterType<RepositorioPlanoDeCobrancaSql>().As<IRepositorioPlanoDeCobranca>();
            builder.RegisterType<RepositorioVeiculoOrm>().As<IRepositorioVeiculo>();
            builder.RegisterType<RepositorioCondutorSql>().As<IRepositorioCondutor>();

            builder.RegisterType<ServicoGrupo>().AsSelf();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ServicoPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ServicoCondutor>().AsSelf();

            builder.RegisterType<ControladorGrupo>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}