namespace Flunt.Web.Mvc.Html
{
    public static class LinkExtensions
    {
        public static ActionLinkHtmlElement LinkForAction(this IHtmlHelper htmlHelper, string action, string inController = null)
        {
            var actionName = action;
            var controllerName = inController;

            return new ActionLinkHtmlElement(actionName, controllerName, htmlHelper);
        }
    }
}
