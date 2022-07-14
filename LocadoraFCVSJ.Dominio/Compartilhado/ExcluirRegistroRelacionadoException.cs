using System.Data.SqlClient;

namespace LocadoraFCVSJ.Dominio.Compartilhado
{
    public class ExcluirRegistroRelacionadoException : Exception
    {
        public ExcluirRegistroRelacionadoException(SqlException ex) : base("", ex) { }
    }
}