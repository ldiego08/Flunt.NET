﻿//-----------------------------------------------------------------------
// <copyright file="WebViewPage.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Flunt.Web.Mvc
{
    /// <summary>
    /// Represents the methods and properties that are needed to render a Razor view.
    /// </summary>
    public abstract class WebViewPage : System.Web.Mvc.WebViewPage
    {
        /// <summary>
        /// Gets or sets the helper used to render HTML.
        /// </summary>
        public new HtmlHelper<object> Html { get; set; }

        /// <summary>
        /// Initializes the helpers used for view rendering.
        /// </summary>
        public override void InitHelpers()
        {
            base.InitHelpers();

            var baseHtmlHelper = new System.Web.Mvc.HtmlHelper<object>(this.ViewContext, this);

            this.Html = new HtmlHelper<object>(baseHtmlHelper);
        }
    }
}
