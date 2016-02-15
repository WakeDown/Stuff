using System.Collections.Generic;

namespace DAL.Entities.Models
{
    public class DocumentType : EnabledEntity
    {
        public DocumentType()
        {
            this.Documents = new List<Document>();
            this.WfwDocumentTypesSchems = new List<WfwDocumentTypeSchem>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<WfwDocumentTypeSchem> WfwDocumentTypesSchems { get; set; }
    }
}
