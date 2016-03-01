using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
{
    public class EmployeeRoleMap : EntityTypeConfiguration<EmployeeRole>
    {
        public EmployeeRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.EmployeeSid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("EmployeeRoles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.EmployeeSid).HasColumnName("EmployeeSid");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.EmployeeRoles)
                .HasForeignKey(d => d.EmployeeSid);

        }
    }
}
