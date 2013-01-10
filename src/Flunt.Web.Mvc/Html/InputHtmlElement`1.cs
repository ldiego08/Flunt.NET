//-----------------------------------------------------------------------
// <copyright file="InputHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a HTML input element to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    public abstract class InputHtmlElement<TModel, TProperty> : HtmlElement<TModel, TProperty>
    {
        /// <summary>
        /// The name of the disabled HTML attribute.
        /// </summary>
        public const string DisabledAttributeName = "disabled";

        /// <summary>
        /// The name of the read-only HTML attribute.
        /// </summary>
        public const string ReadOnlyAttributeName = "readonly";

        /// <summary>
        /// The name of the property in the view bag containing the editor view mode..
        /// </summary>
        public const string ViewModePropertyName = "ViewMode";

        /// <summary>
        /// Indicates whether the element skips editor rules.
        /// </summary>
        private bool skipEditoRules;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputHtmlElement{TModel,TProperty}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public InputHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.skipEditoRules = false;
        }

        /// <summary>
        /// Gets a value indicating whether the element is disabled.
        /// </summary>
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

        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
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

        /// <summary>
        /// Gets a value indicating whether the element skips editor rules.
        /// </summary>
        public bool SkipsEditorRules
        {
            get { return this.skipEditoRules; }
            private set { this.skipEditoRules = value; }
        }

        /// <summary>
        /// Gets the editor view current mode.
        /// </summary>
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

        /// <summary>
        /// Sets configuration values for the rendered HTML input element.
        /// </summary>
        /// <param name="disabled">The disabled state of the element.</param>
        /// <param name="readOnly">The read-only state of the element.</param>
        /// <param name="noEditorRules">Whether the element will skip editor rules.</param>
        /// <param name="cssClass">The class of the element.</param>
        /// <param name="cssStyle">The style of the element.</param>
        /// <returns>The <see cref="InputHtmlElement{TModel,TProperty,TItem}"/> instance.</returns>
        public InputHtmlElement<TModel, TProperty> With(bool disabled = false, bool readOnly = false, bool noEditorRules = false, string cssClass = null, string cssStyle = null) 
        {
            base.With(cssClass, cssStyle);

            this.IsReadOnly = readOnly;
            this.IsDisabled = disabled;

            return this;
        }

        /// <summary>
        /// Gets a value indicating whether the element is disabled according to the specified editor rules.
        /// </summary>
        /// <param name="isDisabled">A value indicating whether the element is disabled.</param>
        /// <param name="skipEditorRules">A value indicating whether the element skips editor rules.</param>
        /// <returns>true whether the element is disabled; otherwise, false.</returns>
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
