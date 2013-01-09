namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;
    
    public abstract class HtmlElement<TModel, TProperty> : HtmlElement<HtmlHelper<TModel>>
    {
        #region Fields

        private readonly Expression<Func<TModel, TProperty>> propertySelector;

        #endregion

        #region Constructors

        public HtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.propertySelector = propertySelector;
        }

        #endregion

        #region Properties

        protected Expression<Func<TModel, TProperty>> PropertySelector
        {
            get { return this.propertySelector; }
        }

        #endregion
    }
}
