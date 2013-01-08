namespace Flunt.Web.Mvc.Html
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public class ActionLinkHtmlElement : HtmlElement
    {
        #region Fields

        private readonly string actionName;

        private readonly string controllerName;

        private string text;

        private object routeValues;

        #endregion

        #region Contructors

        public ActionLinkHtmlElement(string actionName, string controllerName, IHtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            if (actionName.IsNullOrEmpty())
            {
                this.actionName = htmlHelper.ViewContext.RouteData.Values["Action"].ToString();
            }
            else
            {
                this.actionName = actionName;
            }

            if (controllerName.IsNullOrEmpty())
            {
                this.controllerName = htmlHelper.ViewContext.RouteData.Values["Controller"].ToString();
            }
            else
            {
                this.controllerName = controllerName;
            }
        }

        #endregion

        #region Properties

        public string ActionName
        {
            get { return this.actionName; }
        }

        public string ControllerName
        {
            get { return this.controllerName; }
        }

        public string Text
        {
            get { return this.text; }
            private set { this.text = value; }
        }

        public object RouteValues
        {
            get { return this.routeValues; }
            private set { this.routeValues = value; }
        }

        #endregion

        #region Methods

        public ActionLinkHtmlElement With(string text = null, object routeValues = null, string cssClass = null, string cssStyle = null)
        {
            base.With(cssClass, cssStyle);

            this.Text = text;
            this.RouteValues = routeValues;

            return this;
        }

        public override string ToHtmlString()
        {
            var text = this.Text;
            var actionName = this.ActionName;
            var controllerName = this.ControllerName;
            var routeValues = this.RouteValues;
            var htmlAttributes = this.HtmlAttributes;

            IHtmlString actionLink;

            var htmlHelper = this.HtmlHelper as HtmlHelper;

            if (htmlHelper.IsNotNull())
            {
                if (routeValues.IsNotNull())
                {
                    actionLink = htmlHelper.ActionLink(text, actionName, controllerName, routeValues, htmlAttributes);
                }
                else
                {
                    actionLink = htmlHelper.ActionLink(text, actionName, controllerName, null, htmlAttributes);
                }
            }
            else
            {
                actionLink = MvcHtmlString.Empty;
            }

            return actionLink.ToString();
        }

        #endregion
    }
}
