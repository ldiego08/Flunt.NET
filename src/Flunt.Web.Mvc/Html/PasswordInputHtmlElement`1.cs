//-----------------------------------------------------------------------
// <copyright file="PasswordInputHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a password input HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    public class PasswordInputHtmlElement<TModel, TProperty> : TextInputHtmlElement<TModel, TProperty>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordInputHtmlElement{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public PasswordInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var passwordInput = this.HtmlHelper
                                    .InnerHelper
                                           .PasswordFor(
                                                expression: this.PropertySelector,
                                                htmlAttributes: this.HtmlAttributes);

            return passwordInput.ToString();
        }
    }
}
