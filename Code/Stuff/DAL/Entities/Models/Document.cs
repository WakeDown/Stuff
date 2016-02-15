namespace DAL.Entities.Models
{
    public class Document : EnabledEntity
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int? ExecutionId { get; set; }
        public virtual WfwDocumentExecution WfwDocumentExecution { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
