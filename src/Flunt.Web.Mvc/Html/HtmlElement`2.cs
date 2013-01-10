//-----------------------------------------------------------------------
// <copyright file="HtmlElement`2.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a HTML element for a model property to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    public abstract class HtmlElement<TModel, TProperty> : HtmlElement<HtmlHelper<TModel>>
    {
        /// <summary>
        /// The model property selector expression.
        /// </summary>
        private readonly Expression<Func<TModel, TProperty>> propertySelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public HtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.propertySelector = propertySelector;
        }

        /// <summary>
        /// Gets the model property selector expression.
        /// </summary>
        protected Expression<Func<TModel, TProperty>> PropertySelector
        {
            get { return this.propertySelector; }
        }
    }
}
