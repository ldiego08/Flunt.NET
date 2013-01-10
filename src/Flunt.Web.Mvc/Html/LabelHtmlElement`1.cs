//-----------------------------------------------------------------------
// <copyright file="LabelHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a label HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    public class LabelHtmlElement<TModel, TProperty> : HtmlElement<TModel, TProperty>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelHtmlElement{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public LabelHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var propertySelector = this.PropertySelector;
            var htmlAttributes = this.HtmlAttributes;

            var label = this.HtmlHelper.InnerHelper.LabelFor(propertySelector, htmlAttributes);

            return label.ToString();
        }
    }
}
