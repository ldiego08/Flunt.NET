//-----------------------------------------------------------------------
// <copyright file="ActionResultHtmlBlock.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a block of valid HTML markup resulting of the execution of the specified action.
    /// </summary>
    public class ActionResultHtmlBlock : HtmlBlock<Flunt.Web.Mvc.HtmlHelper>
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
        /// The values to be used in the action route.
        /// </summary>
        private RouteValueDictionary routeValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResultHtmlBlock"/> class.
        /// </summary>
        /// <param name="actionName">The name of the target action.</param>
        /// <param name="controllerName">The name of the target controller.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public ActionResultHtmlBlock(string actionName, string controllerName, HtmlHelper htmlHelper)
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
        /// Gets the values used in the action route.
        /// </summary>
        public RouteValueDictionary RouteValues
        {
            get { return this.routeValues; }
            private set { this.routeValues = value; }
        }

        /// <summary>
        /// Sets configuration values for the rendered HTML anchor element.
        /// </summary>
        /// <param name="routeValues">The target action route values.</param>
        /// <returns>The <see cref="ActionResultHtmlBlock"/> instance.</returns>
        public ActionResultHtmlBlock With(object routeValues = null)
        {
            if (routeValues.IsNotNull())
            {
                this.RouteValues = new RouteValueDictionary(routeValues);
            }
            else
            {
                this.RouteValues = null;
            }

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var actionResult = this.HtmlHelper
                                   .InnerHelper
                                        .Action(
                                            actionName: this.ActionName,
                                            controllerName: this.ControllerName,
                                            routeValues: this.RouteValues);
        
            return actionResult.ToString();
        }
    }
}
