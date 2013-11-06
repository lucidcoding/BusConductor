using System.Collections.Generic;
using System.Linq;

namespace BusConductor.Domain.Common
{
    public interface IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        void Save(TEntity obj);
        void Update(TEntity obj);
        TEntity GetById(TId id);
        IList<TEntity> GetAll();
        //IList<TEntity> GetByIds(List<TId> ids);
        //void Flush();
        //void Clear();
    }
}