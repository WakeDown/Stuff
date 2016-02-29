using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
{
    public class EmployeeAlternateMap : EntityTypeConfiguration<EmployeeAlternate>
    {
        public EmployeeAlternateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.EmployeeSid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.AlternateEmployeeSid)
                .IsRequired()
                .HasMaxLength(46);
            // Properties
            // Table & Column Mappings
            this.ToTable("EmployeeAlternates");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmployeeSid).HasColumnName("EmployeeSid");
            this.Property(t => t.AlternateEmployeeSid).HasColumnName("AlternateEmployeeSid");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Notify).HasColumnName("Notify");
            this.Property(t => t.Unlimited).HasColumnName("Unlimited");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.Alternate)
                .WithMany(t => t.EmployeeReplaceds)
                .HasForeignKey(d => d.AlternateEmployeeSid);
            this.HasRequired(t => t.Replaced)
                .WithMany(t => t.EmployeeAlternates)
                .HasForeignKey(d => d.EmployeeSid);
        }
    }
}
