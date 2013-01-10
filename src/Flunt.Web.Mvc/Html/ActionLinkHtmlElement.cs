//-----------------------------------------------------------------------
// <copyright file="ActionLinkHtmlElement.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents an anchor HTML element targeting a controller action to be rendered in a view.
    /// </summary>
    public class ActionLinkHtmlElement : HtmlElement
    {
        /// <summary>
        /// The name of the target action.
        /// </summary>
        private readonly string actionName;

        /// <summary>
        /// The name of the target controller.
        /// </summary>
        private readonly string controllerName;

        /// <summary>
        /// The text displayed in the anchor element.
        /// </summary>
        private string text;

        /// <summary>
        /// The values to be used in the action route.
        /// </summary>
        private object routeValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionLinkHtmlElement"/> class.
        /// </summary>
        /// <param name="actionName">The name of the target action.</param>
        /// <param name="controllerName">The name of the target controller.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public ActionLinkHtmlElement(string actionName, string controllerName, HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            if (actionName.IsNullOrEmpty())
            {
                this.actionName = htmlHelper.InnerHelper.ViewContext.RouteData.Values["Action"].ToString();
            }
            else
            {
                this.actionName = actionName;
            }

            if (controllerName.IsNullOrEmpty())
            {
                this.controllerName = htmlHelper.InnerHelper.ViewContext.RouteData.Values["Controller"].ToString();
            }
            else
            {
                this.controllerName = controllerName;
            }
        }

        /// <summary>
        /// Gets the name of the target action.
        /// </summary>
        public string ActionName
        {
            get { return this.actionName; }
        }

        /// <summary>
        /// Gets the name of the target controller.
        /// </summary>
        public string ControllerName
        {
            get { return this.controllerName; }
        }

        /// <summary>
        /// Gets the text displayed in the anchor element.
        /// </summary>
        public string Text
        {
            get { return this.text; }
            private set { this.text = value; }
        }

        /// <summary>
        /// Gets the values used in the action route.
        /// </summary>
        public object RouteValues
        {
            get { return this.routeValues; }
            private set { this.routeValues = value; }
        }

        /// <summary>
        /// Sets configuration values for the rendered HTML anchor element.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="routeValues">The target action route values.</param>
        /// <param name="cssClass">The element class.</param>
        /// <param name="cssStyle">The element style.</param>
        /// <returns>The <see cref="ActionLinkHtmlElement"/> instance.</returns>
        public ActionLinkHtmlElement With(string text = null, object routeValues = null, string cssClass = null, string cssStyle = null)
        {
            base.With(cssClass, cssStyle);

            this.Text = text;
            this.RouteValues = routeValues;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var text = this.Text;
            var actionName = this.ActionName;
            var controllerName = this.ControllerName;
            var routeValues = this.RouteValues;
            var htmlAttributes = this.HtmlAttributes;

            IHtmlString actionLink;

            if (routeValues.IsNotNull())
            {
                actionLink = this.HtmlHelper.InnerHelper.ActionLink(text, actionName, controllerName, routeValues, htmlAttributes);
            }
            else
            {
                actionLink = this.HtmlHelper.InnerHelper.ActionLink(text, actionName, controllerName, null, htmlAttributes);
            }
            
            return actionLink.ToString();
        }
    }
}
