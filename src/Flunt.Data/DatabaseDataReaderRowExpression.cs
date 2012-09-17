using System.Data.Common;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a database reader row.
    /// </summary>
    public class DatabaseDataReaderRowExpression
    {
        #region Fields

        private readonly DbDataReader _reader; 

        #endregion

        #region Constructors

        private DatabaseDataReaderRowExpression(DbDataReader reader)
        {
            this._reader = reader;
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Gets the value of a column.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The resulting value expression.</returns>
        public DatabaseCommandValueExpression GetValue(string name)
        {
            return DatabaseCommandValueExpression.For(this._reader[name]);
        }

        /// <summary>
        /// Creates a reader row expression for the specified data reader.
        /// </summary>
        /// <param name="reader">The reader the values will be retrieved from.</param>
        /// <returns>The resulting reader row expression.</returns>
        public static DatabaseDataReaderRowExpression For(DbDataReader reader)
        {
            return new DatabaseDataReaderRowExpression(reader);
        } 

        #endregion
    }
}
