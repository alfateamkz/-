using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.EditModels.Roles.Sales;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Sales
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Sales)]
	public class SalesCustomersController : AbsController
	{
		public SalesCustomersController(ControllerParams @params) : base(@params)
		{
		}


		#region Клиенты

		[HttpGet, Route("GetCustomers")]
		public async Task<RequestResult> GetCustomers(int offset, int count = 20)
		{
			var customers = DB.Users.Where(o => o is Customer)
									.Cast<Customer>()
									.Include(o => o.Form)
									.Include(o => o.Company)
									.Include(o => o.FoundBy)
									.Where(o => o.SalesDepartmentId == this.DepartmentId && !o.IsDeleted)
									.Skip(offset)
									.Take(count)
									.ToList();

			var clientModels = CustomerClientModel.CreateItems(customers).Cast<CustomerClientModel>();
			return RequestResult<IEnumerable<CustomerClientModel>>.AsSuccess(clientModels);
		}

		[HttpGet, Route("GetCustomer")]
		public async Task<RequestResult> GetCustomer(int id)
		{
			var customer = DB.Users.Where(o => o is Customer)
								   .Cast<Customer>()
								   .Include(o => o.Form)
								   .Include(o => o.Company)
								   .Include(o => o.FoundBy)
								   .FirstOrDefault(o => !o.IsDeleted && o.Id == id);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseCustomer(customer),
				() =>
				{
					var clientModel = CustomerClientModel.Create(customer) as CustomerClientModel;
					return RequestResult<CustomerClientModel>.AsSuccess(clientModel);
				}
			});
		}



		[HttpPost, Route("CreateCustomer")]
		public async Task<RequestResult> CreateCustomer(CustomerCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var legalForm = DB.LegalForms.FirstOrDefault(o => o.Id == model.FormId && !o.IsDeleted);
			var company = DB.Companies.FirstOrDefault(o => o.Id == model.CountryId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(legalForm != null, 404, "Правовая форма с данным id не найдена"),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					if(model.CompanyId != null && company == null)
					{
						return RequestResult.AsError(404, "Компания с данным id не найдена");
					}

					var customer = model.Create() as Customer;
					customer.SalesDepartmentId = (int)this.DepartmentId;
					customer.FoundById = authorizedUser.Id;

					return CreateModel(DB.Users, customer);
				}
			});
		}

		[HttpPut, Route("UpdateCustomer")]
		public async Task<RequestResult> UpdateCustomer(CustomerEditModel model)
		{
			var customer = DB.Users.Where(o => o is Customer)
								   .Cast<Customer>()
								   .FirstOrDefault(o => !o.IsDeleted && o.Id == model.Id);

			var legalForm = DB.LegalForms.FirstOrDefault(o => o.Id == model.FormId && !o.IsDeleted);
			var company = DB.Companies.FirstOrDefault(o => o.Id == model.CountryId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseCustomer(customer),
				() => RequestResult.FromBoolean(legalForm != null, 404, "Правовая форма с данным id не найдена"),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					if(model.CompanyId != null && company == null)
					{
						return RequestResult.AsError(404, "Компания с данным id не найдена");
					}

					return UpdateModel(DB.Users, customer);
				}
			});
		}


		[HttpDelete, Route("DeleteCustomer")]
		public async Task<RequestResult> DeleteCustomer(int id)
		{
			var customer = DB.Users.Where(o => o is Customer)
								   .Cast<Customer>()
								   .FirstOrDefault(o => !o.IsDeleted && o.Id == id);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseCustomer(customer),
				() => DeleteModel(DB.Users, customer)
			});
		}

		#endregion




		#region Private check methods

		private RequestResult CheckBaseCustomer(Customer customer)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(customer != null,404,"Клиент с данным id не найден"),
				() => RequestResult.FromBoolean(customer.SalesDepartmentId == this.DepartmentId,403,"Нет доступа к данному клиенту"),
			});
		}
		#endregion


	}
}
