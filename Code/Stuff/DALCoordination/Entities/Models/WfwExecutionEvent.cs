namespace DAL.Entities.Models
{
    public class WfwExecutionEvent : EnabledEntity
    {
        public int ExecutionId { get; set; }
        public System.DateTimeOffset Date { get; set; }
        public string CreaterSid { get; set; }
        public int ResultId { get; set; }
        public string Comment { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual WfwDocumentExecution WfwDocumentExecution { get; set; }
        public virtual WfwEventResult WfwEventResult { get; set; }
    }
}
