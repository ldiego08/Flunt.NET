using System.Web.Mvc;
using System.Web.Routing;

namespace Flunt.Web.Mvc
{
    public class HtmlHelper
    {
        private readonly System.Web.Mvc.HtmlHelper innerHtmlHelper;

        public HtmlHelper(System.Web.Mvc.HtmlHelper innerHtmlHelper)
        {
            this.innerHtmlHelper = innerHtmlHelper;
        }

        public System.Web.Mvc.HtmlHelper InnerHelper
        {
            get 
            { 
                return this.innerHtmlHelper; 
            }
        }
    }
}
