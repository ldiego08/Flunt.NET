﻿//-----------------------------------------------------------------------
// <copyright file="ActionLinkHtmlElement.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.Routing;

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
        /// The protocol used in the link target URL.
        /// </summary>
        private string protocol;

        /// <summary>
        /// The host name used in the link target URL.
        /// </summary>
        private string hostName;

        /// <summary>
        /// The fragment used in the link target URL.
        /// </summary>
        private string fragment;

        /// <summary>
        /// The values to be used in the action route.
        /// </summary>
        private RouteValueDictionary routeValues;

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
        /// Gets the protocol used in the link target URL.
        /// </summary>
        public string Protocol
        {
            get { return this.protocol; }
            private set { this.protocol = value; }
        }

        /// <summary>
        /// Gets the host name used in the link target URL.
        /// </summary>
        public string HostName
        {
            get { return this.hostName; }
            private set { this.hostName = value; }
        }

        /// <summary>
        /// Gets the fragment used in the link target URL.
        /// </summary>
        public string Fragment
        {
            get { return this.fragment; }
            private set { this.fragment = value; }
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
        /// <param name="text">The text to display.</param>
        /// <param name="protocol">The protocol used in the link target URL.</param>
        /// <param name="fragment">The fragment used in the link target URL.</param>
        /// <param name="hostName">The host name used in the link target URL.</param>
        /// <param name="routeValues">The target action route values.</param>
        /// <param name="cssClass">The element class.</param>
        /// <param name="cssStyle">The element style.</param>
        /// <returns>The <see cref="ActionLinkHtmlElement"/> instance.</returns>
        public ActionLinkHtmlElement With(
            string text = null, 
            string protocol = null,
            string fragment = null,
            string hostName = null,
            object routeValues = null, 
            string cssClass = null, 
            string cssStyle = null)
        {
            base.With(cssClass, cssStyle);

            this.Text = text;
            this.Protocol = protocol;
            this.HostName = hostName;
            this.Fragment = fragment;

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
            IHtmlString actionLink;

            if (this.Protocol.IsNullOrEmpty().Or(this.HostName.IsNullOrEmpty()).Or(this.Fragment.IsNullOrEmpty()))
            {
                actionLink = this.HtmlHelper
                                 .InnerHelper
                                     .ActionLink(
                                        linkText:       this.Text, 
                                        actionName:     this.ActionName, 
                                        controllerName: this.ControllerName, 
                                        routeValues:    this.RouteValues, 
                                        htmlAttributes: this.HtmlAttributes);
            }
            else
            {
                actionLink = this.HtmlHelper
                                 .InnerHelper
                                     .ActionLink(
                                        linkText:       this.Text, 
                                        actionName:     this.ActionName, 
                                        controllerName: this.ControllerName, 
                                        protocol:       this.Protocol, 
                                        hostName:       this.HostName, 
                                        fragment:       this.Fragment, 
                                        routeValues:    this.RouteValues, 
                                        htmlAttributes: this.HtmlAttributes);
            }
            
            return actionLink.ToString();
        }
    }
}
