//-----------------------------------------------------------------------
// <copyright file="LinkExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper"/> class with additional methods to render anchor HTML elements.
    /// </summary>
    public static class LinkExtensions
    {
        /// <summary>
        /// Returns an anchor HTML element renderer for an action optionally located in another controller.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="action">The name of the target action.</param>
        /// <param name="inController">The name of the target controller.</param>
        /// <returns>A <see cref="ActionLinkHtmlElement"/> instance that renders the element.</returns>
        public static ActionLinkHtmlElement LinkForAction(this HtmlHelper htmlHelper, string action, string inController = null)
        {
            return new ActionLinkHtmlElement(
                actionName:     action, 
                controllerName: inController, 
                htmlHelper:     htmlHelper);
        }

        /// <summary>
        /// Returns an anchor HTML element renderer for a mapped route.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="route">The name of the target route.</param>
        /// <returns>A <see cref="RouteLinkHtmlElement"/> instance that renders the element.</returns>
        public static RouteLinkHtmlElement LinkForRoute(this HtmlHelper htmlHelper, string route)
        {
            return new RouteLinkHtmlElement(route, htmlHelper);
        }
    }
}
