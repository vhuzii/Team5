// <copyright file="HttpError.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// HttpErrorMode
    /// </summary>
    public class HttpError : IComparable<HttpError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpError"/> class.
        /// </summary>
        /// <param name="errorCode">Code of error</param>
        /// <param name="description">Error description</param>
        /// <param name="timeOfError">Time when error occured</param>
        public HttpError(int errorCode, string description, DateTime timeOfError)
        {
            this.Description = description;
            this.ErrorCode = errorCode;
            this.ErrorTime = timeOfError;
        }

        /// <summary>
        /// Gets or sets error code
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets time when error description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets time when error occured
        /// </summary>
        public DateTime ErrorTime { get; set; }

        /// <summary>
        /// Function to compare two errors
        /// </summary>
        /// <param name="obj">error to compare</param>
        /// <returns>1 if this errorCode > obj errorCode, 0 if same, -1 if lower </returns>
        public int CompareTo(HttpError obj)
        {
            return this.ErrorCode.CompareTo(obj.ErrorCode);
        }

        /// <summary>
        /// Method to compare two httpErrors
        /// </summary>
        /// <param name="obj">Error to compare</param>
        /// <returns>return true if obj is error and has same error code</returns>
        public override bool Equals(object obj)
        {
            HttpError item = obj as HttpError;

            if (item == null)
            {
                return false;
            }

            return this.ErrorCode.Equals(item.ErrorCode);
        }

        /// <summary>
        /// get hash code of error by ErrorCode
        /// </summary>
        /// <returns>hash code of error</returns>
        public override int GetHashCode()
        {
            return this.ErrorCode.GetHashCode();
        }

        /// <summary>
        /// get error info
        /// </summary>
        /// <returns>output error info</returns>
        public override string ToString()
        {
            return this.ErrorCode + " " + this.Description + " " + this.ErrorTime;
        }
    }
}
