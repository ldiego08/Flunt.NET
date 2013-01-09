using System;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class ValidationSummaryHtmlElement<TModel> : HtmlElement<HtmlHelper<TModel>>
    {
        private string title;

        private bool skipPropertyErrors;

        public ValidationSummaryHtmlElement(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.title = null;
            this.skipPropertyErrors = true;
        }

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

        public ValidationSummaryHtmlElement<TModel> With(bool skipPropertyErrors = true, string title = null, string cssClass = null, string cssStyle = null)
        {
            base.With(cssClass, cssStyle);

            this.Title = title;
            this.SkipPropertyErrors = skipPropertyErrors;

            return this;
        }

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
