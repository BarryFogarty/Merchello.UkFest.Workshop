﻿namespace Merchello.UkFest.Web.Models
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The layout.
    /// </summary>
    public class Layout
    {
        /// <summary>
        /// Gets or sets the meta values.
        /// </summary>
        [CurrentContentAs]
        public MetaValues MetaValues { get; set; }
    }
}