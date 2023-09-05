using Alfateam.CRM2_0.Models.Attributes;
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

        [RolePriority(10001)] President = 1,  //Директор корпорации
        [RolePriority(10000)] TopManager = 2, //Топ-менеджер корпорации
        [RolePriority(1001)] PartnerOrganigationDirector = 3, //Владелец партнерской организации  
        [RolePriority(1000)] PartnerOrganigationTopManager = 4, //Топ-менеджер партнерской организации  
        [RolePriority(100)] BranchDirector = 5, //Директор филиала/партнерского филиала
        [RolePriority(99)] Financian = 6, //Финансист
        [RolePriority(98)] Accountant = 7, //Бухгалтер
        [RolePriority(97)] ProjectManager = 8, //Проектный менеджер
        [RolePriority(96)] Lawyer = 9, //Юрист
        [RolePriority(95)] TechLead = 10, //Тех.лид
        [RolePriority(94)] TeamLead = 11, //Тим.лид
        [RolePriority(93)] Employee = 12, //Работник
        [RolePriority(92)] Sales = 13, //Работник отдела продаж
        [RolePriority(91)] Marketing = 14, //Работник отдела маркетинга
        [RolePriority(90)] HR = 15, //HR Manager
        [RolePriority(89)] Compliance = 16, //Сотрудник службы комплаенс
        [RolePriority(88)] SecurityService = 17, //Сотрудник службы безопасности
        [RolePriority(87)] ContentMaker = 18, //Контент-мейкер разделов CRM (обычный контент мейкер - Employee)
        [RolePriority(4)] Investor = 19, //Инвестор
        [RolePriority(3)] Partner = 20, //Компания-партнер
        [RolePriority(2)] Customer = 21, //Клиент
        [RolePriority(1)] Candidate = 22, //Роль кандидата на должность
      
    }
}
