using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a database command to be executed.
    /// </summary>
    public class DatabaseCommandExpression
    {
        #region Fields

        private readonly DbCommand _command;
        private readonly Database _database;
        private readonly IList<DatabaseCommandParameterExpression> _parameterExpressions;

        #endregion

        #region Properties
        
        protected string Text
        {
            get { return this._command.CommandText; }
            set { this._command.CommandText = value; }
        }

        protected CommandType Type
        {
            get { return this._command.CommandType; }
            set { this._command.CommandType = value; }
        } 

        #endregion

        #region Constructors

        protected DatabaseCommandExpression(string queryText, Database database)
        {
            if (String.IsNullOrEmpty(queryText))
                throw new ArgumentException("Query text cannot be null or empty");

            this._database = database;
            this._command = _database.Factory.CreateCommand();

            this._command.CommandText = queryText;
            this._command.CommandType = CommandType.Text;

            this._parameterExpressions = new List<DatabaseCommandParameterExpression>();
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Sets a parameter value.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="expression">The value of the parameter.</param>
        /// <returns>The resulting command expression.</returns>
        public DatabaseCommandExpression Where(string parameterName, Action<DatabaseCommandParameterExpression> expression)
        {
            if (String.IsNullOrEmpty(parameterName))
                throw new ArgumentException("The parameter name cannot be null or empty.");

            if (expression == null)
                throw new ArgumentNullException("expression");

            var parameterExpression = DatabaseCommandParameterExpression.For(parameterName, this._database);

            expression(parameterExpression);

            var existingExpression = this._parameterExpressions.SingleOrDefault(exp => exp.Compiled().ParameterName == parameterExpression.Compiled().ParameterName);

            if (existingExpression != null)
                this._parameterExpressions.Remove(existingExpression);

            this._parameterExpressions.Add(parameterExpression);

            return this;
        }

        /// <summary>
        /// Gets the resulting command as a data reader.
        /// </summary>
        /// <returns>The resulting data reader expression.</returns>
        public DatabaseDataReaderExpression AsReader()
        {
            ParseCommandParameters();

            return DatabaseDataReaderExpression.For(this._command, this._database);
        }

        /// <summary>
        /// Executes the resulting command as a non-query.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        public int AsNonQuery()
        {
            ParseCommandParameters();

            using (var connection = this._database.Factory.CreateConnection())
            {
                this._command.Connection = connection;
                this._command.Connection.Open();

                var affectedRows = this._command.ExecuteNonQuery();

                return affectedRows;
            }
        }

        /// <summary>
        /// Gets the System.Data.Common.DbCommand resulting from this expression.
        /// </summary>
        /// <returns>The resulting System.Data.Common.DbCommand.</returns>
        public DbCommand Compiled()
        {
            return this._command;
        }

        /// <summary>
        /// Executes the resulting command as a scalar value.
        /// </summary>
        /// <returns>The resulting value expression.</returns>
        public DatabaseCommandValueExpression AsScalar()
        {
            ParseCommandParameters();

            using (var connection = this._database.Factory.CreateConnection())
            {
                this._command.Connection = connection;
                this._command.Connection.Open();

                var result = this._command.ExecuteScalar();

                return DatabaseCommandValueExpression.For(result);
            }
        }

        /// <summary>
        /// Creates a command expression for the specified query.
        /// </summary>
        /// <param name="queryText">The query the command will execute.</param>
        /// <param name="database">The data provider used to create connections and other database objects.</param>
        /// <returns>The resulting command expression.</returns>
        public static DatabaseCommandExpression For(string queryText, Database database)
        {
            return new DatabaseCommandExpression(queryText, database);
        } 

        private void ParseCommandParameters()
        {
            this._command.Parameters.Clear();

            foreach (var parameterExpression in this._parameterExpressions)
                this._command.Parameters.Add(parameterExpression.Compiled());
        }

        #endregion
    }
}
