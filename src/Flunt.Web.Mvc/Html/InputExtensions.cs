namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;

    public static class InputExtensions
    {
        public static CheckBoxInputHtmlElement<TModel> CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> property)
        {
            var propertySelector = property;
            var checkBox = new CheckBoxInputHtmlElement<TModel>(propertySelector, htmlHelper);

            return checkBox;
        }

        public static TextInputHtmlElement<TModel, TProperty> TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;
            var textBox = new TextInputHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);

            return textBox;
        }

        public static PasswordInputHtmlElement<TModel, TProperty> PasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;
            var passwordTextBox = new PasswordInputHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);

            return passwordTextBox;
        }

        public static TextAreaInputHtmlElement<TModel, TProperty> TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;
            var textArea = new TextAreaInputHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);

            return textArea;
        }
    }
}
