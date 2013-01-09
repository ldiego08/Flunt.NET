using System;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class TextAreaInputHtmlElement<TModel, TProperty> : TextInputHtmlElement<TModel, TProperty>
    {
        public const string RowsAttributeName = "rows";

        public const string ColumnsAttributeName = "cols";

        public TextAreaInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        public int? Rows
        {
            get
            {
                return this.HtmlAttributes[RowsAttributeName] as int?;
            }

            private set
            {
                if (value.HasValue)
                {
                    this.HtmlAttributes[RowsAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(RowsAttributeName);
                }
            }
        }

        public int? Columns
        {
            get
            {
                return this.HtmlAttributes[ColumnsAttributeName] as int?;
            }

            private set
            {
                if (value.HasValue)
                {
                    this.HtmlAttributes[ColumnsAttributeName] = value;
                }
                else
                {
                    this.HtmlAttributes.Remove(ColumnsAttributeName);
                }
            }
        }

        public TextAreaInputHtmlElement<TModel, TProperty> With(string format = null, string placeholder = null, int? columns = null, int? rows = null, bool disabled = false, bool readOnly = false, bool noEditorRules = false, string cssClass = null, string cssStyle = null)
        {
            base.With(format, placeholder, disabled, readOnly, noEditorRules, cssClass, cssStyle);

            this.Rows = rows;
            this.Columns = columns;

            return this;
        }

        public override string ToHtmlString()
        {
            var propertySelector = this.PropertySelector;
            var htmlAttributes = this.HtmlAttributes;

            var textAreaInput = this.HtmlHelper.InnerHelper.TextAreaFor(propertySelector, htmlAttributes);

            return textAreaInput.ToString();
        }
    }
}
