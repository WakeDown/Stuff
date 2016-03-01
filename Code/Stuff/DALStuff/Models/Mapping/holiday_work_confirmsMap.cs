using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class holiday_work_confirmsMap : EntityTypeConfiguration<holiday_work_confirms>
    {
        public holiday_work_confirmsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.employee_sid)
                .HasMaxLength(46);

            this.Property(t => t.full_name)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("holiday_work_confirms");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.employee_sid).HasColumnName("employee_sid");
            this.Property(t => t.id_hw_document).HasColumnName("id_hw_document");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.full_name).HasColumnName("full_name");
            this.Property(t => t.enabled).HasColumnName("enabled");
        }
    }
}
