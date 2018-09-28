// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task2
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Business_Layer.Services;
    using Figure = Data_Access.Repositories.Models.Abstract.Figure;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IService<Figure> figureRepository;
        private PointCollection clickedPoints = new PointCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.figureRepository = new FigureService();
        }

        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            this.clickedPoints.Add(p);
            if (this.clickedPoints.Count == 6)
            {
                Figure f = new Figure
                {
                    Points = this.clickedPoints
                };
                this.figureRepository.Add(f);
                this.DrawFigure(f);
            }
        }

        private void DrawFigure(Figure f)
        {
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            Polygon yellowPolygon = new Polygon();
            yellowPolygon.Stroke = blackBrush;
            yellowPolygon.Fill = yellowBrush;
            yellowPolygon.StrokeThickness = 4;
            PointCollection polygonPoints = new PointCollection();
            foreach (Point point in f.Points)
            {
                polygonPoints.Add(point);
            }
            yellowPolygon.Points = polygonPoints;
            Main.Children.Add(yellowPolygon);
        }
    }
}
