using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class work_daysMap : EntityTypeConfiguration<work_days>
    {
        public work_daysMap()
        {
            // Primary Key
            this.HasKey(t => t.date);

            // Properties
            // Table & Column Mappings
            this.ToTable("work_days");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.work_hours).HasColumnName("work_hours");
        }
    }
}
