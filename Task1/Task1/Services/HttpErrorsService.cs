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
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                   var errors = new List<HttpError>();

                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var items = line.Split(' ');
                        errors.Add(new HttpError(errorCode: int.Parse(items[0]), description: items[1], timeOfError: DateTime.Parse(items[2])));
                    }

                    return errors;
                }
            }
            else
            {
                throw new IOException("Can't open file.");
            }
        }

        /// <summary>
        /// Replace codes in text to code desctiption
        /// </summary>
        /// <param name="errors">errors to replace in text</param>
        /// <param name="path">path to text</param>
        public static void ReplaceCodesToDescription(List<HttpError> errors, string path)
        {
            if (File.Exists(path))
            {
                var text = File.ReadAllText(path);
                var uniqueErrors = errors.Distinct();
                foreach (var item in errors)
                {
                    var replacement = item.Description + " " + item.ErrorTime;
                    text = text.Replace(item.ErrorCode.ToString(), replacement);
                }

                Console.WriteLine(text);
            }
            else
            {
                throw new IOException("Can't open file.");
            }
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

            if (File.Exists(path))
            {
                using (var file = new StreamWriter(path))
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
            else
            {
                throw new IOException("Can't open file.");
            }
        }

        /// <summary>
        /// Output errors in console
        /// </summary>
        /// <param name="errors">errors to output</param>
        public static void OutputErrors(List<HttpError> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
