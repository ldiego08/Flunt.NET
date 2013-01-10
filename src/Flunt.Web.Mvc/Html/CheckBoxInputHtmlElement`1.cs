//-----------------------------------------------------------------------
// <copyright file="CheckBoxInputHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a checkbox input HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class CheckBoxInputHtmlElement<TModel> : InputHtmlElement<TModel, bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxInputHtmlElement{TModel}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public CheckBoxInputHtmlElement(Expression<Func<TModel, bool>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var htmlAttributes = this.HtmlAttributes;
            var propertySelector = this.PropertySelector;
            
            var checkBoxInput = this.HtmlHelper.InnerHelper.CheckBoxFor(propertySelector, htmlAttributes);

            return checkBoxInput.ToString();
        }
    }
}
