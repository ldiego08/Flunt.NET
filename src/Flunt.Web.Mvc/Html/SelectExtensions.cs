namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public static class SelectExtensions
    {
        public static DropDownListHtmlElement<TModel, TProperty, TItem> DropDownListFor<TModel, TProperty, TItem>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property, IEnumerable<TItem> withItems)
        {
            var items = withItems;
            var propertySelector = property;

            return new DropDownListHtmlElement<TModel, TProperty, TItem>(propertySelector, items, htmlHelper);
        }

        public static DropDownListHtmlElement<TModel, TProperty, KeyValuePair<TKey, TValue>> DropDownListFor<TModel, TProperty, TKey, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property, IDictionary<TKey, TValue> withItems)
        {
            var items = withItems;
            var propertySelector = property;

            return new DropDownListHtmlElement<TModel, TProperty, KeyValuePair<TKey, TValue>>(propertySelector, items, htmlHelper);
        }
    }
}
