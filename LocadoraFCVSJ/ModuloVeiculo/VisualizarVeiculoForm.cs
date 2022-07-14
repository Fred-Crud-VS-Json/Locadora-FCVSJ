using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public partial class VisualizarVeiculoForm : KryptonForm
    {
        private readonly Veiculo _veiculo;
        public VisualizarVeiculoForm(Veiculo veiculo)
        {
            InitializeComponent();
            _veiculo = veiculo;

            TxbGrupo.Text = _veiculo.Grupo.Nome;
            TxbModelo.Text = _veiculo.Modelo;
            TxbMarca.Text = _veiculo.Marca;
            TxbPlaca.Text = _veiculo.Placa;
            TxbCor.Text = _veiculo.Cor;
            TxbTipoCombustivel.Text = _veiculo.TipoCombustivel.ToString();
            TxbCapacidadeDoTanque.Text = _veiculo.CapacidadeTanque.ToString();
            TxbAno.Text = _veiculo.Ano.ToString();
            TxbKmPercorrido.Text = _veiculo.KmPercorrido.ToString();
            PbxFoto.Image = ObterImagem();
        }
        private Bitmap ObterImagem()
        {
            if (_veiculo.Foto != null)
            {
                using (MemoryStream ms = new(_veiculo.Foto))
                    return new Bitmap(ms);
            }
            return null;
        }
    }
}