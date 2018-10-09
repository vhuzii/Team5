// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Business_Layer.Services;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IService<Polygon> figureService;
        private PointCollection clickedPoints = new PointCollection();
        private ObservableCollection<Polygon> polygons = new ObservableCollection<Polygon>();
        private Polygon selectedPolygon = null;
        private List<Line> lines = new List<Line>();
        private bool dragging = false;
        private Point clickV;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.figureService = new FigureService();
            this.polygonesList.ItemsSource = this.polygons;

            this.Main.MouseMove += new System.Windows.Input.MouseEventHandler(this.CanvasMouseMove);

            this.Main.MouseUp += new MouseButtonEventHandler(this.CanvasMouseUp);
        }

        private void NewCanvas(object sender, RoutedEventArgs e)
        {
            this.ClearCanvas();
            this.figureService.RemoveAll();
            this.Background = Brushes.White;
        }

        private void SaveCanvas(object sender, RoutedEventArgs e)
        {
            if (this.polygons.Count == 0)
            {
                throw new InvalidOperationException("There is no shapes in the canvas");
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text file (*.xml)|*.xml";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                string path = System.IO.Path.GetFullPath(dialog.FileName);
                this.figureService.SerealizeAll(path);
            }
        }

        private void OpenCanvas(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*.xml)|*.xml";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                string fullPath = System.IO.Path.GetFullPath(dialog.FileName);
                var polygons = this.figureService.DeserializeAll(fullPath);
                this.ClearCanvas();
                this.Background = Brushes.White;
                foreach (var polygon in polygons)
                {
                    this.DrawFigure(polygon);
                }
            }
        }

        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (!this.dragging)
            {
                Point p = e.GetPosition(this);
                this.clickedPoints.Add(p);
                if (this.clickedPoints.Count > 1)
                {
                    this.DrawLine();
                }

                if (this.clickedPoints.Count >= 6)
                {
                    Polygon polygon = this.CreatePolygon();
                    this.DrawFigure(polygon);
                    foreach (var line in this.lines)
                    {
                        this.Main.Children.Remove(line);
                    }

                    this.lines.Clear();
                    this.clickedPoints.Clear();
                }
            }
        }

        private void DrawFigure(Polygon polygon)
        {
            this.polygons.Add(polygon);
            this.Main.Children.Add(polygon);
        }

        private Polygon CreatePolygon()
        {
            Polygon polygon = new Polygon();
            polygon.Points = this.clickedPoints.Clone();
            this.figureService.Add(polygon);
            ChooseColorModal modal = new ChooseColorModal();
            modal.ShowDialog();
            polygon.Fill = new SolidColorBrush(modal.ChosenColor);
            polygon.StrokeThickness = 4;
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            return polygon;
        }

        private void DrawLine()
        {
            int lastPointIndex = this.clickedPoints.Count - 1;
            var line = new Line();
            line.Stroke = Brushes.Black;

            line.X1 = this.clickedPoints[lastPointIndex].X;
            line.X2 = this.clickedPoints[lastPointIndex - 1].X;
            line.Y1 = this.clickedPoints[lastPointIndex].Y;
            line.Y2 = this.clickedPoints[lastPointIndex - 1].Y;
            this.lines.Add(line);
            this.Main.Children.Add(line);
        }

        private void ClearCanvas()
        {
            this.Main.Children.Clear();
            this.polygons.Clear();
            this.lines.Clear();
            this.clickedPoints.Clear();
            this.Main.Visibility = Visibility.Visible;
            this.Hint.Visibility = Visibility.Collapsed;
        }

        private void SelectPolygon(object sender, RoutedEventArgs e)
        {
            if (this.selectedPolygon != null)
            {
                this.selectedPolygon.Stroke = new SolidColorBrush(Colors.Black);
            }

            if (this.polygons.Count == 0)
            {
                throw new InvalidOperationException("There is no shapes in the canvas");
            }

            var item = (System.Windows.Controls.MenuItem)e.OriginalSource;
            this.selectedPolygon = (Polygon)item.DataContext;
            this.selectedPolygon.Stroke = new SolidColorBrush(Colors.Red);
            this.selectedPolygon.MouseDown += new MouseButtonEventHandler(this.PolygonMouseDown);
        }

        private void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.dragging = false;
        }

        private void CanvasMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.dragging && this.selectedPolygon != null)
            {
                Canvas.SetLeft(this.selectedPolygon, e.GetPosition(this.Main).X - this.clickV.X);
                Canvas.SetTop(this.selectedPolygon, e.GetPosition(this.Main).Y - this.clickV.Y);
            }
        }

        private void PolygonMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragging = true;
            this.clickV = e.GetPosition(this.selectedPolygon);
        }

        private void KeyboardClick(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.selectedPolygon != null)
            {
                if (e.Key == Key.Up)
                {
                    var oldPoints = this.selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in oldPoints)
                    {
                        newPoints.Add(new Point(point.X, point.Y - 5));
                    }

                    this.selectedPolygon.Points = newPoints;
                }

                if (e.Key == Key.Down)
                {
                    var oldPoints = this.selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in oldPoints)
                    {
                        newPoints.Add(new Point(point.X, point.Y + 5));
                    }

                    this.selectedPolygon.Points = newPoints;
                }

                if (e.Key == Key.Left)
                {
                    var oldPoints = this.selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in oldPoints)
                    {
                        newPoints.Add(new Point(point.X - 5, point.Y));
                    }

                    this.selectedPolygon.Points = newPoints;
                }

                if (e.Key == Key.Right)
                {
                    var oldPoints = this.selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in this.selectedPolygon.Points)
                    {
                        newPoints.Add(new Point(point.X + 5, point.Y));
                    }

                    this.selectedPolygon.Points = newPoints;
                }
            }
        }
    }
}
