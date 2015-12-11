using System;
using System.Linq;

namespace DataSource
{
  public class BaseRepository<T> : IRepository<T> where T: class, IEntity
  {
    protected readonly HikkaTubeEntities _hikkaTubeEntities;

    public BaseRepository(HikkaTubeEntities hikkaTubeEntities)
    {
      _hikkaTubeEntities = hikkaTubeEntities;
    }

    public void Add(T entity)
    {
      _hikkaTubeEntities.Set<T>().Add(entity);
    }

    public void Update(T oldEntity, T newEntity)
    {
      _hikkaTubeEntities.Set<T>().Remove(oldEntity);
      _hikkaTubeEntities.Set<T>().Add(newEntity);
    }

    public T GetById(Guid id)
    {
      return _hikkaTubeEntities.Set<T>().FirstOrDefault(e => e.Id == id);
    }

    public IQueryable<T> GetAll()
    {
      return _hikkaTubeEntities.Set<T>();
    }

    public IQueryable<T> GetAll(Func<T, bool> predicate)
    {
      return _hikkaTubeEntities.Set<T>().Where(predicate).AsQueryable();
    }

    public void Delete(T entity)
    {
      _hikkaTubeEntities.Set<T>().Remove(entity);
    }

    public void Delete(Guid id)
    {
      var entity = GetById(id);
      _hikkaTubeEntities.Set<T>().Remove(entity);
    }

    public void Commit()
    {
      _hikkaTubeEntities.SaveChanges();
    }
  }
}
