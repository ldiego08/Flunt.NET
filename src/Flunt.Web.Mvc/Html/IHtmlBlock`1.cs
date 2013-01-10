//-----------------------------------------------------------------------
// <copyright file="IHtmlBlock`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web;

namespace Flunt.Web.Mvc.Html
{ 
    /// <summary>
    /// Defines methods for rendering a block of valid HTML in a view.
    /// </summary>
    /// <typeparam name="THtmlHelper">The type of the helper used to render HTML content.</typeparam>
    public interface IHtmlBlock<THtmlHelper> : IHtmlString 
        where THtmlHelper : HtmlHelper
    {
    }
}
