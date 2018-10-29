// <copyright file="TaxiOrder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DLL.Interfaces
{
    using System;
    using DLL.JsonConvertors;
    using Newtonsoft.Json;

    /// <summary>
    /// Order Taxi interface.
    /// </summary>
    [JsonConverter(typeof(TaxiOrderConverter))]
    public abstract class TaxiOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxiOrder"/> class.
        /// </summary>
        /// <param name="numberOfKilometres">number of kilometres to drive.</param>
        public TaxiOrder(double numberOfKilometres)
        {
            this.NumberOfKilometres = numberOfKilometres;
            this.TimeOfOrder = DateTime.Now;
        }

        /// <summary>
        /// Gets price per onoe kilometr.
        /// </summary>
        public abstract double PricePerKilometr { get;  }

        /// <summary>
        /// Gets number of kilometres to drive.
        /// </summary>
        public double NumberOfKilometres { get; set; }

        /// <summary>
        /// Gets order time.
        /// </summary>
        public DateTime TimeOfOrder { get; }

        /// <summary>
        /// Pay for a taxi.
        /// </summary>
        /// <returns>Amount of money client should pay.</returns>
        /// private double numberOfKilmeters;
        public abstract double Pay();
    }
}
