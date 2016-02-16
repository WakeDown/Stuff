using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DbContextAutoGenerated.Models.Mapping
{
    public class WfwSchemeMap : EntityTypeConfiguration<WfwScheme>
    {
        public WfwSchemeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("WfwScheme");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.ContinueLAStStage).HasColumnName("ContinueLAStStage");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
        }
    }
}
