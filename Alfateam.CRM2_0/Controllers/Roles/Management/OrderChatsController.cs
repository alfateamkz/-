using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Management
{

    public class OrderChatsController : AbsController
    {
        public OrderChatsController(ControllerParams @params) : base(@params)
        {
        }


		[HttpGet, Route("GetOrderChats")]
		public async Task<RequestResult> GetOrderChats(int orderId)
        {
            var authorizedUser = GetAuthorizedUser();

			var order = DB.Orders.Include(o => o.SaleInfo)
								 .Include(o => o.ProjectManager)
								 .Include(o => o.TechLead)
								 .Include(o => o.TeamLead)
								 .Include(o => o.Employees)
								 .Include(o => o.Chats)
								 .FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(IsOrderParticipant(order,authorizedUser),403,"Нет доступа к данному заказу"),
                () =>
                {

                }
			});
		}




		private bool IsOrderParticipant(Order order,User user)
        {
            if(user.RoleModel.IsPresident || user.RoleModel.IsTopManager)
            {
                return true;
            }
			else if (user.RoleModel.IsPartnerOrganigationDirector || user.RoleModel.IsPartnerOrganigationTopManager)
			{
                //TODO: проверка принадлежности пользователя и заказа текущему бизнесу
				return true;
			}
            else if (user.RoleModel.HasRole(UserRole.BranchDirector))
            {
				//TODO: проверка принадлежности к текущему бизнесу и филиалу
				return true;
			}
            if(order.SaleInfo.FoundById == user.Id)
            {
                //Продажник может видеть заказ
                return true;
            }

			return order.GetAllParticipants().Any(o => o.Id == user.Id);
        }

    }
}
