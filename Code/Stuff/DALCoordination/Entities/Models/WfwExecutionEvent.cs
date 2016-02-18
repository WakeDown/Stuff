namespace DAL.Entities.Models
{
    public class WfwExecutionEvent : EnabledEntity
    {
        public int ExecutionId { get; set; }
        public System.DateTime Date { get; set; }
        public int CreaterId { get; set; }
        public int ResultId { get; set; }
        public string Comment { get; set; }
        public virtual Employee employee { get; set; }
        public virtual WfwDocumentExecution WfwDocumentExecution { get; set; }
        public virtual WfwEventResult WfwEventResult { get; set; }
    }
}
