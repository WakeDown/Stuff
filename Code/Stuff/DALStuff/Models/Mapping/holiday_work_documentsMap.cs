using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class holiday_work_documentsMap : EntityTypeConfiguration<holiday_work_documents>
    {
        public holiday_work_documentsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("holiday_work_documents");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.date_start).HasColumnName("date_start");
            this.Property(t => t.date_end).HasColumnName("date_end");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
        }
    }
}
