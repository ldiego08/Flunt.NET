//-----------------------------------------------------------------------
// <copyright file="NameExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper"/> and <see cref="HtmlHelper{TModel}"/> classes with additional methods to get HTML element names and identifiers.
    /// </summary>
    public static class NameExtensions
    {
        /// <summary>
        /// Returns a unique HTML identifier for the specified string.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="name">The name to use for the identifier.</param>
        /// <returns>The resolved unique HTML identifier.</returns>
        public static MvcHtmlString Id(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.InnerHelper.Id(name);
        }

        /// <summary>
        /// Returns a unique HTML identifier for the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>The resolved unique HTML identifier.</returns>
        public static MvcHtmlString IdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            return htmlHelper.InnerHelper.IdFor(property);
        }

        /// <summary>
        /// Returns a unique HTML identifier for the current model.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <returns>The resolved unique HTML identifier.</returns>
        public static MvcHtmlString IdForModel(this HtmlHelper htmlHelper)
        {
            return htmlHelper.InnerHelper.IdForModel();
        }

        /// <summary>
        /// Returns a unique HTML name for the specified string.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="name">The name to use for the identifier.</param>
        /// <returns>The resolved unique HTML name.</returns>
        public static MvcHtmlString Name(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.InnerHelper.Name(name);
        }

        /// <summary>
        /// Returns a unique HTML name for the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>The resolved unique HTML name.</returns>
        public static MvcHtmlString NameFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            return htmlHelper.InnerHelper.NameFor(property);
        }

        /// <summary>
        /// Returns a unique HTML name for the current model.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <returns>The resolved unique HTML name.</returns>
        public static MvcHtmlString NameForModel(this HtmlHelper htmlHelper)
        {
            return htmlHelper.InnerHelper.NameForModel();
        }
    }
}
