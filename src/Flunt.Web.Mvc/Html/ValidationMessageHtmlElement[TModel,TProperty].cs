using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class ValidationMessageHtmlElement<TModel, TProperty> : HtmlElement<TModel, TProperty>
    {
        private string message;

        public ValidationMessageHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.message = null;
        }

        public string Message
        {
            get { return this.message; }
            private set { this.message = value; }
        }

        public void With(string cssClass = null, string cssStyle = null, string message = null)
        {
            base.With(cssClass, cssStyle);

            this.Message = message;
        }

        public override string ToHtmlString()
        {
            var propertySelector = this.PropertySelector;
            var message = this.Message;
            var htmlAttributes = this.HtmlAttributes;

            var validationMessage = this.HtmlHelper.InnerHelper.ValidationMessageFor(propertySelector, message, htmlAttributes);

            return validationMessage.ToString();
        }
    }
}
