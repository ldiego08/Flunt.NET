//-----------------------------------------------------------------------
// <copyright file="ExpressionDisplayHtmlBlock`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a block of HTML markup resulting of rendering a model property value optionally
    /// using a template and additional view data.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    public class ExpressionDisplayHtmlBlock<TModel, TProperty> : ModelDisplayHtmlBlock<HtmlHelper<TModel>>
    {
        /// <summary>
        /// The model property to render.
        /// </summary>
        private readonly Expression<Func<TModel, TProperty>> propertySelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionDisplayHtmlBlock{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property to render.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public ExpressionDisplayHtmlBlock(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.propertySelector = propertySelector;
        }

        /// <summary>
        /// Gets the model property to render.
        /// </summary>
        public Expression<Func<TModel, TProperty>> PropertySelector
        {
            get { return this.propertySelector; }
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var expressionDisplay = this.HtmlHelper
                                        .InnerHelper
                                            .DisplayFor(
                                                expression: this.PropertySelector, 
                                                templateName: this.TemplateName, 
                                                htmlFieldName: this.HtmlFieldName, 
                                                additionalViewData: this.AdditionalViewData);

            return expressionDisplay.ToString();
        }
    }
}
