namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc.Html;

    public class TextAreaInputHtmlElement<TModel, TProperty> : TextInputHtmlElement<TModel, TProperty>
    {
        #region Constants

        public const string RowsAttributeName = "rows";

        public const string ColumnsAttributeName = "cols";

        #endregion

        #region Constructors

        public TextAreaInputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
        }

        #endregion

        #region Properties

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

        #endregion

        #region Methods

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

        #endregion
    }
}
