using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.InvestProject;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Accountance
{
    [AccessActionFilter(roles: UserRole.Accountant)]
    [DepartmentFilter]
    public class TransactionsController : AbsController
    {
        public TransactionsController(ControllerParams @params) : base(@params)
        {
        }


        #region Транзакции

        [HttpGet, Route("GetTransactions")]
        public async Task<RequestResult> GetTransactions(int accountId,int offset, int count = 20)
        {
            var account = DB.Accounts.Include(o => o.Transactions).FirstOrDefault(o => o.Id == accountId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAccount(account),
                () =>
                {
                    var transactions = account.Transactions.Where(o => !o.IsDeleted).Skip(offset).Take(count);
                    IncludeItemsToTransactions(transactions);
                    return RequestResult<IEnumerable<Transaction>>.AsSuccess(transactions);
                },
            });
        }

        [HttpGet, Route("GetTransaction")]
        public async Task<RequestResult> GetTransaction(int accountId, int transactionId)
        {
            var account = DB.Accounts.FirstOrDefault(o => o.Id == accountId && !o.IsDeleted);
            var transaction = DB.Transactions.FirstOrDefault(o => o.Id == transactionId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAccountAndTransaction(account,transaction),
                () =>
                {
                    IncludeItemsToTransaction(transaction);
                    return RequestResult<Transaction>.AsSuccess(transaction);
                },
            });
        }




        [HttpPost, Route("CreateTransaction")]
        public async Task<RequestResult> CreateTransaction(int accountId, Transaction transaction)
        {
            var account = DB.Accounts.FirstOrDefault(o => o.Id == accountId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAccount(account),
                () => CheckNewTransaction(transaction),
                () =>
                {
                    account.Transactions.Add(transaction);
                    return UpdateModel(DB.Accounts,account);
                },
            });
        }

        [HttpPut, Route("UpdateTransaction")]
        public async Task<RequestResult> UpdateTransaction(int accountId, TransactionEditModel model)
        {
            var account = DB.Accounts.FirstOrDefault(o => o.Id == accountId && !o.IsDeleted);
            var transaction = DB.Transactions.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAccountAndTransaction(account,transaction),
                () => RequestResult.FromBoolean(model.Value > 0, 400, "Транзакция не может быть меньше или равно нулю"),
                () =>
                {
                    transaction.SaveOldChanges();
                    model.Fill(transaction);

                    return UpdateModel(DB.Transactions,transaction);
                },
            });
        }

        [HttpDelete, Route("DeleteTransaction")]
        public async Task<RequestResult> DeleteTransaction(int accountId, int transactionId)
        {
            var account = DB.Accounts.FirstOrDefault(o => o.Id == accountId && !o.IsDeleted);
            var transaction = DB.Transactions.FirstOrDefault(o => o.Id == transactionId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAccountAndTransaction(account,transaction),
                () => DeleteModel(DB.Transactions,transaction)
            });
        }


        #endregion







        #region Private check methods

        private RequestResult CheckBaseAccount(Account account)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(account != null,404,"Счет с данным id не найден"),
                () => RequestResult.FromBoolean(account.AccountanceDepartmentId == this.DepartmentId,403,"Нет доступа к данному счету"),
            });
        }
        private RequestResult CheckBaseAccountAndTransaction(Account account, Transaction transaction)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAccount(account),
                () => RequestResult.FromBoolean(transaction != null,404,"Счет с данным id не найден"),
                () => RequestResult.FromBoolean(transaction.AccountId == account.Id,403,"Транзакция не принадлежит данному счету"),
            });
        }


        private RequestResult CheckNewTransaction(Transaction transaction)
        {
            if(transaction.Value > 0)
            {
                return RequestResult.AsError(400, "Транзакция не может быть меньше или равно нулю");
            }
            if (!transaction.IsValidToCreate())
            {
                return RequestResult.AsError(400, "Проверьте корректность заполнения полей");
            }

            //TODO: сделать проверку транзакции

            if (transaction is SimpleTransaction simpleTransaction)
            {
                return RequestResult.AsSuccess();
            }
            else if(transaction is WorkerTransaction workerTransaction)
            {
            
            }
            else if (transaction is OrderTransaction orderTransaction)
            {
              
            }
            else if (transaction is MarketingTransaction marketingTransaction)
            {

            }
            else if (transaction is FranchiseTransaction franchiseTransaction)
            {
        
            }
            else if (transaction is DividendInvestProjectTransaction dividendTransaction)
            {

            }
            else if (transaction is AdmissionInvestProjectTransaction admissionTransaction)
            {
              
            }
            else
            {
                throw new NotImplementedException("Check for new Transaction types");
            }

            throw new NotImplementedException();
        }

        #endregion

        #region Private include methods

        private void IncludeItemsToTransactions(IEnumerable<Transaction> transactions)
        {
            foreach (Transaction transaction in transactions)
            {
                IncludeItemsToTransaction(transaction);
            }
        }

        private void IncludeItemsToTransaction(Transaction transaction)
        {
            if (transaction is SimpleTransaction simpleTransaction)
            {
                return;
            }
            else if (transaction is WorkerTransaction workerTransaction)
            {
                workerTransaction.Worker = DB.Users.FirstOrDefault(o => o.Id == workerTransaction.WorkerId) as Worker;
                workerTransaction.Order = DB.Orders.FirstOrDefault(o => o.Id == workerTransaction.OrderId);
                workerTransaction.Milestone = DB.OrderMilestones.FirstOrDefault(o => o.Id == workerTransaction.MilestoneId);
            }
            else if (transaction is OrderTransaction orderTransaction)
            {
                orderTransaction.Order = DB.Orders.FirstOrDefault(o => o.Id == orderTransaction.OrderId);
            }
            else if (transaction is MarketingTransaction marketingTransaction)
            {
                marketingTransaction.Campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == marketingTransaction.CampaignId);
                marketingTransaction.CampaignItem = DB.AdCampaignItems.FirstOrDefault(o => o.Id == marketingTransaction.CampaignItemId);
                marketingTransaction.BudgetItem = DB.AdCampaignBudgetItems.FirstOrDefault(o => o.Id == marketingTransaction.BudgetItemId);
            }
            else if (transaction is FranchiseTransaction franchiseTransaction)
            {
                franchiseTransaction.Franchise = DB.FranchiseSales.FirstOrDefault(o => o.Id == franchiseTransaction.FranchiseId);
            }
            else if (transaction is DividendInvestProjectTransaction dividendTransaction)
            {
                dividendTransaction.Project = DB.InvestProjects.FirstOrDefault(o => o.Id == dividendTransaction.ProjectId);
                dividendTransaction.From = DB.InvestProjectDeposits.FirstOrDefault(o => o.Id == dividendTransaction.FromId);
            }
            else if (transaction is AdmissionInvestProjectTransaction admissionTransaction)
            {
                admissionTransaction.Project = DB.InvestProjects.FirstOrDefault(o => o.Id == admissionTransaction.ProjectId);
                admissionTransaction.To = DB.InvestProjectDeposits.FirstOrDefault(o => o.Id == admissionTransaction.ToId);
            }
            else
            {
                throw new NotImplementedException("Check for new Transaction types");
            }
        }

        #endregion
    }
}
