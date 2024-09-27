using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Documents.Types
{
    
    public class NonFormalizedDocument : Document
    {

   



		public DocumentType Type { get; set; }
        public int TypeId { get; set; }



      
        public List<DocumentVersion> Versions { get; set; } = new List<DocumentVersion>();



        public List<DocumentSigningSide> SigningSides { get; set; } = new List<DocumentSigningSide>();


        public SignedDocument? SignedDocument { get; set; }
		public int? SignedDocumentId { get; set; }




        /// <summary>
        /// Документы, имеющие отношения к текущему документу. Например, счета на оплату, акты выполненных работ и т.д. 
        /// </summary>
        public List<Document> RelatedDocuments { get; set; } = new List<Document>();



    }
}
