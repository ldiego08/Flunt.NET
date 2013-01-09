namespace Flunt.Web.Mvc.Html
{
    public abstract class HtmlElement : HtmlElement<HtmlHelper>
    {
        public HtmlElement(HtmlHelper htmlHelper)
            : base(htmlHelper)
        { 
        }
    }
}
