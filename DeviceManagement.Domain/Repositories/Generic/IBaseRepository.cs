using System.Linq.Expressions;

namespace DeviceManagement.Domain.Repositories.Generic
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<T> GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        Task<bool> Add(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Edit(T entity);

    }

    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
