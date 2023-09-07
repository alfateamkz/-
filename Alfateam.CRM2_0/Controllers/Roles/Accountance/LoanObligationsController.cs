using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Accountance;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.EditModels.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans.Pledges;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Alfateam.CRM2_0.Controllers.Roles.Accountance
{
    [AccessActionFilter(roles: UserRole.Accountant)]
    [DepartmentFilter]
    public class LoanObligationsController : AbsController
    {
        public LoanObligationsController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: добавить методы получения по цепочке вверх

        #region Долговые обязательства

        [HttpGet, Route("GetLoanObligations")]
        public async Task<RequestResult> GetLoanObligations(int offset, int count = 20)
        {
            var includes = DB.LoanObligations.Include(o => o.Penalty)
                                             .Include(o => o.Currency)
                                             .Where(o => o.AccountanceDepartmentId == this.DepartmentId);
            return GetMany<LoanObligation, LoanObligationClientModel>(includes, offset, count);
        }

        [HttpGet, Route("GetLoanObligation")]
        public async Task<RequestResult> GetLoanObligation(int id)
        {
            var includes = DB.LoanObligations.Include(o => o.Penalty)
                                             .Include(o => o.Currency);

            var obligation = includes.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligation(obligation),
                () => RequestResult<LoanObligation>.AsSuccess(obligation)
            });
        }

        [HttpPost, Route("CreateLoanObligation")]
        public async Task<RequestResult> CreateLoanObligation(LoanObligationCreateModel model)
        {
            return TryCreateModel(DB.LoanObligations, model, (item) =>
            {
                item.AccountanceDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }

        [HttpPut, Route("UpdateLoanObligation")]
        public async Task<RequestResult> UpdateLoanObligation(LoanObligationEditModel model)
        {
            var obligation = DB.LoanObligations.Include(o => o.Penalty)
                                               .Include(o => o.Currency)
                                               .FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligation(obligation),
                () => TryUpdateModel(DB.LoanObligations, obligation, model)
            });
        }

        [HttpDelete, Route("DeleteLoanObligation")]
        public async Task<RequestResult> DeleteLoanObligation(int id)
        {
            var obligation = DB.LoanObligations.Include(o => o.Penalty)
                                               .Include(o => o.Currency)
                                               .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            //TODO: проверка нужна, активно ли оно или просто создано
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligation(obligation),
                () => DeleteModel(DB.LoanObligations, obligation)
            });
        }



        #endregion

        #region Залоги долговых обязательств

        [HttpGet, Route("GetLoanObligationPledges")]
        public async Task<RequestResult> GetLoanObligationPledges(int obligationId,int offset, int count = 20)
        {
            var obligation = DB.LoanObligations.Include(o => o.Pledges).FirstOrDefault(o => o.Id == obligationId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligation(obligation),
                () =>
                {
                    IncludeLoanObligationPledgeItems(obligation);
                    var pledges = obligation.Pledges.Where(o => !o.IsDeleted).Skip(offset).Take(count);
                    return RequestResult<IEnumerable<LoanObligationPledge>>.AsSuccess(pledges);
                }
            });
        }

        [HttpGet, Route("GetLoanObligationPledge")]
        public async Task<RequestResult> GetLoanObligationPledge(int obligationId, int pledgeId)
        {
            var obligation = DB.LoanObligations.Include(o => o.Pledges).FirstOrDefault(o => o.Id == obligationId && !o.IsDeleted);
            var pledge = DB.LoanObligationPledges.FirstOrDefault(o => o.Id == pledgeId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligationAndPledge(obligation,pledge),
                () =>
                {
                    IncludePledgeItems(pledge);
                    return RequestResult<LoanObligationPledge>.AsSuccess(pledge);
                }
            });
        }


        [HttpPost, Route("CreateLoanObligationPledge")]
        public async Task<RequestResult> CreateLoanObligationPledge(int obligationId, LoanObligationPledge pledge)
        {
            var obligation = DB.LoanObligations.Include(o => o.Pledges).FirstOrDefault(o => o.Id == obligationId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligation(obligation),
                () => CheckPledgeBeforeCreate(pledge),
                () =>
                {
                    obligation.Pledges.Add(pledge);
                    return UpdateModel(DB.LoanObligations,obligation);
                }
            });
        }

        [HttpPut, Route("UpdateLoanObligationPledge")]
        public async Task<RequestResult> UpdateLoanObligationPledge(int obligationId, LoanObligationPledge pledge)
        {
            //TODO: нельзя удалять, если активное обязательство

            var obligation = DB.LoanObligations.Include(o => o.Pledges).FirstOrDefault(o => o.Id == obligationId && !o.IsDeleted);
            var pledgeFromDB = DB.LoanObligationPledges.AsNoTracking().FirstOrDefault(o => o.Id == pledge.Id && !o.IsDeleted);
         
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligationAndPledge(obligation,pledgeFromDB),
                () => CheckPledgeBeforeUpdate(pledge, pledgeFromDB),
                () => UpdateModel(DB.LoanObligationPledges,pledge)
            });
        }



        [HttpDelete, Route("DeleteLoanObligationPledge")]
        public async Task<RequestResult> DeleteLoanObligationPledge(int obligationId, int pledgeId)
        {
            //TODO: нельзя удалять, если активное обязательство

            var obligation = DB.LoanObligations.Include(o => o.Pledges).FirstOrDefault(o => o.Id == obligationId && !o.IsDeleted);
            var pledge = DB.LoanObligationPledges.FirstOrDefault(o => o.Id == pledgeId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligationAndPledge(obligation,pledge),
                () => DeleteModel(DB.LoanObligationPledges, pledge)
            });
        }

        #endregion



        #region Private check methods

        private RequestResult CheckBaseLoanObligation(LoanObligation obligation)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(obligation != null,404,"Долговое обязательство с данным id не найдено"),
                () => RequestResult.FromBoolean(obligation.AccountanceDepartmentId == this.DepartmentId,403,"Нет доступа к данному долговому обязательству"),
            });
        }
        private RequestResult CheckBaseLoanObligationAndPledge(LoanObligation obligation, LoanObligationPledge pledge)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLoanObligation(obligation),
                () => RequestResult.FromBoolean(pledge != null,404,"Залог с данным id не найден"),
                () => RequestResult.FromBoolean(pledge.LoanObligationId == obligation.Id,403,"Залог не принадлежит данному долговому обязательству"),
            });
        }


        #region CheckPledgeBeforeCreate
        private RequestResult CheckPledgeBeforeCreate(LoanObligationPledge pledge)
        {
            if(pledge.Id != 0)
            {
                return RequestResult.AsError(400, "Id должен быть нулевой");
            }

            if (pledge is DepositLoanPledge depositPledge)
            {
                return CheckDepositLoanPledgeBeforeCreate(depositPledge);
            }
            else if (pledge is RealEstateLoanPledge realEstatePledge)
            {
                return CheckRealEstateLoanPledgeBeforeCreate(realEstatePledge);
            }
            else if (pledge is ThingLoanPledge thingPledge)
            {
                return CheckThingLoanPledgeBeforeCreate(thingPledge);
            }
            else if (pledge is TransportLoanPledge transportPledge)
            {
                return CheckTransportLoanPledgeBeforeCreate(transportPledge);
            }
            else
            {
                throw new NotImplementedException("Check for new LoanObligationPledge inheritors");
            }
        }

        private RequestResult CheckDepositLoanPledgeBeforeCreate(DepositLoanPledge pledge)
        {
            if (!DB.Currencies.Any(o => o.Id == pledge.CurrencyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Валюта с данным id не найдена");
            }
            return RequestResult.AsSuccess();
        }
        private RequestResult CheckRealEstateLoanPledgeBeforeCreate(RealEstateLoanPledge pledge)
        {
            if(!DB.Currencies.Any(o => o.Id == pledge.CurrencyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Валюта с данным id не найдена");
            }

            if(pledge.RealEstate != null && pledge.RealEstate.Id != 0)
            {
                return RequestResult.AsError(400, "Свойство RealEstate должно иметь нулевой id");
            }
            else if (pledge.RealEstate == null)
            {
                return RequestResult.AsError(400, "Свойство RealEstate не должно быть равно null");
            }
            return RequestResult.AsSuccess();
        }
        private RequestResult CheckThingLoanPledgeBeforeCreate(ThingLoanPledge pledge)
        {
            if (!DB.Currencies.Any(o => o.Id == pledge.CurrencyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Валюта с данным id не найдена");
            }

            if (pledge.Thing != null && pledge.Thing.Id != 0)
            {
                return RequestResult.AsError(400, "Свойство Thing должно иметь нулевой id");
            }
            else if(pledge.Thing == null)
            {
                return RequestResult.AsError(400, "Свойство Thing не должно быть равно null");
            }
            return RequestResult.AsSuccess();
        }
        private RequestResult CheckTransportLoanPledgeBeforeCreate(TransportLoanPledge pledge)
        {
            if (!DB.Currencies.Any(o => o.Id == pledge.CurrencyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Валюта с данным id не найдена");
            }

            if (pledge.Transport != null && pledge.Transport.Id != 0)
            {
                return RequestResult.AsError(400, "Свойство Transport должно иметь нулевой id");
            }
            else if (pledge.Transport == null)
            {
                return RequestResult.AsError(400, "Свойство Transport не должно быть равно null");
            }
            return RequestResult.AsSuccess();
        }

        #endregion 

        #region CheckPledgeBeforeUpdate
        private RequestResult CheckPledgeBeforeUpdate(LoanObligationPledge pledge, LoanObligationPledge pledgeFromDB)
        {
            if(pledge.GetType() != pledgeFromDB.GetType())
            {
                return RequestResult.AsError(400, "Не совпадает тип залога");
            }

            if (pledge is DepositLoanPledge depositPledge)
            {
                return CheckDepositLoanPledgeBeforeUpdate(depositPledge, pledge as DepositLoanPledge);
            }
            else if (pledge is RealEstateLoanPledge realEstatePledge)
            {
                return CheckRealEstateLoanPledgeBeforeUpdate(realEstatePledge, pledge as RealEstateLoanPledge);
            }
            else if (pledge is ThingLoanPledge thingPledge)
            {
                return CheckThingLoanPledgeBeforeUpdate(thingPledge, pledge as ThingLoanPledge);
            }
            else if (pledge is TransportLoanPledge transportPledge)
            {
                return CheckTransportLoanPledgeBeforeUpdate(transportPledge, pledge as TransportLoanPledge);
            }
            else
            {
                throw new NotImplementedException("Check for new LoanObligationPledge inheritors");
            }

        }


        private RequestResult CheckDepositLoanPledgeBeforeUpdate(DepositLoanPledge pledge, DepositLoanPledge pledgeFromDB)
        {
            return RequestResult.AsSuccess();
        }
        private RequestResult CheckRealEstateLoanPledgeBeforeUpdate(RealEstateLoanPledge pledge, RealEstateLoanPledge pledgeFromDB)
        {
            if (!DB.Currencies.Any(o => o.Id == pledge.CurrencyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Валюта с данным id не найдена");
            }

            if (pledge.RealEstate == null)
            {
                return RequestResult.AsError(400, "Свойство RealEstate не должно быть равно null");
            }
            else if (pledge.RealEstate.Id != pledgeFromDB.RealEstateId)
            {
                return RequestResult.AsError(400, "Нельзя задать другой объект недвижимости при редактировании");
            }

            return RequestResult.AsSuccess();
        }
        private RequestResult CheckThingLoanPledgeBeforeUpdate(ThingLoanPledge pledge, ThingLoanPledge pledgeFromDB)
        {
            if (!DB.Currencies.Any(o => o.Id == pledge.CurrencyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Валюта с данным id не найдена");
            }

            if (pledge.Thing == null)
            {
                return RequestResult.AsError(400, "Свойство Thing не должно быть равно null");
            }
            else if (pledge.Thing.Id != pledgeFromDB.ThingId)
            {
                return RequestResult.AsError(400, "Нельзя задать другую вещь при редактировании");
            }

            return RequestResult.AsSuccess();
        }
        private RequestResult CheckTransportLoanPledgeBeforeUpdate(TransportLoanPledge pledge, TransportLoanPledge pledgeFromDB)
        {
            if (!DB.Currencies.Any(o => o.Id == pledge.CurrencyId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Валюта с данным id не найдена");
            }

            if (pledge.Transport == null)
            {
                return RequestResult.AsError(400, "Свойство Thing не должно быть равно null");
            }
            else if (pledge.Transport.Id != pledgeFromDB.TransportId)
            {
                return RequestResult.AsError(400, "Нельзя задать другой транспорт при редактировании");
            }

            return RequestResult.AsSuccess();
        }

        

        #endregion


        #endregion

        #region Private include methods

        private void IncludeLoanObligationPledgeItems(LoanObligation obligation)
        {
            foreach(var pledge in obligation.Pledges)
            {
                IncludePledgeItems(pledge);
            }
        }
        private void IncludePledgeItems(LoanObligationPledge pledge)
        {
            if(pledge is DepositLoanPledge depositPledge)
            {
                depositPledge.Currency = DB.Currencies.FirstOrDefault(o => o.Id == depositPledge.CurrencyId);
            }
            else if(pledge is RealEstateLoanPledge realEstatePledge)
            {
                realEstatePledge.Currency = DB.Currencies.FirstOrDefault(o => o.Id == realEstatePledge.CurrencyId);
                realEstatePledge.RealEstate = DB.RealEstates.FirstOrDefault(o => o.Id == realEstatePledge.RealEstateId);
            }
            else if (pledge is ThingLoanPledge thingPledge)
            {
                thingPledge.Currency = DB.Currencies.FirstOrDefault(o => o.Id == thingPledge.CurrencyId);
                thingPledge.Thing = DB.Things.FirstOrDefault(o => o.Id == thingPledge.ThingId);
            }
            else if (pledge is TransportLoanPledge transportPledge)
            {
                transportPledge.Currency = DB.Currencies.FirstOrDefault(o => o.Id == transportPledge.CurrencyId);
                transportPledge.Transport = DB.Transports.FirstOrDefault(o => o.Id == transportPledge.TransportId);
            }
            else
            {
                throw new NotImplementedException("Check for new LoanObligationPledge inheritors");
            }
        }

        #endregion



    }
}
