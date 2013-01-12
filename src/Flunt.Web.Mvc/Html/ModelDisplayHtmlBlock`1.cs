//-----------------------------------------------------------------------
// <copyright file="ModelDisplayHtmlBlock`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a block of HTML markup resulting of rendering property values of the model
    /// in the current view context optionally using a template and additional view data.
    /// </summary>
    /// <typeparam name="THtmlHelper">The type of the helper used to render HTML.</typeparam>
    public class ModelDisplayHtmlBlock<THtmlHelper> : HtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        /// <summary>
        /// The name of the template used to render the property value.
        /// </summary>
        private string templateName;

        /// <summary>
        /// The name for the rendered HTML field.
        /// </summary>
        private string htmlFieldName;

        /// <summary>
        /// Additional view data to be used when rendering the property value.
        /// </summary>
        private object additionalViewData;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelDisplayHtmlBlock{THtmlHelper}"/> class.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public ModelDisplayHtmlBlock(THtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.templateName = null;
            this.htmlFieldName = null;
            this.additionalViewData = null;
        }

        /// <summary>
        /// Gets the name of the template used to render the property value.
        /// </summary>
        public string TemplateName
        {
            get { return this.templateName; }
            private set { this.templateName = value; }
        }

        /// <summary>
        /// Gets the name for the rendered HTML field.
        /// </summary>
        public string HtmlFieldName
        {
            get { return this.htmlFieldName; }
            private set { this.htmlFieldName = value; }
        }

        /// <summary>
        /// Gets the additional view data to be used when rendering the property value.
        /// </summary>
        public object AdditionalViewData
        {
            get { return this.additionalViewData; }
            private set { this.additionalViewData = value; }
        }

        /// <summary>
        /// Sets configuration values for the rendered HTML block.
        /// </summary>
        /// <param name="template">The name of the template used to render the property value.</param>
        /// <param name="fieldName">The name for the rendered HTML field.</param>
        /// <param name="viewData">Additional view data to be used when rendering the property value.</param>
        /// <returns>The <see cref="ModelDisplayHtmlBlock{THtmlHelper}"/> instance.</returns>
        public ModelDisplayHtmlBlock<THtmlHelper> With(string template = null, string fieldName = null, object viewData = null)
        {
            this.TemplateName = template;
            this.HtmlFieldName = fieldName;
            this.AdditionalViewData = viewData;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var templateName = this.TemplateName;
            var htmlFieldName = this.HtmlFieldName;
            var additionalViewData = this.AdditionalViewData;

            var display = this.HtmlHelper.InnerHelper.DisplayForModel(templateName, htmlFieldName, additionalViewData);

            return display.ToString();
        }
    }
}
