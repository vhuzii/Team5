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
            List<HttpError> errors = HttpErrorsService.GetHttpErrorsFromFile(@"..\..\Files\file1.txt").ToList();
            //List<HttpError> errors = HttpErrorsService.GetHttpErrorsFromFile(@"../../Files/file1.txt").ToList();
            Console.WriteLine("errors from file1: ");
            HttpErrorsService.OutputErrors(errors);
            Console.WriteLine("changed file2: ");
            HttpErrorsService.ReplaceCodesToDescription(errors, @"..\..\Files\file2.txt");
            //HttpErrorsService.ReplaceCodesToDescription(errors, @"../../Files/file2.txt");
            HttpErrorsService.PrintCodesToFile(errors, @"..\..\Files\file3.txt");
            //HttpErrorsService.PrintCodesToFile(errors, @"../../Files/file3.txt");
        }
    }
}
