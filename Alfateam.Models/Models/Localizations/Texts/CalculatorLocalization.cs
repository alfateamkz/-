using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts
{

    [GeneratorMetadata("Калькулятор")]
    public class CalculatorLocalization : LocalizationModel
    {
        [GeneratorField("Рассчитать стоимость проекта")]
        public string GetProjectPrice { get; set; } = "Рассчитать стоимость проекта";

        [GeneratorField("Выберите тип услуги")]
        public string SelectTypeOfService { get; set; } = "Выберите тип услуги";
        [GeneratorField("Разработка мобильного приложения")]
        public string TypeOfService_Mobile { get; set; } = "Разработка мобильного приложения";
        [GeneratorField("Прикладное ПО")]
        public string TypeOfService_Software1 { get; set; } = "Прикладное ПО";
        [GeneratorField("Интерактивное ПО")]
        public string TypeOfService_Software2 { get; set; } = "Интерактивное ПО";
        [GeneratorField("Создание сайта")]
        public string TypeOfService_Website { get; set; } = "Создание сайта";


        [GeneratorField("Операционная система")]
        public string OperatingSystem { get; set; } = "Операционная система";
        [GeneratorField("Язык программирования")]
        public string ProgrammingLanguage { get; set; } = "Язык программирования";


        [GeneratorField("Итог")]
        public string Total { get; set; } = "Итог";
        [GeneratorField("Ориентировачная сумма от")]
        public string TotalFrom { get; set; } = "Ориентировачная сумма от";
        [GeneratorField("отправить заявку")]
        public string MakeOrder { get; set; } = "отправить заявку";


        #region Mobile app branch

        [GeneratorField("Телефон")]
        public string MobileBranch_Phone { get; set; } = "Телефон";
        [GeneratorField("Планшет")]
        public string MobileBranch_Tablet { get; set; } = "Планшет";
        [GeneratorField("Часы")]
        public string MobileBranch_Watch { get; set; } = "Часы";
        [GeneratorField("Телевизор")]
        public string MobileBranch_TV { get; set; } = "Телевизор";


        [GeneratorField("Есть дизайн")]
        public string MobileBranch_HasDesign { get; set; } = "Есть дизайн";
        [GeneratorField("Необходимо разработать")]
        public string MobileBranch_DesignRequired { get; set; } = "Необходимо разработать";


        [GeneratorField("Кроссплатформенно")]
        public string MobileBranch_Crossplatform { get; set; } = "Кроссплатформенно";
        [GeneratorField("Нативно")]
        public string MobileBranch_Native { get; set; } = "Нативно";

        #endregion

        #region Software branch
        [GeneratorField("Платформа")]
        public string SoftwareBranch_Platform { get; set; } = "Платформа";
        [GeneratorField("Свой вариант")]
        public string SoftwareBranch_PlatformOther { get; set; } = "Свой вариант";


        [GeneratorField("Дизайн")]
        public string SoftwareBranch_Design { get; set; } = "Дизайн";
        [GeneratorField("Есть дизайн")]
        public string SoftwareBranch_HasDesign { get; set; } = "Есть дизайн";
        [GeneratorField("Необходимо разработать")]
        public string SoftwareBranch_DesignRequired { get; set; } = "Необходимо разработать";
        #endregion

        #region Website branch

        [GeneratorField("Интернет-магазин")]
        public string WebsiteBranch_EShop { get; set; } = "Интернет-магазин";
        [GeneratorField("Многостраничный сайт")]
        public string WebsiteBranch_Website { get; set; } = "Многостраничный сайт";
        [GeneratorField("Лендинг")]
        public string WebsiteBranch_Landing { get; set; } = "Лендинг";
        [GeneratorField("Затрудняюсь ответить")]
        public string WebsiteBranch_Other { get; set; } = "Затрудняюсь ответить";



        [GeneratorField("Необходимо сайт “под ключ”")]
        public string WebsiteBranch_ServiceTurnkey { get; set; } = "Необходимо сайт “под ключ”";
        [GeneratorField("Есть контент для сайта")]
        public string WebsiteBranch_ServiceHasContent { get; set; } = "Есть контент для сайта";
        [GeneratorField("Есть часть контента - нужна помощь")]
        public string WebsiteBranch_ServiceHasPartContent { get; set; } = "Есть часть контента - нужна помощь";



        [GeneratorField("Самописный сайт")]
        public string WebsiteBranch_StackFramework { get; set; } = "Самописный сайт";
        [GeneratorField("CMS")]
        public string WebsiteBranch_StackCMS { get; set; } = "CMS";
        [GeneratorField("CMS для сайта")]
        public string WebsiteBranch_StackCMSForWebsite { get; set; } = "CMS для сайта";
        #endregion

    }
}
