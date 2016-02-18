using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class request_reasonsMap : EntityTypeConfiguration<RequestReason>
    {
        public request_reasonsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("request_reasons");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
        }
    }
}
