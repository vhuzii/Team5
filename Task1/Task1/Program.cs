// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Task1.Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<HttpError> errors = HttpError.GetHttpErrorsFromFile(@"..\..\Files\file1.txt").ToList();

            foreach (var err in errors)
            {
                Console.WriteLine(err.ErrorTime);
            }
        }
    }
}
