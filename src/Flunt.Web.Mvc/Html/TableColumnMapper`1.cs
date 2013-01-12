//-----------------------------------------------------------------------
// <copyright file="TableColumnMapper`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Provides methods and properties to map source item properties to
    /// an HTML table columns.
    /// </summary>
    /// <typeparam name="TItem">The type of the source item mapped.</typeparam>
    public class TableColumnMapper<TItem>
    {
        /// <summary>
        /// The source item mapped properties.
        /// </summary>
        private IList<TableColumnMap<TItem>> mappedProperties;

        /// <summary>
        /// Gets the source item mapped properties.
        /// </summary>
        public IList<TableColumnMap<TItem>> MappedProperties
        {
            get
            {
                if (this.mappedProperties.IsNull())
                {
                    this.mappedProperties = Empty.ListOf<TableColumnMap<TItem>>();
                }

                return this.mappedProperties;
            }
        }

        /// <summary>
        /// Adds a new mapping for the specified source item property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the source item property.</typeparam>
        /// <param name="property">The source item property.</param>
        /// <param name="withHeader">The column header text.</param>
        /// <param name="withFormat">The format used for the column cell values.</param>
        /// <returns>A <see cref="TableColumnMapper{TItem}"/> instance.</returns>
        public TableColumnMapper<TItem> Add<TProperty>(Expression<Func<TItem, TProperty>> property, string withHeader = null, string withFormat = null)
        {
            var sourceMember = property.Body as MemberExpression;

            if (sourceMember.IsNotNull() && sourceMember.Member is PropertyInfo)
            {
                var columnMap = new TableColumnMap<TItem>(sourceMember.Member as PropertyInfo);

                var columnHeaderText = withHeader;
                var columnDataFormat = withFormat;

                if (columnDataFormat.IsNotNullOrEmpty())
                {
                    columnMap.Format = columnDataFormat;
                }

                if (columnHeaderText.IsNotNull())
                {
                    columnMap.HeaderText = columnHeaderText;
                }

                this.MappedProperties.Add(columnMap);
            }

            return this;
        }
    }
}
