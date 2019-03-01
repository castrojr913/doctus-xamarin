using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TipsExam.Dependency;
using TipsExam.Model.Dto;
using TipsExam.Model.Persistence;
using Xamarin.Forms;

namespace TipsExam.Model.Infrastructure
{
    ///<inheritdoc/>
    public class DbTipDao :  DbContext, ITipDao
    {

        #region Properties 

        public DbSet<Tip> Tips { get; set; }

        #endregion

        public DbTipDao() => Database.EnsureCreated();

        #region EF_Setting

        ///<inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabaseDepService>().GetDatabasePath();
             optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        #endregion

        #region Transactions

        ///<inheritdoc/>
        public void AddTip(TipDto dto)
        {
            Tips.Add(new Tip { Description = dto.Description, Title = dto.Title, Date = dto.DateFormatted });
            SaveChanges();
        }

        ///<inheritdoc/>
        public Tip GetTip(int id) => Tips.Find(id);

        ///<inheritdoc/>
        public async Task<List<Tip>> GetTips() => await Tips.ToListAsync();

        ///<inheritdoc/>
        public void RemoveTip(int id)
        {
           Tips.Remove(Tips.Find(id));
           SaveChanges();
        }

        #endregion

    }
}
