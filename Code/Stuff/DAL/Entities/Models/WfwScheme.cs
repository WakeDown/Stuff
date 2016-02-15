using System.Collections.Generic;

namespace DAL.Entities.Models
{
    public class WfwScheme : EnabledEntity
    {
        public WfwScheme()
        {
            this.WfwDocumentTypesSchems = new List<WfwDocumentTypeSchem>();
            this.WfwSchemeStages = new List<WfwSchemeStage>();
        }

        public string Name { get; set; }
        public int Action { get; set; }
        public bool ContinueLastStage { get; set; }
        public virtual ICollection<WfwDocumentTypeSchem> WfwDocumentTypesSchems { get; set; }
        public virtual ICollection<WfwSchemeStage> WfwSchemeStages { get; set; }
    }
}
