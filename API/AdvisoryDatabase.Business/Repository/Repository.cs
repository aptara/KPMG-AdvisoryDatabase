using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Business.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Transactions;

    using AdvisoryDatabase.DataAccess.Common;
    using AdvisoryDatabase.DataAccess.Repository;
    using AdvisoryDatabase.Framework.Common;

    public abstract class Repository<TBaseEntity, TId> : IRepository<TBaseEntity, TId> where TBaseEntity : BaseEntity<TId>
    {

        internal DataAccessRepository<TBaseEntity, TId> DalManager;

        #region "Abstract Methods"

        /// <summary>
        /// Creates the data access manager.
        /// </summary>
        /// <returns></returns>
        protected abstract DataAccessRepository<TBaseEntity, TId> CreateDalManager();

        #endregion


        #region "Virtual Methods/Properties"

        /// <summary>
        /// Validate the entity to be added or updated. on validation fain override method should 
        /// throw an exception WKFException 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="operation"></param>
        protected virtual void Validate(TBaseEntity entity, OperationType operation)
        {
            // 
        }
        /// <summary>
        /// Check duplicate logic on duplicate override method should throw an
        /// exception of type WkfEception
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="operation"></param>
        protected virtual void CheckDuplicate(TBaseEntity entity, OperationType operation)
        {

        }

        /// <summary>
        /// Before removing the entity from the database 
        /// </summary>
        /// <param name="id"></param>
        protected virtual void BeforeRemove(TId id)
        {

        }

        /// <summary>
        /// After removing the entity from data base 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="numberOfrecordUpdated"></param>
        protected virtual void AfterRemove(TId id, int numberOfrecordUpdated)
        {

        }

        /// <summary>
        /// Bare minimum implementation for adding an entity instance. If overridden, 
        /// subclass should also perform all business validations.
        /// </summary>
        /// <remarks>Default implementation forwards the call to DAL manager
        /// </remarks>
        protected virtual TId AddRaw(TBaseEntity instance)
        {
            // Call the DAL
            this.Validate(instance, OperationType.Add);
            this.CheckDuplicate(instance, OperationType.Add);
            return this.GetDalManager().Add(instance);
        }


        protected virtual TId AddRaw(TBaseEntity instance, out List<string> errors)
        {
            errors = new List<string>();
            // Call the DAL
            this.Validate(instance, OperationType.Add);
            this.CheckDuplicate(instance, OperationType.Add);
            return this.GetDalManager().Add(instance);
        }

        /// <summary>
        /// Bare minimum implementation for updating an entity instance. If overridden, 
        /// subclass should also perform all business validations.
        /// </summary>
        /// <remarks>Default implementation forwards the call to DAL manager
        /// </remarks>
        protected virtual void UpdateRaw(TBaseEntity instance)
        {
            // Call the DAL
            this.Validate(instance, OperationType.Update);
            this.CheckDuplicate(instance, OperationType.Update);
            this.GetDalManager().Update(instance);
        }

        /// <summary>
        /// Bare minimum implementation for updating an entity instance. If overridden, 
        /// subclass should also perform all business validations.
        /// </summary>
        /// <remarks>Default implementation forwards the call to DAL manager
        /// </remarks>
        /// <param name="instance"></param>
        /// <param name="recordUpdated"></param>
        protected virtual void UpdateRaw(TBaseEntity instance, out int recordUpdated)
        {
            // Call the DAL
            this.Validate(instance, OperationType.Update);
            this.CheckDuplicate(instance, OperationType.Update);
            recordUpdated = this.GetDalManager().Update(instance);
        }

        /// <summary>
        /// Bare minimum implementation for updating an entity instance. If overridden, 
        /// subclass should also perform all business validations.
        /// </summary>
        /// <remarks>Default implementation forwards the call to DAL manager
        /// </remarks>
        /// <param name="instance"></param>
        /// <param name="errors"></param>
        /// <param name="recordUpdated"></param>
        protected virtual void UpdateRaw(TBaseEntity instance, out List<string> errors, out int recordUpdated)
        {
            errors = new List<string>();
            // Call the DAL
            this.Validate(instance, OperationType.Update);
            this.CheckDuplicate(instance, OperationType.Update);
            recordUpdated = this.GetDalManager().Update(instance);
        }

        /// <summary>
        /// Bare minimum implementation for deleting an entity instance. If overridden, 
        /// subclass should also perform all business validations.
        /// </summary>
        /// <remarks>Default implementation forwards the call to DAL manager
        /// </remarks>
        protected virtual void RemoveRaw(TId id)
        {
            // Call the DAL
            this.BeforeRemove(id);
            var updatedRecoeds = this.GetDalManager().Remove(id);
            this.AfterRemove(id, updatedRecoeds);
        }

        protected virtual int RemoveRawRegLib(TId id)
        {
            // Call the DAL
            this.BeforeRemove(id);
            int updatedRecoeds = this.GetDalManager().RemoveRegLib(id);
            this.AfterRemove(id, updatedRecoeds);
            return Convert.ToInt32(updatedRecoeds);
        }

        protected virtual int RemoveRssFeedById(TBaseEntity id)
        {
            // Call the DAL
            //this.BeforeRemove(id);
            int updatedRecoeds = this.GetDalManager().RemoveRssFeedById(id);
            //this.AfterRemove(id, updatedRecoeds);
            return Convert.ToInt32(updatedRecoeds);
        }


        protected virtual void RemoveRaw(Dictionary<string, object> parameters)
        {
            this.GetDalManager().Remove(parameters);
        }


        protected virtual void RemoveAllRaw<TParentId>(TParentId id)
        {
            this.GetDalManager().RemoveAll(id);
        }

        /// <summary>
        /// Bare minimum implementation for deleting an entity instance. If overridden, 
        /// subclass should also perform all business validations.
        /// </summary>
        /// <remarks>Default implementation forwards the call to DAL manager
        /// </remarks>
        protected virtual void RemoveRaw(TId id, out int recordUpdated)
        {
            this.BeforeRemove(id);
            // Call the DAL
            recordUpdated = this.GetDalManager().Remove(id);
            this.AfterRemove(id, recordUpdated);
        }

        /// <summary>
        /// Bare minimum implementation for retrieving an entity instance. 
        /// If overridden, subclass should perform all business validations.
        /// </summary>
        /// <remarks>Default implementation forwards the call to DAL manager
        /// </remarks>
        protected virtual TBaseEntity GetRaw(TId id)
        {
            // Call the DAL
            return this.GetDalManager().Get(id);
        }

        protected virtual TBaseEntity GetRaw(Dictionary<string, object> parameters)
        {
            // Call the DAL
            return this.GetDalManager().Get(parameters);
        }

        protected virtual TBaseEntity GetRaw(TBaseEntity entity)
        {
            // Call the DAL
            return this.GetDalManager().Get(entity);
        }

        protected virtual List<TBaseEntity> GetAllRaw()
        {
            //call the DAL
            return this.GetDalManager().GetAll();
        }

        protected virtual List<TBaseEntity> GetAllRaw<TParentId>(TParentId parentId)
        {
            //call the DAL
            return this.GetDalManager().GetAll(parentId);
        }

        protected virtual List<TBaseEntity> GetAllRaw(TBaseEntity entity)
        {
            //call the DAL
            return this.GetDalManager().GetAll(entity);
        }

        protected virtual void ActivateDeactivateRaw(TId id, bool status)
        {
            var entity = this.Get(id);
            ActivateDeactivateRaw(entity, status);
        }

        protected virtual void ActivateDeactivateRaw(TBaseEntity entity, bool status)
        {
            entity.IsActive = status;
            this.Update(entity);
        }

        #endregion

        #region "Protected Members"

        protected DataAccessRepository<TBaseEntity, TId> GetDalManager()
        {
            return this.DalManager ?? (this.DalManager = this.CreateDalManager());
        }

        #endregion




        #region "Public repository Methods"

        public List<TBaseEntity> GetAll()
        {
            return this.GetAllUnsecure();
        }

        public List<TBaseEntity> GetAll(TBaseEntity entity)
        {
            return this.GetAllUnsecure(entity);
        }

        public List<TBaseEntity> GetAll<TParentId>(TParentId parentId)
        {
            return this.GetAllUnsecure(parentId);
        }
        
        public TBaseEntity Get(TId id)
        {
            return this.GetUnsecure(id);
        }

        public TBaseEntity Get(Dictionary<string, object> parameters)
        {
            return this.GetUnsecure(parameters);
        }

        public TBaseEntity Get(TBaseEntity entity)
        {
            return this.GetUnsecure(entity);
        }
        public TId Add(TBaseEntity entity)
        {
            return AddUnsecure(entity);
        }

        public TId Add(TBaseEntity entity, out List<string> errors)
        {
            return AddUnsecure(entity, out errors);
        }

        public void Update(TBaseEntity entity, out int recordUpdated)
        {
            UpdateUnsecure(entity, out recordUpdated);
        }

        public void Update(TBaseEntity entity)
        {
            UpdateUnsecure(entity);
        }

        public void Update(TBaseEntity entity, out List<string> errors, out int recordUpdated)
        {
            UpdateUnsecure(entity, out errors, out recordUpdated);
        }

        public void Remove(Dictionary<string, object> parameters)
        {
            RemoveUnsecure(parameters);
        }

        public void Remove(TId id, out int recordUpdated)
        {
            RemoveUnsecure(id, out recordUpdated);
        }

        public void Remove(TId id)
        {
            RemoveUnsecure(id);
        }

        public int RemoveRegLib(TId id)
        {
            int countRecord = RemoveUnsecureRegLib(id);
            return countRecord;
        }

        public int RemoveRssFeed(TBaseEntity id)
        {
            int countRecord = DeleteRssFeed(id);
            return countRecord;
        }

        public void RemoveAll<TParentId>(TParentId id)
        {
            RemoveAllUnsecure(id);
        }

       /* public void ActivateDeactivate(TId id, bool status)
        {
            ActivateDeactivateUnsecure(id, status);
        }*/

      /*  public void ActivateDeactivate(TBaseEntity entity, bool status)
        {
            ActivateDeactivateUnsecure(entity, status);
        }*/

        #endregion



        #region "Internal repository Methods"

        internal List<TBaseEntity> GetAllUnsecure()
        {
            return this.GetAllRaw();
        }

        internal List<TBaseEntity> GetAllUnsecure(TBaseEntity entity)
        {
            return this.GetAllRaw(entity);
        }

        internal List<TBaseEntity> GetAllUnsecure<TParentId>(TParentId parentId)
        {
            return this.GetAllRaw(parentId);
        }
        
        internal TBaseEntity GetUnsecure(TId id)
        {
            return this.GetRaw(id);
        }

        internal TBaseEntity GetUnsecure(Dictionary<string, object> parameters)
        {
            return this.GetRaw(parameters);
        }

        internal TBaseEntity GetUnsecure(TBaseEntity entity)
        {
            return this.GetRaw(entity);
        }

        internal TId AddUnsecure(TBaseEntity entity)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    var id = this.AddRaw(entity);
                    // Complete the transaction
                    scope.Complete();
                    return id;
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
                return entity.Id;
            }
        }

        internal TId AddUnsecure(TBaseEntity entity, out List<string> errors)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    var id = this.AddRaw(entity, out errors);
                    // Complete the transaction
                    scope.Complete();
                    return id;
                }
            }
            catch (TransactionAbortedException ex)
            {
                errors = new List<string>();
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
                return entity.Id;
            }
        }

        internal void UpdateUnsecure(TBaseEntity entity, out int recordUpdated)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.UpdateRaw(entity, out recordUpdated);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                recordUpdated = 0;
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }

        }

        internal void UpdateUnsecure(TBaseEntity entity)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.UpdateRaw(entity);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        internal void UpdateUnsecure(TBaseEntity entity, out List<string> errors, out int recordUpdated)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.UpdateRaw(entity, out errors, out recordUpdated);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                recordUpdated = 0;
                errors = new List<string>();
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        internal void RemoveUnsecure(TId id, out int recordUpdated)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.RemoveRaw(id, out recordUpdated);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                recordUpdated = 0;
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        internal void RemoveUnsecure(Dictionary<string, object> parameters)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.RemoveRaw(parameters);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        internal void RemoveUnsecure(TId id)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.RemoveRaw(id);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        internal int DeleteRssFeed(TBaseEntity id)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    int count = this.RemoveRssFeedById(id);
                    // Complete the transaction
                    scope.Complete();
                    return count;

                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
            return 0;
        }


        internal int RemoveUnsecureRegLib(TId id)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    int count = this.RemoveRawRegLib(id);
                    // Complete the transaction
                    scope.Complete();
                    return count;

                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
            return 0;
        }

        internal void RemoveAllUnsecure<TParentId>(TParentId id)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.RemoveAllRaw(id);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        internal void ActivateDeactivateUnsecure(TId id, bool status)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.ActivateDeactivateRaw(id, status);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        internal void ActivateDeactivateUnsecure(TBaseEntity enetity, bool status)
        {
            try
            {
                using (var scope = DbHelper.CreateTransactionScope())
                {
                    // Invoke raw implementation
                    this.ActivateDeactivateRaw(enetity, status);
                    // Complete the transaction
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
        }

        #endregion

        #region "Private Members"




        #endregion

    }
}
