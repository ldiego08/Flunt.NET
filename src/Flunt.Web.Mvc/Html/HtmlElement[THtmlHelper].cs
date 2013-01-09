namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Collections.Generic;
    
    public abstract class HtmlElement<THtmlHelper> : HtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        #region Constants

        public const string CssClassAttributeName = "class";

        public const string CssStyleAttributeName = "style";

        #endregion

        #region Fields

        private readonly IDictionary<string, object> htmlAttributes;

        #endregion

        #region Constructors

        public HtmlElement(THtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.htmlAttributes = Empty.DictionaryOf<string, object>();
            this.InitializeHtmlAttributes();
        }

        #endregion

        #region Properties

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

        #endregion

        #region Methods

        public HtmlElement<THtmlHelper> With(string cssClass = null, string cssStyle = null)
        {
            this.CssClass = cssClass;
            this.CssStyle = cssStyle;

            return this;
        }

        protected virtual void InitializeHtmlAttributes()
        {
        }

        #endregion
    }
}
