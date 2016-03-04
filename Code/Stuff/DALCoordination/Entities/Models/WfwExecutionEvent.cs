namespace DALCoordination.Entities
{
    public class WfwExecutionEvent : EnabledEntity
    {
        public int WfwDocumentWorkStagesId { get; set; }
        public System.DateTimeOffset Date { get; set; }
        public string CreaterSid { get; set; }
        public int ResultId { get; set; }
        public string Comment { get; set; }
        public virtual Employee Creator { get; set; }
        public virtual WfwDocumentWorkStages WfwDocumentWorkStage { get; set; }
        public virtual WfwEventResult WfwEventResult { get; set; }
    }
}
