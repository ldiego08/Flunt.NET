namespace Flunt.Web.Mvc.Html
{
    using System.Web;
    using System.Web.Mvc;

    public interface IHtmlBlock<THtmlHelper> : IHtmlString 
        where THtmlHelper : IHtmlHelper
    {
    }
}
