using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.DataAccess.Repository
{
    using System.Collections.Generic;

    using AdvisoryDatabase.Framework.Common;

    public interface IDataAccessRepository<TBaseEntity, TId> where TBaseEntity : BaseEntity<TId>
    {
        TBaseEntity Get(TId id);

        TBaseEntity Get(Dictionary<string, object> parameter);

        List<TBaseEntity> GetAll<TParentId>(TParentId parentId);

        List<TBaseEntity> GetAll(TBaseEntity entity);

        List<TBaseEntity> GetAll();

        TId Add(TBaseEntity entity);

        int Update(TBaseEntity entity);

        int Remove(TId id);

        int Remove(Dictionary<string, object> parameter);

        int RemoveAll<TParentId>(TParentId parentId);
    }
}
