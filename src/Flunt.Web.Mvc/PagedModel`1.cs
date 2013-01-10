//-----------------------------------------------------------------------
// <copyright file="PagedModel`1.cs" company="Conturenet">
//     Copyright (c) Conturenet Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Flunt.Web.Mvc
{
    /// <summary>
    /// Represents a model containing data for a paged result-set query.
    /// </summary>
    /// <typeparam name="TItem">The type of the result-set item.</typeparam>
    public class PagedModel<TItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedModel{TItem}"/> class.
        /// </summary>
        public PagedModel()
            : this(null)
        {    
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedModel{TItem}"/> class.
        /// </summary>
        /// <param name="items">The items of the result-set query.</param>
        public PagedModel(IEnumerable<TItem> items)
        {
            if (items.IsNull())
            {
                items = Empty.ListOf<TItem>();
            }

            this.Items = items;
            this.PageIndex = 0;
            this.PageSize = 0;
            this.TotalItems = 0;
            this.IsZeroBased = true;
        }

        /// <summary>
        /// Gets or sets the page index.
        /// </summary>
        public virtual int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public virtual int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of items in the result-set.
        /// </summary>
        public virtual int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the page index is zero-based.
        /// </summary>
        public virtual bool IsZeroBased { get; set; }

        /// <summary>
        /// Gets or sets the result-set query items.
        /// </summary>
        public virtual IEnumerable<TItem> Items { get; set; }
    }
}
