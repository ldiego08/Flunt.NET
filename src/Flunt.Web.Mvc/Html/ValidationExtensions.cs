using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    public static class ValidationExtensions
    {
        public static ValidationMessageHtmlElement<TModel, TProperty> ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;
            var validationMessage = new ValidationMessageHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);

            return validationMessage;
        }

        public static ValidationSummaryHtmlElement<TModel> ValidationSummary<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            var validationSummary = new ValidationSummaryHtmlElement<TModel>(htmlHelper);

            return validationSummary;
        }
    }
}
