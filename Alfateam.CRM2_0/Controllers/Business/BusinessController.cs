using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Enums;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Content.Videos;
using Alfateam.CRM2_0.Models.CreateModels.General;
using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessModel = Alfateam.CRM2_0.Models.General.Business;

namespace Alfateam.CRM2_0.Controllers.Business
{
    //TODO: по проекту чекнуть роль PartnerOrganigationTopManager
    //TODO: проверка юзеров по BusinessID !!!
    public class BusinessController : AbsController
    {
        public BusinessController(ControllerParams @params) : base(@params)
        {
        }

        #region CRUD

        [HttpGet, Route("GetBusinesses")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager })]
        public async Task<RequestResult> GetBusinesses(int offset, int count = 20)
        {
            return GetMany<BusinessModel, BusinessClientModel>(DB.Businesses, offset, count);
        }


        [HttpGet, Route("GetBusiness")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> GetBusiness(int id)
        {
            var user = GetAuthorizedUser();
            if(user.RoleModel.IsPresident || user.RoleModel.IsTopManager)
            {
                return TryGetModel(DB.Businesses, id);
            }
            else if ((user.RoleModel.IsPartnerOrganigationDirector || user.RoleModel.IsPartnerOrganigationTopManager)
                     && user.BusinessId == id)
            {
                return TryGetModel(DB.Businesses, id);
            }
            return RequestResult.AsError(403, "Нет доступа к данному бизнесу");
        }




        [HttpPost, Route("CreateBusiness")]
        [AccessActionFilter(roles: new[] { UserRole.President })]
        public async Task<RequestResult> CreateBusiness(BusinessType type, BusinessCreateModel model,User owner)
        {
            var business = model.Create();

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                () => RequestResult.FromBoolean(owner.Id == 0, 403, "Нужен именно новый пользователь"),
                () =>
                {
                    if(type == BusinessType.Our)
                    {
                        owner.RoleModel.AddRole(UserRole.President);
                    }
                    else if(type == BusinessType.Franchise)
                    {
                        owner.RoleModel.AddRole(UserRole.PartnerOrganigationDirector);
                    }
    
                    business.Users.Add(owner);
                    return CreateModel(DB.Businesses,business);
                }
            });
        }




        [HttpPut, Route("UpdateBusiness")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.PartnerOrganigationDirector })]
        public async Task<RequestResult> UpdateBusiness(BusinessEditModel model)
        {
            var user = GetAuthorizedUser();
            if (user.RoleModel.IsPresident)
            {
                return TryUpdateModel(DB.Businesses, model, PrepareBusinessBeforeUpdate);
            }
            else if (user.RoleModel.IsPartnerOrganigationDirector && user.BusinessId == model.Id)
            {
                return TryUpdateModel(DB.Businesses, model, PrepareBusinessBeforeUpdate);
            }
            return RequestResult.AsError(403, "Нет доступа к данному бизнесу");
        }




        [HttpDelete, Route("DeleteBusiness")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> DeleteBusiness(int id)
        {
            return TryDeleteModel(DB.Businesses, id);
        }
        #endregion

        #region Управление владельцами\топ-менеджерами

        [HttpGet, Route("GetOwners")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> GetOwners(int offset, int count = 20)
        {
            var user = GetAuthorizedUser();

            bool hasAccess = false;
            hasAccess |= user.RoleModel.IsPresident || user.RoleModel.IsTopManager;
            hasAccess |= (user.RoleModel.IsPartnerOrganigationDirector || user.RoleModel.IsPartnerOrganigationTopManager)
                     && user.BusinessId == BusinessId;

            if (hasAccess)
            {
                var users = GetUsersWithRole(BusinessId,
                                             new List<UserRole> {UserRole.President,UserRole.PartnerOrganigationDirector},
                                             offset,
                                             count);
                return RequestResult<IEnumerable<User>>.AsSuccess(users);
            }
            return RequestResult.AsError(403, "Нет доступа к данному бизнесу");
        }

        [HttpGet, Route("GetTopManagers")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> GetTopManagers(int offset, int count = 20)
        {
            var user = GetAuthorizedUser();

            bool hasAccess = false;
            hasAccess |= user.RoleModel.IsPresident || user.RoleModel.IsTopManager;
            hasAccess |= (user.RoleModel.IsPartnerOrganigationDirector || user.RoleModel.IsPartnerOrganigationTopManager)
                     && user.BusinessId == BusinessId;

            if (hasAccess)
            {
                var users = GetUsersWithRole(BusinessId,
                                             new List<UserRole> { UserRole.TopManager, UserRole.PartnerOrganigationTopManager },
                                             offset,
                                             count);
                return RequestResult<IEnumerable<User>>.AsSuccess(users);
            }
            return RequestResult.AsError(403, "Нет доступа к данному бизнесу");
        }


        [HttpPost, Route("AddUser")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> AddUser(User user)
        {
            var authorizedUser = GetAuthorizedUser();
            var business = DB.Businesses.FirstOrDefault(o => o.Id == BusinessId);


           return TryFinishAllRequestes(new[]
           {
                () => RequestResult.FromBoolean(user.IsValidToCreate(), 400, "Проверьте корректность заполнения значений"),
                () => RequestResult.FromBoolean(user.RoleModel.GivenRoles.Any(), 400, "Необходимо выбрать роли пользователю"),
                () => RequestResult.FromBoolean(user.RoleModel.IsStaff && user.OrganizationId != null, 400, "Необходимо указать организацию"),
                () => RequestResult.FromBoolean(authorizedUser.RoleModel.GetHighestRolePriority() > user.RoleModel.GetHighestRolePriority(),
                                                                                403, "Создаваемый пользователь выше по уровню прав, чем Вы"),
                () =>
                {
                    business.Users.Add(user);
                    return UpdateModel(DB.Businesses,business);
                }
            });
        }


        [HttpPut, Route("EditUserMain")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> EditUserMain(UserEditModel model)
        {
            var authorizedUser = GetAuthorizedUser();
            var business = DB.Businesses.FirstOrDefault(o => o.Id == BusinessId);


            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения значений"),
                () => RequestResult.FromBoolean(authorizedUser.RoleModel.GetHighestRolePriority() > GetRoleHighestLevel(model.Id),
                                                                                403, "Создаваемый пользователь выше по уровню прав, чем Вы"),
                () => TryUpdateModel(DB.Users,model)
            });
        }


        [HttpPut, Route("SetUserRoles")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> SetUserRoles(int id,[FromBody] List<UserRole> roles)
        {
            var authorizedUser = GetAuthorizedUser();
            var foundUser = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
                                    .FirstOrDefault(o => o.Id == id);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(foundUser != null,404, "Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(foundUser.Id != authorizedUser.Id, 403, "Невозможно назначить роли самому себе"),
                () => RequestResult.FromBoolean(roles.Count > 0, 400, "Необходимо выбрать хотя бы одну роль"),
                () => RequestResult.FromBoolean(authorizedUser.RoleModel.GetHighestRolePriority() > foundUser.RoleModel.GetHighestRolePriority(),
                                                                                   403, "Редактируемый пользователь выше по уровню прав, чем Вы"),
                () =>
                {
                    foundUser.RoleModel.GivenRoles.Clear();
                    foreach(var role in roles)
                    {
                         foundUser.RoleModel.AddRole(role);
                    }

                    return UpdateModel(DB.Users,foundUser);
                },
            }); ;

        }



        [HttpDelete, Route("RemoveUser")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.PartnerOrganigationDirector})]
        public async Task<RequestResult> RemoveUser(int userId)
        {
            var user = GetAuthorizedUser();
            var foundUser = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
                                    .FirstOrDefault(o => o.Id == userId);


            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(user.Id != userId,400, "Невозможно удалить самого себя"),
                () => RequestResult.FromBoolean(foundUser != null,404, "Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(user.RoleModel.GetHighestRolePriority() > foundUser.RoleModel.GetHighestRolePriority(),
                                                                                403, "Удаляемый пользователь выше по уровню прав, чем Вы"),
                () => DeleteModel(DB.Users,foundUser),
            });
        }

        #endregion






        #region Private prepare methods

        private RequestResult PrepareBusinessBeforeCreate(BusinessModel business)
        {
            if (Request.Form.Files.Any(o => o.Name == "logo"))
            {
                return UploadBusinessLogo(business).Result;
            }
            return RequestResult.AsSuccess();
        }
        private RequestResult PrepareBusinessBeforeUpdate(BusinessModel business)
        {
            if(Request.Form.Files.Any(o => o.Name == "logo"))
            {
                return UploadBusinessLogo(business).Result;
            }
            return RequestResult.AsSuccess();
        }

        private async Task<RequestResult> UploadBusinessLogo(BusinessModel business)
        {
            var logoUploadResult = TryUploadFile("logo", FileType.Image).Result;
            if (!logoUploadResult.Success) return logoUploadResult;

            business.LogoPath = logoUploadResult.Value;

            return RequestResult.AsSuccess();
        }


        #endregion

        #region Other private methods

        private List<User> GetUsersWithRole(int? businessId, IEnumerable<UserRole> roles, int offset, int count = 20)
        {
            var users = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
                                .Where(o => o.BusinessId == businessId && o.RoleModel.HasRole(roles))
                                .Skip(offset)
                                .Take(count)
                                .ToList();
            return users;
        }


        #endregion
    }
}
