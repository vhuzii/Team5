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

    internal class Program
    {

        public static void ReplaceCodesToDescription(List<HttpError> errors)
        {
            string text = File.ReadAllText(@"..\..\Files\file2.txt");
            foreach (var item in errors)
            {
                string replacement = item.Description + " " + item.ErrorTime;
                text = text.Replace(item.ErrorCode.ToString(), replacement);
            }

            Console.WriteLine(text);
            
            //text = text.Replace("400", "new value");
            //File.WriteAllText("test.txt", text);
        }


        private static void Main(string[] args)
        {
            List<HttpError> errors = HttpError.GetHttpErrorsFromFile(@"..\..\Files\file1.txt").ToList();
            ReplaceCodesToDescription(errors);
            
        }
    }
}
