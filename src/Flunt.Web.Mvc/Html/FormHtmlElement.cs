using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Flunt.Web.Mvc.Html
{
    public class FormHtmlElement : HtmlElement
    {
        public FormHtmlElement(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }

        public MvcForm With(string actionName = null, string controllerName = null, object routeValues = null, FormMethod formMethod = FormMethod.Post, string cssClass = null, string cssStyle = null)
        {
            base.With(cssClass, cssStyle);

            if (controllerName.IsNullOrEmpty())
            {
                controllerName = this.HtmlHelper.InnerHelper.ViewContext.RouteData.Values["Controller"] as string;
            }

            if (actionName.IsNullOrEmpty())
            {
                actionName = this.HtmlHelper.InnerHelper.ViewContext.RouteData.Values["Action"] as string;
            }

            var htmlAttributes = this.HtmlAttributes;
            var safeRouteValues = new RouteValueDictionary(routeValues.OrIfIsNull(Empty.Dynamic));

            MvcForm form;

            if (routeValues.IsNotNull())
            {
                form = this.HtmlHelper.InnerHelper.BeginForm(actionName, controllerName, safeRouteValues, formMethod, htmlAttributes);
            }
            else
            {
                form = this.HtmlHelper.InnerHelper.BeginForm(actionName, controllerName, null, formMethod, htmlAttributes);
            }

            return form;
        }

        public override string ToHtmlString()
        {
            return Empty.String;
        } 
    }
}
