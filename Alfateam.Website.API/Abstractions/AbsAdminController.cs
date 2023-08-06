using Alfateam.DB;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Abstractions
{
    public abstract class AbsAdminController : AbsController
    {
        protected AbsAdminController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }


        [NonAction]
        protected Session GetSessionWithRoleInclude()
        {
            //TODO: инклюды по разделам ролей
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);
            return session;
        }



        protected IEnumerable<AvailabilityModel> GetAvailableModels(User user,IEnumerable<AvailabilityModel> allModels)
        {
            var allowedModels = new List<AvailabilityModel>();

            //TODO: внимательно изучить и доработаь

            if (user.RoleModel.IsAllCountriesAccess)
            {
                //кроме запрещенных стран6
                return allModels;
            }
            else
            {
                foreach (var model in allModels)
                {
                    if (model.Availability.AvailableInAllCountries)
                    {
                        allowedModels.Add(model);
                    }
                    else
                    {
                        foreach(var country in user.RoleModel.AvailableCountries)
                        {
                            bool isAvailable = model.Availability.IsAvailable(country.Id);
                            if (isAvailable)
                            {
                                allowedModels.Add(model);
                                break;
                            }
                        }
                    }
                }
            }

            return allowedModels;
        }


        #region Базовая проверка прав

        [NonAction]
        protected RequestResult CheckBaseRights(Session session, AvailabilityModel model)
        {
            var res = new RequestResult();

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
                return res;
            }
            if (!this.CheckBasePermissions(session.User, model))
            {
                res.Code = 403;
                res.Error = "У данного пользователя нет доступа к записи";
            }
            else
            {
                res.Success = true;
            }

            return res;
        }


        [NonAction]
        private bool CheckBasePermissions(User user, AvailabilityModel model/*, AdminActionType type*/)
        {
            bool success = IsInAdminRole(user);
            if (!success) return success;

            if(user.RoleModel.Role == UserRole.Owner) return true;


            //TODO: доработать пермишены

            if (!user.RoleModel.IsAllCountriesAccess)
            {
                bool isAvailable = model.Availability.IsAvailable(user.RoleModel.AvailableCountries);

                success &= isAvailable;
            }
            else
            {
                bool isAvailable = true;


                bool hasForbiddenCountry = false;
                if (model.Availability.AvailableInAllCountries)
                {
                    hasForbiddenCountry = user.RoleModel.ForbiddenCountries.Any();
                }
                else
                {
                    foreach (var country in user.RoleModel.ForbiddenCountries)
                    {
                        hasForbiddenCountry = model.Availability.AllowedCountries.Any(o => o.Id == country.Id);
                        if (hasForbiddenCountry) break;
                    }
                }

 

                if (hasForbiddenCountry)
                {
                    if (model.Availability.AvailableInAllCountries)
                    {

                    }
                }
                else
                {
                    isAvailable = true;
                }
               
               
            }
    

            return success;
        }
        [NonAction]
        private bool IsInAdminRole(User user)
        {
            return user.RoleModel.Role == UserRole.Admin || user.RoleModel.Role == UserRole.Owner;
        }

        #endregion
    }
}
