using System.Web.Mvc;
using System.Web.Routing;

namespace Flunt.Web.Mvc
{
    public class HtmlHelper<TModel> : HtmlHelper
    {
        private readonly System.Web.Mvc.HtmlHelper<TModel> innerHtmlHelper;

        public HtmlHelper(System.Web.Mvc.HtmlHelper<TModel> innerHtmlHelper)
            : base(innerHtmlHelper)
        {
            this.innerHtmlHelper = innerHtmlHelper;
        }

        public new System.Web.Mvc.HtmlHelper<TModel> InnerHelper
        {
            get
            {
                return this.innerHtmlHelper;
            }
        }
    }
}
