using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALCoordination.Entities.Mapping
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

            this.Property(t => t.CoordinatorSid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("WfwSchemeStage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.CoordinatorSid).HasColumnName("CoordinatorSid");
            this.Property(t => t.SchemeId).HasColumnName("SchemeId");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.Coordinator)
                .WithMany(t => t.WfwSchemeStages)
                .HasForeignKey(d => d.CoordinatorSid);
            this.HasOptional(t => t.EmployeeRole)
                .WithMany(t => t.WfwSchemeStages)
                .HasForeignKey(d => d.RoleId);
            this.HasRequired(t => t.WfwScheme)
                .WithMany(t => t.WfwSchemeStages)
                .HasForeignKey(d => d.SchemeId);

        }
    }
}
