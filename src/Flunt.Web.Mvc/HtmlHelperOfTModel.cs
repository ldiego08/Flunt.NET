namespace Flunt.Web.Mvc
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class HtmlHelper<TModel> : HtmlHelper
    {
        #region Fields

        private readonly System.Web.Mvc.HtmlHelper<TModel> innerHtmlHelper;

        #endregion

        #region Constructors

        public HtmlHelper(System.Web.Mvc.HtmlHelper<TModel> innerHtmlHelper)
            : base(innerHtmlHelper)
        {
            this.innerHtmlHelper = innerHtmlHelper;
        }

        #endregion

        #region Properties

        public new System.Web.Mvc.HtmlHelper<TModel> InnerHelper
        {
            get
            {
                return this.innerHtmlHelper;
            }
        }

        #endregion
    }
}
