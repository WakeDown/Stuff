using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class departmentMap : EntityTypeConfiguration<department>
    {
        public departmentMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.creator_sid)
                .HasMaxLength(46);

            this.Property(t => t.sys_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("departments");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.id_parent).HasColumnName("id_parent");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.id_chief).HasColumnName("id_chief");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.hidden).HasColumnName("hidden");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
        }
    }
}
