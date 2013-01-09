using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class PasswordInputHtmlElement<TModel, TProperty> : TextInputHtmlElement<TModel, TProperty>
    {
        public PasswordInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        public override string ToHtmlString()
        {
            var propertySelector = this.PropertySelector;
            var htmlAttributes = this.HtmlAttributes;

            var passwordInput = this.HtmlHelper.InnerHelper.PasswordFor(propertySelector, htmlAttributes);

            return passwordInput.ToString();
        }
    }
}
