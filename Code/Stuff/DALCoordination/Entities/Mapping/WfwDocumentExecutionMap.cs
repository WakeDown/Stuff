using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALCoordination.Entities.Mapping
{
    public class WfwDocumentExecutionMap : EntityTypeConfiguration<WfwDocumentExecution>
    {
        public WfwDocumentExecutionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CreaterSid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("WfwDocumentExecutions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.CreaterSid).HasColumnName("CreaterSid");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.CreatorEmployee)
                .WithMany(t => t.WfwDocumentExecutions)
                .HasForeignKey(d => d.CreaterSid);

        }
    }
}
