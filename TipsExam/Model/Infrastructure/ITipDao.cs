using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipsExam.Model.Dto;
using TipsExam.Model.Persistence;

namespace TipsExam.Model.Infrastructure
{
    /// <summary>
    /// Tip DAO.
    /// </summary>
    public interface ITipDao
    {

        // Note: this definition would apply for every data source which might be used 
        // webservices, database, cache, etc.

        /// <summary>
        /// Gets the tips.
        /// </summary>
        /// <returns>The tips.</returns>
        Task<List<Tip>> GetTips();

        /// <summary>
        /// Gets a specific tip.
        /// </summary>
        /// <returns>The tip.</returns>
        /// <param name="id">Identifier.</param>
        Tip GetTip(int id);

        /// <summary>
        /// Removes the tip.
        /// </summary>
        /// <param name="id">Identifier.</param>
        void RemoveTip(int id);

        /// <summary>
        /// Adds the tip.
        /// </summary>
        /// <param name="dto">Dto.</param>
        void AddTip(TipDto dto);

    }
}
