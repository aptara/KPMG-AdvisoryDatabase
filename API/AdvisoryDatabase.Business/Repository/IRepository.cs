using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Business.Repository
{
    using System.Collections.Generic;

    using AdvisoryDatabase.Framework.Common;
    public interface IRepository<TBaseEntity, TId>
        where TBaseEntity : BaseEntity<TId>
    {
        #region Get All

        /// <summary>
        /// Get Filtered records
        /// </summary>
        /// <returns></returns>
        List<TBaseEntity> GetAll();

        List<TBaseEntity> GetAll<TParentId>(TParentId id);

        List<TBaseEntity> GetAll(TBaseEntity entity);


        #endregion

        #region "Get"

        /// <summary>
        /// Get the record by ID
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns></returns>
        TBaseEntity Get(TId id);

        TBaseEntity Get(Dictionary<string, object> parameters);


        #endregion

        #region "Add"

        /// <summary>
        /// Inserts a new entity into the repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TId Add(TBaseEntity entity);

        /// <summary>
        /// Inserts a new entity into the repository, and out the error collection
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errors">List of error or validation messages</param>
        /// <returns></returns>
        TId Add(TBaseEntity entity, out List<string> errors);

        #endregion

        #region "Update"

        /// <summary>
        /// Updates an existing entity in the repository, out number of records uopdated 
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        /// <param name="recordUpdated"></param>
        void Update(TBaseEntity entity, out int recordUpdated);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TBaseEntity entity);

        /// <summary>
        /// Updates an existing entity in the repository, and out the error collection
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errors">List of error or validation messages</param>
        /// <param name="recordUpdated"></param>
        void Update(TBaseEntity entity, out List<string> errors, out int recordUpdated);

        #endregion

        #region "Remove"

        /// <summary>
        /// Removes an entity from the repository, out number of records updated 
        /// </summary>
        /// <param name="id">Entity to remove.</param>
        /// <param name="recordUpdated"></param>
        void Remove(TId id, out int recordUpdated);


        void Remove(Dictionary<string, object> parameters);

        /// <summary>
        /// Removes an entity from the repository
        /// </summary>
        /// <param name="id"></param>
        void Remove(TId id);

        void RemoveAll<TParentId>(TParentId id);

        #endregion

        


    }
}
