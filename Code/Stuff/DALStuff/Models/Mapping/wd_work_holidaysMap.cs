using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class wd_work_holidaysMap : EntityTypeConfiguration<wd_work_holidays>
    {
        public wd_work_holidaysMap()
        {
            // Primary Key
            this.HasKey(t => t.date);

            // Properties
            // Table & Column Mappings
            this.ToTable("wd_work_holidays");
            this.Property(t => t.date).HasColumnName("date");
        }
    }
}
