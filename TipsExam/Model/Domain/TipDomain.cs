using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipsExam.Model.Dto;
using TipsExam.Model.Infrastructure;
using TipsExam.Model.Persistence;

namespace TipsExam.Model.Domain
{
    public class TipDomain : ITipDomain
    {

        // Note: Considering there's an only source data (Sqlite), then we use an unique DAO

        readonly ITipDao _dbDao;

        public TipDomain(ITipDao dbDao) => _dbDao = dbDao;

        ///<inheritdoc/>
        public void AddTip(TipDto dto) => _dbDao.AddTip(dto);

        ///<inheritdoc/>
        public Tip GetTip(int id) => _dbDao.GetTip(id);

        ///<inheritdoc/>
        public Task<List<Tip>> GetTips() => _dbDao.GetTips();

        ///<inheritdoc/>
        public void RemoveTip(int id) => _dbDao.RemoveTip(id);

    }
}
