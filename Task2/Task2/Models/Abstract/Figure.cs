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

    public abstract class Figure
    {
        public List<Point> Points { get; set; }
        public abstract void Draw();
    }
}
