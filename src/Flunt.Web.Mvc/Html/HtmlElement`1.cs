//-----------------------------------------------------------------------
// <copyright file="HtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
    
namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a HTML element to be rendered in a view.
    /// </summary>
    /// <typeparam name="THtmlHelper">The type of the helper used to render HTML.</typeparam>
    public abstract class HtmlElement<THtmlHelper> : HtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        /// <summary>
        /// The name of the class HTML attribute.
        /// </summary>
        public const string CssClassAttributeName = "class";

        /// <summary>
        /// The name of the style HTML attribute.
        /// </summary>
        public const string CssStyleAttributeName = "style";

        /// <summary>
        /// The attributes to be applied to the rendered element.
        /// </summary>
        private readonly IDictionary<string, object> htmlAttributes;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement{THtmlHelper}"/> class.
        /// </summary>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public HtmlElement(THtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.htmlAttributes = Empty.DictionaryOf<string, object>();
            this.InitializeHtmlAttributes();
        }

        /// <summary>
        /// Gets the element CSS class.
        /// </summary>
        public string CssClass
        {
            get 
            {
                if (this.HtmlAttributes.ContainsKey(CssClassAttributeName))
                {
                    return this.HtmlAttributes[CssClassAttributeName] as string;
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                if (value.IsNotNullOrEmpty())
                {
                    this.HtmlAttributes[CssClassAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(CssClassAttributeName);
                }
            }
        }

        /// <summary>
        /// Gets the element CSS style.
        /// </summary>
        public string CssStyle
        {
            get
            {
                if (this.HtmlAttributes.ContainsKey(CssStyleAttributeName))
                {
                    return this.HtmlAttributes[CssStyleAttributeName] as string;
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                if (value.IsNotNullOrEmpty())
                {
                    this.HtmlAttributes[CssStyleAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(CssStyleAttributeName);
                }
            }
        }

        /// <summary>
        /// Gets a valid HTML attribute for the element CSS style.
        /// </summary>
        protected string CssStyleAttribute
        {
            get
            {
                if (this.CssStyle.IsNotNullOrEmpty())
                {
                    return string.Format(@"style=""{0}""", this.CssStyle);
                }
                else
                {
                    return Empty.String;
                }
            }
        }

        /// <summary>
        /// Gets a valid HTML attribute for the element CSS class.
        /// </summary>
        protected string CssClassAttribute
        {
            get
            {
                if (this.CssClass.IsNotNullOrEmpty())
                {
                    return string.Format(@"class=""{0}""", this.CssClass);
                }
                else
                {
                    return Empty.String;
                }
            }
        }

        /// <summary>
        /// Gets the attributes to be applied to the rendered element.
        /// </summary>
        protected IDictionary<string, object> HtmlAttributes
        {
            get { return this.htmlAttributes; }
        }

        /// <summary>
        /// Sets configuration values for the rendered HTML element.
        /// </summary>
        /// <param name="cssClass">The element class.</param>
        /// <param name="cssStyle">The element style.</param>
        /// <returns>The <see cref="HtmlElement{THtmlHelper}"/> instance.</returns>
        public HtmlElement<THtmlHelper> With(string cssClass = null, string cssStyle = null)
        {
            this.CssClass = cssClass;
            this.CssStyle = cssStyle;

            return this;
        }

        /// <summary>
        /// Initializes the default values for HTML element attributes.
        /// </summary>
        protected virtual void InitializeHtmlAttributes()
        {
        }
    }
}
