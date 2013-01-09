using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class CheckBoxInputHtmlElement<TModel> : InputHtmlElement<TModel, bool>
    {
        public CheckBoxInputHtmlElement(Expression<Func<TModel, bool>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        public override string ToHtmlString()
        {
            var htmlAttributes = this.HtmlAttributes;
            var propertySelector = this.PropertySelector;
            
            var checkBoxInput = this.HtmlHelper.InnerHelper.CheckBoxFor(propertySelector, htmlAttributes);

            return checkBoxInput.ToString();
        }
    }
}
