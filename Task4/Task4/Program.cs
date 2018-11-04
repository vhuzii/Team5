// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task4
{
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// Main class.
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            string sql = "Select FirstName, LastName From Employees Where FirstName Like 'A%'";
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind";
            DatabaseService service = new DatabaseService(connectionString);
            service.ShowData(sql);
        }

    }
}