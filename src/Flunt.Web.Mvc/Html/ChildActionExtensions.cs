//-----------------------------------------------------------------------
// <copyright file="ChildActionExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper"/> class with additional methods to render the result of
    /// executing controller actions.
    /// </summary>
    public static class ChildActionExtensions
    {
        /// <summary>
        /// Returns a renderer for the specified action optionally in another controller and additional 
        /// route values.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="action">The name of the target action.</param>
        /// <param name="inController">The name of the target controller.</param>
        /// <returns>A <see cref="ActionResultHtmlBlock"/> instance.</returns>
        public static ActionResultHtmlBlock ForAction(this HtmlHelper htmlHelper, string action, string inController = null)
        {
            return new ActionResultHtmlBlock(
                actionName:     action,
                controllerName: inController,
                htmlHelper:     htmlHelper);
        }

        /// <summary>
        /// Renders the specified action result directly to the view context HTML writer optionally
        /// located in a different controller and additional route values.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="action">The name of the target action.</param>
        /// <param name="inController">The name of the target controller.</param>
        /// <param name="withRouteValues">The route values.</param>
        public static void ForAction(this HtmlHelper htmlHelper, string action, string inController = null, string withRouteValues = null)
        {
            htmlHelper.InnerHelper.RenderAction(
                actionName:     action,
                controllerName: inController,
                routeValues:    withRouteValues);
        }
    }
}
