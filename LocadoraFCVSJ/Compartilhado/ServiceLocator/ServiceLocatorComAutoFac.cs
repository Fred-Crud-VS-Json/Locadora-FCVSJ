using Autofac;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
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

            builder.RegisterType<RepositorioGrupoSql>().As<IRepositorioGrupo>();
            builder.RegisterType<RepositorioTaxaSql>().As<IRepositorioTaxa>();
            builder.RegisterType<RepositorioFuncionarioSql>().As<IRepositorioFuncionario>();
            builder.RegisterType<RepositorioClienteSql>().As<IRepositorioCliente>();
            builder.RegisterType<RepositorioPlanoDeCobrancaSql>().As<IRepositorioPlanoDeCobranca>();
            builder.RegisterType<RepositorioVeiculoSql>().As<IRepositorioVeiculo>();
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