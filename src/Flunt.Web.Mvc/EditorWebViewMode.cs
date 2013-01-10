//-----------------------------------------------------------------------
// <copyright file="EditorWebViewMode.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Flunt.Web.Mvc
{
    /// <summary>
    /// Specifies the modes for an editor view.
    /// </summary>
    public enum EditorWebViewMode
    {
        /// <summary>
        /// Indicates that the view is in read-only mode.
        /// </summary>
        ReadOnly,

        /// <summary>
        /// Indicates that the view is in create mode.
        /// </summary>
        Create,

        /// <summary>
        /// Indicates that the view is in edit mode.
        /// </summary>
        Edit,

        /// <summary>
        /// Indicates that the view mode has not been specified.
        /// </summary>
        Unspecified
    }
}
