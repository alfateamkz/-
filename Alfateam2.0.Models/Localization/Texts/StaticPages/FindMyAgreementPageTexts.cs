using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages
{
    public class FindMyAgreementPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Поиск договора";
        public string Header { get; set; } = "ПОИСК ДОГОВОРА";


        public string AgreementNumberTitle { get; set; } = "Номер договора";
        public string AgreementNumberPlaceholder { get; set; } = "00001111322";

        public string AgreementCustomerNameTitle { get; set; } = "Наименование заказчика";
        public string AgreementCustomerNamePlaceholder { get; set; } = "ФИО или название компании\\ИП";



        public string BtnFindAgreement { get; set; } = "Проверить";




        public string AgreementInfoHeader { get; set; } = "Информация по договору";
        public string AgreementResultNumber { get; set; } = "Номер  договора: {number}";
        public string AgreementResultSum { get; set; } = "Стоимость: {sum} {curr_code}";
        public string AgreementResultTitle { get; set; } = "Услуга: {title}";
        public string AgreementResultDate { get; set; } = "Дата заключения: {dd.MM.yyyy}";
        public string BtnDownloadPDF { get; set; } = "Скачать PDF";
        public string BtnDownloadDOCX { get; set; } = "Скачать DOCX";



        public string AgreementNotFound { get; set; } = "Договор №{number} не найден";
    }
}
