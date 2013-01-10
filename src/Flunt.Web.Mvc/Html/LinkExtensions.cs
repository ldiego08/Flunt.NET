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
        /// Returns an anchor HTML element renderer optionally targeting a different action or controller.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="action">The name of the target action.</param>
        /// <param name="inController">The name of the target controller.</param>
        /// <returns>A <see cref="ActionLinkHtmlElement"/> instance that renders the element.</returns>
        public static ActionLinkHtmlElement LinkForAction(this HtmlHelper htmlHelper, string action, string inController = null)
        {
            var actionName = action;
            var controllerName = inController;

            return new ActionLinkHtmlElement(actionName, controllerName, htmlHelper);
        }
    }
}
