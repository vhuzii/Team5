// <copyright file="TaxiOrdersRepositry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DLL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DAL.Abstractions;
    using DLL.Interfaces;
    using DLL.Models;
    using Newtonsoft.Json;

    /// <inheritdoc/>
    public class TaxiOrdersRepositry : ITaxiOrderRepository<TaxiOrder>
    {
        private static object locker = new object();

        /// <summary>
        /// Taxi client.
        /// </summary>
        private readonly ITaxiClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxiOrdersRepositry"/> class.
        /// </summary>
        /// <param name="client">taxi client.</param>
        public TaxiOrdersRepositry(ITaxiClient client)
        {
            this.client = client;
        }

        /// <inheritdoc/>
        public double OrderTaxi(TaxiOrder entity) => this.client.GetTaxi(entity);

        /// <inheritdoc/>
        public IEnumerable<TaxiOrder> GetHistory()
        {
            return this.client.OrderHistory;
        }

        /// <inheritdoc/>
        public void RemoveOrderFromHistory(TaxiOrder entity)
        {
            var deleteEntity = this.client.OrderHistory.FirstOrDefault(e => e.NumberOfKilometres == entity.NumberOfKilometres &&
                                                                            e.PricePerKilometr == entity.PricePerKilometr);
            this.client.OrderHistory.Remove(deleteEntity);
        }

        /// <inheritdoc/>
        public void RemoveHistory()
        {
            this.client.OrderHistory.Clear();
        }

        /// <inheritdoc/>
        public void SaveChanges(string path)
        {
            lock (locker)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.Write(JsonConvert.SerializeObject(this.client));
                }
            }
        }

        /// <inheritdoc/>
        public void AddBalance(double amount)
        {
            this.client.Balance += amount;
        }

        /// <inheritdoc/>
        public ITaxiClient DeserealizeTaxiClient(string path)
        {
            ITaxiClient client = null;
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                client = (TaxiClient)serializer.Deserialize(file, typeof(TaxiClient));
            }

            return client;
        }
    }
}
