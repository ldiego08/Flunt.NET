using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class TextInputHtmlElement<TModel,TProperty> : InputHtmlElement<TModel, TProperty>
    {
        public const string PlaceholderAttributeName = "placeholder";

        private string format;

        public TextInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.format = Empty.String;
        }

        public string Placeholder
        {
            get
            {
                return this.HtmlAttributes[PlaceholderAttributeName] as string;
            }

            private set
            {
                if (value.IsNotNullOrEmpty())
                {
                    this.HtmlAttributes[PlaceholderAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(PlaceholderAttributeName);
                }
            }
        }

        public string Format
        {
            get
            {
                return this.format;
            }

            private set
            {
                if (value.IsNotNullOrEmpty())
                {
                    this.format = value;
                }
                else
                {
                    this.format = null;
                }
            }
        }

        public TextInputHtmlElement<TModel, TProperty> With(string format = null, string placeholder = null, bool disabled = false, bool readOnly = false, bool noEditorRules = false, string cssClass = null, string cssStyle = null)
        {
            base.With(disabled, readOnly, noEditorRules, cssClass, cssStyle);

            this.Format = format;
            this.Placeholder = placeholder;

            return this;
        }

        public override string ToHtmlString()
        {
            var format = this.Format;
            var selector = this.PropertySelector;
            var htmlAttributes = this.HtmlAttributes;

            var textInput = this.HtmlHelper.InnerHelper.TextBoxFor(selector, format, htmlAttributes);

            return textInput.ToString();
        } 
    }
}
