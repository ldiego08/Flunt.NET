using System;
using System.Configuration;
using System.Data.Common;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a series of methods to access a local or remote database.
    /// </summary>
    public class Database
    {
        #region Fields

        private string _connectionStringOrName;

        private readonly DbProviderFactory _dataProvider;

        #endregion

        #region Properties

        public DbProviderFactory Factory
        {
            get { return this._dataProvider; }
        }

        public string ConnectionStringOrName
        {
            get { return this._connectionStringOrName; }
        }

        #endregion

        #region Constructors

        private Database(string providerName) : this(DbProviderFactories.GetFactory(providerName)) { }

        private Database(DbProviderFactory dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the connection string or connection string name in the configuration file to be used to connect to the database.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or name.</param>
        /// <returns>The resulting database context.</returns>
        public Database UsingConnection(string connectionStringOrName)
        {
            if (String.IsNullOrEmpty(connectionStringOrName))
                throw new ArgumentException("Connection string or name cannot be null or empty.");

            this._connectionStringOrName = connectionStringOrName;

            return this;
        }

        /// <summary>
        /// Executes a query in the database.
        /// </summary>
        /// <param name="text">The query to execute.</param>
        /// <returns>An expression representing the command to execute.</returns>
        public DatabaseCommandExpression Execute(string text)
        {
            return DatabaseCommandExpression.For(text, this);
        }

        /// <summary>
        /// Executes a stored procedure in the database.
        /// </summary>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <returns>An expression representing the command to execute.</returns>
        public DatabaseStoredProcedureExpression ExecuteProcedure(string procedureName)
        {
            return DatabaseStoredProcedureExpression.For(procedureName, this);
        }

        /// <summary>
        /// Creates a database context for the specified data provider.
        /// </summary>
        /// <param name="providerName">The name of the data provider.</param>
        /// <returns>The Flunt.Data.Database created.</returns>
        public static Database ForProvider(string providerName) 
        {
            return new Database(providerName);
        }

        /// <summary>
        /// Creates a database context for the specified data provider.
        /// </summary>
        /// <param name="dataProvider">The System.Data.Common.DbProviderFactory instance used by the database context.</param>
        /// <returns>The Flunt.Data.Database created.</returns>
        public static Database ForProvider(DbProviderFactory dataProvider) 
        {
            return new Database(dataProvider);
        }

        /// <summary>
        /// Creates a database context using information from a connection string in the application configuration.
        /// </summary>
        /// <param name="connectionStringName">The name of the connection string.</param>
        /// <returns>The Flunt.Data.Database created.</returns>
        public static Database ForConnectionString(string connectionStringName)
        {
            if (String.IsNullOrEmpty(connectionStringName))
                throw new ArgumentException("The connection string name cannot be null or empty.");

            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (connectionString == null)
                throw new ConfigurationErrorsException(String.Format("The connection string with name {0} was not found in the application configuration.", connectionStringName));

            return new Database(connectionString.ProviderName);
        }

        protected string ResolveConnectionString()
        {
            if (String.IsNullOrEmpty(this._connectionStringOrName))
                throw new ArgumentException("The connection string cannot be null or empty.");

            var connectionString = ConfigurationManager.ConnectionStrings[this._connectionStringOrName];

            if (connectionString != null)
                return connectionString.ConnectionString;
            else
                return this._connectionStringOrName;
        }

        #endregion
    }
}
