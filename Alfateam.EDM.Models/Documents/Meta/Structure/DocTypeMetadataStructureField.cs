using Alfateam.Core;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Meta.Structure
{
    public class DocTypeMetadataStructureField : AbsModel
    {
        public DocTypeMetadataStructureField()
        {

        }

        public DocTypeMetadataStructureField(string title, string jsonName, DocTypeMetadataStructureFieldType fieldType, bool isRequred, bool displayToEDMDocsList)
        {
            Title = title;
            JSONName = jsonName;
            FieldType = fieldType;
            IsRequired = isRequred;
            DisplayToEDMDocsList = displayToEDMDocsList;
        }

        public string Title { get; set; }
        public string JSONName { get; set; }
        public DocTypeMetadataStructureFieldType FieldType { get; set; }
        public bool IsRequired { get; set; }



        public bool DisplayToEDMDocsList { get; set; }
    }
}
