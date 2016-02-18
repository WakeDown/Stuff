using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
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
            this.Property(t => t.ContinueLastStage).HasColumnName("ContinueLastStage");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
        }
    }
}
