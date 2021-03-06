﻿//-----------------------------------------------------------------------
// <copyright file="ExpressionDisplayHtmlBlock.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a block of HTML markup resulting of rendering a value represented by the
    /// specified expression optionally using a template and additional view data.
    /// </summary>
    public class ExpressionDisplayHtmlBlock : ModelDisplayHtmlBlock<HtmlHelper>
    {
        /// <summary>
        /// The expression representing the value to be rendered.
        /// </summary>
        private readonly string expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionDisplayHtmlBlock"/> class.
        /// </summary>
        /// <param name="expression">The expression representing the value to be rendered.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public ExpressionDisplayHtmlBlock(string expression, HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Gets the expression representing the value to be rendered.
        /// </summary>
        public string Expression
        {
            get { return this.expression; }
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var expressionDisplay = this.HtmlHelper
                                        .InnerHelper
                                            .Display(
                                                expression: this.Expression, 
                                                templateName: this.TemplateName, 
                                                htmlFieldName: this.HtmlFieldName, 
                                                additionalViewData: this.AdditionalViewData);

            return expressionDisplay.ToString();
        }
    }
}
