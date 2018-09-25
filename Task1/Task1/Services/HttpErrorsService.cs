// <copyright file="HttpErrorsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Task1.Models;

    /// <summary>
    /// functionality of httpError
    /// </summary>
    public class HttpErrorsService
    {
        /// <summary>
        /// read errors from file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>error collectio</returns>
        public static IEnumerable<HttpError> GetHttpErrorsFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                List<HttpError> errors = new List<HttpError>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var items = line.Split(' ');
                    errors.Add(new HttpError(errorCode: int.Parse(items[0]), description: items[1], timeOfError: DateTime.Parse(items[2])));
                }

                return errors;
            }
        }

        /// <summary>
        /// Replace codes in text to code desctiption
        /// </summary>
        /// <param name="errors">errors to replace in text</param>
        /// <param name="path">path to text</param>
        public static void ReplaceCodesToDescription(List<HttpError> errors, string path)
        {
            string text = File.ReadAllText(@"..\..\Files\file2.txt");
            var uniqueErrors = errors.Distinct();
            foreach (var item in errors)
            {
                string replacement = item.Description + " " + item.ErrorTime;
                text = text.Replace(item.ErrorCode.ToString(), replacement);
            }

            Console.WriteLine(text);
        }

        /// <summary>
        /// Outputs codes to file
        /// </summary>
        /// <param name="errors">list of errors to output</param>
        /// <param name="path">path to file</param>
        public static void PrintCodesToFile(List<HttpError> errors, string path)
        {
            var groups = from e in errors
                         group e by e.ErrorCode;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach (IGrouping<int, HttpError> group in groups)
                {
                    file.WriteLine(group.Key);
                    file.WriteLine("--------------");
                    foreach (var t in group)
                    {
                        file.WriteLine(t.ErrorTime);
                        file.WriteLine(string.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Output errors in console
        /// </summary>
        /// <param name="errors">errors to output</param>
        public static void OutputErrors(List<HttpError> errors)
        {
            foreach (HttpError error in errors)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
