// <copyright file="FigureService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Business_Layer.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Xml.Serialization;
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
        public IEnumerable<Polygon> DeserializeAll(string path)
        {
            throw new NotImplementedException();
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

        /// <inheritdoc/>
        public void SerealizeAll(string path)
        {
            IEnumerable<Polygon> allPolygons = this.figureRepository.GetAll();
            var points = allPolygons.SelectMany(p => p.Points).ToArray();
            XmlSerializer formatter = new XmlSerializer(typeof(Point[]));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, points);
            }
        }
    }
}
