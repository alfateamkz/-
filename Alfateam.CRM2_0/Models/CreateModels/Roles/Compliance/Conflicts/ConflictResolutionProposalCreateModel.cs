using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts
{
	public class ConflictResolutionProposalCreateModel : CreateModel<ConflictResolutionProposal>
	{    
		/// <summary>
		/// Сторона конфликта, от которой поступило предложение
		/// </summary>
		public int FromId { get; set; }

		/// <summary>
		/// Стороны конфликта, которым адресовано предложение
		/// </summary>
		public List<int> ToIds { get; set; } = new List<int>();


		public string Title { get; set; }
		public string Description { get; set; }

		public override ConflictResolutionProposal Create()
		{
			throw new NotSupportedException("Use Create(List<ConflictSide> sides) instead");
		}
		public ConflictResolutionProposal Create(List<ConflictSide> sides)
		{
			var entity = new ConflictResolutionProposal();

			entity.FromId = this.FromId;

			foreach(var id in ToIds)
			{
				var side = sides.FirstOrDefault(o => o.Id == id);
				if(side == null)
				{
					throw new ArgumentNullException("No entities found with this id");
				}
				entity.To.Add(side);
			}

			entity.Title = this.Title;
			entity.Description = this.Description;

			return entity;
		}
	}
}
