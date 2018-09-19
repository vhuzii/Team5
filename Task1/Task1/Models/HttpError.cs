// <copyright file="HttpError.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class HttpError : IComparable<HttpError>
    {
        public int ErrorCode { get; set; }

        public string Description { get; set; }

        public DateTime ErrorTime { get; set; }

        public static IEnumerable<HttpError> GetHttpErrorsFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                List<HttpError> errors = new List<HttpError>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var items = line.Split(' ');
                    errors.Add(new HttpError
                    {
                        ErrorCode = int.Parse(items[0]),
                        Description = items[1],
                        ErrorTime = DateTime.Parse(items[2])
                    });
                }

                return errors;
            }
        }

        public int CompareTo(HttpError obj)
        {
            return this.ErrorCode.CompareTo(obj.ErrorCode);
        }

        public override bool Equals(object obj)
        {
            var item = obj as HttpError;

            if (item == null)
            {
                return false;
            }

            return this.ErrorCode.Equals(item.ErrorCode);
        }

        public override int GetHashCode()
        {
            return this.ErrorCode.GetHashCode();
        }
    }
}
