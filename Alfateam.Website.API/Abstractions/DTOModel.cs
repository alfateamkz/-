﻿using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop;
using System.Collections;
using System.Reflection;

namespace Alfateam.Website.API.Abstractions
{


    public abstract class DTOModel
    {

        public int Id { get; set; }


        #region Get values
        protected static List<Cost> GetLocalCosts(PricingMatrix matrix, int? countryId)
        {
            PricingMatrixItem found = null;

            if (countryId != null)
            {
                found = matrix.Costs.FirstOrDefault(o => o.CountryId == countryId);
                if (found != null) return found.Costs;
            }

            found = matrix.Costs.FirstOrDefault(o => o.CountryId == null);
            if (found != null) return found.Costs;

            found = matrix.Costs.FirstOrDefault(o => o.Costs.Any(o => o.Currency.Code == "USD"));
            if (found != null) return found.Costs;

            found = matrix.Costs.FirstOrDefault(o => o.Costs.Any(o => o.Currency.Code == "EUR"));
            if (found != null) return found.Costs;

            found = matrix.Costs.FirstOrDefault();
            return found.Costs;

        }


        public static object GetActualValueGeneric (object oldValue, object newValue)
        {
            if(oldValue is string oldValStr && newValue is string newValStr)
            {
                return GetActualValue(oldValStr, newValStr);
            }
            else if (oldValue is Content oldValContent && newValue is Content newValContent)
            {
                return GetActualValue(oldValContent, newValContent);
            }
            else
            {
                return GetActualValue(oldValue, newValue);
            }
        }
        protected static string GetActualValue(string oldStr, string newStr)
        {
            if (string.IsNullOrEmpty(newStr))
                return oldStr;
            return newStr;
        }
        protected static Content GetActualValue(Content oldValue, Content newValue)
        {
            if (newValue == null || newValue.Items.Count == 0)
            {
                return oldValue;
            }
            return newValue;
        }
        protected static object GetActualValue(object oldValue, object newValue)
        {
            if (newValue == null)
            {
                return oldValue;
            }
            return newValue;
        }
        
        #endregion

        public virtual bool IsValid()
        {
            bool isValid = true;

            var props = this.GetType().GetProperties();
            foreach (var prop in props)
            {
                var type = prop.GetType();

                if (type == typeof(string))
                {
                    isValid &= string.IsNullOrEmpty(prop.GetValue(this) as string);
                }
                else if (type == typeof(int) && prop.Name.Contains("Id"))
                {
                    int val = (int)prop.GetValue(this);
                    isValid &= val > 0;
                }
                else if (Nullable.GetUnderlyingType(typeof(int)) == typeof(int) && prop.Name.Contains("Id"))
                {
                    int? val = (int)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        isValid &= val.Value > 0;
                    }
                }

            }


            return isValid;
        }

       


