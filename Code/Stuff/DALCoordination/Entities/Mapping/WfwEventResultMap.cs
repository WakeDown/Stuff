using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALCoordination.Entities.Mapping
{
    public class WfwEventResultMap : EntityTypeConfiguration<WfwEventResult>
    {
        public WfwEventResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("WfwEventsResults");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Success).HasColumnName("Success");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
        }
    }
}
