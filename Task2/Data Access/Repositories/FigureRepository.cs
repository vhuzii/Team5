// <copyright file="FigureRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Data_Access.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Shapes;
    using Data_Access.Repositories.Interfaces;
    using Data_Access.XMLModels;

    /// <summary>
    /// Repository to store figures
    /// </summary>
    public class FigureRepository : IRepository<Polygon>
    {
        private List<Polygon> figures = new List<Polygon>();

        /// <inheritdoc/>
        public void Add(Polygon entity)
        {
            this.figures.Add(entity);
        }

        /// <inheritdoc/>
        public IEnumerable<Polygon> GetAll()
        {
            return this.figures;
        }

        /// <inheritdoc/>
        public void Remove(Polygon entity)
        {
            this.figures.Remove(entity);
        }

        /// <inheritdoc/>
        public void RemoveAll()
        {
            this.figures.Clear();
        }

        /// <inheritdoc/>
        public void SetAll(IEnumerable<Polygon> entities)
        {
            this.figures = entities.ToList();
        }
    }
}
