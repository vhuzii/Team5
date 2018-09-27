// <copyright file="FigureRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Data_Access.Repositories
{
    using System.Collections.Generic;
    using Data_Access.Repositories.Interfaces;
    using Task2.Models.Abstract;

    /// <summary>
    /// Repository to store figures
    /// </summary>
    public class FigureRepository : IRepository<Figure>
    {
        private readonly List<Figure> figures = new List<Figure>();

        /// <inheritdoc/>
        public void Add(Figure entity)
        {
            this.figures.Add(entity);
        }

        /// <inheritdoc/>
        public IEnumerable<Figure> GetAll()
        {
            return this.figures;
        }

        /// <inheritdoc/>
        public void Remove(Figure entity)
        {
            this.figures.Remove(entity);
        }
    }
}
