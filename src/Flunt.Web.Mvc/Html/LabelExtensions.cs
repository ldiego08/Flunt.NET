using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    public static class LabelExtensions
    {
        public static LabelHtmlElement<TModel, TProperty> LabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;

            return new LabelHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);
        }
    }
}
