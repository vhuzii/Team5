// <copyright file="FigureService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Business_Layer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Shapes;
    using Data_Access.Repositories;
    using Data_Access.Repositories.Interfaces;

    /// <summary>
    /// Service that works with Figures logic
    /// </summary>
    public class FigureService : IService<Polygon>
    {
        private readonly IRepository<Polygon> figureRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FigureService"/> class.
        /// Initiaize figure repository
        /// </summary>
        public FigureService()
        {
            this.figureRepository = new FigureRepository();
        }

        /// <inheritdoc/>
        public void Add(Polygon entity)
        {
            this.figureRepository.Add(entity);
        }

        /// <inheritdoc/>
        public IEnumerable<Polygon> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Remove(Polygon entity)
        {
            throw new NotImplementedException();
        }
    }
}
