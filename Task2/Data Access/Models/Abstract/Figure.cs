// <copyright file="Figure.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task2.Models.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Abstract class figure that containts list of points
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Gets or sets points of Figure
        /// </summary>
        public List<Point> Points { get; set; }
    }
}
