//-----------------------------------------------------------------------
// <copyright file="ValidationSummaryHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a validation summary HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class ValidationSummaryHtmlElement<TModel> : HtmlElement<HtmlHelper<TModel>>
    {
        /// <summary>
        /// The title to show in the summary.
        /// </summary>
        private string title;

        /// <summary>
        /// A value indicating whether model property errors should be shown in the summary.
        /// </summary>
        private bool skipPropertyErrors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationSummaryHtmlElement{TModel}"/> class.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public ValidationSummaryHtmlElement(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.title = null;
            this.skipPropertyErrors = true;
        }

        /// <summary>
        /// Gets the title to show in the summary.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether model property errors should be shown in the summary.
        /// </summary>
        public bool SkipPropertyErrors
        {
            get
            {
                return this.skipPropertyErrors;
            }

            private set
            {
                this.skipPropertyErrors = value;
            }
        }

        /// <summary>
        /// Sets configuration values for the rendered validation summary.
        /// </summary>
        /// <param name="skipPropertyErrors">A value indicating whether model property errors should be shown in the summary.</param>
        /// <param name="title">The title to show in the summary.</param>
        /// <param name="cssClass">The class of the element.</param>
        /// <param name="cssStyle">The style of the element.</param>
        /// <returns>The <see cref="ValidationSummaryHtmlElement{TModel}"/> instance.</returns>
        public ValidationSummaryHtmlElement<TModel> With(
            bool skipPropertyErrors = true, 
            string title = null, 
            string cssClass = null, 
            string cssStyle = null)
        {
            base.With(cssClass, cssStyle);

            this.Title = title;
            this.SkipPropertyErrors = skipPropertyErrors;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var title = this.Title;
            var htmlAttributes = this.HtmlAttributes;
            var skipPropertyErrors = this.SkipPropertyErrors;

            var validationSummary = this.HtmlHelper.InnerHelper.ValidationSummary(skipPropertyErrors, title, htmlAttributes);

            if (validationSummary.IsNotNull())
            {
                return validationSummary.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
