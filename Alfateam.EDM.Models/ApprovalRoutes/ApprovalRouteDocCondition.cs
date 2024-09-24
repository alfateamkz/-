﻿using Alfateam.EDM.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.ApprovalRoutes
{
    public class ApprovalRouteDocCondition
    {

        /// <summary>
        /// Если пусто, то для всех типов документов применяется условие
        /// </summary>
        public List<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

        /// <summary>
        /// Если пусто, то для всех контрагентов применяется условие
        /// </summary>
        public List<Counterparty> Counterparties { get; set; } = new List<Counterparty>();

        /// <summary>
        /// Если пусто, то для всех групп контрагентов применяется условие
        /// </summary>
        public List<CounterpartyGroup> CounterpartyGroups { get; set; } = new List<CounterpartyGroup>();
    }
}
