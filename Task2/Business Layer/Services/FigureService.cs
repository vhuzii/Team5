// <copyright file="FigureService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Business_Layer.Services
{
    using System;
    using System.Collections.Generic;
    using Data_Access.Repositories;
    using Data_Access.Repositories.Interfaces;
    using Task2.Models.Abstract;

    /// <summary>
    /// Service that works with Figures logic
    /// </summary>
    public class FigureService : IService<Figure>
    {
        private readonly IRepository<Figure> figureRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FigureService"/> class.
        /// Initiaize figure repository
        /// </summary>
        public FigureService()
        {
            this.figureRepository = new FigureRepository();
        }

        /// <inheritdoc/>
        public void Add(Figure entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerable<Figure> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Remove(Figure entity)
        {
            throw new NotImplementedException();
        }
    }
}
