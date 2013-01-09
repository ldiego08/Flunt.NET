namespace Flunt.Web.Mvc.Html
{
    public abstract class HtmlBlock<THtmlHelper> : IHtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        private readonly THtmlHelper htmlHelper;

        public HtmlBlock(THtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        protected THtmlHelper HtmlHelper
        {
            get { return this.htmlHelper; }
        }

        public abstract string ToHtmlString();
    }
}
