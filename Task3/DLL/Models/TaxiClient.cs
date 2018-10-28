// <copyright file="TaxiClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DLL.Models
{
    using System;
    using DLL.Interfaces;

    /// <summary>
    /// Taxi User.
    /// </summary>
    public class TaxiClient : ITaxiClient
    {
        /// <inheritdoc/>
        public double GetTaxi(TaxiOrder order)
        {
            return order.Pay();
        }
    }
}
