using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class vendor_statesMap : EntityTypeConfiguration<vendor_states>
    {
        public vendor_statesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            this.Property(t => t.name)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("vendor_states");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_vendor).HasColumnName("id_vendor");
            this.Property(t => t.descr).HasColumnName("descr");
            this.Property(t => t.date_end).HasColumnName("date_end");
            this.Property(t => t.id_organization).HasColumnName("id_organization");
            this.Property(t => t.id_language).HasColumnName("id_language");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
            this.Property(t => t.old_id).HasColumnName("old_id");
            this.Property(t => t.pic_data).HasColumnName("pic_data");
            this.Property(t => t.pic_guid).HasColumnName("pic_guid");
            this.Property(t => t.expired_delivery_sent).HasColumnName("expired_delivery_sent");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.new_delivery_sent).HasColumnName("new_delivery_sent");
            this.Property(t => t.update_delivery_sent).HasColumnName("update_delivery_sent");
        }
    }
}
