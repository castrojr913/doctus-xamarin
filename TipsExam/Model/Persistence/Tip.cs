using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TipsExam.Utilities;

namespace TipsExam.Model.Persistence
{
    /// <summary>
    /// Tip entity.
    /// </summary>
    public class Tip
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("date_create")]
        public string Date { get; set; }

        public DateTime DateTime => DateHelper.Parse(Date, AppSettings.DatabaseDateFormat);

    }
}
