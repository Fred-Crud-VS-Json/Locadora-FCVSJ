using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {
        Veiculo? SelecionarPorModelo(string modelo);
        Veiculo? SelecionarPorPlaca(string placa);
    }
}