using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Extensions;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Enums;
using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Content.Videos;
using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Security;
using Alfateam.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Alfateam.CRM2_0.Helpers;
using Alfateam.CRM2_0.Abstractions.Services;

namespace Alfateam.CRM2_0.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbsController : ControllerBase
    {

        //TODO: переназначение, вдруг если человек уволился или еще что-то
        internal AbsDBService DBService { get; set; }
        internal CRMDBContext DB { get; set; }
        internal IWebHostEnvironment AppEnvironment { get; set; }
        internal AbsUploadFileService FileService { get; set; }



        internal string UserSessid => Request.Headers["Sessid"];
        internal int? BusinessId => GetValueFromHeader("BusinessId");
        internal int? OrganizationId => GetValueFromHeader("OrganizationId");
        internal int? OfficeId => GetValueFromHeader("OfficeId");



        internal int? DepartmentId => GetValueFromHeader("DepartmentId");


        public AbsController(ControllerParams @params)
        {
            DB = @params.DB;
            AppEnvironment = @params.AppEnvironment;
            FileService = @params.FileService;
            DBService = @params.DBService;
        }


    
        public User? GetAuthorizedUser()
        {
            return SessionUserHelper.GetAuthorizedUser(DB,UserSessid);
		}
        public Session? GetCurrentSession()
        {
            return SessionUserHelper.GetCurrentSession(DB, UserSessid);
		}


        public bool CheckSession(Session session)
        {
            return SessionUserHelper.CheckSession(session);
		}
		public RequestResult CheckSessionAsRequestResult(Session session)
        {
            return SessionUserHelper.CheckSessionAsRequestResult(session);

		}


        public int GetRoleHighestLevel(int userId)
        {
            var user = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
                               .FirstOrDefault(o => o.Id == userId);
            if(user == null) return int.MinValue;
            return user.RoleModel.GetHighestRolePriority();
        }
        public bool IsInRole(User user,UserRole role)
        {
            if (user.RoleModel.GivenRoles.Any(o => o.Role == UserRole.President)) return true;

            return user.RoleModel.GivenRoles.Any(o => o.Role == role);
            //TODO: проработать проверку роли
        }



        protected List<T> GetAvailableModels<T>(User user,IEnumerable<T> allModels) where T: AvailabilityModel
        {
            var availableModels = new List<T>();

            var business = GetEmployeeIncludedBusiness((int)BusinessId);
            var businessUsers = GetAllUsersFromBusiness(business);

            foreach(var model in allModels)
            {
                if (IsModelAvalailable(businessUsers, user, model))
                {
                    availableModels.Add(model);
                }
            }

            return availableModels;
        }
        protected bool IsModelAvalailable(IEnumerable<User> allBusinessUsers, User user, AvailabilityModel model)
        {
            //TODO: проверить логику фильтрации доступных моделей
            if (model.Availability.AvailableForAllBusinesses)
            {
                return true;
            }
            if(!allBusinessUsers.Any(o => o.Id == user.Id))
            {
                return false;
            }


            //if (user.RoleModel.HasRole(UserRole.President)
            // || user.RoleModel.HasRole(UserRole.TopManager))
            //{
            //    return true;
            //}
            

            return IsModelAvailableForOrganization(user,model);
        }
        protected bool IsModelAvailableForOrganization(User user, AvailabilityModel model)
        {
            if (model.Availability.AvailableForAllOrganization)
            {
                return !model.Availability.DisallowedOrganizations.Any(o => o.Id == user.OrganizationId);
            }
            else
            {
                var hasOrganization = model.Availability.AllowedOrganizations.Any(o => o.Id == user.OrganizationId);
                if (hasOrganization)
                {
                    return true;
                }
            }


            if (model.Availability.AvailableForAllOrganizationOffices)
            {
                return !model.Availability.DisallowedOffices.Any(o => o.Id == user.OfficeId);
            }
            else
            {
                var hasOffice = model.Availability.AllowedOffices.Any(o => o.Id == user.OfficeId);
                if (hasOffice)
                {
                    return true;
                }
            }
            return false;
        }



        protected bool HasContentModelModifyAccess(User user,ContentModel model)
        {
            if(user.RoleModel.HasRole(UserRole.President) 
              || user.RoleModel.HasRole(UserRole.TopManager))
            {
                return true;
            }

            var business = DB.Businesses.FirstOrDefault(o => o.ContentId == model.BusinessContentId);
            if(user.BusinessId != business.Id)
            {
                return false;
            }


            if (user.RoleModel.HasRole(UserRole.PartnerOrganigationDirector))
            {
                return true;
            }

            if (user.RoleModel.HasRole(UserRole.BranchDirector)
                || user.RoleModel.HasRole(UserRole.ContentMaker))
            {
                return IsModelAvailableForOrganization(user, model);
            }


            return false;
        }



        #region TryFinishAllRequestes
        public RequestResult TryFinishAllRequestes(Func<RequestResult>[] funcs)
        {
            RequestResult successResult = null;

            foreach (var func in funcs)
            {
                var res = func.Invoke();
                if (!res.Success) return res;

                successResult = res;
            }

            return successResult;
        }
        public RequestResult<T> TryFinishAllRequestes<T>(Func<RequestResult>[] funcs)
        {
            return (RequestResult<T>)TryFinishAllRequestes(funcs);
        }

        public RequestResult TryFinishAllRequestes(RequestResult[] funcs)
        {
            RequestResult successResult = null;

            foreach (var res in funcs)
            {
                if (!res.Success) return res;
                successResult = res;
            }

            return successResult;
        }
        public RequestResult<T> TryFinishAllRequestes<T>(RequestResult[] funcs)
        {
            return (RequestResult<T>)TryFinishAllRequestes(funcs);
        }


        #endregion

        #region Get included methods
        protected Business GetEmployeeIncludedBusiness(int businessId)
        {
            var business = DB.Businesses
              .Include(o => o.Owners)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.Accountance).ThenInclude(o => o.Head)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.Compliance).ThenInclude(o => o.Head)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.Finance).ThenInclude(o => o.Head)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.HR).ThenInclude(o => o.Head)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.Law).ThenInclude(o => o.Head)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.Marketing).ThenInclude(o => o.Head)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.Sales).ThenInclude(o => o.Head)
              .Include(o => o.Organizations).ThenInclude(o => o.Departments).ThenInclude(o => o.SecurityService).ThenInclude(o => o.Head)



              .Include(o => o.Organizations).ThenInclude(o => o.Offices).ThenInclude(o => o.Staff).ThenInclude(o => o.Employees)
              .Include(o => o.Organizations).ThenInclude(o => o.Offices).ThenInclude(o => o.SubOffices).ThenInclude(o => o.Staff).ThenInclude(o => o.Employees)
              .FirstOrDefault(o => o.Id == businessId);

            return business;
        }

        protected Business GetStructureIncludedBusiness(int businessId)
        {
            var business = DB.Businesses
              .Include(o => o.Organizations)
              .Include(o => o.Organizations).ThenInclude(o => o.Offices).ThenInclude(o => o.SubOffices)
              .FirstOrDefault(o => o.Id == businessId);

            return business;
        }


        protected List<Organization> GetIncludedOrganizations()
        {
            var organizations = DB.Organizations.Include(o => o.Offices).ThenInclude(o => o.Staff).ThenInclude(o => o.Employees)
                                                .Include(o => o.Offices).ThenInclude(o => o.SubOffices).ThenInclude(o => o.Staff).ThenInclude(o => o.Employees);
            return organizations.ToList();
        }

        #endregion

        #region Проверки, находится ли пользователь где-либо
        public bool IsInThisBusiness(int businessId, int userId)
        {
            var user = GetUserFromBusiness(businessId, userId);
            return user != null;
        }
        public bool IsInThisOffice(int businessId, int officeId, int userId)
        {
            var business = GetEmployeeIncludedBusiness(businessId);

            var offices = GetAllBusinessOffices(business);
            var users = GetAllUsersFromBusiness(business);
            
            var organizationOfficeStaffId = offices.FirstOrDefault(o => o.Id == officeId).Staff.Id;

            return users.Any(o => o.Id == userId
                                  && o is Worker worker
                                  && worker.OrganizationOfficeStaffId == organizationOfficeStaffId);
        }
        #endregion

        #region Вспомогательные методы для работы с сущностью Business
        private SortedSet<OrganizationOffice> GetAllBusinessOffices(Business business)
        {
            var offices = new SortedSet<OrganizationOffice>();

            foreach(var organization in business.Organizations)
            {
                foreach(var office in organization.Offices)
                {
                    offices.Add(office);
                    offices.AddRange(GetAllBusinessOfficesRecurcively(office));
                }
            }

            return offices;
        }
        private SortedSet<OrganizationOffice> GetAllBusinessOfficesRecurcively(OrganizationOffice office)
        {
            var offices = new SortedSet<OrganizationOffice>();

            offices.AddRange(office.SubOffices);
            foreach (var subOffice in office.SubOffices)
            {
                offices.AddRange(GetAllBusinessOfficesRecurcively(subOffice));
            }

            return offices;
        }
        #endregion

        #region Получение пользователей какого-либо бизнеса

        protected User GetUserFromBusiness(int businessId,int userId)
        {
            var business = GetEmployeeIncludedBusiness(businessId);

            if(business == null)
            {
                return null;
            }
            return GetAllUsersFromBusiness(business).FirstOrDefault(o => o.Id == userId);
        }

        private List<User> GetAllUsersFromBusiness(Business business)
        {
            return business.Users;
        }


        //private SortedSet<User> GetAllUsersFromBusiness(Business business)
        //{
        //    var users = new SortedSet<User>();

        //    users.AddRange(business.Owners);

        //    foreach(var organization in business.Organizations)
        //    {
        //        users.AddRange(GetUsersFromOffices(organization));
        //    }

        //    return users;
        //}
        //private SortedSet<User> GetUsersFromDepartments(DepartmentsGrouping departments)
        //{
        //    var users = new SortedSet<User>();

        //    users.Add(departments.Accountance.Head);
        //    users.Add(departments.Compliance.Head);
        //    users.Add(departments.Finance.Head);
        //    users.Add(departments.HR.Head);
        //    users.Add(departments.Law.Head);
        //    users.Add(departments.Marketing.Head);
        //    users.Add(departments.Sales.Head);
        //    users.Add(departments.SecurityService.Head);

        //    return users;
        //}
        //private SortedSet<User> GetUsersFromOffices(Organization organization)
        //{
        //    var users = new SortedSet<User>();

        //    users.AddRange(GetUsersFromDepartments(organization.Departments));
        //    foreach (var office in organization.Offices)
        //    {
        //        users.AddRange(GetUsersFromOfficesRecurcively(office));
        //    }

        //    return users;
        //}
        //private SortedSet<User> GetUsersFromOfficesRecurcively(OrganizationOffice office)
        //{
        //    var users = new SortedSet<User>();

        //    users.AddRange(office.Staff.Employees);
        //    users.AddRange(GetUsersFromDepartments(office.Departments));
        //    foreach (var subOffice in office.SubOffices)
        //    {
        //        users.AddRange(GetUsersFromOfficesRecurcively(subOffice));
        //    }

        //    return users;
        //}

        #endregion









        #region Other private methods

        private int? GetValueFromHeader(string header)
        {
            string valStr = Request.Headers[header];
            if (string.IsNullOrEmpty(valStr)) return null;

            int val = 0;
            if (int.TryParse(valStr, out val))
            {
                return val;
            }
            return null;
        }

        #endregion
    }
}
