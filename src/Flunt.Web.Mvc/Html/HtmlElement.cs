namespace Flunt.Web.Mvc.Html
{
    using System.Web.Mvc;

    public abstract class HtmlElement : HtmlElement<IHtmlHelper>
    {
        #region Constructors

        public HtmlElement(IHtmlHelper htmlHelper)
            : base(htmlHelper)
        { 
        }

        #endregion
    }
}
