using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Mvc.Html;

namespace Flunt.Web.Mvc.Html
{
    public class ActionLinkHtmlElement : HtmlElement
    {
        private readonly string actionName;

        private readonly string controllerName;

        private string text;

        private object routeValues;

        public ActionLinkHtmlElement(string actionName, string controllerName, HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            if (actionName.IsNullOrEmpty())
            {
                this.actionName = htmlHelper.InnerHelper.ViewContext.RouteData.Values["Action"].ToString();
            }
            else
            {
                this.actionName = actionName;
            }

            if (controllerName.IsNullOrEmpty())
            {
                this.controllerName = htmlHelper.InnerHelper.ViewContext.RouteData.Values["Controller"].ToString();
            }
            else
            {
                this.controllerName = controllerName;
            }
        }

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

            if (routeValues.IsNotNull())
            {
                actionLink = this.HtmlHelper.InnerHelper.ActionLink(text, actionName, controllerName, routeValues, htmlAttributes);
            }
            else
            {
                actionLink = this.HtmlHelper.InnerHelper.ActionLink(text, actionName, controllerName, null, htmlAttributes);
            }
            
            return actionLink.ToString();
        }
    }
}
