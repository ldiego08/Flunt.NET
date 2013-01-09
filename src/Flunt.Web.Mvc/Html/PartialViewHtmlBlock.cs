﻿namespace Flunt.Web.Mvc.Html
{
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public class PartialViewHtmlBlock : HtmlBlock<Flunt.Web.Mvc.HtmlHelper>
    {
        #region Fields

        private readonly string partialViewName;

        private object model;

        private ViewDataDictionary viewData;

        #endregion

        #region Constructors

        public PartialViewHtmlBlock(string partialViewName, Flunt.Web.Mvc.HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            this.model = null;
            this.partialViewName = partialViewName;
        }

        #endregion

        #region Properties

        public object Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public ViewDataDictionary ViewData
        {
            get { return this.viewData; }
            private set { this.viewData = value; }
        }

        #endregion

        #region Methods

        public PartialViewHtmlBlock With(object model = null, ViewDataDictionary viewData = null)
        {
            this.Model = model;
            this.viewData = viewData;

            return this;
        }

        public override string ToHtmlString()
        {
            var model = this.Model;
            var viewData = this.ViewData;
            var partialViewName = this.partialViewName;

            var partialView = this.HtmlHelper.InnerHelper.Partial(partialViewName, model, viewData);

            return partialView.ToString();
        }

        #endregion
    }
}