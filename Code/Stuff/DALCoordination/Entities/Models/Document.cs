namespace DAL.Entities.Models
{
    public class Document
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LinkToDoc { get; set; }
        public int LinkToDocId { get; set; }
        public int TypeId { get; set; }
        public int? ExecutionId { get; set; }
        public virtual WfwDocumentExecution WfwDocumentExecution { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public bool Enabled { get; set; }
    }
}
