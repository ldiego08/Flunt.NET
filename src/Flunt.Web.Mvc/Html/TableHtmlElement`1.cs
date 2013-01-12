//-----------------------------------------------------------------------
// <copyright file="TableHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a table HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TItem">The type of the items in the source enumerable.</typeparam>
    public class TableHtmlElement<TItem> : HtmlElement<HtmlHelper>
    {
        /// <summary>
        /// The source items enumerable.
        /// </summary>
        private IEnumerable<TItem> items;

        /// <summary>
        /// The table column map configurator.
        /// </summary>
        private TableColumnMapper<TItem> columnsMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableHtmlElement{TItem}"/> class.
        /// </summary>
        /// <param name="items">The source items.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public TableHtmlElement(IEnumerable<TItem> items, HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            if (items.IsNull())
            {
                throw new ArgumentNullException("items");
            }

            this.items = items;
        }

        /// <summary>
        /// Gets the source items enumerable.
        /// </summary>
        public IEnumerable<TItem> Items
        {
            get { return this.items; }
        }

        /// <summary>
        /// Gets the table column map configurator.
        /// </summary>
        public TableColumnMapper<TItem> ColumnsMapper
        {
            get
            {
                if (this.columnsMapper.IsNull())
                {
                    this.columnsMapper = new TableColumnMapper<TItem>();
                }

                return this.columnsMapper;
            }
        }

        /// <summary>
        /// Sets configuration values for the rendered table HTML element.
        /// </summary>
        /// <param name="columns">The columns configurator action.</param>
        /// <returns>A <see cref="TableHtmlElement{TItem}"/> instance.</returns>
        public TableHtmlElement<TItem> With(Action<TableColumnMapper<TItem>> columns)
        {
            var columnConfigurer = columns;

            if (columnConfigurer.IsNotNull())
            {
                columnConfigurer(this.ColumnsMapper);
            }
            else
            {
                throw new ArgumentNullException("columnsMapper");
            }

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            return this.GetTableElementHtml();
        }
            
        /// <summary>
        /// Returns a table HTML element for the source enumerable.
        /// </summary>
        /// <returns>The table HTML string.</returns>
        private string GetTableElementHtml()
        {
            var html = new StringBuilder();

            var tableHeadersHtml = this.GetTableHeadersHtml();
            var tableBodyHtml = this.GetTableBodyHtml();

            html.AppendFormat(@"<table {0} {1}>", this.CssClassAttribute, this.CssStyleAttribute);
            html.Append(tableHeadersHtml);
            html.Append(tableBodyHtml);
            html.Append("</table>");

            return html.ToString();
        }

        /// <summary>
        /// Returns a table headers HTML element for the mapped columns.
        /// </summary>
        /// <returns>The headers HTML string.</returns>
        private string GetTableHeadersHtml()
        {
            if (this.ColumnsMapper.MappedProperties.IsEmpty())
            {
                return this.GetTableHeadersHtmlForAllProperties();
            }
            else
            {
                var tableHeadersHtml = new StringBuilder();

                tableHeadersHtml.Append("<thead>");

                foreach (var mappedColumn in this.ColumnsMapper.MappedProperties)
                {
                    var headerHtml = this.GetTableHeaderHtmlFor(mappedColumn);

                    tableHeadersHtml.Append(headerHtml);
                }

                tableHeadersHtml.Append("</thead>");

                return tableHeadersHtml.ToString();
            }
        }

        /// <summary>
        /// Returns a table header HTML element for a column map.
        /// </summary>
        /// <param name="columnMap">The column map to use.</param>
        /// <returns>The table header HTML.</returns>
        private string GetTableHeaderHtmlFor(TableColumnMap<TItem> columnMap)
        {
            return string.Format("<th>{0}</th>", columnMap.HeaderText);
        }

        /// <summary>
        /// Returns a table headers HTML elements for all the properties in the 
        /// source item type.
        /// </summary>
        /// <returns>The table headers HTML.</returns>
        private string GetTableHeadersHtmlForAllProperties()
        {
            var tableHeadersHtml = new StringBuilder();
            var sourceItemProperties = typeof(TItem).GetProperties();

            tableHeadersHtml.Append("<thead>");

            foreach (var sourceItemProperty in sourceItemProperties)
            {
                var sourceMemberDisplayNameAttribute = sourceItemProperty.GetCustomAttribute<DisplayNameAttribute>(inherit: true);

                tableHeadersHtml.Append("<th>");

                if (sourceMemberDisplayNameAttribute.IsNotNull())
                {
                    tableHeadersHtml.Append(sourceMemberDisplayNameAttribute.DisplayName);
                }
                else
                {
                    tableHeadersHtml.Append(sourceItemProperty.Name);
                }
            
                tableHeadersHtml.AppendFormat("</th>");
            }

            tableHeadersHtml.Append("</thead>");

            return tableHeadersHtml.ToString();
        }

        /// <summary>
        /// Returns a table body HTML element with rows for the source enumerable items.
        /// </summary>
        /// <returns>The table body HTML.</returns>
        private string GetTableBodyHtml()
        {
            var tableBodyHtml = new StringBuilder();

            tableBodyHtml.Append("<tbody>");

            foreach (var item in this.Items)
            {
                var rowHtml = this.GetTableRowHtmlFor(item);

                tableBodyHtml.Append(rowHtml);
            }

            tableBodyHtml.Append("</tbody>");

            return tableBodyHtml.ToString();
        }

        /// <summary>
        /// Returns a table row HTML element for a single source item.
        /// </summary>
        /// <param name="item">The source item.</param>
        /// <returns>The table row HTML.</returns>
        private string GetTableRowHtmlFor(TItem item)
        {
            var rowHtml = new StringBuilder();

            rowHtml.Append("<tr>");

            if (this.ColumnsMapper.MappedProperties.IsNotEmpty())
            {
                foreach (var mappedColumn in this.ColumnsMapper.MappedProperties)
                {
                    var cellRawContent = mappedColumn.SourceProperty.GetValue(item);

                    string formattedCellContent = null;

                    if (mappedColumn.Format.IsNotNullOrEmpty())
                    {
                        formattedCellContent = string.Format(mappedColumn.Format, cellRawContent);
                    }

                    rowHtml.AppendFormat("<td>{0}</td>", formattedCellContent.OrIfIsNull(cellRawContent.ToString()));
                }
            }
            else
            {
                var sourceItemProperties = typeof(TItem).GetProperties();

                foreach (var sourceItemProperty in sourceItemProperties)
                {
                    var cellContent = sourceItemProperty.GetValue(item);

                    rowHtml.AppendFormat("<td>{0}</td>", cellContent);
                }
            }

            rowHtml.Append("</tr>");

            return rowHtml.ToString();
        }
    }
}
