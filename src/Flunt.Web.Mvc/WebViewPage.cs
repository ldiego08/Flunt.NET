namespace Flunt.Web.Mvc
{
    public abstract class WebViewPage : System.Web.Mvc.WebViewPage
    {
        public new HtmlHelper<object> Html { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();

            var baseHtmlHelper = new System.Web.Mvc.HtmlHelper<object>(this.ViewContext, this);

            this.Html = new HtmlHelper<object>(baseHtmlHelper);
        }
    }
}
