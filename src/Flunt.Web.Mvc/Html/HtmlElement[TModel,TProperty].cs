using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    public abstract class HtmlElement<TModel, TProperty> : HtmlElement<HtmlHelper<TModel>>
    {
        private readonly Expression<Func<TModel, TProperty>> propertySelector;

        public HtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.propertySelector = propertySelector;
        }

        protected Expression<Func<TModel, TProperty>> PropertySelector
        {
            get { return this.propertySelector; }
        }
    }
}
