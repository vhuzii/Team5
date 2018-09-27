// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Data_Access.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Task2.Models.Abstract;

    /// <summary>
    /// interface of repository
    /// </summary>
    /// <typeparam name="T">Stored entity</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Method to add entity
        /// </summary>
        /// <param name="entity">entity to add</param>
        void Add(T entity);

        /// <summary>
        /// Method to remove entity
        /// </summary>
        /// <param name="entity">entity to remove</param>
        void Remove(T entity);

        /// <summary>
        /// get all elements from repository
        /// </summary>
        /// <returns>returns all elements from repository</returns>
        IEnumerable<T> GetAll();
    }
}
