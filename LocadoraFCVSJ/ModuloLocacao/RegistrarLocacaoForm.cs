using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloLocacao;

namespace LocadoraFCVSJ.ModuloLocacao
{
    public partial class RegistrarLocacaoForm : KryptonForm
    {
        private Locacao locacao;
        public RegistrarLocacaoForm()
        {
            InitializeComponent();
        }

        private void BtnConcluir_Click(object sender, EventArgs e)
        {

        }

        public Func<Locacao, Result<Locacao>> SalvarRegistro { get; set; }

        public Locacao Locacao
        {
            get { return locacao; }

            set
            {
                locacao = value;

                MtxbDataLocacao.Text = locacao.DataLocacao.ToString();
            }
        }
    }
}