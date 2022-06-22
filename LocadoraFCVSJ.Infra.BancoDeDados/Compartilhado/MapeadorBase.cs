using LocadoraFCVSJ.Dominio.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract void ConfigurarParametros(T Registro, SqlCommand comando);

        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);   
    }
}