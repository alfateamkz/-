using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Participants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer.LegalCases
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerLitigationParticipantsController : AbsController
	{
		public LawyerLitigationParticipantsController(ControllerParams @params) : base(@params)
		{
		}
		

		#region Участники стороны судебного процесса

		[HttpGet, Route("GetLitigationSideParticipants")]
		public async Task<RequestResult> GetLitigationSideParticipants(int caseId, int litigationId,int sideId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var side = DB.TrialProcessSides.Include(o => o.Participants).ThenInclude(o => o.ConnectedAtHearing)
										   .FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);


			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndSide(legalCase,litigation,side),
				() =>
				{
					IncludeParticipantsFields(side.Participants);

					var clientModels = TrialProcessParticipantClientModel<TrialProcessParticipant>.CreateItems(side.Participants);
					return RequestResult<IEnumerable<TrialProcessParticipantClientModel<TrialProcessParticipant>>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetLitigationSideParticipant")]
		public async Task<RequestResult> GetLitigationSideParticipant(int caseId, int litigationId, int sideId,int participantId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var side = DB.TrialProcessSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			var participant = DB.TrialProcessParticipants.Include(o => o.ConnectedAtHearing)
														 .FirstOrDefault(o => o.Id == participantId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndParticipant(legalCase,litigation,side),
				() =>
				{
					IncludeParticipantFields(participant);

					var clientModel = TrialProcessParticipantClientModel<TrialProcessParticipant>.Create(participant);
					return RequestResult<TrialProcessParticipantClientModel<TrialProcessParticipant>>.AsSuccess(clientModel);
				}
			});
		}



		[HttpPost, Route("CreateLitigationSideParticipant")]
		public async Task<RequestResult> CreateLitigationSideParticipant(int caseId, int litigationId, int sideId, TrialProcessParticipantCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var side = DB.TrialProcessSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndSide(legalCase,litigation,side),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения полей"),
				() =>
				{
					var participant = model.Create();

					var checkFieldsResult = CheckParticipantFields(participant);
					if (!checkFieldsResult.Success)
					{
						return checkFieldsResult;
					}

					side.Participants.Add(participant);
					UpdateModel(DB.TrialProcessSides, side);
					return RequestResult<TrialProcessParticipant>.AsSuccess(participant);
				}
			});
		}

		[HttpPut, Route("UpdateLitigationSideParticipant")]
		public async Task<RequestResult> UpdateLitigationSideParticipant(int caseId, int litigationId, int sideId, TrialProcessParticipantEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var side = DB.TrialProcessSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);
			var participant = DB.TrialProcessParticipants.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndParticipant(legalCase,litigation,side,participant),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения полей"),
				() =>
				{
					model.Fill(participant);

					var checkFieldsResult = CheckParticipantFields(participant);
					if (!checkFieldsResult.Success)
					{
						return checkFieldsResult;
					}

					return UpdateModel(DB.TrialProcessParticipants, participant);
				}
			});

		}


		[HttpDelete, Route("DeleteLitigationSideParticipant")]
		public async Task<RequestResult> DeleteLitigationSideParticipant(int caseId, int litigationId, int sideId, int participantId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var side = DB.TrialProcessSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);
			var participant = DB.TrialProcessParticipants.FirstOrDefault(o => o.Id == participantId && !o.IsDeleted);
			
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndParticipant(legalCase,litigation,side),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => DeleteModel(DB.TrialProcessParticipants, participant)
			});
		}

		#endregion




		#region Private check methods

		private RequestResult CheckBaseLegalCase(LegalCase legalCase)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(legalCase != null,404,"Юридическое дело с данным id не найдено"),
				() => RequestResult.FromBoolean(legalCase.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данному юридическому делу"),
			});
		}
		private RequestResult CheckBaseLegalCaseAndLitigation(LegalCase legalCase, Litigation litigation)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult.FromBoolean(litigation != null,404, "Судебное разбирательство с данным id не найдено"),
				() => RequestResult.FromBoolean(litigation.LegalCaseId == legalCase.Id, 403, "Данное судебное разбирательство не принадлежит текущему юридическому делу"),
			});
		}
		private RequestResult CheckBaseLegalCaseAndLitigationToEdit(LegalCase legalCase, Litigation litigation)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => RequestResult.FromBoolean(litigation.ResultId == null,404, "Редактирование невозможно. Судебное разбирательство завершено"),
			});
		}
	
		
		private RequestResult CheckBaseLegalCaseAndHearing(LegalCase legalCase, Litigation litigation, TrialHearing hearing)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => RequestResult.FromBoolean(hearing != null,404, "Слушание с данным id не найдено"),
				() => RequestResult.FromBoolean(hearing.LitigationId == litigation.Id, 403, "Данное слушание не принадлежит текущему судебному процессу"),
			});
		}



		private RequestResult CheckBaseLegalCaseAndSide(LegalCase legalCase, Litigation litigation, TrialProcessSide side)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => RequestResult.FromBoolean(side != null,404, "Сторона с данным id не найдена"),
				() => RequestResult.FromBoolean(side.LitigationId == litigation.Id, 403, "Данное слушание не принадлежит текущему судебному процессу"),
			});
		}
		private RequestResult CheckBaseLegalCaseAndParticipant(LegalCase legalCase, Litigation litigation, TrialProcessSide side, TrialProcessParticipant participant)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndSide(legalCase,litigation,side),
				() => RequestResult.FromBoolean(participant != null,404, "Участник с данным id не найден"),
				() => RequestResult.FromBoolean(participant.TrialProcessSideId == side.Id, 403, "Данное слушание не принадлежит текущему судебному процессу"),
			});
		}



		private RequestResult CheckParticipantFields(TrialProcessParticipant participant)
		{
			if (participant.ConnectedAtHearingId != null)
			{
				var hearing = DB.TrialHearings.FirstOrDefault(o => o.Id == participant.ConnectedAtHearingId && !o.IsDeleted);

				var hearingCheckResult = CheckBaseLegalCaseAndHearing(legalCase, litigation, hearing);
				if (!hearingCheckResult.Success)
				{
					return hearingCheckResult;
				}
			}


			if (participant is CRMTrialProcessParticipant crmParticipant)
			{
				var user = DB.Users.FirstOrDefault(o => o.Id == crmParticipant.UserId && !o.IsDeleted);
				if (user == null)
				{
					return RequestResult.AsError(404, "Пользователь с таким id не найден");
				}
				else if (user.BusinessId != this.BusinessId)
				{
					return RequestResult.AsError(403, "Нет доступа к данному пользователю");
				}
			}
			else if (participant is InfoTrialProcessParticipant infoParticipant)
			{
				if (!DB.Countries.Any(o => o.Id == infoParticipant.CountryId && !o.IsDeleted))
				{
					return RequestResult.AsError(404, "Страна с таким id не найдена");
				}
			}
			else
			{
				throw new NotImplementedException("Check for new types of InfoTrialProcessParticipant");
			}

			return RequestResult.AsSuccess();
		}

		#endregion

		#region Private other methods

		private void IncludeParticipantsFields(IEnumerable<TrialProcessParticipant> participants)
		{
			foreach(var participant in participants)
			{
				IncludeParticipantFields(participant);
			}
		}
		private void IncludeParticipantFields(TrialProcessParticipant participant)
		{

			if(participant.ConnectedAtHearingId != null && participant.ConnectedAtHearing == null)
			{
				participant.ConnectedAtHearing = DB.TrialHearings.FirstOrDefault(o => o.Id == participant.ConnectedAtHearingId);
			}


			if(participant is CRMTrialProcessParticipant crmParticipant)
			{
				crmParticipant.User = DB.Users.FirstOrDefault(o => o.Id == crmParticipant.UserId);
			}
			else if (participant is InfoTrialProcessParticipant infoParticipant)
			{
				infoParticipant.Country = DB.Users.FirstOrDefault(o => o.Id == infoParticipant.CountryId);
			}
			else
			{
				throw new NotImplementedException("Check for new types of TrialProcessParticipant");
			}
		}

		#endregion
	}
}
