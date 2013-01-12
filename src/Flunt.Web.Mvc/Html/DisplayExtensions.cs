//-----------------------------------------------------------------------
// <copyright file="DisplayExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper"/> and <see cref="HtmlHelper{TModel}"/> classes with additional methods to render view data and model values.
    /// </summary>
    public static class DisplayExtensions
    {
        /// <summary>
        /// Returns an HTML renderer for a model or view data property value  represented by the 
        /// specified expression.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="expression">The expression to render.</param>
        /// <returns>A <see cref="ExpressionDisplayHtmlBlock"/> instance that renders the expression.</returns>
        public static ExpressionDisplayHtmlBlock DisplayFor(this HtmlHelper htmlHelper, string expression)
        {
            return new ExpressionDisplayHtmlBlock(expression, htmlHelper);
        }

        /// <summary>
        /// Returns an HTML renderer for a model property value.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The model property to render.</param>
        /// <returns>
        /// A <see cref="ExpressionDisplayHtmlBlock{TModel,TProperty}"/> instance that renders 
        /// the model property value.
        /// </returns>
        public static ExpressionDisplayHtmlBlock<TModel, TProperty> DisplayFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;

            return new ExpressionDisplayHtmlBlock<TModel, TProperty>(propertySelector, htmlHelper);
        }

        /// <summary>
        /// Returns an HTML renderer for all the properties of the model in the current view context.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <returns>
        /// A <see cref="ModelDisplayHtmlBlock{HtmlHelper}"/> instance that renders all the values of 
        /// each model property.
        /// </returns>
        public static ModelDisplayHtmlBlock<HtmlHelper> DisplayForModel(this HtmlHelper htmlHelper)
        {
            return new ModelDisplayHtmlBlock<HtmlHelper>(htmlHelper);
        }
    }
}
