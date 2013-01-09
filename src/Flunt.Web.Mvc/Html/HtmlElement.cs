namespace Flunt.Web.Mvc.Html
{
    public abstract class HtmlElement : HtmlElement<HtmlHelper>
    {
        #region Constructors

        public HtmlElement(HtmlHelper htmlHelper)
            : base(htmlHelper)
        { 
        }

        #endregion
    }
}
