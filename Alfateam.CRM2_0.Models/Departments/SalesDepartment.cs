using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Отдел продаж
    /// </summary>
    public class SalesDepartment : AbsModel
    {

        #region Funnel
        public List<SalesFunnel> SalesFunnels { get; set; } = new List<SalesFunnel>();
        #endregion

        #region Orders
        public List<Order> Orders { get; set; } = new List<Order>();
        #endregion

        #region Plan
        public List<SalesPlanning> SalesPlannings { get; set; } = new List<SalesPlanning>();
        #endregion

        #region Scripting
        public List<SalesScript> SalesScripts { get; set; } = new List<SalesScript>();
        #endregion

        public List<Customer> Customers { get; set; } = new List<Customer>();


        //TODO: подумать, где должны быть заказы. В отделе продаж, у фирмы в целом, или где-то еще
    }
}
