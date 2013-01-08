namespace Flunt.Web.Mvc
{
    public abstract class WebViewPage : System.Web.Mvc.WebViewPage
    {
        #region Properties

        public new IHtmlHelper<object> Html { get; set; }

        #endregion

        #region Methods

        public override void InitHelpers()
        {
            base.InitHelpers();

            this.Html = new HtmlHelper<object>(this.ViewContext, this);
        }

        #endregion
    }
}
