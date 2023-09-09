using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Checking;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Litigations;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Lawyer)]
    public class LawyerLegalCasesController : AbsController
    {
        public LawyerLegalCasesController(ControllerParams @params) : base(@params)
        {
        }

        #region Запросы на юридическое дело

        [HttpGet, Route("GetActualLegalCaseRequests")]
        public async Task<RequestResult> GetActualLegalCaseRequests(int offset, int count = 20)
        {
            var requests = DB.LegalCaseRequests.Where(o => o.LawDepartmentId == DepartmentId
                                                            ! && o.IsDeleted
                                                            && o.ResultId == null)
                                               .Include(o => o.From)
                                               .Include(o => o.SecondSide)
                                               .Skip(offset)
                                               .Take(count)
                                               .ToList();
            return RequestResult<IEnumerable<LegalCaseRequest>>.AsSuccess(requests);
        }

        [HttpGet, Route("GetHandledLegalCaseRequests")]
        public async Task<RequestResult> GetHandledLegalCaseRequests(LegalCaseRequestResultType type, int offset, int count = 20)
        {
            var requests = DB.LegalCaseRequests.Include(o => o.Result)
                                               .Where(o => o.LawDepartmentId == DepartmentId
                                                            ! && o.IsDeleted
                                                            && o.ResultId != null)
                                               .Include(o => o.From)
                                               .Include(o => o.SecondSide)
                                               .Where(o => o.Result.Type == type)
                                               .Skip(offset)
                                               .Take(count)
                                               .ToList();
            return RequestResult<IEnumerable<LegalCaseRequest>>.AsSuccess(requests);
        }

        [HttpGet, Route("GetLegalCaseRequest")]
        public async Task<RequestResult> GetLegalCaseRequest(int id)
        {
            var request = DB.LegalCaseRequests.Include(o => o.From)
                                              .Include(o => o.SecondSide)
                                              .Include(o => o.Result)
                                              .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCaseRequest(request),
                () => RequestResult<LegalCaseRequest>.AsSuccess(requests)
            });
        }



        [HttpPut, Route("SetLegalCaseRequestResult")]
        public async Task<RequestResult> SetLegalCaseRequestResult(int id, LegalCaseRequestResultCreateModel model)
        {
            var request = DB.LegalCaseRequests.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var authorizedUser = GetAuthorizedUser();

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCaseRequest(request),
                () => RequestResult.FromBoolean(request.ResultId == null, 403, "Результат запроса уже был ранее задан"),
                () =>
                {
                    request.Result = model.Create();

                    if(request.Result.Type == LegalCaseRequestResultType.Approved)
                    {
                        request.Result.LegalCase = new LegalCase
                        {
                            CaseInfo = request.CaseInfo,
                            SecondSideId = request.SecondSideId,
                            CreatedById = authorizedUser.Id,
                            LawDepartmentId = request.LawDepartmentId,
                        };
                    }

                    return UpdateModel(DB.LegalCaseRequests, request);
                }
            });
        }

        #endregion

        #region Юридические дела

        [HttpGet, Route("GetLegalCases")]
        public async Task<RequestResult> GetLegalCases(bool showActual, int offset, int count = 20)
        {
            var legalCases = DB.LegalCases.Where(o => o.LawDepartmentId == DepartmentId
                                                             && !o.IsDeleted)
                                          .Include(o => o.CreatedBy)
                                          .Include(o => o.SecondSide)
                                          .Include(o => o.Result)
                                          .AsEnumerable();

            if (showActual)
            {
                legalCases = checkings.Where(o => o.ResultId == null);
            }
            else
            {
                legalCases = checkings.Where(o => o.ResultId != null);
            }

            legalCases = legalCases.Skip(offset).Take(count).ToList();
            return RequestResult<IEnumerable<LegalCase>>.AsSuccess(legalCases);
        }

        [HttpGet, Route("GetLegalCase")]
        public async Task<RequestResult> GetLegalCase(int id)
        {
            var legalCase = DB.LegalCases.Include(o => o.CreatedBy)
                                         .Include(o => o.SecondSide)
                                         .Include(o => o.Result)
                                         .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCase(legalCase),
                () => RequestResult<LegalCase>.AsSuccess(legalCase)
            });
        }


        [HttpPost, Route("CreateLegalCase")]
        public async Task<RequestResult> CreateLegalCase(LegalCaseCreateModel model)
        {
            var authorizedUser = GetAuthorizedUser();

            if(model.SecondSideId != null)
            {
                var needToCheckUser = DB.Users.FirstOrDefault(o => o.Id == model.CheckedPersonId);
                if(needToCheckUser == null)
                {
                    return RequestResult.AsError(404, "Пользователь с данным id не найден");
                }
                else if(needToCheckUser.BusinessId != this.BusinessId)
                {
                    return RequestResult.AsError(403, "Нет доступа к данному пользователю");
                }
            }

            return TryCreateModel(DB.LegalCases, model, async (item) =>
            {
                item.CreatedById = authorizedUser.Id;
                item.LawDepartmentId = this.DepartmentId;
            });
        }


        #region Документы

        #endregion

        #region Изменение порядка ведения дела

        [HttpPut, Route("SetNonTrialLegalCaseProcedure")]
        public async Task<RequestResult> SetNonTrialLegalCaseProcedure(int caseId, LegalCaseProcedure procedure)
        {
            var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCaseToEdit(legalCase),
                () => RequestResult.FromBoolean(legalCase.Procedure != LegalCaseProcedure.Trial, 403, "Дело уже имеет судебный порядок. Невозможно изменить статус"),
                () => RequestResult.FromBoolean(procedure != LegalCaseProcedure.Trial, 403, "Для LegalCaseProcedure.Trial есть другой метод"),
                () =>
                {
                    legalCase.Procedure = procedure;
                    return UpdateModel(DB.LegalCases, legalCase);
                }
            });
        }

        [HttpPut, Route("SetTrialLegalCaseProcedure")]
        public async Task<RequestResult> SetTrialLegalCaseProcedure(int caseId, LitigationType type)
        {
            var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCaseToEdit(legalCase),
                () => RequestResult.FromBoolean(legalCase.Procedure != LegalCaseProcedure.Trial, 403, "Дело уже имеет судебный порядок. Невозможно изменить статус"),
                () =>
                {
                    legalCase.Procedure = LegalCaseProcedure.Trial;
                    legalCase.Litigation = CreateLigitation(type);

                    UpdateModel(DB.LegalCases, legalCase);
                    return RequestResult<Litigation>.AsSuccess(legalCase.Litigation);
                }
            });
        }

        #endregion

        #region Судебный процесс

        [HttpGet, Route("GetLegalCaseLigitationMain")]
        public async Task<RequestResult> GetLegalCaseLigitationMain(int caseId)
        {
            var legalCase = DB.LegalCases.Include(o => o.Litigation).ThenInclude(o => o.Sides).ThenInclude(o => o.Sides)
                                         .Include(o => o.Litigation).ThenInclude(o => o.TrialRequests)
                                         .Include(o => o.Litigation).ThenInclude(o => o.Hearings)
                                         .Include(o => o.Litigation).ThenInclude(o => o.Result)
                                         .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCase(legalCase),
                () => RequestResult<Litigation>.AsSuccess(legalCase.Litigation)
            });
        }



		#region Стороны судебного процесса


		#endregion

		#region Заявления в суд


		#endregion


		#region Слушания


		[HttpGet, Route("GetLegalCaseLigitationTrialHearings")]
		public async Task<RequestResult> GetLegalCaseLigitationTrialHearings(int caseId)
		{
			var legalCase = DB.LegalCases.Include(o => o.Litigation).ThenInclude(o => o.Hearings).ThenInclude(o => o.Judge).ThenInclude(o => o.Country)
										 .Include(o => o.Litigation).ThenInclude(o => o.Hearings).ThenInclude(o => o.Court).ThenInclude(o => o.Structure)
										 .Include(o => o.Litigation).ThenInclude(o => o.Hearings).ThenInclude(o => o.Result)
										 .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
			    () => RequestResult.FromBoolean(legalCase.LitigationId != null, 400, "Судебный процесс еще не был начат"),
				() =>
				{
					var clientModels = TrialHearingClientModel.CreateItems(legalCase.Litigation.Hearings);
					return RequestResult<IEnumerable<TrialHearingClientModel>>.AsSuccess(clientModels);
				}
			});
		}


		[HttpGet, Route("GetLegalCaseLigitationTrialHearing")]
        public async Task<RequestResult> GetLegalCaseLigitationTrialHearing(int caseId,int hearingId)
        {
            var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

            var hearing = DB.TrialHearings.Include(o => o.Judge).ThenInclude(o => o.Country)
                                          .Include(o => o.Court).ThenInclude(o => o.Structure)
										  .Include(o => o.Result)
                                          .FirstOrDefault(o => o.Id == hearingId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCaseAndHearing(legalCase, hearing),
                () =>
                {
                    var clientModel = TrialHearingClientModel.Create(hearing);
                    return RequestResult<TrialHearingClientModel>.AsSuccess(clientModel);
                }
            });
        }


		
        
        [HttpPost, Route("CreateLegalCaseLigitationTrialHearing")]
		public async Task<RequestResult> CreateLegalCaseLigitationTrialHearing(int caseId, TrialHearingCreateModel model)
        {
			var legalCase = DB.LegalCases.Include(o => o.Litigation)
                                         .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
		    {
				() => CheckBaseLegalCase(legalCase),
                () => RequestResult.FromBoolean(legalCase.LitigationId != null, 400, "Судебный процесс еще не был начат"),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
 				() =>
				{
                    var hearing = model.Create();
                    legalCase.Litigation.Hearings.Add(hearing);

					UpdateModel(DB.LegalCases, legalCase);
					return RequestResult<TrialHearing>.AsSuccess(hearing);
				}
			});
		}

		[HttpPut, Route("UpdateLegalCaseLigitationTrialHearing")]
		public async Task<RequestResult> UpdateLegalCaseLigitationTrialHearing(int caseId, TrialHearingEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var hearing = DB.TrialHearings.FirstOrDefault(o => o.Id == model.Id);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId == null, 403, "Редактирование невозможно, т.к. был задан результат"),
 				() => TryUpdateModel(DB.TrialHearings, hearing, model)
			});
		}

		[HttpDelete, Route("DeleteLegalCaseLigitationTrialHearing")]
		public async Task<RequestResult> DeleteLegalCaseLigitationTrialHearing(int caseId, int hearingId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var hearing = DB.TrialHearings.FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId == null, 403, "Редактирование невозможно, т.к. был задан результат"),
 				() => DeleteModel(DB.TrialHearings, hearing)
			});
		}



		#region Результат слушания


		[HttpPost, Route("CreateLegalCaseTrialHearingResult")]
		public async Task<RequestResult> CreateLegalCaseTrialHearingResult(int caseId, int hearingId, TrialHearingResultCreateModel model)
        {
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var hearing = DB.TrialHearings.FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId == null, 403, "Редактирование невозможно, т.к. был задан результат"),
 				() =>
                {
                    var result = model.Create();
                    hearing.Result = result;

                    UpdateModel(DB.TrialHearings, hearing);
                    return RequestResult<TrialHearingResult>.AsSuccess(result);
				}
			});
		}


		[HttpPut, Route("UpdateLegalCaseTrialHearingResult")]
		public async Task<RequestResult> UpdateLegalCaseTrialHearingResult(int caseId, int hearingId, TrialHearingResultEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var hearing = DB.TrialHearings.Include(o => o.Result).FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId != null, 403, "Редактирование невозможно, т.к. не был еще задан результат"),
				() => RequestResult.FromBoolean(hearing.Result.IsLockedForChanges == false, 403, "Редактирование невозможно, т.к. результат был утвержден"),
 				() => TryUpdateModel(DB.TrialHearingResults, hearing.Result, model)
			});
		}


		[HttpPut, Route("LockLegalCaseTrialHearingResult")]
		public async Task<RequestResult> LockLegalCaseTrialHearingResult(int caseId, int hearingId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var hearing = DB.TrialHearings.Include(o => o.Result).FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId != null, 403, "Редактирование невозможно, т.к. не был еще задан результат"),
 				() =>
				{
                    hearing.Result.IsLockedForChanges = true;
					return UpdateModel(DB.TrialHearingResults, hearing.Result);
				}
			});
		}

		#region Документы к результату слушания



		[HttpGet, Route("GetLegalCaseTrialHearingResultDocuments")]
		public async Task<RequestResult> GetLegalCaseTrialHearingResultDocuments(int caseId, int hearingId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var hearing = DB.TrialHearings.Include(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.Versions)
										  .Include(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.SignedDocument).ThenInclude(o => o.EDMProvider)
										  .FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase, hearing),
 				() =>
				{
					var clientModels = DocumentClientModel.CreateItems(hearing.Result.Documents);
					return RequestResult<IEnumerable<DocumentClientModel>>.AsSuccess(clientModels);
				}
			});
		}


        //TODO: работа с документами
        
		[HttpPost, Route("AddLegalCaseTrialHearingResultDocument")]
		public async Task<RequestResult> AddLegalCaseTrialHearingResultDocument(int caseId, int hearingId, DocumentCreateModel model)
        {

        }


		#endregion


		#endregion


		#endregion

		#region Результаты судебного процесса

		[HttpGet, Route("GetLegalCaseLigitationResult")]
        public async Task<RequestResult> GetLegalCaseLigitationResult(int caseId)
        {
            var legalCase = DB.LegalCases.Include(o => o.Litigation).ThenInclude(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.CreatedBy)
                                         .Include(o => o.Litigation).ThenInclude(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.Versions)
                                         .Include(o => o.Litigation).ThenInclude(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.SignedDocument).ThenInclude(o => o.EDMProvider)
                                         .Include(o => o.Litigation).ThenInclude(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.SignedDocument).ThenInclude(o => o.Version)
                                         .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCase(legalCase),
                () => RequestResult<TrialProcessResult>.AsSuccess(legalCase.Litigation.Result)
            });
        }

        public async Task<RequestResult> SetLegalCaseLigitationResult(int caseId)
        {

        }

        #endregion

        #endregion

        #region Результат дела

        [HttpPut, Route("SetLegalCaseResult")]
        public async Task<RequestResult> SetLegalCaseResult(int caseId, LegalCaseResultCreateModel model)
        {
            var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCaseToEdit(legalCase),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    legalCase.Result = model.Create();
                    UpdateModel(DB.LegalCases, legalCase);
                    RequestResult<LegalCaseResult>.AsSuccess(legalCase.Result);
                }
            });
        }


        #endregion

        #endregion








        #region Private check methods

        private RequestResult CheckBaseLegalCaseRequest(LegalCaseRequest request)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(request != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(request.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
            });
        }



        private RequestResult CheckBaseLegalCase(LegalCase legalCase)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(legalCase != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(legalCase.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
            });
        }
        private RequestResult CheckBaseLegalCaseToEdit(LegalCase legalCase)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLegalCase(legalCase),
                () => RequestResult.FromBoolean(legalCase.ResultId == null, 403, "Редактирование невозможно. Дело закрыто")
            });
        }


        private RequestResult CheckBaseLegalCaseAndHearing(LegalCase legalCase, TrialHearing hearing)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(legalCase != null,404,"Юридическое дело с данным id не найден"),
                () => RequestResult.FromBoolean(legalCase.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
                () => RequestResult.FromBoolean(hearing != null,404, "Слушание с данным id не найдено"),
                () => RequestResult.FromBoolean(hearing.LitigationId == legalCase.Litigation, 403, "Данное слушание не принадлежит текущему юридическому делу"),
            });
        }


        #endregion

        #region Private other methods

        private Litigation CreateLigitation(LitigationType type)
        {
            //TODO: когда проработаем модели, подумать

            switch (type)
            {
                case LitigationType.Administrative:
                    return new AdministrativeLitigation();
                case LitigationType.Arbitration:
                    return new ArbitrationLitigation();
                case LitigationType.Civil:
                    return new CivilLitigation();
                case LitigationType.Constitutional:
                    return new ConstitutionalLitigation();
                case LitigationType.Criminal:
                    return new CriminalLitigation();
                default:
                    throw new NotImplementedException("Check for new Litigation inheritors");
            }
        }

        private void IncludeLigitationFields(Litigation ligitation)
        {
            ligitation.Sides = ligitation.Sides.Where(o => !o.IsDeleted).ToList();
            foreach(var side in ligitation.Sides)
            {
                side.Participants = side.Participants.ToList();
            }


            ligitation.TrialRequests = ligitation.TrialRequests.Where(o => !o.IsDeleted).ToList();
            ligitation.Hearings = ligitation.Hearings.Where(o => !o.IsDeleted).ToList();


            if (ligitation is AdministrativeLitigation administrativeLigitation)
            {

            }
            else if (ligitation is ArbitrationLitigation arbitrationLigitation)
            {

            }
            else if (ligitation is CivilLitigation civilLigitation)
            {

            }
            else if (ligitation is ConstitutionalLitigation constititionalLigitation)
            {

            }
            else if (ligitation is CriminalLitigation criminalLigitation)
            {

            }
            else
            {
                throw new NotImplementedException("Check for new Litigation inheritors");
            }
        }

        #endregion

    }
}
