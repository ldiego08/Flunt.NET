using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class LabelHtmlElement<TModel, TProperty> : HtmlElement<TModel, TProperty>
    {
        public LabelHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        public override string ToHtmlString()
        {
            var propertySelector = this.PropertySelector;
            var htmlAttributes = this.HtmlAttributes;

            var label = this.HtmlHelper.InnerHelper.LabelFor(propertySelector, htmlAttributes);

            return label.ToString();
        }
    }
}
