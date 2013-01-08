namespace Flunt.Web.Mvc.Html
{
    using System.Web.Mvc;

    public abstract class HtmlBlock<THtmlHelper> : IHtmlBlock<THtmlHelper>
        where THtmlHelper : IHtmlHelper
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
