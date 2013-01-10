//-----------------------------------------------------------------------
// <copyright file="HtmlBlock`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a block of valid HTML markup to be rendered in a view.
    /// </summary>
    /// <typeparam name="THtmlHelper">The type of the helper used to render HTML.</typeparam>
    public abstract class HtmlBlock<THtmlHelper> : IHtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        /// <summary>
        /// The helper used to render HTML.
        /// </summary>
        private readonly THtmlHelper htmlHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBlock{THtmlHelper}"/> class.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public HtmlBlock(THtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        /// <summary>
        /// Gets the helper used to render HTML.
        /// </summary>
        protected THtmlHelper HtmlHelper
        {
            get { return this.htmlHelper; }
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public abstract string ToHtmlString();
    }
}
