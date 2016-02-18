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
            // Table & Column Mappings
            this.ToTable("employeeAlternates");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.EmployeeId).HasColumnName("employeeId");
            this.Property(t => t.AlternateEmployeeId).HasColumnName("alternateEmployeeId");
            this.Property(t => t.StartDate).HasColumnName("startDate");
            this.Property(t => t.EndDate).HasColumnName("endDate");
            this.Property(t => t.Notify).HasColumnName("notify");
            this.Property(t => t.Unlimited).HasColumnName("unlimited");
            this.Property(t => t.Enabled).HasColumnName("enabled");

            // Relationships
            this.HasRequired(t => t.Alternate)
                .WithMany(t => t.EmployeeReplaceds)
                .HasForeignKey(d => d.AlternateEmployeeId);
            this.HasRequired(t => t.Replaced)
                .WithMany(t => t.EmployeeAlternates)
                .HasForeignKey(d => d.EmployeeId);
        }
    }
}
