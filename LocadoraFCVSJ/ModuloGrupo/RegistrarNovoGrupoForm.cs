using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloGrupo;

namespace LocadoraFCVSJ.ModuloGrupo
{
    public partial class RegistrarNovoGrupoForm : KryptonForm
    {
        private Grupo grupo;

        public RegistrarNovoGrupoForm()
        {
            InitializeComponent();
        }

        public Grupo Grupo
        {
            get { return grupo; }

            set
            {
                grupo = value;

                kryptonTextBox1.Text = grupo.Nome;
            }
        }

        public Func<Grupo, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            grupo.Nome = kryptonTextBox1.Text;

            ValidationResult resultado = SalvarRegistro(grupo);

            if (resultado.IsValid == false)
            {
                MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;
            }
        }
    }
}