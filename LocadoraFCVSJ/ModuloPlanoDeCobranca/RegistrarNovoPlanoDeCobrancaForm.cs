using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.ModuloPlanoDeCobranca.Controles;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca
{
    public partial class RegistrarNovoPlanoDeCobrancaForm : KryptonForm
    {
        private readonly ServicoPlanoDeCobranca _servicoPlanoDeCobranca;
        private readonly ServicoGrupo _servicoGrupo;

        private PlanoDeCobranca planoDeCobranca;

        private readonly PlanoDiarioControl planoDiarioControl;
        private readonly PlanoLivreControl planoLivreControl;
        private readonly PlanoControladoControl planoControladoControl;

        public RegistrarNovoPlanoDeCobrancaForm(ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoGrupo servicoGrupo)
        {
            InitializeComponent();

            _servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            _servicoGrupo = servicoGrupo;

            // Necessário revisão - 08/07/2022
            _servicoPlanoDeCobranca.SelecionarTodos().ForEach(x =>
            {
                _servicoGrupo.SelecionarTodos().ForEach(y =>
                {
                    if (!x.Grupo.Equals(y))
                        CbxGrupo.Items.Add(y);
                });
            });

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

                if (planoDeCobranca.Id != 0)
                {
                    CbxGrupo.Items.Add(planoDeCobranca.Grupo);
                    CbxGrupo.SelectedItem = planoDeCobranca.Grupo;
                    CbxGrupo.Enabled = false;
                    ChbxPlanoDiario.Checked = true;
                    ChbxPlanoLivre.Checked = true;
                    ChbxPlanoControlado.Checked = true;
                }

                planoDiarioControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoDiario_ValorDiario.ToString("F2");
                planoDiarioControl.TxbValorKm.Text = PlanoDeCobranca.PlanoDiario_ValorKm.ToString("F2");

                planoLivreControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoLivre_ValorDiario.ToString("F2");

                planoControladoControl.TxbValorDiario.Text = PlanoDeCobranca.PlanoControlado_ValorDiario.ToString("F2");
                planoControladoControl.TxbValorKm.Text = PlanoDeCobranca.PlanoControlado_ValorKm.ToString("F2");
                planoControladoControl.TxbLimiteKm.Text = PlanoDeCobranca.PlanoControlado_LimiteKm.ToString();
            }
        }

        public Func<PlanoDeCobranca, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                PlanoDeCobranca.Grupo = (Grupo)CbxGrupo.SelectedItem;

                ValidationResult resultado = SalvarRegistro(planoDeCobranca);

                if (ChbxPlanoDiario.Checked == false || ChbxPlanoLivre.Checked == false || ChbxPlanoControlado.Checked == false)
                    resultado.Errors.Add(new ValidationFailure("", "Todos os planos devem estar 100% cadastrados para concluir."));

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        private void ConfigurarBackgroundBotoes(KryptonButton btn1, KryptonButton btn2, KryptonButton btn3)
        {
            btn1.StateCommon.Back.Color1 = Color.FromArgb(0, 152, 74);
            btn1.StateCommon.Back.Color2 = Color.FromArgb(0, 152, 74);
            btn1.StateCommon.Border.Color1 = Color.FromArgb(0, 152, 74);
            btn1.StateCommon.Border.Color2 = Color.FromArgb(0, 152, 74);

            btn2.StateCommon.Back.Color1 = Color.FromArgb(0, 152, 74);
            btn2.StateCommon.Back.Color2 = Color.FromArgb(0, 152, 74);
            btn2.StateCommon.Border.Color1 = Color.FromArgb(0, 152, 74);
            btn2.StateCommon.Border.Color2 = Color.FromArgb(0, 152, 74);

            btn3.StateCommon.Back.Color1 = Color.FromArgb(17, 92, 54);
            btn3.StateCommon.Back.Color2 = Color.FromArgb(17, 92, 54);
            btn3.StateCommon.Border.Color1 = Color.FromArgb(17, 92, 54);
            btn3.StateCommon.Border.Color2 = Color.FromArgb(17, 92, 54);
        }

        private void ConfigurarPanel(UserControl controle)
        {
            PnlConteudo.Controls.Clear();
            PnlConteudo.Controls.Add(controle);

            controle.Focus();
        }
    }
}