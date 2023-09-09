using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial
{
	public class JudgeCreateModel : CreateModel<Judge>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }



		public int CountryId { get; set; }
		public string City { get; set; }


		public string Position { get; set; }
		public string? Description { get; set; }
		public string? Comment { get; set; }
	}
}
