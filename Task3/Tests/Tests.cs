using BLL.Interfaces;
using BLL.Services;
using DLL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class FigureServiceTest
    {
        [Test]
        public void AddGetBalanceTest()
        {
            IOrderTaxiService service = new OrderTaxiService(new TaxiClient());

            Assert.AreEqual(service.GetBalance(), 0);
            service.AddBalance(25);
            Assert.AreEqual(service.GetBalance(), 25);
            service.AddBalance(25);
            Assert.AreEqual(service.GetBalance(), 50);
        }

        [Test]
        public void SerializeDeserializeCustomer()
        {
            IOrderTaxiService service = new OrderTaxiService(new TaxiClient());

            service.AddBalance(25);
            service.AddBalance(25);
            service.GetBusinessTaxi(2);
            service.SaveChanges(@"Files\file1.json");

            IOrderTaxiService anotherService = new OrderTaxiService(new TaxiClient());
            anotherService.DeserealizeClient(@"Files\file1.json");
            Assert.AreEqual(anotherService.GetBalance(), 30);
        }

        [Test]
        public void GetTaxiTest()
        {
            IOrderTaxiService service = new OrderTaxiService(new TaxiClient());

            service.AddBalance(25);
            service.AddBalance(25);

            Assert.AreEqual(service.GetNormalTaxi(5), 25);
            Assert.AreEqual(service.GetBusinessTaxi(2), 20);
            Assert.AreEqual(service.GetBalance(), 5);
        }

        [Test]
        public void GetDeleteHistoryTest()
        {
            IOrderTaxiService service = new OrderTaxiService(new TaxiClient());

            service.AddBalance(25);
            service.AddBalance(25);

            service.GetNormalTaxi(5);
            service.GetBusinessTaxi(2);

            Assert.AreEqual(service.GetHistory().First().NumberOfKilometres, 5);
            Assert.AreEqual(service.GetHistory().Last().NumberOfKilometres, 2);
        }

        [Test]
        public void OrderToStringTest()
        {
            DateTime timeOfOrder = DateTime.Now;
            BusinessTaxiOrder businessOrder = new BusinessTaxiOrder(5, timeOfOrder);
            Assert.AreEqual(
                timeOfOrder.ToLocalTime().ToString() + ": You just ordered Business taxi and it costs " + 5 * 10 + " $",
                businessOrder.ToString());

            NormalTaxiOrder normal = new NormalTaxiOrder(5, timeOfOrder);
            Assert.AreEqual(
                timeOfOrder.ToLocalTime().ToString() + ": You just ordered Normal taxi and it costs " + 5 * 5 + " $",
                normal.ToString());
        }
    }
}
