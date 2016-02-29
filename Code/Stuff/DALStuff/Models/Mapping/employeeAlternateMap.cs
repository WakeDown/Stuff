using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class employeeAlternateMap : EntityTypeConfiguration<EmployeeAlternate>
    {
        public employeeAlternateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EmployeeSid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.AlternateEmployeeSid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("employeeAlternates");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.EmployeeSid).HasColumnName("employeeSid");
            this.Property(t => t.AlternateEmployeeSid).HasColumnName("alternateEmployeeSid");
            this.Property(t => t.StartDate).HasColumnName("startDate");
            this.Property(t => t.EndDate).HasColumnName("endDate");
            this.Property(t => t.Notify).HasColumnName("notify");
            this.Property(t => t.Unlimited).HasColumnName("unlimited");
            this.Property(t => t.Enabled).HasColumnName("enabled");

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
