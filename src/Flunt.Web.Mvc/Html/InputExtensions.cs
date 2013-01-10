//-----------------------------------------------------------------------
// <copyright file="InputExtensions.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Extends the <see cref="HtmlHelper{TModel}"/> class with additional methods to render input HTML elements.
    /// </summary>
    public static class InputExtensions
    {
        /// <summary>
        /// Returns a checkbox input HTML element renderer for the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>A <see cref="CheckBoxInputHtmlElement{TModel}"/> instance that renders the element.</returns>
        public static CheckBoxInputHtmlElement<TModel> CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> property)
        {
            var propertySelector = property;
            var checkBox = new CheckBoxInputHtmlElement<TModel>(propertySelector, htmlHelper);

            return checkBox;
        }

        /// <summary>
        /// Returns a text input HTML element renderer for the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>A <see cref="TextInputHtmlElement{TModel,TProperty}"/> instance that renders the element.</returns>
        public static TextInputHtmlElement<TModel, TProperty> TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;
            var textBox = new TextInputHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);

            return textBox;
        }

        /// <summary>
        /// Returns a password input HTML element renderer for the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>A <see cref="PasswordInputHtmlElement{TModel,TProperty}"/> instance that renders the element.</returns>
        public static PasswordInputHtmlElement<TModel, TProperty> PasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;
            var passwordTextBox = new PasswordInputHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);

            return passwordTextBox;
        }

        /// <summary>
        /// Returns a text area HTML element renderer for the specified model property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the model property.</typeparam>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        /// <param name="property">The bound model property.</param>
        /// <returns>A <see cref="TextAreaInputHtmlElement{TModel,TProperty}"/> instance that renders the element.</returns>
        public static TextAreaInputHtmlElement<TModel, TProperty> TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertySelector = property;
            var textArea = new TextAreaInputHtmlElement<TModel, TProperty>(propertySelector, htmlHelper);

            return textArea;
        }
    }
}
