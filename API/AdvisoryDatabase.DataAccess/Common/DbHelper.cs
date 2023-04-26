using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.DataAccess.Common
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Runtime.Remoting.Messaging;
    using System.Transactions;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    using AdvisoryDatabase.DataAccess.Repository;
    using AdvisoryDatabase.Framework.Common;

    public static class DbHelper
    {
        #region "Related to Database object creation"

        private static Database GetDatabase()
        {
            // We will store the database object in the call context to save
            // the construction time.
            const string Key = "WKFS_database";
            // See in the current call context
            var database = CallContext.GetData(Key) as Database;

            if (null == database)
            {

                var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;//ConfigurationManager.AppSettings["ConnectionString"];

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new Exception("Missing connection string");
                }
                // Create the database
                database = CreateDatabase(connectionString);
                // Store in the call context
                CallContext.SetData(Key, database);
            }

            return database;
        }


        private static Database CreateDatabase(string connectionString)
        {
            // Create the database - we will be using Sql Server
            return new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(connectionString);
        }

        #endregion

        #region "Database Information"

        /// <summary>
        /// Returns the application/metadata database information such as 
        /// server name/database name.
        /// </summary>
        public static string GetDatabaseInfo()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // ConfigurationManager.AppSettings["ConnectionString"];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Missing connection string");
            }
            return GetDatabaseInfo(connectionString);
        }

        private static string GetDatabaseInfo(string connectionString)
        {
            // ** Sql-server specific implementation **
            var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
            return string.Format("[{0}, {1}]", builder.DataSource, builder.InitialCatalog);
        }

        #endregion

        #region "Transactions related"

        #region "TransactionScope Creation"

        public static TransactionScope CreateTransactionScope()
        {
            return CreateTransactionScope(TransactionScopeOption.Required);
        }

        public static TransactionScope CreateTransactionScope(TransactionScopeOption option)
        {
            // TODO Set transaction time-out
            return new TransactionScope(option);
        }

        public static TransactionScope CreateTransactionScope(
            TransactionScopeOption option,
            System.Transactions.IsolationLevel level)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = level;
            // TODO Set transaction time-out
            return new TransactionScope(option, transactionOptions);
        }

        #endregion

        /// <summary>
        /// Registers a callback when the current transaction completes. The callback
        /// will be invoked with true/false value indicating whether the Transaction
        /// was committed or rolled back. 
        /// </summary>
        /// <returns>
        /// Returns false if there is no current transaction.
        /// </returns>
        public static bool RegisterTransactionCallback(Utility.Method<bool> callback)
        {
            if (null == callback)
            {
                throw new ArgumentNullException();
            }
            var current = Transaction.Current;
            if (null == current)
            {
                return false;
            }
            current.TransactionCompleted +=
                (sender, e) => callback(e.Transaction.TransactionInformation.Status == TransactionStatus.Committed);
            return true;
        }

        #endregion

        #region "Parameter Creation"

        /// <summary>
        /// Creates and returns in parameter with the given name and value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        /// <param name="value"></param>
        public static DbParameter CreateParameter(string name, object value)
        {
            var param = CreateParameter(name);
            param.Direction = ParameterDirection.Input;
            param.Value = value ?? DBNull.Value;
            return param;
        }

        /// <summary>
        /// Creates and returns in parameter of integer type with the given 
        /// name and value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        /// <param name="value"></param>
        public static DbParameter CreateParameter(string name, int value)
        {
            return CreateParameter(name, DbType.Int32, value);
        }

        /// <summary>
        /// Creates and returns in parameter of integer type with the given 
        /// name and null able value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, int? value)
        {
            return CreateParameter(name, DbType.Int32, value.HasValue ? (object)value.Value : null);
        }

        /// <summary>
        /// Creates and returns in parameter of long type with the given 
        /// name and value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, long value)
        {
            return CreateParameter(name, DbType.Int64, value);
        }

        /// <summary>
        /// Creates and returns in parameter of long type with the given 
        /// name and nullable value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, long? value)
        {
            return CreateParameter(name, DbType.Int64, value.HasValue ? (object)value.Value : null);
        }

        /// <summary>
        /// Creates and returns in parameter of integer type with the given 
        /// name and value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, bool value)
        {
            return CreateParameter(name, DbType.Boolean, value);
        }

        /// <summary>
        /// Creates and returns in parameter of integer type with the given 
        /// name and nullable value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, bool? value)
        {
            return CreateParameter(name, DbType.Boolean, value.HasValue ? (object)value.Value : null);
        }

        /// <summary>
        /// Creates and returns in parameter of date/time type with the given 
        /// name and value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, DateTime value)
        {
            return CreateParameter(name, DbType.DateTime, value);
        }

        /// <summary>
        /// Creates and returns in parameter of date/time type with the given 
        /// name and nullable value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, DateTime? value)
        {
            return CreateParameter(name, DbType.DateTime, value.HasValue ? (object)value.Value : null);
        }

        /// <summary>
        /// Creates and returns in parameter of string type with the given 
        /// name and (null able) value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, string value)
        {
            return CreateParameter(name, DbType.String, string.IsNullOrEmpty(value) ? null : value);
        }

        /// <summary>
        /// Creates and returns in parameter with the given name and data type.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, DataType type)
        {
            DbType dbType;
            switch (type)
            {
                case DataType.Integer:
                    dbType = DbType.Int32;
                    break;
                case DataType.Long:
                    dbType = DbType.Int64;
                    break;
                case DataType.Decimal:
                    dbType = DbType.Decimal;
                    break;
                case DataType.String:
                    dbType = DbType.String;
                    break;
                case DataType.DateTime:
                    dbType = DbType.DateTime;
                    break;
                case DataType.Currency:
                    dbType = DbType.Currency;
                    break;
                case DataType.Boolean:
                    dbType = DbType.Boolean;
                    break;
                default:
                    throw new NotSupportedException();
            }
            return CreateParameter(name, dbType, null);
        }


        /// <summary>
        /// Creates and returns in parameter with the given name and data type.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, DbType type)
        {
            return CreateParameter(name, type, null);
        }

        /// <summary>
        /// Creates and returns in parameter with the given name, data type and value.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateParameter(string name, DbType type, object value)
        {
            return CreateParameter(name, type, ParameterDirection.Input, value);
        }

        /// <summary>
        /// Creates and returns out parameter with the given name and data type.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        public static DbParameter CreateOutParameter(string name, DbType type)
        {
            return CreateParameter(name, type, ParameterDirection.Output, null);
        }

        /// <summary>
        /// Creates and returns parameter with the given name, data type, 
        /// direction and data type.
        /// </summary>
        /// <param name="name">The name of the parameter without database specific 
        /// prefix. For example, if in sql server, parameter name is @Value then
        /// pass only Value as a parameter name.</param>
        /// <param name="type"></param>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        public static DbParameter CreateParameter(string name, DbType type, ParameterDirection direction, object value)
        {
            var param = CreateParameter(name);
            param.Direction = direction;
            param.DbType = type;
            param.Value = value ?? DBNull.Value;
            return param;
        }

        #endregion

        #region "Execute/Load DataSet"

        public static DataSet ExecuteDataSet(string procedureName)
        {
            return ExecuteDataSet(CommandType.StoredProcedure, procedureName, null);
        }

        public static DataSet ExecuteDataSet(string procedureName, params DbParameter[] parameters)
        {
            return ExecuteDataSet(CommandType.StoredProcedure, procedureName, parameters);
        }

        public static DataSet ExecuteDataSet(
            CommandType commandType,
            string commandText,
            params DbParameter[] parameters)
        {
            using (var command = GetCommand(commandType, commandText, parameters))
            {
                return GetDatabase().ExecuteDataSet(command);
            }

        }

        public static T ExecuteDataTable<T>(string procedureName, params DbParameter[] parameters)
            where T : DataTable, new()
        {
            return ExecuteDataTable<T>(CommandType.StoredProcedure, procedureName, parameters);
        }

        public static T ExecuteDataTable<T>(
            CommandType commandType,
            string commandText,
            params DbParameter[] parameters) where T : DataTable, new()
        {
            var result = new T();
            LoadDataTable(result, LoadOption.PreserveChanges, commandType, commandText, parameters);
            return result;
        }

        public static void LoadDataSet(
            DataSet dataset,
            string tableName,
            string procedureName,
            params DbParameter[] parameters)
        {
            LoadDataSet(dataset, new[] { tableName }, CommandType.StoredProcedure, procedureName, parameters);
        }

        public static void LoadDataSet(
            DataSet dataset,
            string[] tableNames,
            CommandType commandType,
            string commandText,
            params DbParameter[] parameters)
        {
            using (var command = GetCommand(commandType, commandText, parameters))
            {
                GetDatabase().LoadDataSet(command, dataset, tableNames);
            }
        }

        public static void LoadDataTable(DataTable table, string procedureName, params DbParameter[] parameters)
        {
            LoadDataTable(table, LoadOption.PreserveChanges, CommandType.StoredProcedure, procedureName, parameters);
        }

        public static void LoadDataTable(
            DataTable table,
            LoadOption loadOption,
            CommandType commandType,
            string commandText,
            params DbParameter[] parameters)
        {
            using (var command = GetCommand(commandType, commandText, parameters))
            {
                var reader = GetDatabase().ExecuteReader(command);
                using (reader)
                {
                    table.Load(reader, loadOption);
                }
            }
        }

        #endregion

        #region "Execute Scalar/ Execute NonQuery"

        public static object ExecuteScalar(string procedureName, params DbParameter[] parameters)
        {
            return ExecuteScalar(CommandType.StoredProcedure, procedureName, parameters);
        }

        public static object ExecuteScalar(CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            using (var command = GetCommand(commandType, commandText, parameters))
            {
                return GetDatabase().ExecuteScalar(command);
            }
        }

        public static int ExecuteNonQuery(string procedureName, params DbParameter[] parameters)
        {
            return ExecuteNonQuery(CommandType.StoredProcedure, procedureName, parameters);
        }

        public static int ExecuteNonQuery(CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            using (var command = GetCommand(commandType, commandText, parameters))
            {
                return GetDatabase().ExecuteNonQuery(command);
            }
        }

        #endregion

        #region "Reading Data"

        /// <summary>
        /// Returns the (not nullable) value of the given column.
        /// </summary>
        public static T Read<T>(this DataRow row, string columnName)
        {
            return (T)row[columnName];
        }

        /// <summary>
        /// Returns the nullable string value of the given column.
        /// </summary>
        public static string ReadString(this DataRow row, string columnName)
        {
            var value = row[columnName];
            return value == DBNull.Value ? null : value.ToString();
        }

        /// <summary>
        /// Returns the nullable value of the given column.
        /// </summary>
        public static T? ReadNullable<T>(this DataRow row, string columnName) where T : struct
        {
            var value = row[columnName];
            return value == DBNull.Value ? null : (T?)value;
        }

        /// <summary>
        /// Returns the (not nullable) value of the given column.
        /// </summary>
        public static T Read<T>(DataRow row, int columnIndex)
        {
            return (T)row[columnIndex];
        }

        /// <summary>
        /// Returns the nullable string value of the given column.
        /// </summary>
        public static string ReadString(this DataRow row, int columnIndex)
        {
            var value = row[columnIndex];
            return value == DBNull.Value ? null : value.ToString();
        }

        /// <summary>
        /// Returns the nullable value of the given column.
        /// </summary>
        public static T? ReadNullable<T>(this DataRow row, int columnIndex) where T : struct
        {
            var value = row[columnIndex];
            if (value == DBNull.Value)
            {
                return null;
            }
            return (T)value;
        }

        #endregion

        #region "Parsing Database Error Information"

        /// <summary>
        /// A single value mapped from Db Exception by ParseDbException method
        /// </summary>
        public enum DbError
        {
            /// <summary>
            /// Unknown database error
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// Error initiated by application code - user message id will
            /// be returned
            /// </summary>
            Application = 1,

            /// <summary>
            /// Error due to Foreign Key Constraint Violation
            /// </summary>
            ForeignKeyViolation = 2,

            /// <summary>
            /// Error due to Primary Key Constraint Violation
            /// </summary>
            PrimaryKeyViolation = 3,

            /// <summary>
            /// Error due to Unique Key Constraint Violation
            /// </summary>
            UniqueKeyViolation = 4
        }

        /// <summary>
        /// Analyzes the given DB Exception for retrieving more infomation
        /// about the error. 
        /// </summary>
        /// <param name="messageId">User Message Id retrieved from Db Exception.
        /// Applicable only when return value is DbError.Application</param>
        /// <param name="execption"></param>
        /// <param name="message"></param>
        public static DbError ParseDbException(DbException execption, out string message)
        {
            const string MessageIdKey1 = "[**WKFS_MESSAGE:";
            const string MessageIdKey2 = "**]";

            int messageId = 0;
            // Search for special keys within the exception message
            message = execption.Message;
            var key1Index = message.IndexOf(MessageIdKey1, System.StringComparison.Ordinal);
            if (key1Index >= 0)
            {
                var start = key1Index + MessageIdKey1.Length;
                var end = message.IndexOf(MessageIdKey2, start, System.StringComparison.Ordinal);
                if (end >= 0)
                {
                    // Found, parse the message id
                    if (int.TryParse(message.Substring(start, end - start), out messageId))
                    {
                        return DbError.Application;
                    }
                }
            }

            // Handle Sql Server specific error code
            var sqlExecption = execption as System.Data.SqlClient.SqlException;
            if (null == sqlExecption)
            {
                return DbError.Unknown;
            }
            bool isConstraintViolation = false;
            if (sqlExecption.Number == 547)
            {
                isConstraintViolation = true;
            }
            else if (sqlExecption.Number == 50000
                     && (message.IndexOf("Error Number: 547", System.StringComparison.Ordinal) >= 0
                         || message.IndexOf("Error Number: 2627", System.StringComparison.Ordinal) >= 0))
            {
                // Our Common logging sp converts sql errors into user
                // errors and original sql error can be found in message
                // string - so here we have again found constraint 
                // violation error.
                isConstraintViolation = true;
            }
            // In case of constraint violation, see if its foregin key or
            // unique key or primary key
            if (isConstraintViolation)
            {
                if (message.IndexOf("REFERENCE", System.StringComparison.Ordinal) >= 0)
                {
                    return DbError.ForeignKeyViolation;
                }
                else if (message.IndexOf("PRIMARY KEY", System.StringComparison.Ordinal) >= 0)
                {
                    return DbError.PrimaryKeyViolation;
                }
                else if (message.IndexOf("UNIQUE KEY", System.StringComparison.Ordinal) >= 0)
                {
                    return DbError.UniqueKeyViolation;
                }
            }
            return DbError.Unknown;
        }

        /// <summary>
        /// Attempts to map the generic database exception to specific 
        /// application exception. Returns true if existing exception to
        /// be re-thrown.
        /// </summary>
        public static bool HandleDbException(OperationType operation, DbException e)
        {
            // Parse exception
            string message;
            switch (DbHelper.ParseDbException(e, out message))
            {
                case DbHelper.DbError.Application:
                    throw new Exception(message);

                case DbHelper.DbError.ForeignKeyViolation:
                    if (operation == OperationType.Delete)
                    {
                        throw new Exception("Delete data is in use");
                    }
                    break;

                case DbHelper.DbError.UniqueKeyViolation:
                case DbHelper.DbError.PrimaryKeyViolation:
                    if (operation == OperationType.Add || operation == OperationType.Update)
                    {
                        throw new Exception("Duplicate record");
                    }
                    break;
            }
            return true;
        }

        #endregion

        #region "Database Expressions"

        // Methods for returning various database specific expressions that may
        // be needed in query generation. Add them as need arises.

        /// <summary>
        /// Gets the data base expression for taking left n characters of an
        /// string.
        /// </summary>
        public static string GetDbExpressionForLeft(string variable, int length)
        {
            return GetDbExpressionForSubString(variable, 0, length);
        }

        /// <summary>
        /// Gets the data base expression for getting substring of a given string
        /// variable. Start is zero based index within the string.
        /// </summary>
        public static string GetDbExpressionForSubString(string variable, int start, int length)
        {
            return string.Format("SUBSTRING({0}, {1}, {2})", variable, start + 1, length);
        }

        #endregion

        #region "Helper Methods"

        /// <summary>
        /// Parse time stamp information from the given row provided 
        /// standard column names are used.
        /// </summary>
        public static TimeStamp? ParseTimeStampInfo(DataRow row)
        {
            if (!DbHelper.ReadNullable<DateTime>(row, "CreatedOn").HasValue
                || !DbHelper.ReadNullable<int>(row, "CreatedBy").HasValue
                || !DbHelper.ReadNullable<DateTime>(row, "LastUpdatedOn").HasValue
                || !DbHelper.ReadNullable<int>(row, "LastUpdatedBy").HasValue)
            {
                return null;
            }
            return new TimeStamp()
            {
                CreatedOn = DbHelper.Read<DateTime>(row, "CreatedOn"),
                CreatedBy = DbHelper.Read<int>(row, "CreatedBy"),
                LastUpdatedOn = DbHelper.Read<DateTime>(row, "LastUpdatedOn"),
                LastUpdatedBy = DbHelper.Read<int>(row, "LastUpdatedBy")
            };
        }

        private static DbCommand GetCommand(CommandType commandType, string commandText, DbParameter[] parameters)
        {
            return GetCommand(GetDatabase(), commandType, commandText, parameters);
        }

        private static DbCommand GetCommand(
            Database database,
            CommandType commandType,
            string commandText,
            DbParameter[] parameters)
        {
            // Create command
            DbCommand command;
            if (commandType == CommandType.StoredProcedure)
            {
                // Qualify procedure name
                commandText = QualifyProcedureName(commandText);
                command = database.GetStoredProcCommand(commandText);
            }
            else
            {
                command = database.GetSqlStringCommand(commandText);
            }

            // Configure command
            command.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);//100;

            // Add parameters
            if (null != parameters)
            {
                foreach (DbParameter t in parameters)
                {
                    command.Parameters.Add(t);
                }
            }
            return command;
        }

        private static DbParameter CreateParameter(string name)
        {
            var database = GetDatabase();
            var param = database.DbProviderFactory.CreateParameter();
            param.ParameterName = database.BuildParameterName(name);
            return param;
        }

        // Returns schema/user qualified stored procedure name
        private static string QualifyProcedureName(string name)
        {
            if (!name.StartsWith("dbo.", StringComparison.OrdinalIgnoreCase)
                && name.StartsWith("[dbo].", StringComparison.OrdinalIgnoreCase))
            {
                name = "dbo." + name;
            }
            return name;
        }

        #endregion

    }
}
