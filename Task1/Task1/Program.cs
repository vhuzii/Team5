// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Task1.Models;
    using Task1.Services;

    /// <summary>
    /// class that contains main function
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                HttpErrorsService service = new HttpErrorsService();
                List<HttpError> errors = service.GetHttpErrorsFromFile(@"..\..\Files\file1.txt").ToList();
                Console.WriteLine("errors from file1: ");
                service.OutputErrors(errors);
                Console.WriteLine("changed file2: ");
                service.ReplaceCodesToDescription(errors, @"..\..\Files\file2.txt");
                service.PrintCodesToFile(errors, @"..\..\Files\file3.txt");
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
