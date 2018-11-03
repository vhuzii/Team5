// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TeamBlankTask4
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string userCommand = string.Empty;
            connection.Open();
            string sql = "Select Distinct e.City From Employees As e, Customers As c, Orders As o Where e.City = c.City And c.City = o.ShipCity";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    object[] raw = new object[dataReader.FieldCount];
                    dataReader.GetValues(raw);
                    foreach (var item in raw)
                    {
                        Console.Write($"{item}\t\t");
                    }

                    Console.WriteLine();
                }

                dataReader.Close();
            }

            // 1 string sql = "Select * From Employees Where EmployeeID = 8";
            // 2 string sql = "Select FirstName, LastName From Employees Where City = 'London'";
            // 3  string sql = "Select FirstName, LastName From Employees Where FirstName Like 'A%'";
            // finish me please 4 string sql = "Select FirstName, LastName, BirthDate From Employees Where Year(BirthDate) > 55 Order By LastName";
            // 5  string sql = "Select Count(City)From Employees Where City = 'London'";
            // finish me please 6   string sql = "Select Min(BirthDate), Max(BirthDate), Avg(Year(BirthDate)) From Employees Where City = 'London'";
            // finish me please 7  string sql = "Select City, Min(BirthDate), Max(BirthDate), Avg(Year(BirthDate)) From Employees Group By City";
            // finish me please 8 string sql = "Select City, Avg(Year(BirthDate)) From Employees Group By City Having Avg(Year(BirthDate)) > 60";
            // 9  string sql = "Select BirthDate, FirstName From Employees Where BirthDate = (Select Min(BirthDate) From Employees)";
            // 10 string sql = "Select Top 3 BirthDate, FirstName From Employees Order By BirthDate ";
            // 11  string sql = "Select Distinct City From Employees";
            // 12   string sql = "Select FirstName, LastName, BirthDate From Employees Where Month(GetDate()) = Month(BirthDate)";
            // 13  string sql = "Select Distinct FirstName, LastName From Employees, Orders Where ShipCity = 'Madrid' And Orders.EmployeeID = Employees.EmployeeID";
            // 14 string sql = "Select e.FirstName, e.LastName, Count(o.OrderID) From Employees As e Left Join Orders As o On e.EmployeeID = o.EmployeeID" +
            //   " Where OrderDate Between '01-Jan-97 00:00:00 AM' And '31-Dec-97 12:00:00 PM' Group By e.FirstName, e.LastName, e.EmployeeID";
            // 15  string sql = "Select e.FirstName, e.LastName, Count(o.OrderID) From Employees As e, Orders As o Where e.EmployeeID = o.EmployeeID And " +
            // "OrderDate Between '01-Jan-97 00:00:00 AM' And '31-Dec-97 12:00:00 PM' Group By e.FirstName, e.LastName, e.EmployeeID";
            // 16 string sql = "Select e.FirstName, e.LastName, Count(o.OrderID) From Employees As e Left Join Orders As o On e.EmployeeID = o.EmployeeID" +
            // " Where OrderDate Between '01-Jan-97 00:00:00 AM' And '31-Dec-97 12:00:00 PM' And o.RequiredDate < o.ShippedDate " +
            // "Group By e.FirstName, e.LastName, e.EmployeeID";
            // 17 string sql = "Select Count(o.OrderID) From Orders As o, Customers As c Where o.CustomerID = c.CustomerID And c.Country = 'France' Group By c.CustomerID";
            // 18  string sql = "Select c.ContactName From Orders As o, Customers As c Where o.CustomerID = c.CustomerID And c.Country = 'France' " +
            // "Group By c.CustomerID, c.ContactName Having Count(o.OrderID) > 1";
            // 19 nani
            // 20  string sql = "Select ContactName From Customers As c, Orders As o, [Order Details] As od, Products As p "
            // +"Where c.CustomerID = o.CustomerID And o.OrderID = od.OrderID And od.ProductID = p.ProductID "
            // + "And p.ProductName = 'Tofu'";
            // finish me 21  string sql = "Select ContactName, Count(p.ProductName) From Customers As c, Orders As o, [Order Details] As od, Products As p "
            // +"Where c.CustomerID = o.CustomerID And o.OrderID = od.OrderID And od.ProductID = p.ProductID "
            // + "And p.ProductName = 'Tofu' Group By c.CustomerID, c.ContactName";
            // 22 Boring
            // 23  string sql = "Select Distinct c.ContactName From Orders As o, Customers As c, Suppliers As s, Products As p, [Order Details] as od " +
            // " Where c.Country = 'France' And c.CustomerID = o.CustomerID And o.OrderID = od.OrderID And od.ProductID = p.ProductID And " +
            // " p.SupplierID = s.SupplierId And s.Country <> 'France'";
            // 24 string sql = "Select Distinct c.ContactName From Orders As o, Customers As c, Suppliers As s, Products As p, [Order Details] as od " +
            //   " Where c.Country = 'France' And c.CustomerID = o.CustomerID And o.OrderID = od.OrderID And od.ProductID = p.ProductID And " +
            //   " p.SupplierID = s.SupplierId And s.Country = 'France'";
            // 25 string sql = "Select c.ContactName, s.Country, Sum(od.Quantity * od.UnitPrice) From Orders As o, Customers As c, Suppliers As s, Products As p, [Order Details] as od " +
            // " Where c.CustomerID = o.CustomerID And o.OrderID = od.OrderID And od.ProductID = p.ProductID And " +
            // " p.SupplierID = s.SupplierId Group By s.Country, c.ContactName";
            // 26 
            // 27
            // 28
            // 29 string sql = "Select e1.FirstName, e2.FirstName From Employees As e1 Left Join Employees As e2 On e1.ReportsTo = e2.EmployeeID";
            // 30  string sql = "Select Distinct e.City From Employees As e, Customers As c, Orders As o Where e.City = c.City And c.City = o.ShipCity";
        }
    }
}