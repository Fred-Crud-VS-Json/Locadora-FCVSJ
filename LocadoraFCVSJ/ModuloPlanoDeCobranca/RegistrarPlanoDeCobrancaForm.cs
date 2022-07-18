using FluentResults;
using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.ModuloPlanoDeCobranca.Controles;
using System.Text;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca
{
    public partial class RegistrarPlanoDeCobrancaForm : KryptonForm
    {
        private readonly ServicoPlanoDeCobranca _servicoPlanoDeCobranca;
        private readonly ServicoGrupo _servicoGrupo;

        private PlanoDeCobranca planoDeCobranca;

        public readonly PlanoDiarioControl planoDiarioControl;
        public readonly PlanoLivreControl planoLivreControl;
        public readonly PlanoControladoControl planoControladoControl;

        public RegistrarPlanoDeCobrancaForm(ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoGrupo servicoGrupo)
        {
            InitializeComponent();

            _servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            _servicoGrupo = servicoGrupo;

            List<Grupo> gruposDisponiveis = new();

            _servicoGrupo.SelecionarTodos().Value.ForEach(x =>
            {
                if (!_servicoPlanoDeCobranca.SelecionarTodos().Value.Select(x => x.Grupo).Contains(x))
                    gruposDisponiveis.Add(x);
            });

            gruposDisponiveis.ForEach(x => CbxGrupo.Items.Add(x));

            planoDiarioControl = new(this);
            planoLivreControl = new(this);
            planoControladoControl = new(this);
        }

        public PlanoDeCobranca PlanoDeCobranca
        {
            get { return planoDeCobranca; }

            set
            {
                planoDeCobranca = value;

                if (PlanoDeCobranca.Grupo != null)
                {
                    CbxGrupo.Items.Add(planoDeCobranca.Grupo);
                    CbxGrupo.SelectedItem = planoDeCobranca.Grupo;
                    CbxGrupo.Enabled = false;
                }

                if (PlanoDeCobranca.PlanoDiario_ValorDiario != 0)
                    planoDiarioControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoDiario_ValorDiario.ToString("F2");

                if (PlanoDeCobranca.PlanoDiario_ValorKm != 0)
                    planoDiarioControl.TxbValorKm.Text = PlanoDeCobranca.PlanoDiario_ValorKm.ToString("F2");

                if (PlanoDeCobranca.PlanoLivre_ValorDiario != 0)
                    planoLivreControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoLivre_ValorDiario.ToString("F2");

                if (PlanoDeCobranca.PlanoControlado_ValorDiario != 0)
                    planoControladoControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoControlado_ValorDiario.ToString("F2");

                if (PlanoDeCobranca.PlanoControlado_ValorKm != 0)
                    planoControladoControl.TxbValorKm.Text = PlanoDeCobranca.PlanoControlado_ValorKm.ToString("F2");

                if (PlanoDeCobranca.PlanoControlado_LimiteKm != 0)
                    planoControladoControl.TxbLimiteKm.Text = PlanoDeCobranca.PlanoControlado_LimiteKm.ToString();
            }
        }

        public Func<PlanoDeCobranca, Result<PlanoDeCobranca>> SalvarRegistro { get; set; }

        private void BtnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                PlanoDeCobranca.Grupo = (Grupo)CbxGrupo.SelectedItem;

                Result<PlanoDeCobranca> resultado = SalvarRegistro(planoDeCobranca);

                if (resultado.IsFailed)
                {
                    StringBuilder erros = new();

                    foreach (Error erro in resultado.Errors)
                        erros.AppendLine(erro.Message);

                    MessageBox.Show(erros.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro ao registrar valores, verifique-os e tente novamente.", "Locadora FCSVJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.None;
            }
        }

        private void BtnDiario_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnLivre, BtnControlado, BtnDiario);
            ConfigurarPanel(planoDiarioControl);
        }

        private void BtnLivre_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnDiario, BtnControlado, BtnLivre);
            ConfigurarPanel(planoLivreControl);
        }

        private void BtnControlado_Click(object sender, EventArgs e)
        {
            ConfigurarBackgroundBotoes(BtnLivre, BtnDiario, BtnControlado);
            ConfigurarPanel(planoControladoControl);
        }

        private void ConfigurarPanel(UserControl controle)
        {
            PnlConteudo.Controls.Clear();
            PnlConteudo.Controls.Add(controle);

            controle.Focus();
        }

        private static void ConfigurarBackgroundBotoes(KryptonButton btn1, KryptonButton btn2, KryptonButton btn3)
        {
            btn1.StateCommon.Back.Color1 = Color.FromArgb(83, 142, 187);
            btn1.StateCommon.Back.Color2 = Color.FromArgb(83, 142, 187);
            btn1.StateCommon.Border.Color1 = Color.FromArgb(83, 142, 187);
            btn1.StateCommon.Border.Color2 = Color.FromArgb(83, 142, 187);

            btn2.StateCommon.Back.Color1 = Color.FromArgb(83, 142, 187);
            btn2.StateCommon.Back.Color2 = Color.FromArgb(83, 142, 187);
            btn2.StateCommon.Border.Color1 = Color.FromArgb(83, 142, 187);
            btn2.StateCommon.Border.Color2 = Color.FromArgb(83, 142, 187);

            btn3.StateCommon.Back.Color1 = Color.FromArgb(43, 95, 134);
            btn3.StateCommon.Back.Color2 = Color.FromArgb(43, 95, 134);
            btn3.StateCommon.Border.Color1 = Color.FromArgb(43, 95, 134);
            btn3.StateCommon.Border.Color2 = Color.FromArgb(43, 95, 134);
        }
    }
}