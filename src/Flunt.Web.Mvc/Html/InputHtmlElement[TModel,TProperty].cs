using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    public abstract class InputHtmlElement<TModel, TProperty> : HtmlElement<TModel, TProperty>
    {
        public const string DisabledAttributeName = "disabled";

        public const string ReadOnlyAttributeName = "readonly";

        public const string ViewModePropertyName = "ViewMode";

        private bool skipEditoRules;

        public InputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.skipEditoRules = false;
        }

        public bool IsDisabled
        {
            get
            {
                return this.HtmlAttributes.ContainsKey(DisabledAttributeName);
            }

            private set
            {
                if (value.IsTrue())
                {
                    this.HtmlAttributes[DisabledAttributeName] = "disabled";
                }
                else
                {
                    this.HtmlAttributes.Remove(DisabledAttributeName);
                }
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this.HtmlAttributes.ContainsKey(ReadOnlyAttributeName);
            }

            private set
            {
                if (value.IsTrue())
                {
                    this.HtmlAttributes[ReadOnlyAttributeName] = "readonly";
                }
                else
                {
                    this.HtmlAttributes.Remove(ReadOnlyAttributeName);
                }
            }
        }

        public bool SkipsEditorRules
        {
            get { return this.skipEditoRules; }
            private set { this.skipEditoRules = value; }
        }

        protected EditorWebViewMode ViewMode
        {
            get
            {
                var viewBag = this.HtmlHelper.InnerHelper.ViewBag as object;

                if (viewBag.Has(ViewModePropertyName))
                {
                    return (EditorWebViewMode)this.HtmlHelper.InnerHelper.ViewBag.ViewMode;
                }
                else
                {
                    return EditorWebViewMode.Unspecified;
                }
            }
        }

        public InputHtmlElement<TModel, TProperty> With(bool disabled = false, bool readOnly = false, bool noEditorRules = false, string cssClass = null, string cssStyle = null) 
        {
            base.With(cssClass, cssStyle);

            this.IsReadOnly = readOnly;
            this.IsDisabled = disabled;

            return this;
        }

        protected bool GetDisabledState(bool isDisabled, bool skipEditorRules)
        {
            if (skipEditorRules)
            {
                return isDisabled;
            }
            else
            {
                var viewModeIsEdit = this.ViewMode.IsEqualTo(EditorWebViewMode.Edit);
                var viewModeIsCreate = this.ViewMode.IsEqualTo(EditorWebViewMode.Create);

                return viewModeIsEdit.Or(viewModeIsCreate).IsFalse();
            }
        } 
    }
}
