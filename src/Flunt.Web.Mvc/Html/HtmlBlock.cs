namespace Flunt.Web.Mvc.Html
{
    public abstract class HtmlBlock<THtmlHelper> : IHtmlBlock<THtmlHelper>
        where THtmlHelper : HtmlHelper
    {
        #region Fields

        private readonly THtmlHelper htmlHelper;

        #endregion

        #region Constructors

        public HtmlBlock(THtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        #endregion

        #region Properties

        protected THtmlHelper HtmlHelper
        {
            get { return this.htmlHelper; }
        }

        #endregion

        #region Methods

        public abstract string ToHtmlString();

        #endregion
    }
}
