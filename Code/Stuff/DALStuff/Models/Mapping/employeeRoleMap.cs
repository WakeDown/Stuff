using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class employeeRoleMap : EntityTypeConfiguration<EmployeeRole>
    {
        public employeeRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("EmployeeRoles");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.EmployeeSid).HasColumnName("employeeSid");
            this.Property(t => t.Enabled).HasColumnName("enabled");

            // Relationships
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.EmployeeRoles)
                .HasForeignKey(d => d.EmployeeSid);

        }
    }
}
