using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class photoMap : EntityTypeConfiguration<photo>
    {
        public photoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.path)
                .HasMaxLength(4000);

            this.Property(t => t.picture_name)
                .HasMaxLength(100);

            this.Property(t => t.creator_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("photos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_employee).HasColumnName("id_employee");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.path).HasColumnName("path");
            this.Property(t => t.picture).HasColumnName("picture");
            this.Property(t => t.picture_name).HasColumnName("picture_name");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
        }
    }
}
