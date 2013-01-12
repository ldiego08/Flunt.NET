using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class ExpressionDisplayHtmlBlock : DisplayHtmlBlock<HtmlHelper>
    {
        private readonly string expression;

        public ExpressionDisplayHtmlBlock(string expression, HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.expression = expression;
        }

        public override string ToHtmlString()
        {
            var expression = this.expression;
            var templateName = this.TemplateName;
            var htmlFieldName = this.HtmlFieldName;
            var additionalViewData = this.AdditionalViewData;

            var expressionDisplay = this.HtmlHelper.InnerHelper.Display(expression, templateName, htmlFieldName, additionalViewData);

            return expressionDisplay.ToString();
        }
    }
}
