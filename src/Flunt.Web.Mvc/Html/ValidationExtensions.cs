//-----------------------------------------------------------------------
// <copyright file="ValidationExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper{TModel}"/> class with additional methods to render validation messages.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Represents a validation message HTML element for the specified property to be rendered in a view.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>A <see cref="ValidationMessageHtmlElement{TModel,TProperty}"/> instance that renders the element.</returns>
        public static ValidationMessageHtmlElement<TModel, TProperty> ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var validationMessage = new ValidationMessageHtmlElement<TModel, TProperty>(property, htmlHelper);

            return validationMessage;
        }

        /// <summary>
        /// Represents a validation summary HTML element for the current model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <returns>A <see cref="ValidationSummaryHtmlElement{TModel}"/> instance that renders the element.</returns>
        public static ValidationSummaryHtmlElement<TModel> ValidationSummary<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            var validationSummary = new ValidationSummaryHtmlElement<TModel>(htmlHelper);

            return validationSummary;
        }
    }
}
