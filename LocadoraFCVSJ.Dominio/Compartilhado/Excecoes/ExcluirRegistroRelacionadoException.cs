using System.Data.SqlClient;

namespace LocadoraFCVSJ.Dominio.Compartilhado.Excecoes
{
    public class ExcluirRegistroRelacionadoException : Exception
    {
        public ExcluirRegistroRelacionadoException(SqlException ex) : base("", ex) { }
    }
}