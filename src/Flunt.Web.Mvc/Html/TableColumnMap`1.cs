//-----------------------------------------------------------------------
// <copyright file="TableColumnMap`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Reflection;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a table column mapping for a single source item property.
    /// </summary>
    /// <typeparam name="TItem">The type of the source item.</typeparam>
    public class TableColumnMap<TItem>
    {
        /// <summary>
        /// The source item property accessor.
        /// </summary>
        private readonly PropertyInfo sourceProperty;

        /// <summary>
        /// The column header text.
        /// </summary>
        private string headerText;

        /// <summary>
        /// The format used with the source item property value.
        /// </summary>
        private string format;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableColumnMap{TItem}"/> class.
        /// </summary>
        /// <param name="sourceProperty">The source item property accessor.</param>
        public TableColumnMap(PropertyInfo sourceProperty)
        {
            if (sourceProperty.IsNull())
            {
                throw new ArgumentNullException("sourceProperty");
            }

            this.format = null;
            this.headerText = null;
            this.sourceProperty = sourceProperty;
        }

        /// <summary>
        /// Gets the source item property accessor.
        /// </summary>
        public PropertyInfo SourceProperty
        {
            get 
            { 
                return this.sourceProperty; 
            }
        }

        /// <summary>
        /// Gets or sets the column header text.
        /// </summary>
        public string HeaderText
        {
            get 
            {
                if (this.headerText.IsNotNull())
                {
                    return this.headerText;
                }
                else
                {
                    var displayNameAttribute = this.sourceProperty.GetCustomAttribute<DisplayNameAttribute>(inherit: true);

                    if (displayNameAttribute.IsNotNull())
                    {
                        return displayNameAttribute.DisplayName;
                    }
                    else
                    {
                        return this.sourceProperty.Name;
                    }
                }
            }

            set 
            {
                this.headerText = value; 
            }
        }

        /// <summary>
        /// Gets or sets the format used with the source item property value.
        /// </summary>
        public string Format
        {
            get { return this.format; }
            set { this.format = value; }
        }
    }
}
