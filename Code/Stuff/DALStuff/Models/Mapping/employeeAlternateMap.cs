using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class employeeAlternateMap : EntityTypeConfiguration<employeeAlternate>
    {
        public employeeAlternateMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("employeeAlternates");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.employeeId).HasColumnName("employeeId");
            this.Property(t => t.alternateEmployeeId).HasColumnName("alternateEmployeeId");
            this.Property(t => t.startDate).HasColumnName("startDate");
            this.Property(t => t.endDate).HasColumnName("endDate");
            this.Property(t => t.notify).HasColumnName("notify");
            this.Property(t => t.unlimited).HasColumnName("unlimited");
            this.Property(t => t.enabled).HasColumnName("enabled");

            // Relationships
            this.HasRequired(t => t.employee)
                .WithMany(t => t.employeeAlternates)
                .HasForeignKey(d => d.alternateEmployeeId);
            this.HasRequired(t => t.employee1)
                .WithMany(t => t.employeeAlternates1)
                .HasForeignKey(d => d.employeeId);

        }
    }
}
