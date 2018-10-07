using Business_Layer.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Threading;

namespace Tests
{
    [Apartment(ApartmentState.STA)]
    [TestFixture]
    public class FigureServiceTest
    {
        [Test]
        public void AddGetAllFiguresTest()
        {
            FigureService service = new FigureService();
            List<Point> points = new List<Point>();
            points.Add(new Point(8, 3));
            points.Add(new Point(4, 2));
            points.Add(new Point(-2, 3));

            List<Point> points2 = new List<Point>();
            points2.Add(new Point(88, 3));
            points2.Add(new Point(4, 22));
            points2.Add(new Point(-22, 3));

            Polygon polygon = new Polygon()
            {
                Points = new PointCollection(points)
            };

            Polygon polygon2 = new Polygon()
            {
                Points = new PointCollection(points2)
            };

            service.Add(polygon);
            service.Add(polygon2);
            var allFigures = service.GetAll().ToArray();

            Assert.AreEqual(allFigures[0].Points.First(), points.First());
            Assert.AreEqual(allFigures[0].Points.Last(), points.Last());
            Assert.AreEqual(allFigures[1].Points.First(), points2.First());
            Assert.AreEqual(allFigures[1].Points.Last(), points2.Last());
        }

        [Test]
        public void RemoveFigureTest()
        {
            FigureService service = new FigureService();
            List<Point> points = new List<Point>();
            points.Add(new Point(8, 3));
            points.Add(new Point(4, 2));
            points.Add(new Point(-2, 3));
          
            Polygon polygon = new Polygon()
            {
                Points = new PointCollection(points)
            };

            service.Add(polygon);
            int numberOfFiguresBeforeRemove = service.GetAll().Count();
            service.Remove(polygon);
            int numberOfFiguresAfterRemove = service.GetAll().Count() ;

            Assert.AreEqual(numberOfFiguresBeforeRemove, 1);
            Assert.AreEqual(numberOfFiguresAfterRemove, 0);
        }

        [Test]
        public void RemoveAllTests()
        {
            FigureService service = new FigureService();
            List<Point> points = new List<Point>();
            points.Add(new Point(8, 3));
            points.Add(new Point(4, 2));
            points.Add(new Point(-2, 3));

            List<Point> points2 = new List<Point>();
            points2.Add(new Point(88, 3));
            points2.Add(new Point(4, 22));
            points2.Add(new Point(-22, 3));

            Polygon polygon = new Polygon()
            {
                Points = new PointCollection(points)
            };

            Polygon polygon2 = new Polygon()
            {
                Points = new PointCollection(points2)
            };

            service.Add(polygon);
            service.Add(polygon2);

            Assert.AreEqual(service.GetAll().Count(), 2);
            service.RemoveAll();
            Assert.AreEqual(service.GetAll().Count(), 0);
        }

        [Test]
        public void SerializeDeserializeTest()
        {
            FigureService service = new FigureService();
            List<Point> points = new List<Point>();
            points.Add(new Point(8, 3));
            points.Add(new Point(4, 2));
            points.Add(new Point(-2, 3));

            List<Point> points2 = new List<Point>();
            points2.Add(new Point(88, 3));
            points2.Add(new Point(4, 22));
            points2.Add(new Point(-22, 3));

            Polygon polygon = new Polygon()
            {
                Points = new PointCollection(points)
            };

            Polygon polygon2 = new Polygon()
            {
                Points = new PointCollection(points2),
                Fill = new SolidColorBrush(Colors.Aquamarine)
            };

            service.Add(polygon);
            service.Add(polygon2);

            service.SerealizeAll("testSer.xml");
            var allFigures = service.DeserializeAll("testSer.xml").ToArray();

            Assert.AreEqual(allFigures[0].Points.First(), points.First());
            Assert.AreEqual(allFigures[0].Points.Last(), points.Last());
            Assert.AreEqual(allFigures[1].Points.First(), points2.First());
            Assert.AreEqual(allFigures[1].Points.Last(), points2.Last());
        }
    }
}
