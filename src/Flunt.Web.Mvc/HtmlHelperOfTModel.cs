namespace Flunt.Web.Mvc
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class HtmlHelper<TModel> : System.Web.Mvc.HtmlHelper<TModel>, IHtmlHelper<TModel>
    {
        #region Constructors

        public HtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer)
            : base(viewContext, viewDataContainer)
        {
        }

        public HtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
            : base(viewContext, viewDataContainer, routeCollection)
        {
        }

        #endregion
    }
}
