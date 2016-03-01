using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class rest_holiday_transfer_daysMap : EntityTypeConfiguration<rest_holiday_transfer_days>
    {
        public rest_holiday_transfer_daysMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descr)
                .HasMaxLength(500);

            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("rest_holiday_transfer_days");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.descr).HasColumnName("descr");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
        }
    }
}
