namespace DALCoordination.Entities
{
    public abstract class EnabledEntity : BaseEntity
    {
        public EnabledEntity()
        {
            Enabled = true;
        }

        public bool Enabled { get; set; }
    }
}
