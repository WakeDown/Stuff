using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class employeeRoleMap : EntityTypeConfiguration<employeeRole>
    {
        public employeeRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("EmployeeRoles");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.employeeId).HasColumnName("employeeId");
            this.Property(t => t.enabled).HasColumnName("enabled");

            // Relationships
            this.HasRequired(t => t.employee)
                .WithMany(t => t.EmployeeRoles)
                .HasForeignKey(d => d.employeeId);

        }
    }
}
