using System.Data;

namespace Flunt.Data
{
    /// <summary>
    /// Represents a set of additional options available for a database command parameter.
    /// </summary>
    public class DatabaseCommandParameterOptions
    {
        /// <summary>
        /// Indicates the precision of numeric values.
        /// </summary>
        public byte Precision { get; set; }

        /// <summary>
        /// Gets or sets the name of the source column mapped to the Ststem.Data.DataSet and used for loading or returning the Value.
        /// </summary>
        public string SourceColumn { get; set; }

        /// <summary>
        /// Gets or sets the System.Data.DataRowVersion to use when you load Value.
        /// </summary>
        public DataRowVersion SourceVersion { get; set; }
    }
}
