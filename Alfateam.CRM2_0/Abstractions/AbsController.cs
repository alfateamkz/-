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

namespace Alfateam.CRM2_0.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbsController : ControllerBase
    {
        internal CRMDBContext DB { get; set; }
        internal IWebHostEnvironment AppEnvironment { get; set; }



        internal string UserSessid => Request.Headers["Sessid"];
        internal int? BusinessId => GetValueFromHeader("BusinessId");
        internal int? OrganizationId => GetValueFromHeader("OrganizationId");
        internal int? OfficeId => GetValueFromHeader("OfficeId");



        internal int? DepartmentId => GetValueFromHeader("DepartmentId");


        public AbsController(ControllerParams @params)
        {
            DB = @params.DB;
            AppEnvironment = @params.AppEnvironment;
        }


    
        public User? GetAuthorizedUser()
        {
            if (string.IsNullOrWhiteSpace(UserSessid))
            {
                return null;
            }

            var session = GetCurrentSession();
            if (!CheckSession(session))
            {
                return null;
            }

            return session.User;
        }
        public Session? GetCurrentSession()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
                                .FirstOrDefault(o => o.SessID == UserSessid);
            return session;
        }


        public bool CheckSession(Session session)
        {
            if(session == null) return false;
            if(session.IsExpired) return false;
            if(session.IsDeactivated )return false;

            return true;
        }
        public RequestResult CheckSessionAsRequestResult(Session session)
        {
            if (session == null) return RequestResult.AsError(404,"Сессия с данным ключом не найдена");
            if (session.IsExpired) return RequestResult.AsError(401, "Сессия уже просрочена");
            if (session.IsDeactivated) return RequestResult.AsError(401, "Сессия была деактивирована");

            return RequestResult.AsSuccess();
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



        #region Get generic methods

        protected RequestResult GetMany<T, ClModel>(IEnumerable<T> dbSet, int offset, int count = 20) where T : AbsModel where ClModel : ClientModel<T>, new()
        {
            var items = dbSet.Where(o => !o.IsDeleted).Skip(offset).Take(count);
            var models = new ClModel().CreateModels(items);
            return RequestResult<IEnumerable<ClientModel<T>>>.AsSuccess(models);
        }
        protected RequestResult GetAvailableMany<T, ClModel>(IEnumerable<T> dbSet, int offset, int count = 20) where T : AvailabilityModel where ClModel : ClientModel<T>, new()
        {
            var user = GetAuthorizedUser();

            var items = GetAvailableModels(user, dbSet.Where(o => !o.IsDeleted)).Skip(offset).Take(count);
            var models = new ClModel().CreateModels(items);
            return RequestResult<IEnumerable<ClientModel<T>>>.AsSuccess(models);
        }
        protected RequestResult GetAvailableEditableMany<T, ClModel>(IQueryable<T> dbSet, int offset, int count = 20) where T : ContentModel where ClModel : ClientModel<T>, new()
        {
            var user = GetAuthorizedUser();
            var availableItems = new List<T>();

            var items = GetAvailableModels(user, dbSet.Where(o => !o.IsDeleted));      
            foreach (var item in items)
            {
                if (HasContentModelModifyAccess(user, item))
                {
                    availableItems.Add(item);
                }
            }


            var models = new ClModel().CreateModels(availableItems).Skip(offset).Take(count);
            return RequestResult<IEnumerable<ClientModel<T>>>.AsSuccess(models);
        }



        protected RequestResult TryGetModel<T>(IQueryable<T> dbSet, int id) where T : AbsModel
        {
            var item = dbSet.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Сущность с данным id не существует"),
                () => RequestResult<T>.AsSuccess(item)
            });
        }
        protected RequestResult TryGetContentModel<T>(IQueryable<T> dbSet, int id) where T : ContentModel
        {
            var item = dbSet.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            //TODO: TryGetContentModel, мб некорректно
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Сущность с данным id не существует"),
                () => RequestResult<T>.AsSuccess(item)
            });
        }

        #endregion

        #region Create generic methods

        protected RequestResult TryCreateModel<T>(DbSet<T> dbSet, CreateModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : AbsModel, new()
        {
            var user = GetAuthorizedUser();

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                //TODO: тщательно проверить права доступа
                () => prepareCallback?.Invoke(newItem),
                () => CreateModel(dbSet,model)
            });
        }
        protected RequestResult TryCreateContentModel<T>(string contentPropName, CreateModel<T> model,Func<T, RequestResult> prepareCallback = null) where T : ContentModel, new()
        {
            var user = GetAuthorizedUser();

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                () => RequestResult.FromBoolean(user.BusinessId == BusinessId,403,"Нет доступа к данному бизнесу"),
                () => CreateContentModel(contentPropName,model,prepareCallback)
            });
        }



        private RequestResult CreateContentModel<T>(string contentPropName, CreateModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : ContentModel, new()
        {
            var business = DB.Businesses.Include(o => o.Content).FirstOrDefault(o => o.Id == BusinessId);

            var newItem = new T();
            model.Fill(newItem);
            newItem.Id = 0;

            var contentProp = business.Content.GetType().GetProperty(contentPropName);
            var propList = contentProp.GetValue(business.Content) as IList<T>;
            propList.Add(newItem);

            prepareCallback?.Invoke(newItem);

            DB.Businesses.Update(business);
            DB.SaveChanges();
            return RequestResult<T>.AsSuccess(newItem);
        }

        #endregion

        #region Update generic methods

        protected RequestResult TryUpdateModel<T>(DbSet<T> dbSet, EditModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : AbsModel
        {
            var user = GetAuthorizedUser();
            var item = dbSet.FirstOrDefault(o => o.Id == model.Id);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                () => prepareCallback?.Invoke(item),
                () => UpdateModel(dbSet,item,model)
            });
        }
        protected RequestResult TryUpdateContentModel<T>(DbSet<T> dbSet, EditModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : ContentModel
        {
            var user = GetAuthorizedUser();
            var item = dbSet.FirstOrDefault(o => o.Id == model.Id);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(HasContentModelModifyAccess(user,item), 403, "Нет прав на редактирование сущности"),
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                () => prepareCallback?.Invoke(item),
                () => UpdateModel(dbSet,item,model)
            });
        }

        #endregion


        #region Delete generic methods

        protected RequestResult TryDeleteModel<T>(DbSet<T> dbSet, int id) where T : AbsModel
        {
            var item = dbSet.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => DeleteModel(dbSet,item)
            });
        }
        protected RequestResult TryDeleteContentModel<T>(DbSet<T> dbSet,int id) where T : ContentModel
        {
            var user = GetAuthorizedUser();
            var item = dbSet.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(HasContentModelModifyAccess(user,item), 403, "Нет прав на удаление сущности"),
                () => DeleteModel(dbSet,item)
            });
        }


        #endregion


        #region DB methods


        protected RequestResult CreateModel<T>(DbSet<T> dbSet, EditModel<T> model) where T : AbsModel, new()
        {
            var item = new T();
            model.Fill(item);
            item.Id = 0;
            return CreateModel(dbSet, item);
        }
        protected RequestResult CreateModel<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            dbSet.Add(item);
            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }


        protected RequestResult UpdateModel<T>(DbSet<T> dbSet, T item,EditModel<T> model) where T : AbsModel
        {
            model.Fill(item);
            return UpdateModel(dbSet, item);
        }
        protected RequestResult UpdateModel<T>(DbSet<T> dbSet,T item) where T : AbsModel
        {
            item.UpdatedAt = DateTime.UtcNow;
            dbSet.Update(item);
            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }
        protected RequestResult DeleteModel<T>(DbSet<T> dbSet, T item, bool softDelete = true) where T : AbsModel
        {
            if (softDelete)
            {
                item.IsDeleted = true;
                item.DeletedAt = DateTime.UtcNow;
                dbSet.Update(item);
            }
            else
            {
                dbSet.Remove(item);
            }

            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }

        #endregion

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





        #region File check
        protected RequestResult CheckImageFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsImageFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        protected RequestResult CheckDocumentFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsDocumentFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        protected RequestResult CheckAudioFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsAudioFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        protected RequestResult CheckVideoFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsVideoFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        private RequestResult CheckFileBase(IFormFile file)
        {
            if (file == null)
            {
                return RequestResult.AsError(400, "Необходимо загрузить файл");
            }
            else if (file.Length == 0)
            {
                return RequestResult.AsError(400, "Пустой файл");
            }
            return RequestResult.AsSuccess();
        }



        protected bool IsImageFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp";
        }
        protected bool IsDocumentFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".pdf" || ext == ".docx" || ext == ".xls" || ext == ".xlsx" || ext == ".ort" || ext == ".rtf";
        }
        protected bool IsAudioFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".mp3" || ext == ".wav" || ext == ".ogg";
        }
        protected bool IsVideoFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".mp4" || ext == ".avi" || ext == ".mkv";
        }
        #endregion

        #region UploadFile


        protected async Task<RequestResult<string>> TryUploadFile(string formFileName, FileType fileType)
        {
            var res = new RequestResult<string>();

            //Загрузка главной картинки
            var file = Request.Form.Files.FirstOrDefault(o => o.Name == formFileName);

            RequestResult fileCheckResult = null;
            switch (fileType)
            {
                case FileType.Image:
                    fileCheckResult = this.CheckImageFile(file);
                    break;
                case FileType.Document:
                    fileCheckResult = this.CheckDocumentFile(file);
                    break;
                case FileType.Video:
                    fileCheckResult = this.CheckVideoFile(file);
                    break;
                case FileType.Audio:
                    fileCheckResult = this.CheckAudioFile(file);
                    break;
            }



            if (!fileCheckResult.Success)
            {
                res.FillFromRequestResult(fileCheckResult);
                res.Error += $"\r\nПроблема с файлом {formFileName}";
                return res;
            }

            string filepath = await this.UploadFile(file);
            return res.SetSuccess(filepath);
        }
        protected async Task<RequestResult<string>> TryUploadFile(IFormFile file, FileType fileType)
        {
            var res = new RequestResult<string>();

            RequestResult fileCheckResult = null;
            switch (fileType)
            {
                case FileType.Image:
                    fileCheckResult = this.CheckImageFile(file);
                    break;
                case FileType.Document:
                    fileCheckResult = this.CheckDocumentFile(file);
                    break;
                case FileType.Video:
                    fileCheckResult = this.CheckVideoFile(file);
                    break;
                case FileType.Audio:
                    fileCheckResult = this.CheckAudioFile(file);
                    break;
            }



            if (!fileCheckResult.Success)
            {
                res.FillFromRequestResult(fileCheckResult);
                res.Error += $"\r\nПроблема с файлом {file.Name}";
                return res;
            }

            string filepath = await this.UploadFile(file);
            return res.SetSuccess(filepath);
        }

        protected async Task<string> UploadFile(int index = 0)
        {
            var attachment = Request.Form.Files.Skip(index).FirstOrDefault();
            var filePath = "/uploads/" + Guid.NewGuid().ToString();

            if (attachment != null && attachment.Length > 0)
            {
                string path = filePath + attachment.FileName;
                using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await attachment.CopyToAsync(fileStream);
                }
                return path;
            }
            return "";
        }
        protected async Task<string> UploadFile(IFormFile file)
        {
            var filePath = "/uploads/" + Guid.NewGuid().ToString();

            if (file != null && file.Length > 0)
            {
                string path = filePath + file.FileName;
                using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return path;
            }
            return "";
        }
        protected async Task<string> UploadFile(string formFileName)
        {
            var attachment = Request.Form.Files.FirstOrDefault(o => o.Name == formFileName);
            var filePath = "/uploads/" + Guid.NewGuid().ToString();

            if (attachment != null && attachment.Length > 0)
            {
                string path = filePath + attachment.FileName;
                using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await attachment.CopyToAsync(fileStream);
                }
                return path;
            }
            return "";
        }
        #endregion

        #region Delete file
        protected void DeleteFiles(List<string> paths)
        {
            foreach (var path in paths)
            {
                DeleteFile(path);
            }
        }
        protected void DeleteFile(string path)
        {
            if (System.IO.File.Exists(AppEnvironment.WebRootPath + path))
            {
                System.IO.File.Delete(AppEnvironment.WebRootPath + path);
            }
        }


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
