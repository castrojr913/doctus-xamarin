using System;
using TipsExam.Utilities;
using static TipsExam.AppSettings;

namespace TipsExam.Model.Dto
{
    /// <summary>
    /// Tip dto.
    /// </summary>
    public class TipDto
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string DateFormatted => DateHelper.Format(Date, DatabaseDateFormat);
    }
}
