using System.Data;
using System.Data.Common;

namespace Flunt.Data
{
    /// <summary>
    /// Creates data access objects by using a System.Data.Common.DbProviderFactory object.
    /// </summary>
    public class DataObjectsFactory : IDataObjectsFactory
    {
        #region Fields

        private readonly DbProviderFactory _innerFactory; 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Flunt.Data.DataObjectsFactory class.
        /// </summary>
        /// <param name="innerFactory">The data provider used to create data objects.</param>
        public DataObjectsFactory(DbProviderFactory innerFactory)
        {
            this._innerFactory = innerFactory;
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Creates a command used to execute queries against a database.
        /// </summary>
        /// <returns>The System.Data.IDbCommand object created by the underlying data provider.</returns>
        public IDbCommand CreateCommand()
        {
            return this._innerFactory.CreateCommand();
        }

        /// <summary>
        /// Creates a parameter used with commands.
        /// </summary>
        /// <returns>The System.Data.IDbDataParameter object created by the underlying data provider.</returns>
        public IDbDataParameter CreateParameter()
        {
            return this._innerFactory.CreateParameter();
        }

        /// <summary>
        /// Creates a connection used to connect to a database.
        /// </summary>
        /// <returns>The System.Data.IDbConnection object created by the underlying data provider.</returns>
        public IDbConnection CreateConnection()
        {
            return this._innerFactory.CreateConnection();
        } 

        #endregion
    }
}
