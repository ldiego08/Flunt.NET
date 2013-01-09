namespace Flunt.Web.Mvc
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        #region Properties

        public new HtmlHelper<TModel> Html { get; set; }

        #endregion

        #region Methods

        public override void InitHelpers()
        {
            base.InitHelpers();

            var baseHtmlHelper = new System.Web.Mvc.HtmlHelper<TModel>(this.ViewContext, this);

            this.Html = new HtmlHelper<TModel>(baseHtmlHelper);
        }

        #endregion
    }
}
