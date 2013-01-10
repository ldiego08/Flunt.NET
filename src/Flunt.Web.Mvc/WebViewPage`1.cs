//-----------------------------------------------------------------------
// <copyright file="WebViewPage`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Flunt.Web.Mvc
{
    /// <summary>
    /// Represents the methods and properties that are needed to render a Razor view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        /// <summary>
        /// Gets or sets the helper used to render HTML.
        /// </summary>
        public new HtmlHelper<TModel> Html { get; set; }

        /// <summary>
        /// Initializes the helpers used for view rendering.
        /// </summary>
        public override void InitHelpers()
        {
            base.InitHelpers();

            var baseHtmlHelper = new System.Web.Mvc.HtmlHelper<TModel>(this.ViewContext, this);

            this.Html = new HtmlHelper<TModel>(baseHtmlHelper);
        }
    }
}
