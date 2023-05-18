using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.DataAccess.Repository
{
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;

    using AdvisoryDatabase.DataAccess.Common;
    using AdvisoryDatabase.Framework.Common;
    public abstract class DataAccessRepository<TBaseEntity, TId> : IDataAccessRepository<TBaseEntity, TId> where TBaseEntity : BaseEntity<TId>
    {
        #region "Nested Types"

        /// <summary>
        /// Common parameters that this manager class can handle
        /// </summary>
        protected enum ParameterType
        {
            /// <summary>
            /// Parameter to indicate the edit operation. Operation parameter 
            /// is not applicable (and not added) for get operation.
            /// </summary>
            Operation = 0,

            /// <summary>
            /// Id parameter
            /// </summary>
            Id = 1,

            LastUpdatedOn = 2,
            LastUpdatedBy = 3,
            CreatedOn = 4,
            CreatedBy = 5
        }

        #endregion

        #region "Static Members"        
        protected const string LastUpdatedOn = "LastUpdatedOn";
        protected const string LastUpdatedBy = "LastUpdatedBy";
        protected const string CreatedOn = "CreatedOn";
        protected const string CreatedBy = "CreatedBy";
        private static readonly string[] ParametersNames;

        static DataAccessRepository()
        {
            ParametersNames = new string[6];
            ParametersNames[(int)ParameterType.Operation] = "Operation";
            ParametersNames[(int)ParameterType.Id] = "Id";
            ParametersNames[(int)ParameterType.LastUpdatedOn] = "LastUpdatedOn";
            ParametersNames[(int)ParameterType.LastUpdatedBy] = "LastUpdatedBy";
            ParametersNames[(int)ParameterType.CreatedOn] = "CreatedOn";
            ParametersNames[(int)ParameterType.CreatedBy] = "CreatedBy";
        }

        #endregion

        #region Repository Public methods

        /// <summary>
        /// Gets list of all entity instances for the given parent id.
        /// </summary>
        /// <typeparam name="TParentId">type of parent id</typeparam>
        public List<TBaseEntity> GetAll<TParentId>(TParentId parentId)
        {
            // Create parameters
            var parameters = CreateParentIdParameters<TParentId>(parentId, OperationType.GetAll);

            // Execute the command to get the data
            var data = DbHelper.ExecuteDataSet(
                GetProcedureName(OperationType.GetAll), parameters.ToArray());
            // Convert data to entity instance
            var instances = this.ParseGetAllData(data);
            return instances;
        }

        /// <summary>
        /// Gets list of all entity instances for the given parent id.
        /// </summary>
        /// <typeparam name="TParentId">type of parent id</typeparam>
        public List<TBaseEntity> GetAll(TBaseEntity entity)
        {
            // Create parameters
            var parameters = CreateParameters(OperationType.GetAll, entity);

            // Execute the command to get the data
            var data = DbHelper.ExecuteDataSet(
                GetProcedureName(OperationType.GetAll), parameters);
            // Convert data to entity instance
            var instances = this.ParseGetAllData(data);
            return instances;
         }
        
       
        public TBaseEntity Get(Dictionary<string, object> parameter)
        {
            // Create parameters
            // Add extra parameters from override
            var dbParameters = new List<DbParameter>();
            this.FillGetParameters(parameter, dbParameters);
            // Execute the command to get the data
            var data = DbHelper.ExecuteDataSet(GetProcedureName(OperationType.Get), dbParameters.ToArray());
            // Convert data to entity instance
            var instance = this.ParseGetData(data);
            return instance;
        }

        /// <summary>
        /// Get the entity instance for the given id from the data store
        /// </summary>
        /// <returns>Returns null if instance with given id could not be found
        /// </returns>
        public TBaseEntity Get(TId id)
        {
            // Create parameters
            var parameters = CreateParameters(OperationType.Get, id);
            // Execute the command to get the data
            var data = DbHelper.ExecuteDataSet(GetProcedureName(OperationType.Get), parameters);
            // Convert data to entity instance
            var instance = this.ParseGetData(data);
            return instance;
        }

        /// <summary>
        /// Get the entity instance for the given entity from the data store
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns null if instance with given entity could not be found</returns>
        public TBaseEntity Get(TBaseEntity entity)
        {
            // Create parameters
            var parameters = CreateParameters(OperationType.Get, entity);

            // Execute the command to get the data
            try
            {
                var data = DbHelper.ExecuteDataSet(GetProcedureName(OperationType.Get), parameters);
                var instance = this.ParseGetData(data);
                return instance;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            // Convert data to entity instance


        }
        /// <summary>
        /// Gets list of all entity instances.
        /// </summary>
        public List<TBaseEntity> GetAll()
        {
            var parameter = DbHelper.CreateParameter("Operation", (int)OperationType.GetAll);

            // Execute the command to get the data
            var data = DbHelper.ExecuteDataSet(GetProcedureName(OperationType.GetAll), parameter);
            // Convert data to entity instance
            var instances = this.ParseGetAllData(data);

            return instances;
        }

        public TId Add(TBaseEntity instance)
        {
            var scope = DbHelper.CreateTransactionScope();
            try
            {
                // Invoke Before Hook
                this.BeforeAddUpdate(OperationType.Add, instance);
                // Create parameters
                var parameters = CreateParameters(OperationType.Add, instance);
                // Execute the command
                var idValue = DbHelper.ExecuteScalar(GetProcedureName(OperationType.Add), parameters);
                //WkfsLogger.WriteInfo(string.Format("Params {0}", string.Join(", ", parameters.Select(f=> f.Value).ToList())));
                TId id = default(TId);
                if (idValue != null)
                    id = (TId)idValue;
                // Invoke After Hook
                this.AfterAddUpdate(OperationType.Add, id, instance);
                // Complete transaction
                scope.Complete();
                return id;
            }
            catch (DbException e)
            {
                // Parse the exception
                if (DbHelper.HandleDbException(OperationType.Add, e))
                {
                    throw;
                }
                return default(TId);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// Updates the given entity instance into the data store. 
        /// </summary>
        public int Update(TBaseEntity instance)
        {

            var scope = DbHelper.CreateTransactionScope();
            try
            {
                // Invoke Before Hook
                this.BeforeAddUpdate(OperationType.Update, instance);
                // Create parameters
                var parameters = CreateParameters(OperationType.Update, instance);
                // Execute the command
                var rowUpdated = DbHelper.ExecuteNonQuery(
                    GetProcedureName(OperationType.Update), parameters);
                // Invoke After Hook
                this.AfterAddUpdate(OperationType.Update, instance.Id, instance);
                // Complete transaction
                scope.Complete();
                return rowUpdated;
            }
            catch (DbException e)
            {
                // Parse the exception
                if (DbHelper.HandleDbException(OperationType.Update, e))
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                scope.Dispose();
            }
            return 0;
        }

        public int Remove(Dictionary<string, object> parameters)
        {
            var scope = DbHelper.CreateTransactionScope();
            try
            {
                var dbParameters = new List<DbParameter>();
                this.FillGetParameters(parameters, dbParameters);
                var found =
                    dbParameters.Find(
                        f => f.ParameterName.Equals("@Operation", StringComparison.CurrentCultureIgnoreCase));
                if (null == found)
                {
                    dbParameters.Add(DbHelper.CreateParameter("Operation", (int)OperationType.Delete));
                }
                // Execute the command
                var rowUpdate = DbHelper.ExecuteNonQuery(
                    GetProcedureName(OperationType.Delete), dbParameters.ToArray());

                // Complete transaction
                scope.Complete();
                return rowUpdate;
            }
            catch (DbException e)
            {
                // Parse the exception
                if (DbHelper.HandleDbException(OperationType.Delete, e))
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                scope.Dispose();
            }
            return 0;

        }

        /// <summary>
        /// Deletes the entiy instance with given id from the data store.
        /// </summary>
        public int Remove(TId id)
        {
            var scope = DbHelper.CreateTransactionScope();
            try
            {
                // Invoke Before Hook
                this.BeforeDelete(id);
                // Create parameters
                var parameters = CreateParameters(OperationType.Delete, id);
                // Execute the command
                var rowUpdate = DbHelper.ExecuteScalar(
                    GetProcedureName(OperationType.Delete), parameters);
                // Invoke After Hook
                this.AfterDelete(id);
                // Complete transaction
                scope.Complete();
                return Convert.ToInt32(rowUpdate);
            }
            catch (DbException e)
            {
                // Parse the exception
                if (DbHelper.HandleDbException(OperationType.Delete, e))
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                scope.Dispose();
            }
            return 0;
        }


        /// </summary>
        public int RemoveRegLib(TId id)
        {
            var scope = DbHelper.CreateTransactionScope();
            try
            {
                // Invoke Before Hook
                this.BeforeDelete(id);
                // Create parameters
                var parameters = CreateParameters(OperationType.Delete, id);
                // Execute the command
                var rowUpdate = DbHelper.ExecuteScalar(
                    GetProcedureName(OperationType.Delete), parameters);
                // Invoke After Hook
                this.AfterDelete(id);
                // Complete transaction
                scope.Complete();
                return Convert.ToInt32(rowUpdate);
            }
            catch (DbException e)
            {
                // Parse the exception
                if (DbHelper.HandleDbException(OperationType.Delete, e))
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                scope.Dispose();
            }
            return 0;
        }

        public int RemoveRssFeedById(TBaseEntity id)
        {
            var scope = DbHelper.CreateTransactionScope();
            try
            {
                var parameters = CreateParameters(OperationType.Delete, id);
                var rowUpdate = DbHelper.ExecuteScalar(
                GetProcedureName(OperationType.Delete), parameters);
                scope.Complete();
                return Convert.ToInt32(rowUpdate);
            }
            catch (DbException e)
            {
                if (DbHelper.HandleDbException(OperationType.Delete, e))
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                scope.Dispose();
            }
            return 0;
        }

        public int RemoveAll<TParentId>(TParentId parentId)
        {
            // Create parameters
            var parameters = CreateParameters(OperationType.Delete, parentId);

            return DbHelper.ExecuteNonQuery(GetProcedureName(OperationType.Delete), parameters);
        }



        #endregion

        #region "Abstract Methods"

        /// <summary>
        /// Gets the procedure name to execute for the given operation
        /// </summary>
        protected abstract string GetProcedureName(OperationType operation);


        /// <summary>
        /// Gets the procedure name to execute for the given operation
        /// </summary>
        //protected abstract string GetProcedureName(OperationType operation,string recordType);

        /// <summary>
        /// Creates and fills parameters for performing the given operation on
        /// the given entity instance. Invoked for Add and Update operation.
        /// </summary>
        protected abstract void FillParameters(OperationType operation, TBaseEntity instance, List<DbParameter> parameters);

        /// <summary>
        /// Creates the entity instance from the given data.
        /// </summary>
        protected abstract TBaseEntity Parse(DataRow data);

        #endregion

        #region "Virtual Methods (Protected)"
        /// <summary>
        /// Can change the default parent id parameter to custom
        /// </summary>
        protected virtual List<DbParameter> CreateParentIdParameters<TParentId>(TParentId parentId, OperationType operation)
        {
            return new List<DbParameter>
                                 {
                                     DbHelper.CreateParameter("ParentId", parentId),
                                     DbHelper.CreateParameter("Operation", (int)operation)
                                 };
        }

        /// <summary>
        /// Parses the dataset returned by Get procedure. Default implementation
        /// parses the first row from the first table into the main entity instance.
        /// </summary>
        protected virtual TBaseEntity ParseGetData(DataSet data)
        {
            if (data.Tables.Count > 0)
            {
                var rows = data.Tables[0].Rows;
                if (rows.Count > 0)
                {
                    var row = rows[0];
                    var instance = this.Parse(row);
                    this.ReadCommonAttributes(row, instance);
                    return instance;
                }
            }
            return null;
        }

        /// <summary>
        /// Parses the dataset returned by GetAll procedure. Default implementation
        /// parses the all row from the first table into the main entity instance.
        /// </summary>
        protected virtual List<TBaseEntity> ParseGetAllData(DataSet data)
        {
            var instances = new List<TBaseEntity>();
            if (data.Tables.Count <= 0)
            {
                return instances;
            }
            var rows = data.Tables[0].Rows;
            if (rows.Count <= 0)
            {
                return instances;
            }
            foreach (DataRow row in rows)
            {
                var instance = this.Parse(row);
                this.ReadCommonAttributes(row, instance);
                instances.Add(instance);
            }
            return instances;
        }

        /// <summary>
        /// Reads common attributes such as CreatedOn, CreatedBy, LastUpdated
        /// and LastUpdatedBy.
        /// </summary>
        protected virtual void ReadCommonAttributes(DataRow row, BaseEntity<TId> instance)
        {
            instance.CreatedOn = row.Read<DateTime>("CreatedOn");
            instance.CreatedBy = row.Read<int>("CreatedBy");
            instance.LastUpdatedOn = row.Read<DateTime>("LastUpdatedOn");
            instance.LastUpdatedBy = row.Read<int>("LastUpdatedBy");
        }

        /// <summary>
        /// Gets the name of given common parameter type. Subclass can override this
        /// method if default names are not correct. Subclass can also return empty
        /// string to indicate not to add the common parameter.
        /// </summary>
        protected virtual string GetParameterName(ParameterType parameter)
        {
            return ParametersNames[(int)parameter];
        }

        /// <summary>
        /// Creates and fills parameters for performing the given operation on
        /// the given entity instance id. Invoked for Get, Delete and 
        /// UpdateLastUpdated operation.
        /// </summary>
        protected virtual void FillParameters(OperationType operation, TId id, List<DbParameter> parameters)
        {
            // Do nothing
        }

        /// <summary>
        /// Creates and fills parameters for performing the given operation on
        /// the given entity instance id. Invoked for GetAll operation.
        /// </summary>
        protected virtual void FillParameters<TParentId>(OperationType operation, TParentId parentId, List<DbParameter> parameters)
        {
            // Do nothing
        }

        protected virtual void FillGetParameters(Dictionary<string, object> spParametres, List<DbParameter> parameters)
        {
            parameters.AddRange(spParametres.Select(p => DbHelper.CreateParameter(p.Key, p.Value)));
        }

        protected virtual void AddCommonParameters(List<DbParameter> parameters, TBaseEntity instance)
        {
            // Add parameters for last updated on and last updated by
            string parameterName = this.GetParameterName(ParameterType.LastUpdatedOn);
            if (!string.IsNullOrEmpty(parameterName))
            {
                parameters.Add(DbHelper.CreateParameter(parameterName,
                    DateTime.Now));
            }
            parameterName = this.GetParameterName(ParameterType.LastUpdatedBy);
            if (!string.IsNullOrEmpty(parameterName))
            {
                parameters.Add(DbHelper.CreateParameter(parameterName,
                    instance.LastUpdatedBy));
            }

            parameterName = this.GetParameterName(ParameterType.CreatedOn);
            if (!string.IsNullOrEmpty(parameterName))
            {
                parameters.Add(DbHelper.CreateParameter(parameterName,
                    DateTime.Now));
            }
            parameterName = this.GetParameterName(ParameterType.CreatedBy);
            if (!string.IsNullOrEmpty(parameterName))
            {
                parameters.Add(DbHelper.CreateParameter(parameterName,
                    instance.CreatedBy));
            }
        }


        /// <summary>
        /// Before hook for Add/Update operations - default implementation does
        /// nothing
        /// </summary>
        protected virtual void BeforeAddUpdate(OperationType operation, TBaseEntity instance)
        {
            // Do Nothing
        }

        /// <summary>
        /// After hook for Add/Update operations - default implementation does
        /// nothing
        /// </summary>
        protected virtual void AfterAddUpdate(OperationType operation, TId instanceId, TBaseEntity instance)
        {
            // Do Nothing
        }

        /// <summary>
        /// Before hook for Delete operation - default implementation does
        /// nothing
        /// </summary>
        protected virtual void BeforeDelete(TId id)
        {
            // Do Nothing
        }

        /// <summary>
        /// After hook for Delete operation - default implementation does
        /// nothing
        /// </summary>
        protected virtual void AfterDelete(TId id)
        {
            // Do Nothing
        }

        #endregion

        #region "Private Methods"

        /// <summary>
        /// Create parameters for Add/Update methods
        /// </summary>
        private DbParameter[] CreateParameters(OperationType operation, TBaseEntity instance)
        {
            var parameters = new List<DbParameter>();
            // Add parameters for last updated on and last updated by
            AddCommonParameters(parameters, instance);


            var parameterName = GetParameterName(ParameterType.Operation);
            if (!string.IsNullOrEmpty(parameterName))
            {
                parameters.Add(DbHelper.CreateParameter(parameterName,
                    (int)operation));
            }

            if (operation == OperationType.Update)
            {
                // Add parameter for id 
                parameterName = this.GetParameterName(ParameterType.Id);
                if (!string.IsNullOrEmpty(parameterName))
                {
                    parameters.Add(DbHelper.CreateParameter(parameterName,
                        instance.Id));
                }
            }

            // Fill parameters
            this.FillParameters(operation, instance, parameters);

            return parameters.ToArray();
        }

        /// <summary>
        /// Create parameters for Delete/Get methods
        /// </summary>
        private DbParameter[] CreateParameters(OperationType operation, TId id)
        {
            var parameters = new List<DbParameter>();

            // Add parameter for id 
            string parameterName = this.GetParameterName(ParameterType.Id);
            if (!string.IsNullOrEmpty(parameterName))
            {
                parameters.Add(DbHelper.CreateParameter(parameterName, id));
            }

            // Add parameter for operation (not applicable for get)
            // if (operation != OperationType.Get)
            // {
            parameterName = GetParameterName(ParameterType.Operation);
            if (!string.IsNullOrEmpty(parameterName))
            {
                parameters.Add(DbHelper.CreateParameter(parameterName,
                    (int)operation));
            }
            //  }

            // Add parameters for last updated on and last updated by
            // (applicable for LastUpdated operation)
            if (operation == OperationType.Update)
            {
                parameterName = this.GetParameterName(ParameterType.LastUpdatedOn);
                if (!string.IsNullOrEmpty(parameterName))
                {
                    parameters.Add(DbHelper.CreateParameter(parameterName,
                        DateTime.Now));
                }
                parameterName = this.GetParameterName(ParameterType.LastUpdatedBy);
                if (!string.IsNullOrEmpty(parameterName))
                {
                    //TODO Need to find out way to get logged in user
                    parameters.Add(DbHelper.CreateParameter(parameterName,
                        "System"));
                }
            }

            // Fill parameters
            this.FillParameters(operation, id, parameters);

            return parameters.ToArray();
        }




        protected virtual DbParameter[] CreateParameters<TParentId>(OperationType operation, TParentId parentId)
        {
            var parameters = CreateParentIdParameters(parentId, operation);
            // Add parameter for operation
            this.FillParameters<TParentId>(operation, parentId, parameters);
            return parameters.ToArray();
        }
        #endregion
    }

    public enum OperationType
    {
        Get = 0,
        Add = 1,
        Update = 2,
        Delete = 3,
        GetAll = 5,
        
    }
}
