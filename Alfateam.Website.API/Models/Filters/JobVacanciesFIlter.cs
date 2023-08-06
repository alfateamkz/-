namespace Alfateam.Website.API.Models.Filters
{
    public class JobVacanciesFIlter
    {
        public int Offset { get; set; }
        public int Count { get; set; } = 20;


        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public int? ExperienceYearsFrom { get; set; }
        public int? ExperienceYearsTo { get; set; }



    }
}
