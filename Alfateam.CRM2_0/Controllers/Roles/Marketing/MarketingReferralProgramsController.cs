using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing.Referral;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing.Referral;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.EditModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.InvestProject;
using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Programs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.Referral;

namespace Alfateam.CRM2_0.Controllers.Roles.Marketing
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Marketing)]
	public class MarketingReferralProgramsController : AbsController
    {
        public MarketingReferralProgramsController(ControllerParams @params) : base(@params)
        {
        }

		//TODO: только глава маркетингового отдела может делать круд

		#region Реферальные программы

		[HttpGet, Route("GetReferralPrograms")]
		public async Task<RequestResult> GetReferralPrograms(int offset, int count = 20)
		{
			var queryable = DB.BaseReferralPrograms.Where(o => o.MarketingDepartmentId == this.DepartmentId);
			return GetMany<BaseReferralProgram, BaseReferralProgramClientModel>(queryable, offset, count);
		}

		[HttpGet, Route("GetReferralProgram")]
		public async Task<RequestResult> GetReferralProgram(int id)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseReferralProgram(program),
				() => RequestResult<BaseReferralProgram>.AsSuccess(program)
			});
		}




		[HttpPost, Route("CreateReferralProgram")]
		public async Task<RequestResult> CreateReferralProgram(BaseReferralProgramCreateModel model)
		{
			return TryFinishAllRequestes(new[]
			{
				() => TryCreateModel(DB.BaseReferralPrograms, model, (item) =>
				{
					item.MarketingDepartmentId = (int)this.DepartmentId;
					return RequestResult<BaseReferralProgram>.AsSuccess(item);
				})
			});
		}


		[HttpPut, Route("UpdateReferralProgram")]
		public async Task<RequestResult> UpdateReferralProgram(BaseReferralProgramEditModel model)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseReferralProgram(program),
				() => TryUpdateModel(DB.BaseReferralPrograms, program, model)
			});
		}

		[HttpDelete, Route("DeleteReferralProgram")]
		public async Task<RequestResult> DeleteReferralProgram(int id)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseReferralProgram(program),
				() => DeleteModel(DB.BaseReferralPrograms, program)
			});
		}

		#endregion

		#region Уровни реферальной программы (только для MultiLevelReferralProgram)

		[HttpGet, Route("GetMultiLevelReferralProgramLevels")]
		public async Task<RequestResult> GetMultiLevelReferralProgramLevels(int programId)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckForMultiLevelReferralProgram(program),
				() =>
				{
					var clientModels = MultiLevelReferralProgramLevelClientModel.CreateModels((program as MultiLevelReferralProgram).Levels);
					return RequestResult<IEnumerable<MultiLevelReferralProgramLevelClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetMultiLevelReferralProgramLevel")]
		public async Task<RequestResult> GetMultiLevelReferralProgramLevel(int programId, int levelId)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);
			var level = DB.MultiLevelReferralProgramLevels.FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckMultiLevelReferralProgramAndLevel(program, level),
				() =>
				{
					var clientModel = MultiLevelReferralProgramLevelClientModel.Create(level);
					return RequestResult<MultiLevelReferralProgramLevelClientModel>.AsSuccess(clientModel);
				}
			});
		}





		[HttpPost, Route("CreateMultiLevelReferralProgramLevel")]
		public async Task<RequestResult> CreateMultiLevelReferralProgramLevel(int programId, MultiLevelReferralProgramLevelCreateModel model)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckForMultiLevelReferralProgram(program),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var level = model.Create();
					(program as MultiLevelReferralProgram).Levels.Add(level);

					UpdateModel(DB.BaseReferralPrograms, program);
					return RequestResult<MultiLevelReferralProgramLevel>.AsSuccess(level);
				}
			});
		}

		[HttpPut, Route("UpdateMultiLevelReferralProgramLevel")]
		public async Task<RequestResult> UpdateMultiLevelReferralProgramLevel(int programId, int levelId)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);
			var level = DB.MultiLevelReferralProgramLevels.FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckMultiLevelReferralProgramAndLevel(program, level),
				() => TryUpdateModel(DB.MultiLevelReferralProgramLevels, level, model)
			});
		}

		[HttpDelete, Route("DeleteMultiLevelReferralProgramLevel")]
		public async Task<RequestResult> DeleteMultiLevelReferralProgramLevel(int programId, int levelId)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);
			var level = DB.MultiLevelReferralProgramLevels.FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckMultiLevelReferralProgramAndLevel(program, level),
				() => DeleteModel(DB.MultiLevelReferralProgramLevels, level)
			});
		}


		#endregion




		#region Рефералы

		[HttpGet, Route("GetReferrals")]
		public async Task<RequestResult> GetReferrals(int programId, int offset, int count = 20)
		{
			var program = DB.BaseReferralPrograms.Include(o => o.Referrals).ThenInclude(o => o.Owner)
											     .FirstOrDefault(o => o.Id == programId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseReferralProgram(program),
				() =>
				{
					var referals = program.Referrals.Skip(offset).Take(count);

					var clientModels = ReferralClientModel.CreateModels(referals);
					return RequestResult<IEnumerable<ReferralClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetSubReferrals")]
		public async Task<RequestResult> GetSubReferrals(int programId, int ownerReferralId, int offset, int count = 20)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);

			var ownerReferal = DB.Referrals.Include(o => o.Owner)
										   .Include(o => o.Referrals).ThenInclude(o => o.Owner)
										   .FirstOrDefault(o => o.Id == ownerReferralId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckReferralProgramAndReferral(program, ownerReferal),
				() =>
				{
					var referals = ownerReferal.Referrals.Skip(offset).Take(count);

					var clientModels = ReferralClientModel.CreateModels(referals);
					return RequestResult<IEnumerable<ReferralClientModel>>.AsSuccess(clientModels);
				}
			});
		}



		[HttpGet, Route("GetReferral")]
		public async Task<RequestResult> GetReferral(int programId, int referralId)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);

			var referral = DB.Referrals.Include(o => o.Owner)
									   .FirstOrDefault(o => o.Id == ownerReferralId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckReferralProgramAndReferral(program, referral),
				() =>
				{
					var clientModel = ReferralClientModel.Create(referral);
					return RequestResult<ReferralClientModel>.AsSuccess(clientModel);
				}
			});
		}

		#endregion

		#region Счета рефералов и транзакции

		[HttpGet, Route("GetReferralAccounts")]
		public async Task<RequestResult> GetReferralAccounts(int programId, int referralId)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);

			var referral = DB.Referrals.Include(o => o.Accounts).ThenInclude(o => o.Currency)
									   .FirstOrDefault(o => o.Id == referralId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckReferralProgramAndReferral(program, referral),
				() =>
				{
					var clientModels = AccountClientModel.CreateItems(referral.Accounts.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<AccountClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetReferralAccount")]
		public async Task<RequestResult> GetReferralAccount(int programId, int referralId, int accountId)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);

			var referral = DB.Referrals.Include(o => o.Accounts).ThenInclude(o => o.Currency)
									   .FirstOrDefault(o => o.Id == referralId && !o.IsDeleted);

			var account = referral.Accounts.FirstOrDefault(o => o.Id == accountId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckReferralProgramAndReferralAccount(program, referral, account),
				() =>
				{
					var clientModel = AccountClientModel.Create(account);
					return RequestResult<AccountClientModel>.AsSuccess(clientModel);
				}
			});
		}

		
		[HttpGet, Route("GetReferralAccountTransactions")]
		public async Task<RequestResult> GetReferralAccountTransactions(int programId, int referralId, int accountId, int offset, int count)
		{
			var program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == programId && !o.IsDeleted);

			var referral = DB.Referrals.Include(o => o.Accounts).ThenInclude(o => o.Transactions)
									   .FirstOrDefault(o => o.Id == referralId && !o.IsDeleted);

			var account = referral.Accounts.FirstOrDefault(o => o.Id == accountId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckReferralProgramAndReferralAccount(program, referral,account),
				() =>
				{
					var transactions = account.Transactions.Where(o => !o.IsDeleted).Skip(offset).Take(count);
					IncludeItemsToTransactions(transactions);

					var clientModels = TransactionClientModel.CreateItems(transactions);
					return RequestResult<IEnumerable<TransactionClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		#endregion









		#region Private check methods
		protected RequestResult CheckBaseReferralProgram(BaseReferralProgram program)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(program != null,404,"Реферальная программа с данным id не найдена"),
				() => RequestResult.FromBoolean(program.MarketingDepartmentId == this.DepartmentId,403,"Нет доступа к данной реферальной программе"),
			});
		}
		protected RequestResult CheckForMultiLevelReferralProgram(BaseReferralProgram program)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseReferralProgram(program),
				() => RequestResult.FromBoolean(program is MultiLevelReferralProgram,400,"Реферальная программа не является многоуровневой"),
			});
		}
	
		
		
		
		
		protected RequestResult CheckMultiLevelReferralProgramAndLevel(BaseReferralProgram program, MultiLevelReferralProgramLevel level)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckForMultiLevelReferralProgram(program),
				() => RequestResult.FromBoolean(level != null,404,"Уровень с данным id не найден"),
				() => RequestResult.FromBoolean(level.MultiLevelReferralProgramId == program.Id,403,"Уровень не принадлежит данной реферальной программе"),
			});
		}
		protected RequestResult CheckReferralProgramAndReferral(BaseReferralProgram program, Referral referral)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseReferralProgram(program),
				() => RequestResult.FromBoolean(referral != null,404,"Реферал с данным id не найден"),
				() => RequestResult.FromBoolean(referral.BaseReferralProgramId == program.Id,403,"Реферал не принадлежит данной реферальной программе"),
			});
		}
		protected RequestResult CheckReferralProgramAndReferralAccount(BaseReferralProgram program, Referral referral, Account account)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckReferralProgramAndReferral(program,referral),
				() => RequestResult.FromBoolean(account != null,404,"Счет с данным id не найден или не принадлежит текущему рефералу"),
			});
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
			if (transaction is ReferralWithdrawalTransaction withdrawalTransaction)
			{
				return;
			}
			else if (transaction is ReferralAdmissionTransaction admissionTransaction)
			{
				admissionTransaction.Program = DB.BaseReferralPrograms.FirstOrDefault(o => o.Id == admissionTransaction.ProgramId);
				admissionTransaction.Order = DB.Orders.FirstOrDefault(o => o.Id == admissionTransaction.OrderId);
			}
			else
			{
				throw new NotImplementedException("Для рефералов возможно только 2 типа транзакций");
			}
		}

		#endregion

	}
}
