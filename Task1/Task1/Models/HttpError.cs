// <copyright file="HttpError.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class HttpError : IComparable<HttpError>
    {
        public HttpError(int errorCode, string description, DateTime timeOfError)
        {
            this.Description = description;
            this.ErrorCode = errorCode;
            this.ErrorTime = timeOfError;
        }

        public int ErrorCode { get; set; }

        public string Description { get; set; }

        public DateTime ErrorTime { get; set; }

        public int CompareTo(HttpError obj)
        {
            return this.ErrorCode.CompareTo(obj.ErrorCode);
        }

        public override bool Equals(object obj)
        {
            HttpError item = obj as HttpError;

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

        public override string ToString()
        {
            return this.ErrorCode + " " + this.Description + " " + this.ErrorTime;
        }
    }
}
