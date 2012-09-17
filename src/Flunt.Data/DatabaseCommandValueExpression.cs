using System;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a value resulting of a database command execution.
    /// </summary>
    public class DatabaseCommandValueExpression
    {
        #region Fields

        private readonly object _value; 

        #endregion

        #region Constructors

        private DatabaseCommandValueExpression(object value)
        {
            this._value = value;
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Converts the value to a specified type.
        /// </summary>
        /// <typeparam name="TValue">The value destination type.</typeparam>
        /// <returns>The converted value.</returns>
        public TValue As<TValue>()
        {
            if (this._value is TValue)
                return (TValue)this._value;
            else
                throw new InvalidCastException(String.Format("The value cannot be converted to the {0} type.", typeof(TValue).FullName));
        }

        /// <summary>
        /// Creates a database command value expression.
        /// </summary>
        /// <param name="value">The value containes by the created expression.</param>
        /// <returns>the resulting command value expression.</returns>
        public static DatabaseCommandValueExpression For(object value)
        {
            return new DatabaseCommandValueExpression(value);
        } 

        #endregion
    }
}
