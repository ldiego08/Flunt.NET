using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class ExpressionDisplayHtmlBlock<TModel, TProperty> : DisplayHtmlBlock<HtmlHelper<TModel>>
    {
        private readonly Expression<Func<TModel, TProperty>> propertySelector;

        public ExpressionDisplayHtmlBlock(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.propertySelector = propertySelector;
        }

        public override string ToHtmlString()
        {
            var propertySelector = this.propertySelector;
            var templateName = this.TemplateName;
            var htmlFieldName = this.HtmlFieldName;
            var additionalViewData = this.AdditionalViewData;

            var expressionDisplay = this.HtmlHelper.InnerHelper.DisplayFor(propertySelector, templateName, htmlFieldName, additionalViewData);

            return expressionDisplay.ToString();
        }
    }
}
