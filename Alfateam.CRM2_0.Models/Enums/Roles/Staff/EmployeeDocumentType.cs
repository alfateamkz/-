using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff
{
    /// <summary>
    /// Тип документа сотрудника
    /// </summary>
    public enum EmployeeDocumentType
    {
        IdentifyCard = 1, //Удостоверение личности
        Passport = 2, //Паспорт
        InternationalPassport = 3, //Заграничный паспорт
        ResidencePermission = 4, //Вид на жительство/разрешение на проживание
        MilitaryCard = 6, //Военное удостоверение/приписное свидетельство
        Diploma = 7, //Диплом
        CourseCertificate = 8, //Сертификат о прохождении курса
        SchoolCertificate = 9, //Школьный аттестат
        DriverLicense = 10, //Водительское удостоверение 
        RegistrationCertificate = 11, //Свидетельство о регистрации


        Other = 999 //Прочее
    }
}
