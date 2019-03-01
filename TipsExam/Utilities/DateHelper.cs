using System;
using System.Globalization;

namespace TipsExam.Utilities
{
    /// <summary>
    /// Date helper.
    /// </summary>
    public static class DateHelper
    {
        #region = FORMAT & PARSE =

        /// <summary>
        /// Parse the specified formattedDate and format.
        /// </summary>
        /// <returns>The parse.</returns>
        /// <param name="formattedDate">Formatted date.</param>
        /// <param name="format">Format.</param>
        public static DateTime Parse(string formattedDate, string format)
        {
            DateTime date;
            try
            {
                var formatInfo = new DateTimeFormatInfo { ShortDatePattern = format };
                date = Convert.ToDateTime(formattedDate, formatInfo);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                date = DateTime.Now;
            }
            return date;
        }

        /// <summary>
        /// Format the specified date, format and language.
        /// </summary>
        /// <returns>The format.</returns>
        /// <param name="date">Date.</param>
        /// <param name="format">Format.</param>
        /// <param name="language">Language.</param>
        public static string Format(DateTime date, string format, string language = "es")
        {
            var formatted = string.Empty;
            try
            {
                formatted = date.ToString(format, new CultureInfo(language));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return formatted;
        }

        /// <summary>
        /// Changes the format.
        /// </summary>
        /// <returns>The format.</returns>
        /// <param name="formattedDate">Formatted date.</param>
        /// <param name="currentFormat">Current format.</param>
        /// <param name="targetFormat">Target format.</param>
        public static string ChangeFormat(string formattedDate, string currentFormat, string targetFormat)
        {
            if (string.IsNullOrEmpty(formattedDate)) return string.Empty;
            var formatted = string.Empty;
            try
            {
                var parsedDate = Parse(formattedDate, currentFormat);
                formatted = Format(parsedDate, targetFormat);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return formatted;
        }

        #endregion

        #region DATETIME

        /// <summary>
        /// Creates the date time.
        /// </summary>
        /// <returns>The date time.</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        /// <param name="hour">Hour.</param>
        /// <param name="minute">Minute.</param>
        public static DateTime CreateDateTime(int day, int month, int year, int hour, int minute = 0)
            => new DateTime(year, month, day, hour, minute, 0);

        /// <summary>
        /// Creates the date time.
        /// </summary>
        /// <returns>The date time.</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static DateTime CreateDateTime(int day, int month, int year) => new DateTime(year, month, day);

        /// <summary>
        /// Compares if matches.
        /// </summary>
        /// <returns><c>true</c>, if if matches was compared, <c>false</c> otherwise.</returns>
        /// <param name="t1">T1.</param>
        /// <param name="t2">T2.</param>
        public static bool CompareIfMatches(DateTime t1, DateTime t2)
            => t1.Year == t2.Year && t1.Month == t2.Month && t1.Day == t2.Day;
    }

    #endregion

}