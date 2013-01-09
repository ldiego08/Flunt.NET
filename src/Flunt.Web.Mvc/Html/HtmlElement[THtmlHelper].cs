using System;
using System.Collections.Generic;
    
namespace Flunt.Web.Mvc.Html
{
    public abstract class HtmlElement<THtmlHelper> : HtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        public const string CssClassAttributeName = "class";

        public const string CssStyleAttributeName = "style";

        private readonly IDictionary<string, object> htmlAttributes;

        public HtmlElement(THtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.htmlAttributes = Empty.DictionaryOf<string, object>();
            this.InitializeHtmlAttributes();
        }

        public string CssClass
        {
            get 
            {
                return this.HtmlAttributes[CssClassAttributeName] as string; 
            }
            set
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

        public string CssStyle
        {
            get
            {
                return this.HtmlAttributes[CssStyleAttributeName] as string;
            }
            set
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

        protected IDictionary<string, object> HtmlAttributes
        {
            get { return this.htmlAttributes; }
        }

        public HtmlElement<THtmlHelper> With(string cssClass = null, string cssStyle = null)
        {
            this.CssClass = cssClass;
            this.CssStyle = cssStyle;

            return this;
        }

        protected virtual void InitializeHtmlAttributes()
        {
        }
    }
}
