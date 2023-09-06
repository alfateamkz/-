using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Enums;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Candidates;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Candidates;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.Candidates;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{

    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.HR)]
    public class HRCandidatesController : AbsController
    {
        public HRCandidatesController(ControllerParams @params) : base(@params)
        {
        }


        //TODO: добавить методы получения по цепочке вверх
        //TODO: client models??
        #region Кандидаты

        [HttpGet, Route("GetCandidates")]
        public async Task<RequestResult> GetCandidates(int offset, int count = 20)
        {
            var allCandidates = DB.Users.Where(o => o is Candidate && !o.IsDeleted).Cast<Candidate>();
            var ourCandidates = allCandidates.Where(o => o.HRDepartmentId == this.DepartmentId)
                                             .Skip(offset)
                                             .Take(count)
                                             .ToList();

            foreach(var candidate in ourCandidates)
            {
                if(candidate is CandidateCounterparty counterpartyCandidate)
                {
                    ClearDeletedSubparties(counterpartyCandidate);
                }
            }
          
            return RequestResult<IEnumerable<Candidate>>.AsSuccess(ourCandidates);
        }

        [HttpGet, Route("GetCandidate")]
        public async Task<RequestResult> GetCandidate(int id)
        {
            var allCandidates = DB.Users.Where(o => o is Candidate).Cast<Candidate>();
            var ourCandidates = allCandidates.Where(o => o.HRDepartmentId == this.DepartmentId);

            var candidate = ourCandidates.FirstOrDefault(o => o.Id == id);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 400, "Сущность с данным id не найдена"),
                () =>
                {
                    if(candidate is CandidateCounterparty counterpartyCandidate)
                    {
                        ClearDeletedSubparties(counterpartyCandidate);
                    }
                    return RequestResult<Candidate>.AsSuccess(candidate);
                }
            });
        }




        [HttpPost, Route("CreateCandidateEmployee")]
        public async Task<RequestResult> CreateCandidateEmployee(CandidateEmployeeCreateModel model)
        {
            //TODO: чекнуть, а то спорно, будет ли работать или надо переопределять методы
            var candidate = model.Create() as CandidateEmployee;
            candidate.HRDepartmentId = (int)this.DepartmentId;

            var cvFile = Request.Form.Files.FirstOrDefault(o => o.Name == "cvFile");
            if (cvFile != null)
            {
                var cvUploadResult = await TryUploadFile(cvFile, FileType.Document);
                if (!cvUploadResult.Success) return cvUploadResult;

                candidate.CVPath = cvUploadResult.Value;
            }

            return CreateModel(DB.Users, candidate);
        }

        [HttpPost, Route("CreateCandidateCounterparty")]
        public async Task<RequestResult> CreateCandidateCounterparty(CandidateCounterpartyCreateModel model)
        {
            //TODO: чекнуть, а то спорно, будет ли работать или надо переопределять методы
            var candidate = model.Create() as CandidateCounterparty;
            candidate.HRDepartmentId = (int)this.DepartmentId;

            if(!DB.Companies.Any(o => o.Id == candidate.CompanyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Компания с данным id не найдена");
            }

            return CreateModel(DB.Users, candidate);
        }



        [HttpPut, Route("UpdateCandidateEmployee")]
        public async Task<RequestResult> UpdateCandidateEmployee(CandidateEmployeeEditModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted) as CandidateEmployee;

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCandidate(candidate),
                () =>
                {
                     var cvFile = Request.Form.Files.FirstOrDefault(o => o.Name == "cvFile");
                     if (cvFile != null)
                     {
                        var cvUploadResult = TryUploadFile(cvFile, FileType.Document).Result;
                        if (!cvUploadResult.Success) return cvUploadResult;

                         candidate.CVPath = cvUploadResult.Value;
                     }

                    return UpdateModel(DB.Users, candidate, model);
                }
            });

           
        }

        [HttpPut, Route("UpdateCandidateCounterparty")]
        public async Task<RequestResult> UpdateCandidateCounterparty(CandidateCounterpartyEditModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted) as CandidateCounterparty;
           
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCandidate(candidate),
                () => UpdateModel(DB.Users,candidate)
            });
        }



        //TODO: в интервью меняем статус кандидата
        [HttpPut, Route("SetCandidateStatus")]
        public async Task<RequestResult> SetCandidateStatus(int candidateId, CandidateStatus status)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && !o.IsDeleted) as CandidateCounterparty;

            return TryFinishAllRequestes(new[]
          {
                () => CheckBaseCandidate(candidate),
                () =>
                {
                    candidate.Status = status;
                    return UpdateModel(DB.Users,candidate);
                }
            });
        }



        #region Редактирование субподрячиков/работников CandidateCounterparty  

        [HttpPost, Route("CreateCounterpartySubparty")]
        public async Task<RequestResult> CreateCounterpartySubparty(int candidateCounterpartyId, CounterpartySubpartyCreateModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateCounterpartyId && !o.IsDeleted) as CandidateCounterparty;
           
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCandidate(candidate),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var subparty = model.Create();
                    subparty.SetCandidateCounterpartyIdRecursively(candidate.Id);

                    candidate.Subparties.Add(subparty);
                    return UpdateModel(DB.Users, candidate);
                }
            });
        }

        [HttpPost, Route("AddCounterpartySubpartyToCompanySubparty")]
        public async Task<RequestResult> AddCounterpartySubpartyToCompanySubparty(int candidateCounterpartyId, int companySubpartyId, CounterpartySubpartyCreateModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateCounterpartyId && !o.IsDeleted) as CandidateCounterparty;
            var companySubparty = DB.CounterpartySubparties.FirstOrDefault(o => o.Id == companySubpartyId && !o.IsDeleted) as CompanySubparty;


            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCandidate(candidate),
                () => CheckBaseSubparty(companySubparty, candidate.Id),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var subParty = model.Create();
                    companySubparty.Subparties.Add(subParty);
                    return UpdateModel(DB.CounterpartySubparties,companySubparty);
                }
            });
        }





        [HttpPut, Route("UpdateCounterpartySubparty")]
        public async Task<RequestResult> UpdateCounterpartySubparty(int candidateCounterpartyId, CounterpartySubpartyEditModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateCounterpartyId && !o.IsDeleted) as CandidateCounterparty;
            var subparty = DB.CounterpartySubparties.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);


            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCandidate(candidate),
                () => CheckBaseSubparty(subparty, candidate.Id),
                () => UpdateModel(DB.CounterpartySubparties,subparty,model)
            });

        }


        [HttpDelete, Route("DeleteCounterpartySubparty")]
        public async Task<RequestResult> DeleteCounterpartySubparty(int candidateCounterpartyId, int subpartyId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateCounterpartyId && !o.IsDeleted) as CandidateCounterparty;
            var subparty = DB.CounterpartySubparties.FirstOrDefault(o => o.Id == subpartyId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCandidate(candidate),
                () => CheckBaseSubparty(subparty, candidate.Id),
                () => DeleteModel(DB.CounterpartySubparties,subparty)
            });
        }



      


        #endregion


        [HttpDelete, Route("DeleteCandidate")]
        public async Task<RequestResult> DeleteCandidate(int id)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == id && !o.IsDeleted) as Candidate;

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCandidate(candidate),
                () => DeleteModel(DB.Users, candidate)
            });
        }

        #endregion





        #region Private check methods

        private RequestResult CheckBaseCandidate(Candidate candidate)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == this.DepartmentId, 403, "Нет доступа к данной сущности"),
            });
        }

        private RequestResult CheckBaseSubparty(CounterpartySubparty subparty,int candidateId)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(subparty != null, 404, "Субподрядчик/работник кандидата-компании не найден"),
                () => RequestResult.FromBoolean(subparty.CandidateCounterpartyId == candidateId, 403, "Субподрядчик/работник не принадлежит данному кандидату-компании"),
            });
        }

        #endregion

        #region Private other methods

        private void ClearDeletedSubparties(CandidateCounterparty counterparty)
        {
            foreach(var subparty in counterparty.Subparties.Where(o => o is CompanySubparty).Cast<CompanySubparty>())
            {
                ClearDeletedSubparties(subparty);
            }
        }

        private void ClearDeletedSubparties(CompanySubparty subparty)
        {
            foreach(var deleted in subparty.Subparties.Where(o => o.IsDeleted))
            {
                subparty.Subparties.Remove(deleted);
            }
   
            foreach (var sub in subparty.Subparties.Where(o => o is CompanySubparty).Cast<CompanySubparty>())
            {
                ClearDeletedSubparties(sub);
            }
        }


        #endregion
    }
}
