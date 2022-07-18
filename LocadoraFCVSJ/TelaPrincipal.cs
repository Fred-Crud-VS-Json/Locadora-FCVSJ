using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Compartilhado;
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
        private readonly Dictionary<string, ControladorBase> controladores;

        public TelaPrincipal()
        {
            InitializeComponent();

            _instancia = this;

            ServicoGrupo servicoGrupo = new(new RepositorioGrupo());
            ServicoTaxa servicoTaxa = new(new RepositorioTaxa());
            ServicoCliente servicoCliente = new(new RepositorioCliente());
            ServicoFuncionario servicoFuncionario = new(new RepositorioFuncionario());
            ServicoPlanoDeCobranca servicoPlanoDeCobranca = new(new RepositorioPlanoDeCobranca());
            ServicoVeiculo servicoVeiculo = new(new RepositorioVeiculo());
            ServicoCondutor servicoCondutor = new(new RepositorioCondutor(), servicoCliente);


            controladores = new()
            {
                { "Grupos", new ControladorGrupo(servicoGrupo) },
                { "Funcionarios", new ControladorFuncionario(servicoFuncionario) },
                { "Taxas", new ControladorTaxa(servicoTaxa) },
                { "Clientes", new ControladorCliente(servicoCliente) },
                { "Planos", new ControladorPlanoDeCobranca(servicoGrupo, servicoPlanoDeCobranca) },
                { "Condutores", new ControladorCondutor(servicoCondutor, servicoCliente) },
                { "Veiculos", new ControladorVeiculo(servicoVeiculo, servicoGrupo) }
            };
        }

        public static TelaPrincipal Instancia { get { return _instancia; } }

        private void BtnAcessarGrupos_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarGrupos);
        }

        private void BtnAcessarTaxas_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarTaxas);
        }

        private void BtnAcessarFuncionarios_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarFuncionarios);
        }

        private void BtnAcessarClientes_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarClientes);
        }

        private void BtnAcessarPlanos_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarPlanos);
        }

        private void BtnAcessarVeiculos_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarVeiculos);
        }

        private void BtnAcessarCondutores_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarCondutores);
        }

        private void AbrirTela(KryptonButton botao)
        {
            controlador = controladores[botao.AccessibleName];

            WindowState = FormWindowState.Minimized;

            controlador.ObterTela().ShowDialog();
        }

    }
}