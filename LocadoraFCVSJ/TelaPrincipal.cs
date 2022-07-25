using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Compartilhado.ServiceLocator;
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

namespace LocadoraFCVSJ
{
    public partial class TelaPrincipal : KryptonForm
    {
        private static TelaPrincipal _instancia;

        private ControladorBase? controlador;
        private readonly IServiceLocator _serviceLocator;

        public TelaPrincipal(IServiceLocator serviceLocator)
        {
            InitializeComponent();

            _serviceLocator = serviceLocator;

            _instancia = this;
        }

        public static TelaPrincipal Instancia { get { return _instancia; } }

        private void BtnAcessarGrupos_Click(object sender, EventArgs e)
        {
            AbrirTela(_serviceLocator.Get<ControladorGrupo>());
        }

        private void BtnAcessarTaxas_Click(object sender, EventArgs e)
        {
            AbrirTela(_serviceLocator.Get<ControladorTaxa>());
        }

        private void BtnAcessarFuncionarios_Click(object sender, EventArgs e)
        {
            AbrirTela(_serviceLocator.Get<ControladorFuncionario>());
        }

        private void BtnAcessarClientes_Click(object sender, EventArgs e)
        {
            AbrirTela(_serviceLocator.Get<ControladorCliente>());
        }

        private void BtnAcessarPlanos_Click(object sender, EventArgs e)
        {
            AbrirTela(_serviceLocator.Get<ControladorPlanoDeCobranca>());
        }

        private void BtnAcessarVeiculos_Click(object sender, EventArgs e)
        {
            AbrirTela(_serviceLocator.Get<ControladorVeiculo>());
        }

        private void BtnAcessarCondutores_Click(object sender, EventArgs e)
        {
            AbrirTela(_serviceLocator.Get<ControladorCondutor>());
        }

        private void AbrirTela(ControladorBase controladorBase)
        {
            controlador = controladorBase;

            WindowState = FormWindowState.Minimized;

            controlador.ObterTela().ShowDialog();
        }

    }
}