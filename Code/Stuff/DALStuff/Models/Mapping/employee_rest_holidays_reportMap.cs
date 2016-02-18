using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class employee_rest_holidays_reportMap : EntityTypeConfiguration<employee_rest_holidays_report>
    {
        public employee_rest_holidays_reportMap()
        {
            // Primary Key
            this.HasKey(t => new { t.employee, t.duration, t.date_create, t.can_edit, t.confirmed });

            // Properties
            this.Property(t => t.department)
                .HasMaxLength(150);

            this.Property(t => t.employee)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.duration)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.confimator)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("employee_rest_holidays_report");
            this.Property(t => t.department).HasColumnName("department");
            this.Property(t => t.employee).HasColumnName("employee");
            this.Property(t => t.year).HasColumnName("year");
            this.Property(t => t.start_date).HasColumnName("start_date");
            this.Property(t => t.end_date).HasColumnName("end_date");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.date_create).HasColumnName("date_create");
            this.Property(t => t.can_edit).HasColumnName("can_edit");
            this.Property(t => t.confirmed).HasColumnName("confirmed");
            this.Property(t => t.confimator).HasColumnName("confimator");
        }
    }
}
