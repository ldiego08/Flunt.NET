namespace Flunt.Web.Mvc.Html
{
    using System.Web;
    
    public interface IHtmlBlock<THtmlHelper> : IHtmlString 
        where THtmlHelper : HtmlHelper
    {
    }
}
