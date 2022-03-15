using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Repositories.Generic
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<T> GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }

    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
