// <copyright file="TaxiOrderConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DLL.JsonConvertors
{
    using System;
    using DLL.Interfaces;
    using DLL.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Convertor for TaxiOrder.
    /// </summary>
    public class TaxiOrderConverter
        : CustomCreationConverter<TaxiOrder>
    {
        private int pricePerKm;
        private DateTime timeOfOrder;
        private double numberOfKilomitres;

        /// <summary>
        /// read json.
        /// </summary>
        /// <param name="reader">reader.</param>
        /// <param name="objectType">object type.</param>
        /// <param name="existingValue">existing value.</param>
        /// <param name="serializer">serializer.</param>
        /// <returns>obj.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobj = JObject.ReadFrom(reader);
            this.pricePerKm = jobj["PricePerKilometr"].ToObject<int>();
            this.timeOfOrder = jobj["TimeOfOrder"].ToObject<DateTime>();
            this.numberOfKilomitres = jobj["NumberOfKilometres"].ToObject<double>();
            return base.ReadJson(jobj.CreateReader(), objectType, existingValue, serializer);
        }

        /// <summary>
        /// Create necessary object from price.
        /// </summary>
        /// <param name="objectType">object type.</param>
        /// <returns>Tai order object.</returns>
        public override TaxiOrder Create(Type objectType)
        {
            switch (this.pricePerKm)
            {
                case 5:
                    return new NormalTaxiOrder(this.numberOfKilomitres, this.timeOfOrder);
                case 10:
                    return new BusinessTaxiOrder(this.numberOfKilomitres, this.timeOfOrder);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
