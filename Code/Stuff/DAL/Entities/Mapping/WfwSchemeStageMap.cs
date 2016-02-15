using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
{
    public class WfwSchemeStageMap : EntityTypeConfiguration<WfwSchemeStage>
    {
        public WfwSchemeStageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("WfwSchemeStage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.CoordinatorId).HasColumnName("CoordinatorId");
            this.Property(t => t.SchemeId).HasColumnName("SchemeId");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasOptional(t => t.EmployeeRole)
                .WithMany(t => t.WfwSchemeStages)
                .HasForeignKey(d => d.RoleId);
            this.HasRequired(t => t.WfwScheme)
                .WithMany(t => t.WfwSchemeStages)
                .HasForeignKey(d => d.SchemeId);

        }
    }
}
