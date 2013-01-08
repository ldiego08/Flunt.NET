namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc.Html;

    public class CheckBoxInputHtmlElement<TModel> : InputHtmlElement<TModel, bool>
    {
        #region Constructors

        public CheckBoxInputHtmlElement(Expression<Func<TModel, bool>> propertySelector, IHtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        #endregion

        #region Methods

        public override string ToHtmlString()
        {
            var htmlAttributes = this.HtmlAttributes;
            var propertySelector = this.PropertySelector;
            var htmlHelper = this.HtmlHelper as HtmlHelper<TModel>;

            var checkBoxInput = htmlHelper.CheckBoxFor(propertySelector, htmlAttributes);

            return checkBoxInput.ToString();
        }

        #endregion
    }
}
