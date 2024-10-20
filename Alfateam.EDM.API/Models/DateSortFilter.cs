using Alfateam.EDM.API.Enums;

namespace Alfateam.EDM.API.Models
{
    public class DateSortFilter
    {
        public DateSortFilterType Type { get; set; }


        /// <summary>
        /// Используется, если Type == Day или Interval
        /// </summary>
        public DateTime Date1 { get; set; }
        /// <summary>
        /// Используется, если Type == Interval
        /// </summary>
        public DateTime Date2 { get; set; }

        /// <summary>
        /// Используется, если Type == Month, Quarter или Year
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Используется, если Type == Month или Quarter
        /// </summary>
        public int MonthOrQuarter { get; set; }
    }
}
