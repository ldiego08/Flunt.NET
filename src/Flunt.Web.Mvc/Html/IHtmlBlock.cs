using System.Web;

namespace Flunt.Web.Mvc.Html
{ 
    public interface IHtmlBlock<THtmlHelper> : IHtmlString 
        where THtmlHelper : HtmlHelper
    {
    }
}
