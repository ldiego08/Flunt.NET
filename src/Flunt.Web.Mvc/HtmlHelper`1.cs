//-----------------------------------------------------------------------
// <copyright file="HtmlHelper`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;

namespace Flunt.Web.Mvc
{
    /// <summary>
    /// Provides methods to render HTML elements and content for a model class.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class HtmlHelper<TModel> : HtmlHelper
    {
        /// <summary>
        /// The inner <see cref="System.Web.Mvc.HtmlHelper{TModel}"/> used.
        /// </summary>
        private readonly System.Web.Mvc.HtmlHelper<TModel> innerHtmlHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Flunt.Web.Mvc.HtmlHelper{TModel}"/> class.
        /// </summary>
        /// <param name="innerHtmlHelper">The inner <see cref="System.Web.Mvc.HtmlHelper{TModel}"/> used.</param>
        public HtmlHelper(System.Web.Mvc.HtmlHelper<TModel> innerHtmlHelper)
            : base(innerHtmlHelper)
        {
            this.innerHtmlHelper = innerHtmlHelper;
        }

        /// <summary>
        /// Gets the inner <see cref="System.Web.Mvc.HtmlHelper{TModel}"/> used.
        /// </summary>
        public new System.Web.Mvc.HtmlHelper<TModel> InnerHelper
        {
            get
            {
                return this.innerHtmlHelper;
            }
        }
    }
}
