//-----------------------------------------------------------------------
// <copyright file="HtmlElement.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a HTML element to be rendered in a view.
    /// </summary>
    public abstract class HtmlElement : HtmlElement<HtmlHelper>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement"/> class.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public HtmlElement(HtmlHelper htmlHelper)
            : base(htmlHelper)
        { 
        }
    }
}
