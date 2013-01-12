//-----------------------------------------------------------------------
// <copyright file="DropDownListHtmlElement`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    /// <summary>
    /// Represents a select HTML element bound to a strongly-typed enumerable to be rendered in a view.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the model property.</typeparam>
    /// <typeparam name="TItem">The type of the elements in the enumerable.</typeparam>
    public class DropDownListHtmlElement<TModel, TProperty, TItem> : InputHtmlElement<TModel, TProperty>
    {
        /// <summary>
        /// The enumerable containing the list items.
        /// </summary>
        private IEnumerable<TItem> items;

        /// <summary>
        /// The select list item text property selector expression.
        /// </summary>
        private Expression<Func<TItem, object>> textPropertySelector;

        /// <summary>
        /// The select list item value property selector expression.
        /// </summary>
        private Expression<Func<TItem, object>> valuePropertySelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownListHtmlElement{TModel,TProperty,TItem}"/> class.
        /// </summary>
        /// <param name="propertySelector">The model property selector expression.</param>
        /// <param name="items">The enumerable containing the list items.</param>
        /// <param name="htmlHelper">The helper used to render HTML.</param>
        public DropDownListHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, IEnumerable<TItem> items, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.items = items;
        }

        /// <summary>
        /// Gets the enumerable containing the list items.
        /// </summary>
        public IEnumerable<TItem> Items
        {
            get { return this.items; }
            private set { this.items = value; }
        }

        /// <summary>
        /// Sets configuration values for the rendered select HTML element.
        /// </summary>
        /// <param name="text">The property to bind the list item text.</param>
        /// <param name="value">The property to bind the list item value.</param>
        /// <param name="disabled">The disabled state of the element.</param>
        /// <param name="readOnly">The read-only state of the element.</param>
        /// <param name="noEditorRules">Whether the element will skip editor rules.</param>
        /// <param name="cssClass">The class of the element.</param>
        /// <param name="cssStyle">The style of the element.</param>
        /// <returns>The <see cref="DropDownListHtmlElement{TModel,TProperty,TItem}"/> instance.</returns>
        public DropDownListHtmlElement<TModel, TProperty, TItem> With(
            Expression<Func<TItem, object>> text, 
            Expression<Func<TItem, object>> value, 
            bool disabled = false, 
            bool readOnly = false, 
            bool noEditorRules = false, 
            string cssClass = null, 
            string cssStyle = null)
        {
            base.With(disabled, readOnly, noEditorRules, cssClass, cssStyle);

            this.textPropertySelector = text;
            this.valuePropertySelector = value;

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        public override string ToHtmlString()
        {
            var htmlHelper = this.HtmlHelper as HtmlHelper<TModel>;

            if (htmlHelper.IsNotNull())
            {
                var selectList = this.GetSelectList();
                
                var dropDownList = this.HtmlHelper
                                       .InnerHelper
                                            .DropDownListFor(
                                                selectList: selectList,
                                                expression: this.PropertySelector,
                                                htmlAttributes: this.HtmlAttributes);

                return dropDownList.ToString();
            }
            else
            {
                return Empty.String;
            }
        }

        /// <summary>
        /// Returns a list of <see cref="System.Web.Mvc.SelectListItem"/> resulting of parsing the specified
        /// source enumerable.
        /// </summary>
        /// <returns>The resulting <see cref="System.Web.Mvc.SelectListItem"/> list.</returns>
        private IEnumerable<System.Web.Mvc.SelectListItem> GetSelectList()
        {
            if (this.Items.IsDerivedOfGenericType(typeof(IDictionary<,>)))
            {
                this.InitializePropertySelectorsForDictionary();
            }

            var selectList = Empty.ListOf<System.Web.Mvc.SelectListItem>();

            var getTextFrom = this.textPropertySelector.Compile();
            var getValueFrom = this.valuePropertySelector.Compile();

            foreach (var item in this.Items)
            {
                string text;
                string value;

                if (this.textPropertySelector.IsNotNull())
                {
                    text = getTextFrom(item).ToString();
                }
                else
                {
                    text = item.ToString();
                }

                if (this.valuePropertySelector.IsNotNull())
                {
                    value = getValueFrom(item).ToString();
                }
                else
                {
                    value = item.ToString();
                }

                selectList.Add(new System.Web.Mvc.SelectListItem
                {
                    Text = text.ToString(),
                    Value = value.ToString()
                });
            }

            return selectList;
        }

        /// <summary>
        /// Initializes the text and value property selectors to be used with a dictionary.
        /// </summary>
        private void InitializePropertySelectorsForDictionary()
        {
            var expressionParameter = Expression.Parameter(typeof(TItem), "item");

            var keyPropertyExpression = Expression.Property(expressionParameter, "Key");
            var valuePropertyExpression = Expression.Property(expressionParameter, "Value");

            var keyPropertySelector = Expression.Lambda<Func<TItem, object>>(keyPropertyExpression, expressionParameter);
            var valuePropertySelector = Expression.Lambda<Func<TItem, object>>(valuePropertyExpression, expressionParameter);

            this.textPropertySelector = keyPropertySelector;
            this.valuePropertySelector = valuePropertySelector;
        }
    }
}
