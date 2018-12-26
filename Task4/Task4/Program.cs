// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task4
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// Main class.
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            List<string> sqls = new List<string>();
            sqls.Add("Select FirstName, LastName, BirthDate From Employees Where Month(GetDate()) = Month(BirthDate)");
            sqls.Add("Select Distinct FirstName, LastName From Employees, Orders Where ShipCity = 'Madrid' And Orders.EmployeeID = Employees.EmployeeID");
            sqls.Add("Select Count(o.OrderID) From Orders As o, Customers As c Where o.CustomerID = c.CustomerID And c.Country = 'France' Group By c.CustomerID");
            sqls.Add("Select Top 5 * From Employees Order By EmployeeID DESC");
            sqls.Add("Select e.FirstName, e.LastName, Count(o.OrderID) From Employees As e, Orders As o Where e.EmployeeID = o.EmployeeID And " +
            "OrderDate Between '01-Jan-97 00:00:00 AM' And '31-Dec-97 12:00:00 PM' Group By e.FirstName, e.LastName, e.EmployeeID");
            sqls.Add("Select c.ContactName From Orders As o, Customers As c Where o.CustomerID = c.CustomerID And c.Country = 'France' " +
            "Group By c.CustomerID, c.ContactName Having Count(o.OrderID) > 1");
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind";
            DatabaseService service = new DatabaseService(connectionString);
            service.ShowData(sqls[1]);
            System.Console.ReadLine();
        }

    }
}