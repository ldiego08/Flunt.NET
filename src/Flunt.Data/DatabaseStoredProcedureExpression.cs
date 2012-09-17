using System.Data;
using System.Data.Common;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a database stored procedure to be executed.
    /// </summary>
    public class DatabaseStoredProcedureExpression : DatabaseCommandExpression
    {
        #region Constructors

        private DatabaseStoredProcedureExpression(string storedProcedureName, Database database)
            : base(storedProcedureName, database)
        {
            this.Type = CommandType.StoredProcedure;
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Creates a stored procedure expression for the specified stored procedure.
        /// </summary>
        /// <param name="storedProcedureName">The name of the stored procedure.</param>
        /// <param name="database">The data provider used to create connections and other database objects.</param>
        /// <returns>The resulting stored procedure expression.</returns>
        public static new DatabaseStoredProcedureExpression For(string storedProcedureName, Database database)
        {
            return new DatabaseStoredProcedureExpression(storedProcedureName, database);
        } 

        #endregion
    }
}
