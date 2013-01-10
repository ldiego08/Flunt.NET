//-----------------------------------------------------------------------
// <copyright file="PartialExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper"/> class with additional methods to render partial views.
    /// </summary>
    public static class PartialExtensions
    {
        /// <summary>
        /// Returns a partial view renderer for the specified partial view name.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="partialViewName">The name of the partial view to render.</param>
        /// <returns>A <see cref="PartialViewHtmlBlock"/> instance that renders the partial view.</returns>
        public static PartialViewHtmlBlock PartialView(this HtmlHelper htmlHelper, string partialViewName)
        {
            return new PartialViewHtmlBlock(partialViewName, htmlHelper);
        }
    }
}
