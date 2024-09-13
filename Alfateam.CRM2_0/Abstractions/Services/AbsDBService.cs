using Alfateam.DB;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Abstractions.Services
{
    public abstract class AbsDBService
    {
        public readonly CRMDBContext DB;
        public AbsDBService(CRMDBContext db)
        {
            DB = db;
        }


        #region Get generic methods

        public RequestResult GetMany<T, ClModel>(IEnumerable<T> dbSet, int offset, int count = 20) where T : AbsModel where ClModel : ClientModel<T>, new()
        {
            var items = dbSet.Where(o => !o.IsDeleted).Skip(offset).Take(count);
            var models = new ClModel().CreateModels(items);
            return RequestResult<IEnumerable<ClientModel<T>>>.AsSuccess(models);
        }
        public RequestResult GetAvailableMany<T, ClModel>(IEnumerable<T> dbSet, int offset, int count = 20) where T : AvailabilityModel where ClModel : ClientModel<T>, new()
        {
            var user = GetAuthorizedUser();

            var items = GetAvailableModels(user, dbSet.Where(o => !o.IsDeleted)).Skip(offset).Take(count);
            var models = new ClModel().CreateModels(items);
            return RequestResult<IEnumerable<ClientModel<T>>>.AsSuccess(models);
        }
        public RequestResult GetAvailableEditableMany<T, ClModel>(IQueryable<T> dbSet, int offset, int count = 20) where T : ContentModel where ClModel : ClientModel<T>, new()
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



        public RequestResult TryGetModel<T>(IQueryable<T> dbSet, int id) where T : AbsModel
        {
            var item = dbSet.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Сущность с данным id не существует"),
                () => RequestResult<T>.AsSuccess(item)
            });
        }
        public RequestResult TryGetContentModel<T>(IQueryable<T> dbSet, int id) where T : ContentModel
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

        public RequestResult TryCreateModel<T>(DbSet<T> dbSet, CreateModel<T> model, Action<T> prepareCallback = null) where T : AbsModel, new()
        {
            var user = GetAuthorizedUser();

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                //TODO: тщательно проверить права доступа
                () =>
                {
                    prepareCallback?.Invoke(newItem);
                    return RequestResult.AsSuccess();
                },
                () => CreateModel(dbSet,model)
            });
        }
        public RequestResult TryCreateModel<T>(DbSet<T> dbSet, CreateModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : AbsModel, new()
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
        public RequestResult TryCreateContentModel<T>(string contentPropName, CreateModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : ContentModel, new()
        {
            var user = GetAuthorizedUser();

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                () => RequestResult.FromBoolean(user.BusinessId == BusinessId,403,"Нет доступа к данному бизнесу"),
                () => CreateContentModel(contentPropName,model,prepareCallback)
            });
        }



        public RequestResult CreateContentModel<T>(string contentPropName, CreateModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : ContentModel, new()
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

        public RequestResult TryUpdateModel<T>(DbSet<T> dbSet, T item, EditModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : AbsModel
        {
            var user = GetAuthorizedUser();

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(model.IsValid(),400, "Неверно заполнены поля"),
                () => prepareCallback?.Invoke(item),
                () => UpdateModel(dbSet,item,model)
            });
        }
        public RequestResult TryUpdateModel<T>(DbSet<T> dbSet, EditModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : AbsModel
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
        public RequestResult TryUpdateContentModel<T>(DbSet<T> dbSet, EditModel<T> model, Func<T, RequestResult> prepareCallback = null) where T : ContentModel
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

        public RequestResult TryDeleteModel<T>(DbSet<T> dbSet, int id) where T : AbsModel
        {
            var item = dbSet.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => DeleteModel(dbSet,item)
            });
        }
        public RequestResult TryDeleteContentModel<T>(DbSet<T> dbSet, int id) where T : ContentModel
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


        public RequestResult CreateModel<T>(DbSet<T> dbSet, EditModel<T> model) where T : AbsModel, new()
        {
            var item = new T();
            model.Fill(item);
            item.Id = 0;
            return CreateModel(dbSet, item);
        }
        public RequestResult CreateModel<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            dbSet.Add(item);
            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }


        public RequestResult UpdateModel<T>(DbSet<T> dbSet, T item, EditModel<T> model) where T : AbsModel
        {
            model.Fill(item);
            return UpdateModel(dbSet, item);
        }
        public RequestResult UpdateModel<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            item.UpdatedAt = DateTime.UtcNow;
            dbSet.Update(item);
            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }
        public RequestResult DeleteModel<T>(DbSet<T> dbSet, T item, bool softDelete = true) where T : AbsModel
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
    }
}
