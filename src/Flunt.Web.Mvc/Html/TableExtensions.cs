//-----------------------------------------------------------------------
// <copyright file="TableExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper"/> class with additional methods to render HTMl table elements
    /// </summary>
    public static class TableExtensions
    {
        /// <summary>
        /// Returns a table HTML element renderer for a enumerable.
        /// </summary>
        /// <typeparam name="TItem">The type of the source enumerable items.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="items">The table source enumerable.</param>
        /// <returns>A <see cref="TableHtmlElement{TItem}"/> instance that renders the element.</returns>
        public static TableHtmlElement<TItem> TableFor<TItem>(this HtmlHelper htmlHelper, IEnumerable<TItem> items)
        {
            return new TableHtmlElement<TItem>(items, htmlHelper);
        }
    }
}
