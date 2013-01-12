using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    public static class DisplayExtensions
    {
        public static ExpressionDisplayHtmlBlock DisplayFor(this HtmlHelper htmlHelper, string expression)
        {
            return new ExpressionDisplayHtmlBlock(expression, htmlHelper);
        }

        public static ExpressionDisplayHtmlBlock<TModel, TProperty> DisplayFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;

            return new ExpressionDisplayHtmlBlock<TModel, TProperty>(propertySelector, htmlHelper);
        }

        public static DisplayHtmlBlock<HtmlHelper> DisplayForModel(this HtmlHelper htmlHelper)
        {
            return new DisplayHtmlBlock<HtmlHelper>(htmlHelper);
        }
    }
}
