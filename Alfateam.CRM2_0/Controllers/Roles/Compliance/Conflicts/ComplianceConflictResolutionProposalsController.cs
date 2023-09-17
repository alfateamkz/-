using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConflictEntity = Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Conflict;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Conflicts
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceConflictResolutionProposalsController : AbsController
	{
		public ComplianceConflictResolutionProposalsController(ControllerParams @params) : base(@params)
		{
		}

		#region Предложения по решению конфликта


		[HttpGet, Route("GetConflictResolutionProposals")]
		public async Task<RequestResult> GetConflictResolutionProposals(int conflictId)
		{
			var item = DB.Conflicts.Include(o => o.Proposals).ThenInclude(o => o.From)
								   .Include(o => o.Proposals).ThenInclude(o => o.To)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() =>
				{
					var clientModels = ConflictResolutionProposalClientModel.CreateItems(item.Proposals.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<ConflictResolutionProposalClientModel>>.AsSuccess(clientModels);
				}
			});
		}
	
		[HttpGet, Route("GetConflictResolutionProposal")]
		public async Task<RequestResult> GetConflictResolutionProposal(int conflictId, int proposalId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var proposal = DB.ConflictResolutionProposals.FirstOrDefault(o => o.Id == proposalId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposal(item, proposal),
				() => RequestResult<ConflictResult>.AsSuccess(item)
			});
		}


		[HttpPost, Route("CreateConflictResolutionProposal")]
		public async Task<RequestResult> CreateConflictResolutionProposal(int conflictId, ConflictResolutionProposalCreateModel model)
		{
			var item = DB.Conflicts.Include(o => o.Sides)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilctToEdit(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var proposal = model.Create(item.Sides);
					item.Proposals.Add(proposal);

					UpdateModel(DB.Conflicts, item);
					return RequestResult<ConflictResolutionProposal>.AsSuccess(proposal);
				}
			});
		}

		[HttpPut, Route("UpdateConflictResolutionProposal")]
		public async Task<RequestResult> UpdateConflictResolutionProposal(int conflictId, ConflictResolutionProposalEditModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var proposal = DB.ConflictResolutionProposals.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposalToEdit(item, proposal),
				() => TryUpdateModel(DB.ConflictResolutionProposals, proposal, model)
			});
		}

		[HttpDelete, Route("DeleteConflictResolutionProposal")]
		public async Task<RequestResult> DeleteConflictResolutionProposal(int conflictId, int proposalId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			var proposal = DB.ConflictResolutionProposals.Include(o => o.Feedback)
														 .FirstOrDefault(o => o.Id == proposalId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposalToEdit(item, proposal),
				() => RequestResult.FromBoolean(proposal.Feedback.Count(o => !o.IsDeleted), 403, "Невозможно удалить, т.к. есть ответ на предложение"),
				() => DeleteModel(DB.ConflictResolutionProposals, proposal)
			});
		}


		#endregion

		#region Ответы по предложению по решению конфликта

		[HttpGet, Route("GetConflictResolutionProposalFeedbacks")]
		public async Task<RequestResult> GetConflictResolutionProposalFeedbacks(int conflictId, int proposalId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			var proposal = DB.ConflictResolutionProposals.Include(o => o.Feedback).ThenInclude(o => o.Side)
													     .FirstOrDefault(o => o.Id == proposalId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposal(item, proposal),
				() => RequestResult<ConflictResult>.AsSuccess(item),
				() =>
				{
					var clientModels = ConflictResolutionProposalFeedbackClientModel.CreateItems(proposal.Feedback.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<ConflictResolutionProposalFeedbackClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetConflictResolutionProposalFeedback")]
		public async Task<RequestResult> GetConflictResolutionProposalFeedback(int conflictId, int proposalId, int feedbackId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var proposal = DB.ConflictResolutionProposals.FirstOrDefault(o => o.Id == proposalId && !o.IsDeleted);
			var feedback = DB.ConflictResolutionProposalFeedbacks.FirstOrDefault(o => o.Id == feedbackId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposalFeedback(item, proposal, feedback),
				() => RequestResult<ConflictResolutionProposalFeedback>.AsSuccess(feedback)
			});
		}



		[HttpPost, Route("CreateConflictResolutionProposalFeedback")]
		public async Task<RequestResult> CreateConflictResolutionProposalFeedback(int conflictId, int proposalId, ConflictResolutionProposalFeedbackCreateModel model)
		{
			var item = DB.Conflicts.Include(o => o.Sides)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			var proposal = DB.ConflictResolutionProposals.FirstOrDefault(o => o.Id == proposalId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposalToEdit(item, proposal),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var side = item.Sides.FirstOrDefault(o => o.Id == model.SideId && !o.IsDeleted);
					if(side == null)
					{
						return RequestResult.AsError(404, "Сторона конфликта с данным id не найдена");
					}



					var feedback = model.Create();
					proposal.Feedback.Add(feedback);

					UpdateModel(DB.ConflictResolutionProposals, proposal);
					return RequestResult<ConflictResolutionProposalFeedback>.AsSuccess(feedback);
				}
			});
		}

		[HttpPut, Route("UpdateConflictResolutionProposalFeedback")]
		public async Task<RequestResult> CreateConflictResolutionProposalFeedback(int conflictId, int proposalId, ConflictResolutionProposalFeedbackEditModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var proposal = DB.ConflictResolutionProposals.FirstOrDefault(o => o.Id == proposalId && !o.IsDeleted);
			var feedback = DB.ConflictResolutionProposalFeedbacks.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposalFeedbackToEdit(item, proposal, feedback),
				() => TryUpdateModel(DB.ConflictResolutionProposalFeedbacks, feedback, model)
			});
		}

		[HttpDelete, Route("DeleteConflictResolutionProposalFeedback")]
		public async Task<RequestResult> DeleteConflictResolutionProposalFeedback(int conflictId, int proposalId, int feedbackId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var proposal = DB.ConflictResolutionProposals.FirstOrDefault(o => o.Id == proposalId && !o.IsDeleted);
			var feedback = DB.ConflictResolutionProposalFeedbacks.FirstOrDefault(o => o.Id == feedbackId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposalFeedbackToEdit(item, proposal, feedback),
				() => DeleteModel(DB.ConflictResolutionProposalFeedbacks, feedback)
			});
		}

		#endregion




		#region Private check methods

		private RequestResult CheckBaseConfilct(ConflictEntity item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(item != null,404,"Конфликт с данным id не найден"),
				() => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному конфликту"),
			});
		}
		private RequestResult CheckBaseConfilctToEdit(ConflictEntity item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}


		private RequestResult CheckBaseConflictAndProposal(ConflictEntity item, ConflictResolutionProposal proposal)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(proposal != null,404,"Предложение с данным id не найдено"),
				() => RequestResult.FromBoolean(proposal.ConflictId == item.Id,403,"Предложение не принадлежит текущему конфликту"),
			});
		}
		private RequestResult CheckBaseConflictAndProposalToEdit(ConflictEntity item, ConflictResolutionProposal proposal)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposal(item, proposal),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}


		private RequestResult CheckBaseConflictAndProposalFeedback(ConflictEntity item, ConflictResolutionProposal proposal, ConflictResolutionProposalFeedback feedback)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposal(item,proposal),
				() => RequestResult.FromBoolean(feedback != null,404,"Ответ с данным id не найден"),
				() => RequestResult.FromBoolean(feedback.ConflictResolutionProposalId == proposal.Id,403,"Ответ не принадлежит текущему предложению"),
			});
		}
		private RequestResult CheckBaseConflictAndProposalFeedbackToEdit(ConflictEntity item, ConflictResolutionProposal proposal, ConflictResolutionProposalFeedback feedback)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndProposalFeedback(item, proposal,feedback),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}

		#endregion
	}
}
