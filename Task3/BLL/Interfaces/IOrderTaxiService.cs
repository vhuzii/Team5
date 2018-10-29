// <copyright file="IOrderTaxiService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Interfaces
{
    using System.Collections.Generic;
    using DLL.Interfaces;

    /// <summary>
    /// Interface for taxi order service.
    /// </summary>
    public interface IOrderTaxiService
    {
        /// <summary>
        /// Add money on user balance.
        /// </summary>
        /// <param name="amount">amount of money to add.</param>
        void AddBalance(double amount);

        /// <summary>
        /// Get business taxi.
        /// </summary>
        /// <param name="numberOfKilometres">num of kilometres.</param>
        /// <returns>Amount of money user shoud pay.</returns>
        double GetBusinessTaxi(double numberOfKilometres);

        /// <summary>
        /// Get taxi.
        /// </summary>
        /// <param name="numberOfKilometres">num of kilometres.</param>
        /// <returns>Amount of money user shoud pay.</returns>
        double GetNormalTaxi(double numberOfKilometres);

        /// <summary>
        /// History of Taxi orders.
        /// </summary>
        /// <returns>list of tai orders history.</returns>
        List<TaxiOrder> GetHistory();

        /// <summary>
        /// Save changes in json.
        /// </summary>
        /// <param name="path">path to file.</param>
        void SaveChanges(string path);

        /// <summary>
        /// get client from file.
        /// </summary>
        /// <param name="path">file path.</param>
        /// <returns>Customer.</returns>
        ITaxiClient DeserealizeClient(string path);

        /// <summary>
        /// Get customer Balance
        /// </summary>
        /// <returns>balance</returns>
        double GetBalance();
    }
}
