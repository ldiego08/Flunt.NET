using System;
using System.Data;
using System.Data.Common;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a parameter for a database command.
    /// </summary>
    public class DatabaseCommandParameterExpression
    {
        #region Fields

        private readonly DbParameter _parameter;
        private readonly Database _database; 

        #endregion

        #region Constructors

        private DatabaseCommandParameterExpression(string name, Database database)
        {
            this._database = database;

            this._parameter = _database.Factory.CreateParameter();
            this._parameter.Direction = ParameterDirection.Input;
            this._parameter.ParameterName = ParseParameterName(name);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the value of the parameter.
        /// </summary>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>The resulting command parameter expression.</returns>
        public DatabaseCommandParameterExpression Is(object value)
        {
            this._parameter.Value = value;
            return this;
        }

        /// <summary>
        /// Sets the type of the parameter value.
        /// </summary>
        /// <param name="type">The type of the parameter value.</param>
        /// <returns>The resulting command parameter expression.</returns>
        public DatabaseCommandParameterExpression OfType(DbType type)
        {
            this._parameter.DbType = type;
            return this;
        }

        /// <summary>
        /// Sets the size of the parameter value.
        /// </summary>
        /// <param name="size">The size of the parameter value.</param>
        /// <returns>The resulting command parameter expression.</returns>
        public DatabaseCommandParameterExpression WithSize(int size)
        {
            this._parameter.Size = size;
            return this;
        }

        /// <summary>
        /// Sets additional options to be used by the command parameter.
        /// </summary>
        /// <param name="predicate">The predicate that configures the parameter options.</param>
        /// <returns>The resulting command parameter expression.</returns>
        public DatabaseCommandParameterExpression WithOptions(Action<DatabaseCommandParameterOptions> predicate)
        {
            var parameterOptions = new DatabaseCommandParameterOptions();

            predicate(parameterOptions);

            this._parameter.SourceColumn = parameterOptions.SourceColumn;
            this._parameter.SourceColumnNullMapping = parameterOptions.SourceColumnNullMapping;
            this._parameter.SourceVersion = parameterOptions.SourceVersion;

            return this;
        }

        /// <summary>
        /// Sets the parameter to output a value.
        /// </summary>
        /// <returns>The resulting command parameter expression.</returns>
        public DatabaseCommandParameterExpression AsOutput()
        {
            this._parameter.Direction = ParameterDirection.Output;

            return this;
        }

        /// <summary>
        /// Creates a command parameter.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="database">The data provider used to create connections and other database objects.</param>
        /// <returns>The resulting command parameter expression.</returns>
        public static DatabaseCommandParameterExpression For(string name, Database database)
        {
            return new DatabaseCommandParameterExpression(name, database);
        }

        private string ParseParameterName(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Parameter name cannot be null or empty.");

            if (!name.StartsWith("@"))
                return String.Concat("@", name);

            return name;
        } 

        #endregion
    }
}
