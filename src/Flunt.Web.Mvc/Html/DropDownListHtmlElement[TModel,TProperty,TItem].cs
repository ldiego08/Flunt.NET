namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc.Html;

    public class DropDownListHtmlElement<TModel, TProperty, TItem> : InputHtmlElement<TModel, TProperty>
    {
        #region Fields

        private IEnumerable<TItem> items;

        private Expression<Func<TItem, object>> textPropertySelector;

        private Expression<Func<TItem, object>> valuePropertySelector;

        #endregion

        #region Constructor

        public DropDownListHtmlElement(Expression<Func<TModel, TProperty>> propertySelector, IEnumerable<TItem> items, HtmlHelper<TModel> htmlHelper)
            : base(propertySelector, htmlHelper)
        {
            this.items = items;
        }

        #endregion

        #region Properties

        public IEnumerable<TItem> Items
        {
            get { return this.items; }
            private set { this.items = value; }
        }

        #endregion

        #region Methods

        public DropDownListHtmlElement<TModel, TProperty, TItem> With(Expression<Func<TItem, object>> text, Expression<Func<TItem, object>> value, bool disabled = false, bool readOnly = false, bool noEditorRules = false, string cssClass = null, string cssStyle = null)
        {
            base.With(disabled, readOnly, noEditorRules, cssClass, cssStyle);

            this.textPropertySelector = text;
            this.valuePropertySelector = value;

            this.Items = items;

            return this;
        }

        public override string ToHtmlString()
        {
            var htmlHelper = this.HtmlHelper as HtmlHelper<TModel>;

            if (htmlHelper.IsNotNull())
            {
                var selectList = this.GetSelectList();
                var htmlAttributes = this.HtmlAttributes;
                var propertySelector = this.PropertySelector;
                
                var dropDownList = this.HtmlHelper.InnerHelper.DropDownListFor(propertySelector, selectList, htmlAttributes);

                return dropDownList.ToString();
            }
            else
            {
                return Empty.String;
            }
        }

        private IEnumerable<System.Web.Mvc.SelectListItem> GetSelectList()
        {
            if (items.IsDerivedOfGenericType(typeof(IDictionary<,>)))
            {
                this.InitializePropertySelectorsForDictionary();
            }

            var selectList = Empty.ListOf<System.Web.Mvc.SelectListItem>();

            var getTextFrom = this.textPropertySelector.Compile();
            var getValueFrom = this.valuePropertySelector.Compile();

            foreach (var item in items)
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

        #endregion
    }
}
