namespace Flunt.Web.Mvc
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class HtmlHelper
    {
        #region Fields

        private readonly System.Web.Mvc.HtmlHelper innerHtmlHelper;

        #endregion

        #region Constructors

        public HtmlHelper(System.Web.Mvc.HtmlHelper innerHtmlHelper)
        {
            this.innerHtmlHelper = innerHtmlHelper;
        }

        #endregion

        #region Properties

        public System.Web.Mvc.HtmlHelper InnerHelper
        {
            get 
            { 
                return this.innerHtmlHelper; 
            }
        }

        #endregion
    }
}
