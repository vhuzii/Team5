// <copyright file="Figure.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Data_Access.Repositories.Models.Abstract
{
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// Abstract class figure that containts list of points
    /// </summary>
    public class Figure
    {
        /// <summary>
        /// Gets or sets points of Figure
        /// </summary>
        public List<Point> Points { get; set; }
    }
}
