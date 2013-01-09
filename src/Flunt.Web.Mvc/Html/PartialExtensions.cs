namespace Flunt.Web.Mvc.Html
{
    public static class PartialExtensions
    {
        public static PartialViewHtmlBlock PartialView(this HtmlHelper htmlHelper, string partialViewName)
        {
            return new PartialViewHtmlBlock(partialViewName, htmlHelper);
        }
    }
}
