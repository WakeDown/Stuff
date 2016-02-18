using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class wd_short_daysMap : EntityTypeConfiguration<wd_short_days>
    {
        public wd_short_daysMap()
        {
            // Primary Key
            this.HasKey(t => t.date);

            // Properties
            // Table & Column Mappings
            this.ToTable("wd_short_days");
            this.Property(t => t.date).HasColumnName("date");
        }
    }
}
