//-----------------------------------------------------------------------
// <copyright file="LabelExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper{TModel}"/> class with additional methods to render label HTML elements.
    /// </summary>
    public static class LabelExtensions
    {
        /// <summary>
        /// Returns a label HTML element renderer for the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>A <see cref="LabelHtmlElement{TModel,TProperty}"/> instance that renders the element.</returns>
        public static LabelHtmlElement<TModel, TProperty> LabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            return new LabelHtmlElement<TModel, TProperty>(property, htmlHelper);
        }
    }
}
