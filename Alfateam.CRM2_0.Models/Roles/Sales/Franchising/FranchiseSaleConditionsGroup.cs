using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising
{
    /// <summary>
    /// Условия по конкретной продаже франшизы
    /// </summary>
    public class FranchiseSaleConditionsGroup : AbsModel
    {
        /// <summary>
        /// Первоначальные условия по франшизе при ее покупке
        /// </summary>
        public FranchiseSaleConditions InitialConditions { get; set; }
        /// <summary>
        /// Если франшиза куплена, то здесь находятся текущие условия по франшизе
        /// InitialConditions может быть равен ActualConditions, если условия после покупки франшизы не менялись
        /// </summary>
        public FranchiseSaleConditions? ActualConditions { get; set; }

        /// <summary>
        /// Список изменений условий по франшизе
        /// Например человек захотел увеличить кол-во сотрудников в фирме или открыть еще один филиал
        /// Последний элемент списка всегда должен быть в ActualConditions
        /// </summary>
        public List<FranchiseSaleConditions> SaleConditions { get; set; } = new List<FranchiseSaleConditions>();
    }
}
