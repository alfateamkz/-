using Alfateam.CRM2_0.Models.Content.Tests;
using Alfateam.DB;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Extensions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections;
using System.Linq.Expressions;
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


        protected DbContext DB;
        public void SetDBContext(DbContext db)
        {
            DB = db;

            foreach(var prop in this.GetType().GetProperties())
            {
                var propVal = prop.GetValue(this);
                if(IsModelTypeOf(prop.PropertyType, typeof(DTOModel)))
                {
                    if(propVal != null)
                    {
                        (propVal as DTOModel).SetDBContext(db);
                    }
                }
                else if (prop.PropertyType.FullName.Contains("System.Collections.Generic.List")
                            && prop.PropertyType.GenericTypeArguments.Any(o => IsModelTypeOf(o, typeof(DTOModel))))
                {
                    foreach(DTOModel dto in propVal as IList)
                    {
                        dto.SetDBContext(db);
                    }
                }
            }
        }



        #region Get derived types 



        public static List<Type> FindAllDerivedTypes(Type type)
        {
            return Assembly.GetAssembly(type)
                .GetTypes()
                .Where(t =>
                    t != type &&
                    type.IsAssignableFrom(t)
                    ).ToList();

        }


        public static List<Type> FindAllDerivedTypes<T>()
        {
            return FindAllDerivedTypes<T>(Assembly.GetAssembly(typeof(T)));
        }
        public static List<Type> FindAllDerivedTypes<T>(Assembly assembly)
        {
            var baseType = typeof(T);
            return assembly
                .GetTypes()
                .Where(t =>
                    t != baseType &&
                    baseType.IsAssignableFrom(t)
                    ).ToList();

        }

        #endregion

    }

    public abstract class DTOModel<T> : DTOModel where T : AbsModel, new()
    {
        #region Клиентские модели (для просмотра)

        public DTOModel<T> CreateDTO(T item)
        {
            var clone = this.Clone();

            var types = FindAllDerivedTypes(clone.GetType());
            if (types.Any())
            {
                var discriminatorProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "Discriminator");
                if (discriminatorProp != null)
                {
                    var discriminatorValue = discriminatorProp.GetValue(item);
                    var foundType = types.FirstOrDefault(o => o.Name.Equals($"{discriminatorValue}DTO"));

                    clone = (DTOModel<T>)Activator.CreateInstance(foundType);
                }
            }


            var thisProps = clone.GetType().GetProperties();
            var itemProps = item.GetType().GetProperties();


            foreach (var thisProp in thisProps)
            {
                var thisVal = thisProp.GetValue(clone);

                var itemProp = FindSameProp(thisProp, itemProps);
                if (itemProp != null && thisProp.CanWrite)
                {
                    var itemPropVal = itemProp.GetValue(item);

                    if (thisProp.PropertyType == typeof(List<int>))
                    {
                        SetDTOField_ListOfIds(clone, thisProp, itemPropVal);
                    }
                    else if (thisProp.PropertyType.FullName.Contains("System.Collections.Generic.List")
                        && thisProp.PropertyType.GenericTypeArguments.Any(o => IsModelTypeOf(o, typeof(DTOModel))))
                    {
                        SetDTOField_ListOfDBEntities(clone, thisProp, itemPropVal);
                    }
                    else if (DTOModel.IsModelTypeOf(thisProp.PropertyType, typeof(DTOModel)))
                    {
                        SetDTOField_DTOModel(clone, thisProp, itemPropVal);
                    }
                    else if (itemProp.PropertyType == thisProp.PropertyType)
                    {
                        SetDTOField_SimpleVal(clone, thisProp, itemPropVal);
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



        #region Set DTO Field Methods

        private void SetDTOField_ListOfDBEntities(DTOModel DTOModelObject, PropertyInfo DTOModelObjectProp, object dbPropVal)
        {
            var itemPropValList = ((IList)dbPropVal).Cast<AbsModel>().ToList();
            var newDTOsList = (IList)Activator.CreateInstance(DTOModelObjectProp.PropertyType);

            foreach (var itemPropDbEntity in itemPropValList)
            {
                var newDTOinstance = Activator.CreateInstance(DTOModelObjectProp.PropertyType.GenericTypeArguments[0]);
                newDTOinstance = newDTOinstance.GetType().GetMethod("CreateDTO").Invoke(newDTOinstance, new[] { itemPropDbEntity });

                newDTOsList.Add(newDTOinstance as DTOModel);
            }

            DTOModelObjectProp.SetValue(DTOModelObject, newDTOsList);
        }
        private void SetDTOField_ListOfIds(DTOModel DTOModelObject, PropertyInfo DTOModelObjectProp, object dbPropVal)
        {
            var itemPropValList = ((IList)dbPropVal).Cast<AbsModel>().ToList();

            var ids = new List<int>();
            foreach (var itemPropDbEntity in itemPropValList)
            {
                ids.Add(itemPropDbEntity.Id);
            }

            DTOModelObjectProp.SetValue(DTOModelObject, ids);
        }
        private void SetDTOField_SimpleVal(DTOModel DTOModelObject, PropertyInfo DTOModelObjectProp, object dbPropVal)
        {
            DTOModelObjectProp.SetValue(DTOModelObject, dbPropVal);
        }
        private void SetDTOField_DTOModel(DTOModel DTOModelObject, PropertyInfo DTOModelObjectProp, object dbPropVal)
        {
            var thisPropValue = DTOModelObjectProp.GetValue(DTOModelObject);
            if (thisPropValue == null && dbPropVal != null)
            {
                thisPropValue = Activator.CreateInstance(DTOModelObjectProp.PropertyType);

                DTOModelObjectProp.SetValue(DTOModelObject, thisPropValue);
                thisPropValue = DTOModelObjectProp.GetValue(DTOModelObject);
            }

            if (dbPropVal != null)
            {
                thisPropValue = thisPropValue.GetType().GetMethod("CreateDTO").Invoke(thisPropValue, new[] { dbPropVal });
                DTOModelObjectProp.SetValue(DTOModelObject, thisPropValue);
            }
        }


        #endregion




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

            var types = FindAllDerivedTypes<T>();
            if (types.Any())
            {
                var discriminatorProp = this.GetType().GetProperties().FirstOrDefault(o => o.Name == "Discriminator");
                if(discriminatorProp != null)
                {
                    var discriminatorValue = discriminatorProp.GetValue(this);
                    var foundType = types.FirstOrDefault(o => o.Name.Equals(discriminatorValue));

                    newItem = (T)Activator.CreateInstance(foundType);
                }            
            }
        
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
                if (!CanPropertyBeSet(prop, mode) 
                    || (mode == DBModelFillMode.Update && prop.Name == "Id"))
                {
                    continue;
                }

                var itemSameProp = FindSameProp(prop, itemProps);
                if (itemSameProp != null && itemSameProp.CanWrite)
                {
                 
                    if (prop.PropertyType == typeof(List<int>))
                    {
                        FillDBProp_FromListOfIds(item, itemSameProp, prop);
                    }
                    else if (prop.PropertyType.FullName.Contains("System.Collections.Generic.List")
                            && prop.PropertyType.GenericTypeArguments.Any(o => IsModelTypeOf(o, typeof(DTOModel))))
                    {
                        FillDBProp_FromDTOsList(item, itemSameProp, prop);
                    }
                    if (prop.GetValue(this) is DTOModel dtoModel)
                    {
                        FillDBProp_FromDTOModel(item, itemSameProp, prop, mode);
                    }
                    else if(itemSameProp.PropertyType == prop.PropertyType)
                    {
                        FillDBProp_SimpleValue(item, itemSameProp, prop.GetValue(this));
                    }
  
                }
            }
        }


        #region Fill DB Prop Methods

        private void FillDBProp_FromListOfIds(AbsModel dbEntity, PropertyInfo dbEntityProp, PropertyInfo dtoModelProp)
        {
            var itemPropBindAttr = dtoModelProp.GetCustomAttributes().FirstOrDefault(o => o.GetType() == typeof(DTOFieldBindWith)) as DTOFieldBindWith;
            if (itemPropBindAttr != null)
            {
                var dbSetProp = DB.GetType().GetProperties()
                                            .FirstOrDefault(o => o.PropertyType.GenericTypeArguments.Any(o => o == itemPropBindAttr.TypeOfEntity));

                var ids = dtoModelProp.GetValue(this) as List<int>;
                foreach (var id in ids)
                {
                    Expression<Func<AbsModel, bool>> funcLambda = (e) => e.Id == id;

                    //Ищем метод с 2 параметрами (IQueryable<T> dataset и T obj)
                    var firstOrDefaultMethods = typeof(Queryable).GetMethods().Where(o => o.Name == "FirstOrDefault").ToList();
                    var neededMethod = firstOrDefaultMethods[2].MakeGenericMethod(typeof(AbsModel));
                    var foundDBEntity = neededMethod.Invoke(null, new object[] { dbSetProp.GetValue(DB), funcLambda });




                    var dbEntityPropValue = dbEntityProp.GetValue(dbEntity) as IList;
                    dbEntityPropValue.Add(foundDBEntity);
                }
            }
        }
        private void FillDBProp_FromDTOsList(AbsModel dbEntity, PropertyInfo dbEntityProp, PropertyInfo dtoModelProp)
        {
            var itemSamePropValue = ((IList)dbEntityProp.GetValue(dbEntity));
            itemSamePropValue.Clear();


            var DTOs = dtoModelProp.GetValue(this) as IList;

            foreach (DTOModel dto in DTOs)
            {
                var createdDbEntity = (AbsModel)dto.GetType().GetMethod("CreateDBModelFromDTO").Invoke(dto, Array.Empty<object>());
                itemSamePropValue.Add(createdDbEntity);
            }
        }
        private void FillDBProp_FromDTOModel(AbsModel dbEntity, PropertyInfo dbEntityProp, PropertyInfo dtoModelProp, DBModelFillMode mode)
        {
            if (mode == DBModelFillMode.Update)
            {
                dtoModelProp.GetValue(this).GetType().GetMethod("FillDBModel").Invoke(dtoModelProp.GetValue(this), new[] { dbEntityProp.GetValue(dbEntity), mode });
            }
            else if (mode == DBModelFillMode.Create)
            {
                var createdDbEntity = dtoModelProp.GetValue(this).GetType().GetMethod("CreateDBModelFromDTO").Invoke(dtoModelProp.GetValue(this), Array.Empty<object>());
                dbEntityProp.SetValue(dbEntity, createdDbEntity);
            }
        }
        private void FillDBProp_SimpleValue(AbsModel dbEntity,PropertyInfo dbEntityProp, object dtoPropValue)
        {
            dbEntityProp.SetValue(dbEntity, dtoPropValue);
        }


        #endregion


        private PropertyInfo FindSameProp(PropertyInfo dtoProp, PropertyInfo[] itemProps)
        {
            var itemProp = itemProps.FirstOrDefault(o => o.Name == dtoProp.Name);
            if (itemProp == null)
            {
                var itemPropBindAttr = dtoProp.GetCustomAttributes().FirstOrDefault(o => o.GetType() == typeof(DTOFieldBindWith)) as DTOFieldBindWith;
                if (itemPropBindAttr != null)
                {
                    var dbItemPropSearchName = itemPropBindAttr.PropName;
                    if (string.IsNullOrEmpty(dbItemPropSearchName))
                    {
                        dbItemPropSearchName = dtoProp.Name.Replace("Ids", "");
                        itemProp = itemProps.FirstOrDefault(o => o.Name == dbItemPropSearchName);
                    }
                }
            }

            return itemProp;
        }
        private bool CanPropertyBeSet(PropertyInfo dtoPropInfo, DBModelFillMode mode)
        {
            var restrictionAttr = dtoPropInfo.GetCustomAttributes().FirstOrDefault(o => o.GetType() == typeof(DTOFieldFor)) as DTOFieldFor;
            if (restrictionAttr != null)
            {
                if (restrictionAttr.For == DTOFieldForType.UpdateOnly && mode != DBModelFillMode.Update)
                {
                    return false;
                }
                if (restrictionAttr.For == DTOFieldForType.CreationOnly && mode != DBModelFillMode.Create)
                {
                    return false;
                }
            }

            if(dtoPropInfo.GetCustomAttributes().Any(o => o.GetType() == typeof(ForClientOnly)))
            {
                return false;
            }

            return true;
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
