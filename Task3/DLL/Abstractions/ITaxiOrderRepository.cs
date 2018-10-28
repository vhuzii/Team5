// <copyright file="ITaxiOrderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Abstractions
{
    using System.Collections.Generic;
    using DLL.Interfaces;

    /// <summary>
    /// interface of repository.
    /// </summary>
    /// <typeparam name="TEntity">Stored entity.</typeparam>
    public interface ITaxiOrderRepository<TEntity>
        where TEntity : TaxiOrder
    {
        /// <summary>
        /// Method to add entity.
        /// </summary>
        /// <param name="entity">entity to add.</param>
        /// <returns>amount of money user should pay.</returns>
        double OrderTaxi(TEntity entity);

        /// <summary>
        /// Method to remove entity.
        /// </summary>
        /// <param name="entity">entity to remove.</param>
        void RemoveOrderFromHistory(TEntity entity);

        /// <summary>
        /// get all elements from repository.
        /// </summary>
        /// <returns>returns all elements from repository.</returns>
        IEnumerable<TEntity> GetHistory();

        /// <summary>
        /// Remove all entities from repository.
        /// </summary>
        void RemoveHistory();

        /// <summary>
        /// Add balance on users account.
        /// </summary>
        /// <param name="amount">amount of money.</param>
        void AddBalance(double amount);

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <param name="path">path to file.</param>
        void SaveChanges(string path);

        /// <summary>
        /// get client from file.
        /// </summary>
        /// <param name="path">file path.</param>
        /// <returns>Customer.</returns>
        ITaxiClient DeserealizeTaxiClient(string path);

        /// <summary>
        /// Get customer Balance
        /// </summary>
        /// <returns>balance</returns>
        double GetBalance();
    }
}