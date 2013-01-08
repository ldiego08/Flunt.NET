namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;

    public static class InputExtensions
    {
        public static CheckBoxInputHtmlElement<TModel> CheckBoxFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> property)
        {
            return new CheckBoxInputHtmlElement<TModel>(property, htmlHelper);
        }
    }
}
