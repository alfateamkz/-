using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Staff {
    public class EmployeeDocuments : BaseModel {


        public string? CVPath { get; set; } = "";


        public string? MainDocumentPath { get; set; } = "";
        public string? MilitaryIDPath { get; set; } = "";


        public string? DiplomaPath { get; set; } = "";
    }
}
