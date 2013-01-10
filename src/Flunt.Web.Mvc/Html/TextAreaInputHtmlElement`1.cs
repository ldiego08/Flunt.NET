//-----------------------------------------------------------------------
// <copyright file="TextAreaInputHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a text area input HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    public class TextAreaInputHtmlElement<TModel, TProperty> : TextInputHtmlElement<TModel, TProperty>
    {
        /// <summary>
        /// The name of the rows HTML attribute.
        /// </summary>
        public const string RowsAttributeName = "rows";

        /// <summary>
        /// The name of the columns HTML attribute.
        /// </summary>
        public const string ColumnsAttributeName = "cols";

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAreaInputHtmlElement{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public TextAreaInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        /// <summary>
        /// Gets the number of rows.
        /// </summary>
        public int? Rows
        {
            get
            {
                return this.HtmlAttributes[RowsAttributeName] as int?;
            }

            private set
            {
                if (value.HasValue)
                {
                    this.HtmlAttributes[RowsAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(RowsAttributeName);
                }
            }
        }

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        public int? Columns
        {
            get
            {
                return this.HtmlAttributes[ColumnsAttributeName] as int?;
            }

            private set
            {
                if (value.HasValue)
                {
                    this.HtmlAttributes[ColumnsAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(ColumnsAttributeName);
                }
            }
        }

        /// <summary>
        /// Sets configuration values for the rendered HTML text area.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <param name="placeholder">The placeholder to use on empty text.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="rows">The number of rows.</param>
        /// <param name="disabled">The disabled state of the element.</param>
        /// <param name="readOnly">The read-only state of the element.</param>
        /// <param name="noEditorRules">Whether the element will skip editor rules.</param>
        /// <param name="cssClass">The class of the element.</param>
        /// <param name="cssStyle">The style of the element.</param>
        /// <returns>The <see cref="TextAreaInputHtmlElement{TModel,TProperty,TItem}"/> instance.</returns>
        public TextAreaInputHtmlElement<TModel, TProperty> With(
            string format = null, 
            string placeholder = null, 
            int? columns = null, 
            int? rows = null, 
            bool disabled = false, 
            bool readOnly = false, 
            bool noEditorRules = false, 
            string cssClass = null, 
            string cssStyle = null)
        {
            base.With(format, placeholder, disabled, readOnly, noEditorRules, cssClass, cssStyle);

            this.Rows = rows;
            this.Columns = columns;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var propertySelector = this.PropertySelector;
            var htmlAttributes = this.HtmlAttributes;

            var textAreaInput = this.HtmlHelper.InnerHelper.TextAreaFor(propertySelector, htmlAttributes);

            return textAreaInput.ToString();
        }
    }
}
