using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public static class NameExtensions
    {
        public static MvcHtmlString Id(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.InnerHelper.Id(name);
        }

        public static MvcHtmlString IdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            return htmlHelper.InnerHelper.IdFor(property);
        }

        public static MvcHtmlString IdForModel(this HtmlHelper htmlHelper)
        {
            return htmlHelper.InnerHelper.IdForModel();
        }

        public static MvcHtmlString Name(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.InnerHelper.Name(name);
        }

        public static MvcHtmlString NameFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            return htmlHelper.InnerHelper.NameFor(property);
        }

        public static MvcHtmlString NameForModel(this HtmlHelper htmlHelper)
        {
            return htmlHelper.InnerHelper.NameForModel();
        }
    }
}
