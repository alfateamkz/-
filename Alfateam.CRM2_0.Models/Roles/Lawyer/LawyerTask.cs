using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer
{
    /// <summary>
    /// Модель поручения юристу
    /// </summary>
    public class LawyerTask : AbsModel
    {

        /// <summary>
        /// Статус поручения
        /// </summary>
        public LawyerTaskStatus Status { get; set; } = LawyerTaskStatus.Waiting;



        /// <summary>
        /// Какой документ нужно составить юристу
        /// </summary>
        public DocumentType DocumentType { get; set; }


        /// <summary>
        /// Вторая сторона
        /// </summary>
        public User SecondSide { get; set; }


        /// <summary>
        /// Заказ, с каким связано дело
        /// Может быть пустым
        /// </summary>
        public Order? Order { get; set; }




        /// <summary>
        /// Комментарий к поручению
        /// </summary>
        public string? Comment { get; set; }




        /// <summary>
        /// Кто создал поручение
        /// </summary>
        public User CreatedBy { get; set; }

        /// <summary>
        /// Кто принял поручение
        /// По умолчанию null, потому что в компании может быть несколько юристов
        /// Сюда подставляется юрист, который быстрее всех подтвердил поручение
        /// </summary>
        public User? AcceptedBy { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int LawDepartmentId { get; set; }
    }
}
