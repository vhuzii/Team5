// <copyright file="TaxiClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DLL.Models
{
    using System;
    using System.Collections.Generic;
    using DLL.Interfaces;

    /// <summary>
    /// Taxi User.
    /// </summary>
    public class TaxiClient : ITaxiClient
    {
        /// <inheritdoc/>
        public double Balance { get; set; }

        /// <inheritdoc/>
        public List<TaxiOrder> OrderHistory { get; private set; } = new List<TaxiOrder>();

        /// <inheritdoc/>
        public double GetTaxi(TaxiOrder order)
        {
            double price = order.Pay();
            if ((this.Balance - price) < 0)
            {
                throw new InvalidOperationException("You have not enough money");
            }

            this.Balance -= price;
            this.OrderHistory.Add(order);
            return price;
        }
    }
}
