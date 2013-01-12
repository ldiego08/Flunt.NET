//-----------------------------------------------------------------------
// <copyright file="PartialViewResultHtmlBlock.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a partial view to be rendered in a view.
    /// </summary>
    public class PartialViewResultHtmlBlock : HtmlBlock<Flunt.Web.Mvc.HtmlHelper>
    {
        /// <summary>
        /// The name of the partial view to render.
        /// </summary>
        private readonly string partialViewName;

        /// <summary>
        /// The model used by the partial view.
        /// </summary>
        private object model;

        /// <summary>
        /// The view data used by the partial view.
        /// </summary>
        private ViewDataDictionary viewData;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartialViewResultHtmlBlock"/> class.
        /// </summary>
        /// <param name="partialViewName">The name of the partial view to render.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public PartialViewResultHtmlBlock(string partialViewName, Flunt.Web.Mvc.HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.model = null;
            this.partialViewName = partialViewName;
            this.viewData = htmlHelper.InnerHelper.ViewData;
        }

        /// <summary>
        /// Gets the model used by the partial view.
        /// </summary>
        public object Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        /// <summary>
        /// Gets the view data used by the partial view.
        /// </summary>
        public ViewDataDictionary ViewData
        {
            get { return this.viewData; }
            private set { this.viewData = value; }
        }

        /// <summary>
        /// Sets configuration values for the rendered partial view.
        /// </summary>
        /// <param name="model">The model used by the partial view.</param>
        /// <param name="viewData">The view data used by the partial view.</param>
        /// <returns>The <see cref="PartialViewResultHtmlBlock"/> instance.</returns>
        public PartialViewResultHtmlBlock With(object model = null, ViewDataDictionary viewData = null)
        {
            this.Model = model;
            this.viewData = viewData;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var partialView = this.HtmlHelper
                                  .InnerHelper
                                       .Partial(
                                            partialViewName: this.partialViewName, 
                                            model: this.Model, 
                                            viewData: this.ViewData);

            return partialView.ToString();
        }
    }
}
