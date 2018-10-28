// <copyright file="OrderTaxiService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using BLL.Interfaces;
    using DAL.Abstractions;
    using DLL.Interfaces;
    using DLL.Models;
    using DLL.Repositories;
    using Newtonsoft.Json;

    /// <inheritdoc/>
    public class OrderTaxiService : IOrderTaxiService
    {
        private readonly ITaxiOrderRepository<TaxiOrder> taxiOrderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTaxiService"/> class.
        /// </summary>
        /// <param name="client">tai client.</param>
        public OrderTaxiService(ITaxiClient client)
        {
            this.taxiOrderRepository = new TaxiOrdersRepositry(client);
        }

        /// <inheritdoc/>
        public void AddBalance(double amount)
        {
            this.taxiOrderRepository.AddBalance(amount);
        }

        /// <inheritdoc/>
        public ITaxiClient DeserealizeClient(string path)
        {
            return this.taxiOrderRepository.DeserealizeTaxiClient(path);
        }

        /// <inheritdoc/>
        public double GetBusinessTaxi(double numberOfKilometres)
        {
            TaxiOrder businessTaxiOrder = new BusinessTaxiOrder(numberOfKilometres);
            return this.taxiOrderRepository.OrderTaxi(businessTaxiOrder);
        }

        /// <inheritdoc/>
        public List<TaxiOrder> GetHistory()
        {
            return this.taxiOrderRepository.GetHistory().ToList();
        }

        /// <inheritdoc/>
        public double GetNormalTaxi(double numberOfKilometres)
        {
            TaxiOrder businessTaxiOrder = new NormalTaxiOrder(numberOfKilometres);
            return this.taxiOrderRepository.OrderTaxi(businessTaxiOrder);
        }

        /// <inheritdoc/>
        public void SaveChanges(string path)
        {
            this.taxiOrderRepository.SaveChanges(path);
        }
    }
}
