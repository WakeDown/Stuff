using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
{
    public class WfwExecutionEventMap : EntityTypeConfiguration<WfwExecutionEvent>
    {
        public WfwExecutionEventMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CreaterSid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("WfwExecutionEvents");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ExecutionId).HasColumnName("ExecutionId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.CreaterSid).HasColumnName("CreaterSid");
            this.Property(t => t.ResultId).HasColumnName("ResultId");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.WfwExecutionEvents)
                .HasForeignKey(d => d.CreaterSid);
            this.HasRequired(t => t.WfwDocumentExecution)
                .WithMany(t => t.WfwExecutionEvents)
                .HasForeignKey(d => d.ExecutionId);
            this.HasRequired(t => t.WfwEventResult)
                .WithMany(t => t.WfwExecutionEvents)
                .HasForeignKey(d => d.ResultId);

        }
    }
}
