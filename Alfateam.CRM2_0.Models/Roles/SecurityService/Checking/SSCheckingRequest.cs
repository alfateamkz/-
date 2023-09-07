using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking
{
    /// <summary>
    /// Запрос на проверку службой безопасности
    /// </summary>
    public class SSCheckingRequest : AbsModel
    {
        /// <summary>
        /// Кто запросил проверку. Если пустое поле, то проверку запросила сама система
        /// </summary>
        public User? From { get; set; }
        public int? FromId { get; set; }

        /// <summary>
        /// Кого необходимо проверить
        /// </summary>
        public User NeedToCheck { get; set; }
        public int NeedToCheckId { get; set; }



        /// <summary>
        /// Информация, которую нужно проверить
        /// </summary>
        public SSCheckingData CheckingData { get; set; }
        public int CheckingDataId { get; set; }


        /// <summary>
        /// Результат запроса проверки
        /// </summary>
        public SSCheckingRequestResult? Result { get; set; }
        public int? ResultId { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SecurityServiceDepartmentId { get; set; }
    }
}
