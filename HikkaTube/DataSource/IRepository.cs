using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
  public interface IRepository<T> where T : IEntity
  {
    void Add(T entity);

    void Update(T oldEntity, T newEntity);

    T GetById(Guid id);

    IQueryable<T> GetAll();

    IQueryable<T> GetAll(Func<T, bool> predicate);

    void Delete(T entity);

    void Delete(Guid id);

    void Commit();
  }
}
