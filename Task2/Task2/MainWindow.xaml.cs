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
        private List<Point> clickedPoints = new List<Point>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.figureRepository = new FigureService();
        }

        private void StartDrawing(object sender, RoutedEventArgs e)
        {
            this.Main.Visibility = Visibility.Visible;
            this.Hint.Visibility = Visibility.Collapsed;
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
                this.clickedPoints.Clear();
            }
            else
            {
                this.Main.Children.Clear();
            }
        }

        private void DrawFigure(Figure f)
        {
            ChooseColorModal modal = new ChooseColorModal();
            modal.ShowDialog();
            SolidColorBrush colorBrush = new SolidColorBrush();
            colorBrush.Color = modal.ChosenColor;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            Polygon polygon = new Polygon();
            polygon.Stroke = blackBrush;
            polygon.Fill = colorBrush;
            polygon.StrokeThickness = 4;
            PointCollection polygonPoints = new PointCollection();
            foreach (Point point in f.Points)
            {
                polygonPoints.Add(point);
            }

            polygon.Points = polygonPoints;
            this.Main.Children.Add(polygon);
        }
    }
}
