//-----------------------------------------------------------------------
// <copyright file="PartialExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Mvc.Html;

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
        /// <returns>A <see cref="PartialViewResultHtmlBlock"/> instance that renders the partial view.</returns>
        public static PartialViewResultHtmlBlock ForPartialView(this HtmlHelper htmlHelper, string partialViewName)
        {
            return new PartialViewResultHtmlBlock(partialViewName, htmlHelper);
        }

        /// <summary>
        /// Renders the specified partial view directly to the view context HTML writer optionally using the 
        /// specified model and view data.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="partialViewName">The name of the partial view.</param>
        /// <param name="withModel">The model for the partial view.</param>
        /// <param name="withViewData">The view data for the partial view.</param>
        public static void RenderPartialView(
            this HtmlHelper htmlHelper, 
            string partialViewName, 
            object withModel = null, 
            ViewDataDictionary withViewData = null)
        {
            htmlHelper.InnerHelper
                           .RenderPartial(
                                partialViewName, 
                                model: withModel, 
                                viewData: withViewData);
        }
    }
}
