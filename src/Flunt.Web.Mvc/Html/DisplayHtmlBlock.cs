using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class DisplayHtmlBlock<THtmlHelper> : HtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        private string templateName;

        private string htmlFieldName;

        private object additionalViewData;

        public DisplayHtmlBlock(THtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.templateName = null;
            this.htmlFieldName = null;
            this.additionalViewData = null;
        }

        public string TemplateName
        {
            get { return this.templateName; }
            private set { this.templateName = value; }
        }

        public string HtmlFieldName
        {
            get { return this.htmlFieldName; }
            private set { this.htmlFieldName = value; }
        }

        public object AdditionalViewData
        {
            get { return this.additionalViewData; }
            private set { this.additionalViewData = value; }
        }

        public DisplayHtmlBlock<THtmlHelper> With(string template = null, string fieldName = null, object viewData = null)
        {
            this.TemplateName = template;
            this.HtmlFieldName = fieldName;
            this.AdditionalViewData = viewData;

            return this;
        }

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
