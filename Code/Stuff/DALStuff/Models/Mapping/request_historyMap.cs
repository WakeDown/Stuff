using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class request_historyMap : EntityTypeConfiguration<request_history>
    {
        public request_historyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CrteatorSid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("request_history");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RequestId).HasColumnName("RequestId");
            this.Property(t => t.RequestOldStatusId).HasColumnName("RequestOldStatusId");
            this.Property(t => t.RequestNewStatusId).HasColumnName("RequestNewStatusId");
            this.Property(t => t.CrteatorSid).HasColumnName("CrteatorSid");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasRequired(t => t.Creator)
                .WithMany(t => t.request_history)
                .HasForeignKey(d => d.CrteatorSid);
            this.HasRequired(t => t.NewRequestStatuses)
                .WithMany(t => t.request_history_to_new_status)
                .HasForeignKey(d => d.RequestNewStatusId);
            this.HasRequired(t => t.OldRequestStatuses)
                .WithMany(t => t.request_history_to_old_status)
                .HasForeignKey(d => d.RequestOldStatusId);
            this.HasRequired(t => t.Request)
                .WithMany(t => t.RequestHistoryes)
                .HasForeignKey(d => d.RequestId);
        }
    }
}
