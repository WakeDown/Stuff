using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
{
    public class WfwDocumentExecutionMap : EntityTypeConfiguration<WfwDocumentExecution>
    {
        public WfwDocumentExecutionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("WfwDocumentExecutions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Stage).HasColumnName("Stage");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.CreaterId).HasColumnName("CreaterId");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.employee)
                .WithMany(t => t.WfwDocumentExecutions)
                .HasForeignKey(d => d.CreaterId);

        }
    }
}
