//-----------------------------------------------------------------------
// <copyright file="ValidationMessageHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a validation message HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    public class ValidationMessageHtmlElement<TModel, TProperty> : HtmlElement<TModel, TProperty>
    {
        /// <summary>
        /// The validation message.
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationMessageHtmlElement{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public ValidationMessageHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.message = null;
        }

        /// <summary>
        /// Gets the validation message.
        /// </summary>
        public string Message
        {
            get { return this.message; }
            private set { this.message = value; }
        }

        /// <summary>
        /// Sets configuration values for the rendered validation message.
        /// </summary>
        /// <param name="cssClass">The class of the element.</param>
        /// <param name="cssStyle">The style of the element.</param>
        /// <param name="message">The validation message.</param>
        /// <returns>The <see cref="ValidationMessageHtmlElement{TModel,TProperty}"/> instance.</returns>
        public ValidationMessageHtmlElement<TModel, TProperty> With(string cssClass = null, string cssStyle = null, string message = null)
        {
            base.With(cssClass, cssStyle);

            this.Message = message;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var validationMessage = this.HtmlHelper
                                        .InnerHelper
                                             .ValidationMessageFor(
                                                  expression: this.PropertySelector,
                                                  validationMessage: this.Message,
                                                  htmlAttributes: this.HtmlAttributes);

            return validationMessage.ToString();
        }
    }
}
