//-----------------------------------------------------------------------
// <copyright file="TextInputHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a text input HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    public class TextInputHtmlElement<TModel, TProperty> : InputHtmlElement<TModel, TProperty>
    {
        /// <summary>
        /// The name of the placeholder HTML attribute.
        /// </summary>
        public const string PlaceholderAttributeName = "placeholder";

        /// <summary>
        /// The text format to use.
        /// </summary>
        private string format;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextInputHtmlElement{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public TextInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.format = Empty.String;
        }

        /// <summary>
        /// Gets the placeholder used in case of empty text.
        /// </summary>
        public string Placeholder
        {
            get
            {
                return this.HtmlAttributes[PlaceholderAttributeName] as string;
            }

            private set
            {
                if (value.IsNotNullOrEmpty())
                {
                    this.HtmlAttributes[PlaceholderAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(PlaceholderAttributeName);
                }
            }
        }

        /// <summary>
        /// Gets the text format used.
        /// </summary>
        public string Format
        {
            get
            {
                return this.format;
            }

            private set
            {
                if (value.IsNotNullOrEmpty())
                {
                    this.format = value;
                }
                else
                {
                    this.format = null;
                }
            }
        }

        /// <summary>
        /// Sets configuration values for the rendered HTML text input.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <param name="placeholder">The placeholder to use on empty text.</param>
        /// <param name="disabled">The disabled state of the element.</param>
        /// <param name="readOnly">The read-only state of the element.</param>
        /// <param name="noEditorRules">Whether the element will skip editor rules.</param>
        /// <param name="cssClass">The class of the element.</param>
        /// <param name="cssStyle">The style of the element.</param>
        /// <returns>The <see cref="TextInputHtmlElement{TModel,TProperty,TItem}"/> instance.</returns>
        public TextInputHtmlElement<TModel, TProperty> With(string format = null, string placeholder = null, bool disabled = false, bool readOnly = false, bool noEditorRules = false, string cssClass = null, string cssStyle = null)
        {
            base.With(disabled, readOnly, noEditorRules, cssClass, cssStyle);

            this.Format = format;
            this.Placeholder = placeholder;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var textInput = this.HtmlHelper
                                .InnerHelper
                                     .TextBoxFor(
                                          format: this.Format,
                                          expression: this.PropertySelector,
                                          htmlAttributes: this.HtmlAttributes);

            return textInput.ToString();
        } 
    }
}