        public static bool IsModelTypeOf(Type modelType, Type requiredType)
        {
            if (modelType == requiredType) return true;

            var baseModel = modelType.BaseType;

            if (baseModel == requiredType)
            {
                return true;
            }
            else if (baseModel != typeof(Object))
            {
                return IsModelTypeOf(baseModel, requiredType);
            }
            return false;
        }


    }

    public class DTOModel<T> : DTOModel where T : AbsModel, new()
    {
        #region Клиентские модели (для просмотра)

        public DTOModel<T> CreateDTO(T item)
        {
            var clone = this.Clone();

            var thisProps = clone.GetType().GetProperties();
            var props = item.GetType().GetProperties();
            foreach (var prop in props)
            {
                var val = prop.GetValue(item);

                var thisProp = thisProps.FirstOrDefault(o => o.Name == prop.Name);
                if (thisProp != null && thisProp.CanWrite)
                {
                    if (thisProp.PropertyType.GetType() == typeof(DTOModel<T>))
                    {
                        //TODO: этот кусок кода тщательно протестировать
                        if (val is IEnumerable<T> enumerable)
                        {
                            val = this.CreateDTOs(enumerable);
                        }
                        else if (val is T singleModel)
                        {
                            val = this.CreateDTO(singleModel);
                        }
                    }
                    else if(DTOModel.IsModelTypeOf(thisProp.PropertyType, typeof(DTOModel)))
                    {
                        var thisPropValue = thisProp.GetValue(clone);
                        if(thisPropValue == null && val != null)
                        {
                            thisPropValue = Activator.CreateInstance(thisProp.PropertyType);

                            thisProp.SetValue(clone, thisPropValue);
                            thisPropValue = thisProp.GetValue(clone);
                        }

                        if(val != null)
                        {
                            thisPropValue = thisPropValue.GetType().GetMethod("CreateDTO").Invoke(thisPropValue, new[] { val});
                            thisProp.SetValue(clone, thisPropValue);
                        }
                    }
                    else if (prop.PropertyType == thisProp.PropertyType)
                    {
                        thisProp.SetValue(clone, prop.GetValue(item));
                    }
                }
            }


            return clone;
        }
        public DTOModel<T> CreateDTOWithLocalization(T item, int? languageId)
        {
            var dto = CreateDTO(item);

            var localizationsListProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "Localizations");
            var mainLangIdProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
            if (localizationsListProp != null && mainLangIdProp != null)
            {
                var listBaseValue = localizationsListProp.GetValue(item) as IList;
                var listValue = listBaseValue.Cast<LocalizableModel>();

                var mainLangId = (int)mainLangIdProp.GetValue(item);

                if (mainLangId != languageId)
                {
                    var localization = listValue.FirstOrDefault(o => o.LanguageEntityId == languageId);
                    if (localization != null)
                    {
                        //TODO: этот кусок кода доработать и тщательно протестировать
                        SetObjectLocalizationTexts(dto, localization);
                    }
                }

            }


            return dto;
        }




        public IEnumerable<DTOModel<T>> CreateDTOs(IEnumerable<T> items)
        {
            var models = new List<DTOModel<T>>();
            foreach (var item in items)
            {
                models.Add(CreateDTO(item));
            }
            return models;
        }    
        public IEnumerable<DTOModel<T>> CreateDTOsWithLocalization(IEnumerable<T> items, int? languageId)
        {
            var models = new List<DTOModel<T>>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, languageId));
            }
            return models;
        }


   




        //public static DTOModel<T> Create(T item)
        //{
        //     throw new NotImplementedException();
        //}
        //public static DTOModel<T> CreateWithLocalization(T item, int? languageId)
        //{
        //    var model = Create(item);

        //    var localizationsListProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "Localizations");
        //    var mainLangIdProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
        //    if (localizationsListProp != null && mainLangIdProp != null)
        //    {
        //        var listBaseValue = localizationsListProp.GetValue(item) as IList;
        //        var listValue = listBaseValue.Cast<LocalizableModel>();

        //        var mainLangId = (int)mainLangIdProp.GetValue(item);

        //        if (mainLangId != languageId)
        //        {
        //            var localization = listValue.FirstOrDefault(o => o.LanguageEntityId == languageId);
        //            if (localization != null)
        //            {
        //                //TODO: этот кусок кода доработать и тщательно протестировать
        //                SetObjectLocalizationTexts(model, localization);
        //            }
        //        }

        //    }


        //    return model;
        //}


        //public static IEnumerable<DTOModel<T>> CreateItems(IEnumerable<T> items)
        //{
        //    var models = new List<DTOModel<T>>();
        //    foreach (var item in items)
        //    {
        //        models.Add(Create(item));
        //    }
        //    return models;
        //}
        //public static IEnumerable<DTOModel<T>> CreateItemsWithLocalization(IEnumerable<T> items, int? languageId)
        //{
        //    var models = new List<DTOModel<T>>();
        //    foreach (var item in items)
        //    {
        //        models.Add(CreateWithLocalization(item, languageId));
        //    }
        //    return models;
        //}



        //public static DTOModel<T> Create(T item)
        //{
        //    var model = new DTOModel<T>();

        //    var thisProps = model.GetType().GetProperties();
        //    var props = item.GetType().GetProperties();
        //    foreach (var prop in props)
        //    {
        //        var val = prop.GetValue(item);

        //        var thisProp = thisProps.FirstOrDefault(o => o.Name == prop.Name);
        //        if (thisProp != null && thisProp.CanWrite)
        //        {
        //            if (thisProp.PropertyType.GetType() == typeof(DTOModel<T>))
        //            {
        //                //TODO: этот кусок кода тщательно протестировать
        //                if (val is IEnumerable<T> enumerable)
        //                {
        //                    val = DTOModel<T>.CreateItems(enumerable);
        //                }
        //                else if (val is T singleModel)
        //                {
        //                    val = DTOModel<T>.Create(singleModel);
        //                }
        //            }

        //            thisProp.SetValue(model, val);
        //        }
        //    }


        //    return model;
        //}
        //public static DTOModel<T> CreateWithLocalization(T item, int? languageId)
        //{
        //    var model = Create(item);

        //    var localizationsListProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "Localizations");
        //    var mainLangIdProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
        //    if (localizationsListProp != null && mainLangIdProp != null)
        //    {
        //        var listBaseValue = localizationsListProp.GetValue(item) as IList;
        //        var listValue = listBaseValue.Cast<LocalizableModel>();

        //        var mainLangId = (int)mainLangIdProp.GetValue(item);

        //        if (mainLangId != languageId)
        //        {
        //            var localization = listValue.FirstOrDefault(o => o.LanguageEntityId == languageId);
        //            if (localization != null)
        //            {
        //                //TODO: этот кусок кода доработать и тщательно протестировать
        //                SetObjectLocalizationTexts(model, localization);
        //            }
        //        }

        //    }


        //    return model;
        //}


        //public static IEnumerable<DTOModel<T>> CreateItems(IEnumerable<T> items)
        //{
        //    var models = new List<DTOModel<T>>();
        //    foreach (var item in items)
        //    {
        //        models.Add(Create(item));
        //    }
        //    return models;
        //}
        //public static IEnumerable<DTOModel<T>> CreateItemsWithLocalization(IEnumerable<T> items, int? languageId)
        //{
        //    var models = new List<DTOModel<T>>();
        //    foreach (var item in items)
        //    {
        //        models.Add(CreateWithLocalization(item, languageId));
        //    }
        //    return models;
        //}


        private static void SetObjectLocalizationTexts(DTOModel<T> model, LocalizableModel localization)
        {
            foreach(var prop in localization.GetType().GetProperties())
            {
                if (prop.Name == "Id"
                    || prop.Name == "LanguageEntity"
                    || prop.Name == "LanguageEntityId"
                    || prop.Name == "IsDeleted"
                    || prop.Name == "CreatedAt"
                    || prop.Name == "UpdatedAt")
                {
                    continue;
                }

                var dtoFoundProp = model.GetType().GetProperties().FirstOrDefault(o => o.Name == prop.Name);
                if(dtoFoundProp != null)
                {
                    var dtoFoundPropVal = dtoFoundProp.GetValue(model);
                    var localizationModelPropVal = prop.GetValue(localization);

                    dtoFoundProp.SetValue(model, DTOModel.GetActualValueGeneric(dtoFoundPropVal, localizationModelPropVal));

                }
            }
        }



        #endregion

        #region Создание новых сущностей БД из DTO 
        public virtual T CreateDBModelFromDTO()
        {
            var newItem = new T();
            this.FillDBModel(newItem, DBModelFillMode.Create);
            newItem.Id = 0;

            return newItem;
        }
        public static IEnumerable<T> CreateDBModelsFromDTO(IEnumerable<DTOModel<T>> models)
        {
            var items = new List<T>();

            foreach (var model in models)
            {
                items.Add(model.CreateDBModelFromDTO());
            }

            return items;
        }

        #endregion

        #region Заполнение сущности БД из DTO
        public virtual void FillDBModel(T item, DBModelFillMode mode)
        {
            var props = this.GetType().GetProperties();
            var itemProps = item.GetType().GetProperties();

            foreach (var prop in props)
            {
                if(mode == DBModelFillMode.Update && prop.Name == "Id")
                {
                    continue;
                }

                var itemSameProp = itemProps.FirstOrDefault(o => o.Name == prop.Name);
                if (itemSameProp != null && itemSameProp.CanWrite)
                {
                    var restrictionAttr = prop.GetCustomAttributes().FirstOrDefault(o => o.GetType() == typeof(DTOFieldFor)) as DTOFieldFor;
                    if (restrictionAttr != null)
                    {
                        if(restrictionAttr.For == DTOFieldForType.UpdateOnly && mode != DBModelFillMode.Update)
                        {
                            continue;
                        }
                        if (restrictionAttr.For == DTOFieldForType.CreationOnly && mode != DBModelFillMode.Create)
                        {
                            continue;
                        }
                    }


                    if (prop.GetValue(this) is DTOModel dtoModel)
                    {
                       

                        if(mode == DBModelFillMode.Update)
                        {
                            var a = itemSameProp.GetValue(item);
                            prop.GetValue(this).GetType().GetMethod("FillDBModel").Invoke(prop.GetValue(this), new[] { itemSameProp.GetValue(item), mode });
                        }
                        else if(mode == DBModelFillMode.Create)
                        {
                            var createdDbEntity = prop.GetValue(this).GetType().GetMethod("CreateDBModelFromDTO").Invoke(prop.GetValue(this), Array.Empty<object>());
                            itemSameProp.SetValue(item, createdDbEntity);
                        }                     
                    }
                    else if(itemSameProp.PropertyType == prop.PropertyType)
                    {
                        itemSameProp.SetValue(item, prop.GetValue(this));
                    }
  
                }
            }
        }



        #endregion


        public DTOModel<T> Clone()
        {
            return this.MemberwiseClone() as DTOModel<T>;
        }

    }

    public enum DBModelFillMode
    {
        Create = 1,
        Update = 2,
    }

  


  

}
