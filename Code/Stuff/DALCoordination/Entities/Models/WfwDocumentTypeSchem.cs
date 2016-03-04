namespace DALCoordination.Entities
{
    public class WfwDocumentTypeSchem : EnabledEntity
    {
        public int DocumentTypeId { get; set; }
        public int SchemeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual WfwScheme WfwScheme { get; set; }
    }
}
