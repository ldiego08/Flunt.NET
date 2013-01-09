namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;

    public static class LabelExtensions
    {
        public static LabelHtmlElement<TModel, TProperty> LabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;

            return new LabelHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);
        }
    }
}
