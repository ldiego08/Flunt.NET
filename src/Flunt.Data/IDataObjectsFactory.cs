using System.Data;

namespace Flunt.Data
{
    /// <summary>
    /// Creates data access objects by using a System.Data.Common.DbProviderFactory object.
    /// </summary>
    public interface IDataObjectsFactory
    {
        /// <summary>
        /// Creates a command used to execute queries against a database.
        /// </summary>
        /// <returns>The System.Data.IDbCommand object created by the underlying data provider.</returns>
        IDbCommand CreateCommand();

        /// <summary>
        /// Creates a parameter used with commands.
        /// </summary>
        /// <returns>The System.Data.IDbDataParameter object created by the underlying data provider.</returns>
        IDbConnection CreateConnection();

        /// <summary>
        /// Creates a connection used to connect to a database.
        /// </summary>
        /// <returns>The System.Data.IDbConnection object created by the underlying data provider.</returns>
        IDbDataParameter CreateParameter();
    }
}
