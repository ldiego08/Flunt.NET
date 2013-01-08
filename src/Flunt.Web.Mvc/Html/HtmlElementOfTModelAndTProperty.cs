namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public abstract class HtmlElement<TModel, TProperty> : HtmlElement<IHtmlHelper<TModel>>
    {
        #region Fields

        private readonly Expression<Func<TModel, TProperty>> propertySelector;

        #endregion

        #region Constructors

        public HtmlElement(Expression<Func<TModel, TProperty>> propertySelector, IHtmlHelper<TModel> htmlHelper)
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
