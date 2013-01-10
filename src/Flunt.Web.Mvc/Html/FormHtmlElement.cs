//-----------------------------------------------------------------------
// <copyright file="FormHtmlElement.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a form HTML element to be rendered in a view.
    /// </summary>
    public class FormHtmlElement : HtmlElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormHtmlElement"/> class.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public FormHtmlElement(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }

        /// <summary>
        /// Sets configuration values for the rendered HTML form.
        /// </summary>
        /// <param name="actionName">The name of the target action.</param>
        /// <param name="controllerName">The name of the target controller.</param>
        /// <param name="routeValues">The route values for the target action.</param>
        /// <param name="formMethod">The method used to submit the form.</param>
        /// <param name="cssClass">The element class.</param>
        /// <param name="cssStyle">The element style.</param>
        /// <returns>The configured <see cref="System.Web.Mvc.Html.MvcForm"/> instance.</returns>
        public MvcForm With(
            string actionName = null, 
            string controllerName = null, 
            object routeValues = null, 
            FormMethod formMethod = FormMethod.Post, 
            string cssClass = null, 
            string cssStyle = null)
        {
            base.With(cssClass, cssStyle);

            if (controllerName.IsNullOrEmpty())
            {
                controllerName = this.HtmlHelper.InnerHelper.ViewContext.RouteData.Values["Controller"] as string;
            }

            if (actionName.IsNullOrEmpty())
            {
                actionName = this.HtmlHelper.InnerHelper.ViewContext.RouteData.Values["Action"] as string;
            }

            var htmlAttributes = this.HtmlAttributes;
            var safeRouteValues = new RouteValueDictionary(routeValues.OrIfIsNull(Empty.Dynamic));

            MvcForm form;

            if (routeValues.IsNotNull())
            {
                form = this.HtmlHelper.InnerHelper.BeginForm(actionName, controllerName, safeRouteValues, formMethod, htmlAttributes);
            }
            else
            {
                form = this.HtmlHelper.InnerHelper.BeginForm(actionName, controllerName, null, formMethod, htmlAttributes);
            }

            return form;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            return Empty.String;
        } 
    }
}
