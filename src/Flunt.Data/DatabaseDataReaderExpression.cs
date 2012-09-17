using System;
using System.Data.Common;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a data reader resulting of a database command execution.
    /// </summary>
    public class DatabaseDataReaderExpression
    {
        #region Fields

        private readonly DbCommand _command;
        private readonly Database _database; 

        #endregion

        #region Constructors

        private DatabaseDataReaderExpression(DbCommand command, Database database)
        {
            this._command = command;
            this._database = database;
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Executes an action for each row contained in the data reader.
        /// </summary>
        /// <param name="action">The action to execute for each data row.</param>
        public void ForEachRow(Action<DatabaseDataReaderRowExpression> action)
        {
            using (var connection = this._database.Factory.CreateConnection())
            {
                this._command.Connection = connection;
                this._command.Connection.Open();

                using (var dataReader = this._command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        action(DatabaseDataReaderRowExpression.For(dataReader));
                    }
                }
            }
        }

        /// <summary>
        /// Creates a data reader expression for the specified database command.
        /// </summary>
        /// <param name="command">The command where the data reader is to be retrieved.</param>
        /// <param name="database">The data provider used to create connections and other database objects.</param>
        /// <returns>The resulting data reader expression.</returns>
        public static DatabaseDataReaderExpression For(DbCommand command, Database database)
        {
            return new DatabaseDataReaderExpression(command, database);
        } 

        #endregion
    }
}
