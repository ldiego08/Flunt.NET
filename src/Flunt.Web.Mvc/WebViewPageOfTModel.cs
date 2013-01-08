namespace Flunt.Web.Mvc
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        #region Properties

        public new IHtmlHelper<TModel> Html { get; set; }

        #endregion

        #region Methods

        public override void InitHelpers()
        {
            base.InitHelpers();

            this.Html = new HtmlHelper<TModel>(this.ViewContext, this);
        }

        #endregion
    }
}
