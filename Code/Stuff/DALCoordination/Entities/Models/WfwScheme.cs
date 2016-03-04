using System.Collections.Generic;

namespace DALCoordination.Entities
{
    public class WfwScheme : EnabledEntity
    {
        public WfwScheme()
        {
//            this.WfwDocumentTypesSchems = new List<WfwDocumentTypeSchem>();
            this.WfwSchemeStages = new List<WfwSchemeStage>();
            this.DocumentTypes = new List<DocumentType>();
        }

        public string Name { get; set; }
        public int Action { get; set; }
        public bool ContinueLastStage { get; set; }
//        public virtual ICollection<WfwDocumentTypeSchem> WfwDocumentTypesSchems { get; set; }
        public virtual ICollection<WfwSchemeStage> WfwSchemeStages { get; set; }
        public virtual ICollection<DocumentType> DocumentTypes { get; set; }
    }
}
