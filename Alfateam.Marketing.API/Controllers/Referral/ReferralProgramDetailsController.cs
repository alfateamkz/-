using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Enums;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Referral.Main;
using Alfateam.Marketing.API.Models.Referral;
using Alfateam.Marketing.API.Models.SearchFilters;
using Alfateam.Marketing.API.Models.SearchFilters.Referral;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Referral;
using Alfateam.Marketing.Models.Referral.Main;
using Alfateam.Marketing.Models.Referral.Main.Transactions;
using Alfateam.Marketing.Models.SalesGenerators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.Marketing.API.Controllers.Referral
{
    public class ReferralProgramDetailsController : AbsController
    {
        public ReferralProgramDetailsController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение и управление рефералами

        [HttpGet, Route("GetUsers")]
        public async Task<ItemsWithTotalCount<ReferralUserDTO>> GetUsers(ReferralUsersSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ReferralUser, ReferralUserDTO>(GetAvailableReferralProgramUsers(filter.ReferralProgramId), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                //if (!string.IsNullOrEmpty(filter.Query))
                //{
                //    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                //}
                if (filter.ShowBanned == false)
                {
                    condition &= entity.BanInfoId == null;
                }
                if (filter.ShowBanned == true)
                {
                    condition &= entity.BanInfoId != null;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetUser")]
        public async Task<ReferralUserDTO> GetUser(int referralProgramId, int userId)
        {
            return (ReferralUserDTO)DBService.TryGetOne(GetAvailableReferralProgramUsers(referralProgramId), userId, new ReferralUserDTO());
        }

        [HttpGet, Route("GetUserStats")]
        public async Task<ReferralUserStats> GetUserStats(int referralProgramId, int userId)
        {
            var userDTO = (ReferralUserDTO)DBService.TryGetOne(GetAvailableReferralProgramUsers(referralProgramId), userId, new ReferralUserDTO());

            return new ReferralUserStats
            {
                User = userDTO,
                ReferralsCount = GetUserReferrals(referralProgramId, userId).Count(),
                EarnedSum = GetReferralEarnedSum(referralProgramId,userId),
                OrdersCount = GetReferralOrdersCount(referralProgramId, userId),
                SumOnAccounts = GetReferralSumOnAccounts(referralProgramId,userId),
                SumOnWithdrawal = GetReferralSumOnWithdrawal(referralProgramId, userId),
            };
        }






        [HttpPut, Route("BanUser")]
        public async Task BanUser(int referralProgramId, int userId, ReferralBanInfoDTO banInfo)
        {
            DBService.TryGetOne(GetAvailableReferralProgramUsers(referralProgramId), userId);
            DBService.TryCreateEntity(DB.ReferralBanInfo, banInfo, (entity) =>
            {
                entity.ReferralUserId = userId;
            });
        }

        [HttpPut, Route("UnbanUser")]
        public async Task UnbanUser(int referralProgramId, int userId)
        {
            var user = DBService.TryGetOne(GetAvailableReferralProgramUsers(referralProgramId), userId);

            user.BanInfoId = null;
            user.BanInfo = null;

            DBService.UpdateEntity(DB.ReferralUsers, user);
        }



        #endregion

        #region Счета рефералов

        [HttpGet, Route("GetAccounts")]
        public async Task<ItemsWithTotalCount<ReferralAccountDTO>> GetAccounts(RefUserAccountsSearchFilter filter)
        {
            var user = DBService.TryGetOne(GetAvailableReferralProgramUsers(filter.ReferralProgramId), filter.UserId);

            return DBService.GetManyWithTotalCount<ReferralAccount, ReferralAccountDTO>(user.Accounts, filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.CurrencyCode.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.HideZeroBalancedAccounts == false)
                {
                    condition &= entity.GetBalance() > 0;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetAccount")]
        public async Task<ReferralAccountDTO> GetAccount(int referralProgramId, int userId, int accountId)
        {
            var user = DBService.TryGetOne(GetAvailableReferralProgramUsers(referralProgramId), userId);
            return (ReferralAccountDTO)DBService.TryGetOne(user.Accounts, accountId, new ReferralAccountDTO());
        }

        #endregion




        #region Private get available methods

        private IEnumerable<ReferralProgram> GetAvailableReferralPrograms()
        {
            //TODO: ReferralPrograms includes
            return DB.ReferralPrograms.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        private IEnumerable<ReferralUser> GetAvailableReferralProgramUsers(int programId)
        {
            DBService.TryGetOne(GetAvailableReferralPrograms(), programId);

            var users = DB.ReferralUsers.Include(o => o.BanInfo)
                                        .Include(o => o.Accounts)
                                        .Where(o => !o.IsDeleted && o.ReferralProgramId == programId);
            return users;
        }

        #endregion

        #region Private referral methods

        private IEnumerable<ReferralUser> GetUserReferrals(int referralProgramId, int userId)
        {

            var program = DBService.TryGetOne(GetAvailableReferralPrograms(), referralProgramId);
            var user = DB.ReferralUsers.Include(o => o.Referrals)
                                       .FirstOrDefault(o => !o.IsDeleted && o.ReferralProgramId == referralProgramId && o.Id == userId);


            if(program is MLMNetworkReferralProgram mlmProgram)
            {
                return GetMLMNetworkReferralsRecursively(user, 1, mlmProgram.Levels.Count(o => !o.IsDeleted));
            }
            else
            {
                return user.Referrals;
            }
        }
        private IEnumerable<ReferralUser> GetMLMNetworkReferralsRecursively(ReferralUser user, int recursionLevel, int maxLevel)
        {       
            if (maxLevel < recursionLevel)
            {
                return new List<ReferralUser>();
            }


            var referrals = new List<ReferralUser>(user.Referrals);

            foreach (var referral in user.Referrals)
            {
                referrals.AddRange(GetMLMNetworkReferralsRecursively(referral, recursionLevel + 1, maxLevel));
            }

            return referrals;
        }1


        private double GetReferralEarnedSum(int referralProgramId, int userId)
        {
            double sum = 0;
            var user = DB.ReferralUsers.Include(o => o.Accounts).ThenInclude(o => o.Transactions)
                                       .FirstOrDefault(o => !o.IsDeleted && o.ReferralProgramId == referralProgramId && o.Id == userId);

            //TODO: основная валюта

            string mainCurrCode = "KZT";

            foreach(var account in user.Accounts)
            {
                foreach(var transaction in account.Transactions.Where(o => o is AdmissionReferralAccountTransaction).Cast<AdmissionReferralAccountTransaction>())
                {
                    if(mainCurrCode != account.CurrencyCode)
                    {
                        sum += CurrencyRatesDB.GetRate(account.CurrencyCode, mainCurrCode) * (double)transaction.Value;
                    }
                    else
                    {
                        sum += (double)transaction.Value;
                    }
                }
            }
            return sum;
        }
        private double GetReferralSumOnAccounts(int referralProgramId, int userId)
        {
            double sum = 0;
            var user = DB.ReferralUsers.Include(o => o.Accounts).ThenInclude(o => o.Transactions)
                                       .FirstOrDefault(o => !o.IsDeleted && o.ReferralProgramId == referralProgramId && o.Id == userId);

            //TODO: основная валюта

            string mainCurrCode = "KZT";

            foreach (var account in user.Accounts)
            {
                if (mainCurrCode != account.CurrencyCode)
                {
                    sum += CurrencyRatesDB.GetRate(account.CurrencyCode, mainCurrCode) * (double)account.GetBalance();
                }
                else
                {
                    sum += (double)account.GetBalance();
                }
            }
            return sum;
        }
        private double GetReferralSumOnWithdrawal(int referralProgramId, int userId)
        {
            double sum = 0;
            var user = DB.ReferralUsers.Include(o => o.Accounts).ThenInclude(o => o.Transactions)
                                       .FirstOrDefault(o => !o.IsDeleted && o.ReferralProgramId == referralProgramId && o.Id == userId);

            //TODO: основная валюта

            string mainCurrCode = "KZT";

            foreach (var account in user.Accounts)
            {
                if (mainCurrCode != account.CurrencyCode)
                {
                    sum += CurrencyRatesDB.GetRate(account.CurrencyCode, mainCurrCode) * (double)account.GetBlockedSum();
                }
                else
                {
                    sum += (double)account.GetBlockedSum();
                }
            }
            return sum;
        }


        private int GetReferralOrdersCount(int referralProgramId, int userId)
        {
            var user = DB.ReferralUsers.Include(o => o.Accounts).ThenInclude(o => o.Transactions)
                                       .FirstOrDefault(o => !o.IsDeleted && o.ReferralProgramId == referralProgramId && o.Id == userId);

            return user.Accounts.SelectMany(o => o.Transactions)
                                .Where(o => o is AdmissionReferralAccountTransaction)
                                .Cast<AdmissionReferralAccountTransaction>()
                                .DistinctBy(o => o.ExtOrderId)
                                .Count();
        }


        #endregion

    }
}
