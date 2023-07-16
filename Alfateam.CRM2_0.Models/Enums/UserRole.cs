using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Роль пользователя CRM
    /// </summary>
    public enum UserRole
    {
        Director = 1, //Директор корпорации
        TopManager = 2, //Топ-менеджер корпорации/партнерской организации
        PartnerOrganigationDirector = 3, //Владелец партнерской организации  
        BranchDirector = 4, //Директор филиала/партнерского филиала
        Financian = 5, //Финансист
        ProjectManager = 6, //Проектный менеджер
        Lawyer = 7, //Юрист
        TechLead = 8, //Тех.лид
        TeamLead = 9, //Тим.лид
        Employee = 10, //Работник
        SalesDirector = 11, //Руководитель отдела продаж
        SalesManager = 12, //Менеджер по продажам
        MarketingDirector = 13, //Директор отдела маркетинга
        MarketingEmployee = 14, //Работник отдела маркетинга
        Partner = 15, //Компания-партнер
        Customer = 16, //Клиент
        HR = 17, //HR Manager
        Compliance = 18, //Сотрудник службы комплаенс
        SecurityService = 19, //Сотрудник службы безопасности
        ContentMaker = 20, //Контент-мейкер разделов CRM (обычный контент мейкер - Employee)
        Candidate = 21, //Роль кандидата на должность
        Investor = 22 //Инвестор
    }
}
