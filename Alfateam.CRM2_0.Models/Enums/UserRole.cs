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
        President = 1, //Директор корпорации
        TopManager = 2, //Топ-менеджер корпорации/партнерской организации
        PartnerOrganigationDirector = 3, //Владелец партнерской организации  
        BranchDirector = 4, //Директор филиала/партнерского филиала
        Financian = 5, //Финансист
        ProjectManager = 6, //Проектный менеджер
        Lawyer = 7, //Юрист
        TechLead = 8, //Тех.лид
        TeamLead = 9, //Тим.лид
        Employee = 10, //Работник
        Sales = 11, //Работник отдела продаж
        Marketing = 12, //Работник отдела маркетинга
        Partner = 13, //Компания-партнер
        Customer = 14, //Клиент
        HR = 15, //HR Manager
        Compliance = 16, //Сотрудник службы комплаенс
        SecurityService = 17, //Сотрудник службы безопасности
        ContentMaker = 18, //Контент-мейкер разделов CRM (обычный контент мейкер - Employee)
        Candidate = 19, //Роль кандидата на должность
        Investor = 20 //Инвестор
    }
}
