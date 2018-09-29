// <copyright file="IService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Business_Layer.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// Generic service
    /// </summary>
    /// <typeparam name="TEntity">Service Entity</typeparam>
    public interface IService<TEntity>
    {
        /// <summary>
        /// Method to add entity
        /// </summary>
        /// <param name="entity">entity to add</param>
        void Add(TEntity entity);

        /// <summary>
        /// Method to remove entity
        /// </summary>
        /// <param name="entity">entity to remove</param>
        void Remove(TEntity entity);

        /// <summary>
        /// get all elements from repository
        /// </summary>
        /// <returns>returns all elements from repository</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Serialize all entities
        /// </summary>
        /// <param name="path">serialization path</param>
        void SerealizeAll(string path);

        /// <summary>
        /// serialize collection from file
        /// </summary>
        /// <param name="path">path of file</param>
        /// <returns>entity collection</returns>
        IEnumerable<TEntity> DeserializeAll(string path);
    }
}
