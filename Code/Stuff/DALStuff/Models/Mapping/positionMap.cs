using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class positionMap : EntityTypeConfiguration<position>
    {
        public positionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.creator_sid)
                .HasMaxLength(46);

            this.Property(t => t.name_rod)
                .HasMaxLength(500);

            this.Property(t => t.name_dat)
                .HasMaxLength(500);

            this.Property(t => t.sys_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("positions");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.order_num).HasColumnName("order_num");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.name_rod).HasColumnName("name_rod");
            this.Property(t => t.name_dat).HasColumnName("name_dat");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
        }
    }
}
