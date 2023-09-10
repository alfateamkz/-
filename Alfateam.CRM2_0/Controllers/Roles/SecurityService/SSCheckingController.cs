using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Checking;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Models.Roles.SecurityService.Checking.Data;
using Microsoft.EntityFrameworkCore;
using Alfateam.CRM2_0.Models.EditModels.Roles.SecurityService.Checking;
using System.Net.Mail;
using Alfateam.CRM2_0.Models.General.Verification;

namespace Alfateam.CRM2_0.Controllers.Roles.SecurityService
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.SecurityService)]
    public class SSCheckingController : AbsController
    {
        public SSCheckingController(ControllerParams @params) : base(@params)
        {
        }

        

        #region Запросы на проверку

        [HttpGet, Route("GetSSCheckingRequests")]
        public async Task<RequestResult> GetActualSSCheckingRequests(int offset, int count = 20)
        {
            var requests = DB.SSCheckingRequests.Where(o => o.SecurityServiceDepartmentId == DepartmentId
                                                            && !o.IsDeleted
                                                            && o.ResultId == null)
                                                 .Skip(offset)
                                                 .Take(count)
                                                 .ToList();
            return RequestResult<IEnumerable<SSCheckingRequest>>.AsSuccess(requests);
        }

        [HttpGet, Route("GetHandledSSCheckingRequests")]
        public async Task<RequestResult> GetHandledSSCheckingRequests(SSCheckingRequestResultType type, int offset, int count = 20)
        {
            var requests = DB.SSCheckingRequests.Include(o => o.Result)
                                                 .Where(o => o.SecurityServiceDepartmentId == DepartmentId
                                                            && !o.IsDeleted
                                                            && o.ResultId != null)
                                                 .Where(o => o.Result.Type == type)
                                                 .Skip(offset)
                                                 .Take(count)
                                                 .ToList();
            return RequestResult<IEnumerable<SSCheckingRequest>>.AsSuccess(requests);
        }


        [HttpGet, Route("GetSSCheckingRequest")]
        public async Task<RequestResult> GetSSCheckingRequest(int id)
        {
            var request = DB.SSCheckingRequests.Include(o => o.From)
                                                .Include(o => o.NeedToCheck)
                                                .Include(o => o.CheckingData).ThenInclude(o => o.Attachments)
                                                .Include(o => o.Result)
                                                .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingRequest(request),
                () => RequestResult<SSCheckingRequest>.AsSuccess(requests)
            });
        }




        [HttpPut, Route("SetSSCheckingRequestResult")]
        public async Task<RequestResult> SetSSCheckingRequestResult(int id, SSCheckingRequestResultCreateModel model)
        {
            var request = DB.SSCheckingRequests.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var authorizedUser = GetAuthorizedUser();

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingRequest(request),
                () => RequestResult.FromBoolean(request.ResultId == null, 403, "Результат запроса уже был ранее задан"),
                () =>
                {
                    request.Result = model.Create();

                    if(request.Result.Type == SSCheckingRequestResultType.Approved)
                    {
                        request.Result.Checking = new SSChecking
                        {
                            CheckedById = authorizedUser.Id,
                            CheckedPersonId = request.NeedToCheckId,
                            CheckingDataId = request.CheckingDataId,
                            SecurityServiceDepartmentId = request.SecurityServiceDepartmentId,
                        };
                    }

                    return UpdateModel(DB.SSCheckingRequests, request);
                }
            });
        }

        #endregion

        #region Проверки

        [HttpGet, Route("GetSSCheckings")]
        public async Task<RequestResult> GetSSCheckings(bool showActual, int offset, int count = 20)
        {
            var checkings = DB.SSCheckings.Where(o => o.SecurityServiceDepartmentId == DepartmentId && !o.IsDeleted)
                                          .Include(o => o.CheckedBy)
                                          .Include(o => o.CheckedPerson)
                                          .Include(o => o.Result)
                                          .AsEnumerable();

            if (showActual)
            {
                checkings = checkings.Where(o => o.ResultId == null);
            }
            else
            {
                checkings = checkings.Where(o => o.ResultId != null);
            }

            checkings = checkings.Skip(offset).Take(count).ToList();
            return RequestResult<IEnumerable<SSChecking>>.AsSuccess(checkings);
        }


        [HttpGet, Route("GetSSChecking")]
        public async Task<RequestResult> GetSSChecking(int id)
        {
            var checking = DB.SSCheckings.Include(o => o.CheckedBy)
                                         .Include(o => o.CheckedPerson)
                                         .Include(o => o.CheckingData).ThenInclude(o => o.Attachments)
                                         .Include(o => o.VerificationResults).ThenInclude(o => o.VerificationCode)
                                         .Include(o => o.ScoringResults).ThenInclude(o => o.ScoringModel)
                                         .Include(o => o.ScoringResults).ThenInclude(o => o.QuestionGroups).ThenInclude(o => o.Questions).ThenInclude(o => o.AvailableOptions)
                                         .Include(o => o.ScoringResults).ThenInclude(o => o.QuestionGroups).ThenInclude(o => o.Questions).ThenInclude(o => o.Answer)
                                         .Include(o => o.Result)
                                         .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSChecking(checking),
                () => RequestResult<SSChecking>.AsSuccess(checking)
            });
        }


        [HttpPost, Route("CreateSSChecking")]
        public async Task<RequestResult> CreateSSChecking(SSCheckingCreateModel model)
        {
            var authorizedUser = GetAuthorizedUser();
            var needToCheckUser = DB.Users.FirstOrDefault(o => o.Id == model.CheckedPersonId);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(needToCheckUser != null, 404, "Пользователь с данным id не найден"),
                () => RequestResult.FromBoolean(needToCheckUser.BusinessId == this.BusinessId, 403, "Нет доступа к данному пользователю"),
                () => RequestResult.FromBoolean(model.CheckingData != null, 400, "CheckingData не должно быть null"),
                () => TryCreateModel(DB.SSCheckings, model, async (item) =>
                {
                    item.CheckedById = authorizedUser.Id;
                })
            });
        }


        #region Checking data

        [HttpPut, Route("UpdateCheckingData")]
        public async Task<RequestResult> UpdateCheckingData(int checkingId, SSCheckingDataEditModel model)
        {
            var checking = DB.SSCheckings.Include(o => o.CheckingData)
                                         .FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () =>
                {
                    model.Fill(checking.CheckingData);
                    return UpdateModel(DB.SSCheckings, checking.CheckingData);
                }
            });
        }

        #endregion

        #region Вложения в CheckingData

        [HttpPost, Route("AddCheckingDataAttachment")]
        public async Task<RequestResult> AddCheckingDataAttachment(int checkingId, SSCheckingDataAttachmentType type)
        {
            var checking = DB.SSCheckings.Include(o => o.CheckingData)
                                         .FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);

            var uploadedFile = Request.Form.Files.FirstOrDefault();

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () => RequestResult.FromBoolean(uploadedFile != null, 400, "Не был загружен файл"),
                () =>
                {
                    var uploadResult = TryUploadFile(uploadedFile, Enums.FileType.Any).Result;
                    if(!uploadResult.Success) return checkDataFileUploadResult;

                    checking.CheckingData.Attachments.Add(new Models.Roles.SecurityService.Checking.Data.SSCheckingDataAttachment
                    {
                        AttachmentType = type,
                        AttachmentPath = uploadResult.Value,
                    });
                }
            });
        }

        [HttpPut, Route("SetCheckingDataAttachmentType")]
        public async Task<RequestResult> SetCheckingDataAttachmentType(int checkingId, int attachmentId, SSCheckingDataAttachmentType type)
        {
            var checking = DB.SSCheckings.Include(o => o.CheckingData).ThenInclude(o => o.Attachments)
                                        .FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () =>
                {
                    var attachment = checking.CheckingData.Attachments.FirstOrDefault(o => o.Id == attachmentId && !o.IsDeleted);
                    if(attachment == null)
                    {
                        return RequestResult.AsError(404, "Вложение с данным id не найдено");
                    }

                    attachment.AttachmentType = type;
                    return UpdateModel(DB.SSCheckingDataAttachments, attachment);
                }
            });
        }

        [HttpDelete, Route("DeleteCheckingDataAttachment")]
        public async Task<RequestResult> DeleteCheckingDataAttachment(int checkingId, int attachmentId)
        {
            var checking = DB.SSCheckings.Include(o => o.CheckingData).ThenInclude(o => o.Attachments)
                                         .FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () =>
                {
                    var attachment = checking.CheckingData.Attachments.FirstOrDefault(o => o.Id == attachmentId && !o.IsDeleted);
                    if(attachment == null)
                    {
                        return RequestResult.AsError(404, "Вложение с данным id не найдено");
                    }
                    return DeleteModel(DB.SSCheckingDataAttachments, attachment);
                }
            });
        }


        #endregion

        #region Результаты скорингов

        [HttpPost, Route("AddCheckingScoringResult")]
        public async Task<RequestResult> AddCheckingScoringResult(int checkingId, SSCheckingScoringResultCreateModel model)
        {
            var checking = DB.SSCheckings.FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    if(!DB.ScoringModels.Any(o => o.Id == model.ScoringModelId))
                    {
                        return RequestResult.AsError(404, "Скоринг модель с данным id не найдена");
                    }

                    checking.ScoringResults.Add(model.Create());
                    return UpdateModel(DB.SSCheckings, checking);
                }
            });
        }


        #endregion

        #region Верификация контактных данных

        [HttpPut, Route("AddCheckingVerificationRequest")]
        public async Task<RequestResult> AddCheckingVerificationRequest(int checkingId, VerificationType type, string contact)
        {
            var checking = DB.SSCheckings.Include(o => o.VerificationResults).ThenInclude(o => o.VerificationCode)
                                         .FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () =>
                {
                    var foundVerification = checking.VerificationResults.FirstOrDefault(o => o.VerificationCode.Contact == contact
                                                                                          && o.VerificationCode.Type == type
                                                                                          && o.VerificationCode.IsVerified);
                    if(foundVerification != null)
                    {
                        return RequestResult.AsError(403, "Данный контакт уже был ранее верифицирован");
                    }

                    checking.VerificationResults.Add(new SSCheckingVerificationInfo
                    {
                        VerificationCode = new VerificationCode
                        {
                            Contact = contact,
                            Type = type
                        }
                    });

                    //TODO: отправка кода. будем здесь делать или где-то в едином эндпоинте?

                    return UpdateModel(DB.SSCheckings,checking);
                }
            });
        }

        [HttpPut, Route("VerifyCheckingVerificationRequest")]
        public async Task<RequestResult> VerifyCheckingVerificationRequest(int checkingId, int requestId, string code)
        {
            var checking = DB.SSCheckings.Include(o => o.VerificationResults).ThenInclude(o => o.VerificationCode)
                                        .FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () =>
                {
                    var foundVerification = checking.VerificationResults.FirstOrDefault(o => o.Id == requestId);
                    if(foundVerification == null)
                    {
                        return RequestResult.AsError(404, "Запрос на верификацию с данным id не найден");
                    }

                    if (foundVerification.VerificationCode.IsVerified)
                    {
                        return RequestResult.AsError(403, "Данный запрос уже был ранее верифицирован");
                    }

                    if (foundVerification.VerificationCode.IsExpired)
                    {
                        return RequestResult.AsError(403, "Срок данного запрос уже истек. Запросите код еще раз");
                    }
                    
                    if(foundVerification.VerificationCode.Code == code)
                    {
                        foundVerification.VerificationCode.IsVerified = true;
                        UpdateModel(DB.SSCheckingVerificationInfos, foundVerification);
                        return RequestResult<bool>.AsSuccess(true);
                    }
                    else
                    {
                         return RequestResult<bool>.AsSuccess(false);
                    }
                }
            });
        }


        #endregion

        #region Результат проверки

        [HttpPut, Route("SetCheckingResult")]
        public async Task<RequestResult> SetCheckingResult(int checkingId, SSCheckingResultCreateModel model)
        {
            var checking = DB.SSCheckings.FirstOrDefault(o => o.Id == checkingId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSCheckingToEdit(checking),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    checking.Result = model.Create();
                    return UpdateModel(DB.SSCheckings, checking);
                }
            });
        }

        #endregion

        #endregion





        #region Private check methods

        private RequestResult CheckBaseSSCheckingRequest(SSCheckingRequest request)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(request != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(request.SecurityServiceDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
            });
        }

        private RequestResult CheckBaseSSChecking(SSChecking checking)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(checking != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(checking.SecurityServiceDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
            });
        }

        private RequestResult CheckBaseSSCheckingToEdit(SSChecking checking)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseSSChecking(checking),
                () => RequestResult.FromBoolean(checking.ResultId == null, 403, "Редактирование невозможно. Проверка закрыта")
            });
        }

        #endregion
    }
}
