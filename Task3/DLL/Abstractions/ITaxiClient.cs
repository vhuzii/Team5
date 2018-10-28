// <copyright file="ITaxiClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DLL.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Client of Taxi Servicem.
    /// </summary>
    public interface ITaxiClient
    {
        /// <summary>
        /// Gets or sets userBalance.
        /// </summary>
        double Balance { get; set; }

        /// <summary>
        /// Gets OrderHistory.
        /// </summary>
        List<TaxiOrder> OrderHistory { get; }

        /// <summary>
        /// Get Taxi for a client.
        /// </summary>
        /// <param name="order">Taxi Order.</param>
        /// <returns>Amount of money client should pay.</returns>
        double GetTaxi(TaxiOrder order);
    }
}
