//-----------------------------------------------------------------------
// <copyright file="ValueExtensions.cs" company="Conturenet">
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
    /// Extends the <see cref="HtmlHelper"/> and <see cref="HtmlHelper{TModel}"/> classes with additional methods to 
    /// render view data values.
    /// </summary>
    public static class ValueExtensions
    {
        /// <summary>
        /// Returns the value of the view data or model property represented by the specified name.
        /// </summary>
        /// <param name="htmlHelper">The the helper used to render HTML.</param>
        /// <param name="name">The name of the view data or model property.</param>
        /// <param name="withFormat">The format to use with the value.</param>
        /// <returns>The view data property value.</returns>
        public static MvcHtmlString ValueFor(this HtmlHelper htmlHelper, string name, string withFormat = null)
        {
            return htmlHelper.InnerHelper.Value(name, format: withFormat);
        }

        /// <summary>
        /// Returns the value of the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProprety">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The model property.</param>
        /// <param name="withFormat">The format to use with the property value.</param>
        /// <returns>The model property value.</returns>
        public static MvcHtmlString ValueFor<TModel, TProprety>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProprety>> property, string withFormat = null)
        {
            return htmlHelper.InnerHelper.ValueFor(property, format: withFormat);
        }

        /// <summary>
        /// Returns the value of the current model.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="withFormat">The format to use with the value.</param>
        /// <returns>The model value.</returns>
        public static MvcHtmlString ValueForModel(this HtmlHelper htmlHelper, string withFormat = null)
        {
            return htmlHelper.InnerHelper.ValueForModel(withFormat);
        }
    }
}
