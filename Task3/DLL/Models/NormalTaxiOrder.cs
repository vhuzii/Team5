// <copyright file="NormalTaxiOrder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DLL.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DLL.Interfaces;

    /// <inheritdoc/>
    public class NormalTaxiOrder : TaxiOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalTaxiOrder"/> class.
        /// </summary>
        /// <param name="numberOfKilometres">Number oof kilometres to drive.</param>
        public NormalTaxiOrder(double numberOfKilometres)
            : base(numberOfKilometres)
        {
        }

        /// <inheritdoc/>
        protected override double PricePerKilometr => 5;

        /// <inheritdoc/>
        public override double Pay()
        {
            return this.PricePerKilometr * this.NumberOfKilometres;
        }
    }
}
