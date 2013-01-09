namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc.Html;

    public class PasswordInputHtmlElement<TModel, TProperty> : TextInputHtmlElement<TModel, TProperty>
    {
        #region Constructors

        public PasswordInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        #endregion

        #region Methods

        public override string ToHtmlString()
        {
            var propertySelector = this.PropertySelector;
            var htmlAttributes = this.HtmlAttributes;

            var passwordInput = this.HtmlHelper.InnerHelper.PasswordFor(propertySelector, htmlAttributes);

            return passwordInput.ToString();
        }

        #endregion
    }
}
