using Alfateam.Core;
using Alfateam.CRM2_0.Models.Content.Tests;
using Alfateam.DB;
using Alfateam.Core.Attributes.DTO;
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
    public abstract class DTOModel<T> : DTOModelAbs<T> where T : AbsModel, new()
    {

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


        public static object GetActualValueGeneric(object oldValue, object newValue)
        {
            if (oldValue is string oldValStr && newValue is string newValStr)
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


        #region Клиентские модели (для просмотра)
        public DTOModel<T> CreateDTOWithLocalization(T item, int? languageId)
        {
            if(item == null)
            {
                return null;
            }

            var dto = this.CreateDTO(item) as DTOModel<T>;

            var localizationsListProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "Localizations");
            var mainLangIdProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
            if (localizationsListProp != null && mainLangIdProp != null)
            {
                var listBaseValue = localizationsListProp.GetValue(item) as IList;
                var listValue = listBaseValue.Cast<LocalizableModel>();

                var mainLangId = (int?)mainLangIdProp.GetValue(item);

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
        public IEnumerable<DTOModel<T>> CreateDTOsWithLocalization(IEnumerable<T> items, int? languageId)
        {
            var models = new List<DTOModel<T>>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, languageId));
            }
            return models;
        }



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

                    dtoFoundProp.SetValue(model, DTOModel<T>.GetActualValueGeneric(dtoFoundPropVal, localizationModelPropVal));

                }
            }
        }

        #endregion



    }
}
