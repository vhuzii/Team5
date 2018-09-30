// <copyright file="XMLPolygon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Data_Access.XMLModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Class for xml serialization of Polygon
    /// </summary>
    public class XMLPolygon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XMLPolygon"/> class.
        /// Empty constructr for xml serialization
        /// </summary>
        public XMLPolygon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMLPolygon"/> class.
        /// Constructor with params
        /// </summary>
        /// <param name="points">polygon points</param>
        /// <param name="fill">polygon fill</param>
        /// <param name="strokeThickness">polygon thickness</param>
        public XMLPolygon(List<Point> points, Brush fill, double strokeThickness)
        {
            this.Points = points;
            this.Color = ((SolidColorBrush)fill).Color;
            this.StrokeThickness = strokeThickness;
        }

        /// <summary>
        /// Gets or sets points of polygon
        /// </summary>
        public List<Point> Points { get; set; }

        /// <summary>
        /// Gets or sets color of polygon
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets thickness of polygon
        /// </summary>
        public double StrokeThickness { get; set; }
    }
}
