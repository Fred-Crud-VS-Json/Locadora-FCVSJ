using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.Compartilhado
{
    public abstract class RepositorioBaseOrm<T> : IRepositorio<T> where T : EntidadeBase<T>
    {
        private readonly DbContext _dbContext;
        protected DbSet<T> _dbSet;

        public RepositorioBaseOrm(IContextoPersistencia dbContext)
        {
            _dbContext = (LocadoraOrmContext)dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual void Inserir(T registro)
        {
            if (_dbSet.Contains(registro) == false)
                _dbSet.Add(registro);
        }

        public virtual void Editar(T registro)
        {
            T? registroSelecionado = _dbSet.Find(registro.Id);

            if (registroSelecionado != null)
                _dbSet.Update(registroSelecionado);
        }

        public virtual void Excluir(T registro)
        {
            T? registroSelecionado = _dbSet.Find(registro.Id);

            if (registroSelecionado != null)
                _dbSet.Remove(registroSelecionado);
        }

        public virtual T? SelecionarPorId(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual List<T> SelecionarTodos()
        {
            return _dbSet.ToList();
        }
    }
}