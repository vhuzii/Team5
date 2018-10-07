// <copyright file="FigureService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Business_Layer.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Xml.Serialization;
    using Data_Access.Repositories;
    using Data_Access.Repositories.Interfaces;
    using Data_Access.XMLModels;

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
            XmlSerializer formatter = new XmlSerializer(typeof(XMLPolygon[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<XMLPolygon> xmlPolygons = ((XMLPolygon[])formatter.Deserialize(fs)).ToList();
                List<Polygon> newPolygons = new List<Polygon>();
                foreach (var xmlPolygon in xmlPolygons)
                {
                    newPolygons.Add(this.GetPolygon(xmlPolygon));
                }

                this.figureRepository.SetAll(newPolygons);
                return this.GetAll();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Polygon> GetAll()
        {
            return this.figureRepository.GetAll();
        }

        /// <inheritdoc/>
        public void Remove(Polygon entity)
        {
            this.figureRepository.Remove(entity);
        }

        /// <inheritdoc/>
        public void SerealizeAll(string path)
        {
            System.Collections.Generic.IEnumerable<Polygon> allPolygons = this.figureRepository.GetAll();
            var points = allPolygons.Select(polygon => new XMLPolygon(polygon.Points.ToList(), polygon.Fill, polygon.StrokeThickness)).ToArray();
            XmlSerializer formatter = new XmlSerializer(typeof(XMLPolygon[]));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, points);
            }
        }

        /// <summary>
        /// Remove all figures
        /// </summary>
        public void RemoveAll()
        {
            this.figureRepository.RemoveAll();
        }

        private Polygon GetPolygon(XMLPolygon xmlPolygon)
        {
            return new Polygon()
            {
                Points = new PointCollection(xmlPolygon.Points),
                StrokeThickness = xmlPolygon.StrokeThickness,
                Fill = new SolidColorBrush(xmlPolygon.Color),
                Stroke = new SolidColorBrush(Colors.Black)
            };
        }
    }
}
