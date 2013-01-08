namespace Flunt.Web.Mvc
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class HtmlHelper : System.Web.Mvc.HtmlHelper
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
