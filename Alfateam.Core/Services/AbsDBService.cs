using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Core.Services
{
    public class AbsDBService
    {
        public DbContext DB { get; private set; }
        public AbsDBService(DbContext db)
        {
            DB = db;
        }


        public AbsDBService SetDB(DbContext db)
        {
            DB = db;
            return this;
        }


        #region Get



        public IEnumerable<DTO> GetMany<T, DTO>(IEnumerable<T> from,
                                                Func<T, bool> predicate = null) where T : AbsModel, new()
                                                                                where DTO : DTOModelAbs<T>, new()
        {
            return GetManyWithTotalCount<T, DTO>(from, 0, int.MaxValue, predicate).Items;
        }
        public IEnumerable<DTO> GetMany<T,DTO>(IEnumerable<T> from,
                                                      int offset,
                                                      int count,
                                                      Func<T, bool> predicate = null) where T : AbsModel, new()
                                                                                      where DTO : DTOModelAbs<T>, new()
        {
            return GetManyWithTotalCount<T,DTO>(from, offset, count, predicate).Items;
        }
        public ItemsWithTotalCount<DTO> GetManyWithTotalCount<T, DTO>(IEnumerable<T> from, 
                                                                            int offset = 0, 
                                                                            int count = int.MaxValue, 
                                                                            Func<T,bool> predicate = null) where T : AbsModel, new()
                                                                                                           where DTO : DTOModelAbs<T>, new()
        {
            var dtoModel = new DTO();


            var filtered = from.Where(o => !o.IsDeleted);
            if(predicate != null)
            {
                filtered = filtered.Where(predicate);
            }

            var toReturn = new ItemsWithTotalCount<DTO>
            {
                TotalCount = filtered.Count(),
            };

            var toTake = filtered.Skip(offset).Take(count);
            foreach(var item in toTake)
            {
                toReturn.Items.Add((DTO)dtoModel.CreateDTO(item));
            }

            return toReturn;
        }





        public DTOModelAbs<T> TryGetOne<T>(IEnumerable<T> fromModels, int id, DTOModelAbs<T> dTOModel) where T : AbsModel, new()
        {
            var dbModel = TryGetOne(fromModels, id);
            return dTOModel.CreateDTO(dbModel);
        }
        public T TryGetOne<T>(IEnumerable<T> fromModels, int id) where T : AbsModel, new()
        {
            var item = fromModels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item is null)
            {
                throw new Exception404("Запись по данному id не найдена");
            }

            return item;
        }


        #endregion

        #region Create

        public DTOModelAbs<T> TryCreateEntity<T>(DbSet<T> dbSet,
                                                 DTOModelAbs<T> model,
                                                 Action<T> callback = null,
                                                 Action<T> afterSuccessCallback = null) where T : AbsModel, new()
        {
            model.SetDBContext(DB);
            ValidateToCreateEntity(model);

           


            var dbModel = new T();
            model.FillDBModel(dbModel, DBModelFillMode.Create);

            callback?.Invoke(dbModel);

            dbSet.Add(dbModel);
            DB.SaveChanges();
            model.Id = dbModel.Id;

            afterSuccessCallback?.Invoke(dbModel);

            return model;
        }

        public IEnumerable<DTOModelAbs<T>> TryCreateEntities<T>(DbSet<T> dbSet, 
                                                                IEnumerable<DTOModelAbs<T>> models,
                                                                Action<IEnumerable<T>> callback = null) where T : AbsModel, new()
        {
            var dbModels = new List<T>();

            foreach(var model in models)
            {
                model.SetDBContext(DB);
                ValidateToCreateEntity(model);

                var dbModel = new T();
                model.FillDBModel(dbModel, DBModelFillMode.Create);

                dbModels.Add(dbModel);
            }

            callback?.Invoke(dbModels);
            dbSet.AddRange(dbModels);

            DB.SaveChanges();

            for(int i = 0; i<models.Count(); i++)
            {
                models.ElementAt(i).Id = dbModels[i].Id;
            }

            return models;
        }


        public T CreateEntity<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            dbSet.Add(item);
            DB.SaveChanges();

            return item;
        }
        public T CreateEntity<T>(DbSet<T> dbSet, DTOModelAbs<T> model) where T : AbsModel, new()
        {
            var item = new T();

            model.SetDBContext(DB);
            model.FillDBModel(item, DBModelFillMode.Create);

            dbSet.Add(item);
            DB.SaveChanges();

            return item;
        }





        #endregion

        #region Update


        public DTOModelAbs<T> TryUpdateEntity<T>(DbSet<T> dbSet, 
                                                DTOModelAbs<T> model, 
                                                T item, 
                                                Action<T> callback = null,
                                                Action<T> afterSuccessCallback = null) where T : AbsModel, new()
        {
           
            ValidateToUpdateEntity(item, model);


            callback?.Invoke(item);

            UpdateEntity(dbSet, model, item);

            afterSuccessCallback?.Invoke(item);

            return model;
        }


        public T UpdateEntity<T>(DbSet<T> dbSet, DTOModelAbs<T> model, T item) where T : AbsModel, new()
        {
            model.SetDBContext(DB);
            model.FillDBModel(item, DBModelFillMode.Update);

            dbSet.Update(item);
            DB.SaveChanges();

            model.CreateDTO(item);
            return item;
        }
        public void UpdateEntity<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            dbSet.Update(item);
            DB.SaveChanges();
        }
        public void UpdateEntities<T>(DbSet<T> dbSet, IEnumerable<T> items) where T : AbsModel
        {
            dbSet.UpdateRange(items);
            DB.SaveChanges();
        }

        #endregion

        #region Delete
        public void TryDeleteEntity<T>(DbSet<T> dbSet, T item, bool softDelete = true, Action afterSuccessCallback = null) where T : AbsModel
        {
            if (item == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }
            DeleteEntity(dbSet, item, softDelete);

            afterSuccessCallback?.Invoke();
        }
        public void DeleteEntity<T>(DbSet<T> dbSet, T item, bool softDelete = true) where T : AbsModel
        {
            if (softDelete)
            {
                item.IsDeleted = true;
                dbSet.Update(item);
            }
            else
            {
                dbSet.Remove(item);
            }

            DB.SaveChanges();
        }



        public void DeleteEntities<T>(DbSet<T> dbSet,IEnumerable<T> items, bool softDelete = true) where T : AbsModel
        {
            foreach (var item in items)
            {
                if (softDelete)
                {
                    item.IsDeleted = true;
                    dbSet.Update(item);
                }
                else
                {
                    dbSet.Remove(item);
                }
            }

            DB.SaveChanges();
        }

        #endregion



        #region Validate methods
        public virtual void ValidateToCreateEntity<T>(DTOModelAbs<T> item) where T : AbsModel, new()
        {
            if (item.Id != 0)
            {
                throw new Exception400("Id должен быть нулевым");
            }

            item.SetDBContext(DB);
            if (!item.IsValid())
            {
                throw new Exception400("Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }

        }
        public virtual void ValidateToUpdateEntity<T>(T item, DTOModelAbs<T> model) where T : AbsModel, new()
        {
            if (item == null)
            {
                throw new Exception404("Запись по данному id не найдена");
            }

            if (item.Id != model.Id)
            {
                throw new Exception400("Нельзя изменить id сущности");
            }

            model.SetDBContext(DB);
            if (!model.IsValid())
            {
                throw new Exception400("Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
        }

        #endregion

    }

}
