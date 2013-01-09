namespace Flunt.Web.Mvc
{
    public abstract class WebViewPage : System.Web.Mvc.WebViewPage
    {
        #region Properties

        public new HtmlHelper<object> Html { get; set; }

        #endregion

        #region Methods

        public override void InitHelpers()
        {
            base.InitHelpers();

            var baseHtmlHelper = new System.Web.Mvc.HtmlHelper<object>(this.ViewContext, this);

            this.Html = new HtmlHelper<object>(baseHtmlHelper);
        }

        #endregion
    }
}
