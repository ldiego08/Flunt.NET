//-----------------------------------------------------------------------
// <copyright file="SelectExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper{TModel}"/> class with additional methods to render select lists HTML elements.
    /// </summary>
    public static class SelectExtensions
    {
        /// <summary>
        /// Returns a drop-down select list HTML element renderer for the specified model property using the specified 
        /// enumerable as source.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <typeparam name="TItem">The type of the list source items.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <param name="withItems">The list source enumerable.</param>
        /// <returns>A <see cref="DropDownListHtmlElement{TModel,TProperty,TItem}"/> instance that renders the element.</returns>
        public static DropDownListHtmlElement<TModel, TProperty, TItem> DropDownListFor<TModel, TProperty, TItem>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> property, 
            IEnumerable<TItem> withItems)
        {
            var items = withItems;
            var propertySelector = property;

            return new DropDownListHtmlElement<TModel, TProperty, TItem>(propertySelector, items, htmlHelper);
        }

        /// <summary>
        /// Returns a drop-down select list HTML element renderer for the specified model property using the specified 
        /// dictionary as source.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <typeparam name="TKey">The type of the dictionary element key.</typeparam>
        /// <typeparam name="TValue">The type of the dictionary element value.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <param name="withItems">The list source dictionary.</param>
        /// <returns>A <see cref="DropDownListHtmlElement{TModel,TProperty,TItem}"/> instance that renders the element.</returns>
        public static DropDownListHtmlElement<TModel, TProperty, KeyValuePair<TKey, TValue>> DropDownListFor<TModel, TProperty, TKey, TValue>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> property, 
            IDictionary<TKey, TValue> withItems)
        {
            var items = withItems;
            var propertySelector = property;

            return new DropDownListHtmlElement<TModel, TProperty, KeyValuePair<TKey, TValue>>(propertySelector, items, htmlHelper);
        }
    }
}
