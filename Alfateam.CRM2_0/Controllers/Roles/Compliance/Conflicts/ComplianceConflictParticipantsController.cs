using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Participants;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption.Participants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConflictEntity = Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Conflict;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Conflicts
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceConflictParticipantsController : AbsController
	{
		public ComplianceConflictParticipantsController(ControllerParams @params) : base(@params)
		{
		}


		#region Участники сторон конфликта

		[HttpGet, Route("GetParticipants")]
		public async Task<RequestResult> GetParticipants(int conflictId, int sideId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			var side = DB.ConflictSides.Include(o => o.Participants)
									   .FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSide(item, side),
				() =>
				{
					IncludeParticipantsFields(side.Participants.Where(o => !o.IsDeleted));

					var clientModels = ConflictParticipantClientModel.CreateItems(side.Participants.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<ConflictParticipantClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetParticipant")]
		public async Task<RequestResult> GetParticipant(int conflictId, int sideId, int participantId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var side = DB.ConflictSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);
			var participant = DB.ConflictParticipants.FirstOrDefault(o => o.Id == participantId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndParticipant(item, side,participant),
				() =>
				{
					IncludeParticipantFields(participant);
					return RequestResult<ConflictParticipant>.AsSuccess(participant);
				},
			});
		}



		[HttpPost, Route("CreateParticipant")]
		public async Task<RequestResult> CreateParticipant(int conflictId, int sideId, ConflictParticipantCreateModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var side = DB.ConflictSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSideToEdit(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var participant = model.Create();
					side.Participants.Add(participant);

					var validateResult = ValidateParticipant(participant);
					if (!validateResult.Success)
					{
						return validateResult;
					}

					UpdateModel(DB.ConflictSides, side);
					return RequestResult<ConflictParticipant>.AsSuccess(participant);
				}
			});
		}

		[HttpPut, Route("UpdateParticipant")]
		public async Task<RequestResult> UpdateParticipant(int conflictId, int sideId, ConflictParticipantEditModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var side = DB.ConflictSides.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			var participant = DB.ConflictParticipants.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndParticipantToEdit(item, side, participant),
				() =>
				{
					model.Fill(participant);

					var validateResult = ValidateParticipant(participant);
					if (!validateResult.Success)
					{
						return validateResult;
					}

					return UpdateModel(DB.ConflictParticipants, participant);
				},
			});
		}

		[HttpDelete, Route("DeleteParticipant")]
		public async Task<RequestResult> DeleteParticipant(int conflictId, int sideId, int participantId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var side = DB.ConflictSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);
			var participant = DB.ConflictParticipants.FirstOrDefault(o => o.Id == participantId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndParticipantToEdit(item, side, participant),
				() => DeleteModel(DB.ConflictParticipants, participant)
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


		private RequestResult CheckBaseConflictAndSide(ConflictEntity item, ConflictSide side)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflict(item),
				() => RequestResult.FromBoolean(side != null,404,"Сторона конфликта с данным id не найдена"),
				() => RequestResult.FromBoolean(side.ConflictId == item.Id,403,"Сторона не принадлежит данному конфликту"),
			});
		}
		private RequestResult CheckBaseConflictAndSideToEdit(ConflictEntity item, ConflictSide side)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSide(item,side),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}


		private RequestResult CheckBaseConflictAndParticipant(ConflictEntity item, ConflictSide side, ConflictParticipant participant)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSide(item,side),
				() => RequestResult.FromBoolean(participant != null,404,"Участник конфликта с данным id не найден"),
				() => RequestResult.FromBoolean(participant.ConflictSideId == side.Id,403,"Участник конфликта не принадлежит данной стороне"),
			});
		}
		private RequestResult CheckBaseConflictAndParticipantToEdit(ConflictEntity item, ConflictSide side, ConflictParticipant participant)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndParticipant(item,side,participant),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}


		private RequestResult ValidateParticipant(ConflictParticipant participant)
		{
			if (participant is CRMBindedConflictParticipant crmBindedParticipant)
			{
				var user = DB.Users.FirstOrDefault(o => o.Id == crmBindedParticipant.PersonId && !o.IsDeleted);
				if (user == null)
				{
					return RequestResult.AsError(404, "Пользователь с таким id не найден");
				}
				else if (user.BusinessId != this.BusinessId)
				{
					return RequestResult.AsError(403, "Нет доступа к данному пользователю");
				}
			}
			else if (participant is InfoConflictParticipant infoParticipant)
			{
				if (!DB.Countries.Any(o => o.Id == infoParticipant.CountryId && !o.IsDeleted))
				{
					return RequestResult.AsError(404, "Страна с таким id не найдена");
				}
			}
			else
			{
				throw new NotImplementedException("Check for new types of CorruptionCaseParticipant");
			}

			return RequestResult.AsSuccess();
		}

		#endregion

		#region Private include methods
		private void IncludeParticipantsFields(IEnumerable<ConflictParticipant> participants)
		{
			foreach (var participant in participants)
			{
				IncludeParticipantFields(participant);
			}
		}
		private void IncludeParticipantFields(ConflictParticipant participant)
		{
			if (participant is CRMBindedConflictParticipant crmBindedParticipant)
			{
				crmBindedParticipant.Person = DB.Users.Include(o => o.Country)
													  .FirstOrDefault(o => o.Id = crmBindedParticipant.PersonId);
			}
			else if (participant is InfoConflictParticipant infoParticipant)
			{
				infoParticipant.Country = DB.Countries.FirstOrDefault(o => o.Id == infoParticipant.CountryId);
			}
			else
			{
				throw new NotImplementedException("Check for new types of CorruptionCaseParticipant");
			}
		}

		#endregion
	}
}
