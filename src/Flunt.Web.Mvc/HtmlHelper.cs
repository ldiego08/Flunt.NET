//-----------------------------------------------------------------------
// <copyright file="HtmlHelper.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;

namespace Flunt.Web.Mvc
{
    /// <summary>
    /// Provides methods to render HTML elements and content.
    /// </summary>
    public class HtmlHelper
    {
        /// <summary>
        /// The inner <see cref="System.Web.Mvc.HtmlHelper"/> used.
        /// </summary>
        private readonly System.Web.Mvc.HtmlHelper innerHtmlHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Flunt.Web.Mvc.HtmlHelper"/> class.
        /// </summary>
        /// <param name="innerHtmlHelper">The inner <see cref="System.Web.Mvc.HtmlHelper"/> used.</param>
        public HtmlHelper(System.Web.Mvc.HtmlHelper innerHtmlHelper)
        {
            this.innerHtmlHelper = innerHtmlHelper;
        }

        /// <summary>
        /// Gets the inner <see cref="System.Web.Mvc.HtmlHelper"/> used.
        /// </summary>
        public System.Web.Mvc.HtmlHelper InnerHelper
        {
            get 
            { 
                return this.innerHtmlHelper; 
            }
        }
    }
}
