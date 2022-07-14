using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using System.Text;

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

                TxbNome.Text = grupo.Nome;
            }
        }

        public Func<Grupo, Result<Grupo>> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            grupo.Nome = TxbNome.Text;

            Result<Grupo> resultado = SalvarRegistro(grupo);

            if (resultado.IsFailed)
            {
                StringBuilder erros = new();

                foreach(Error erro in resultado.Errors)
                    erros.AppendLine(erro.Message);

                MessageBox.Show(erros.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;
            }
        }
    }
}