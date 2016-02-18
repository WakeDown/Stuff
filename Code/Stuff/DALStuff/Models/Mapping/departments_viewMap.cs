using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class departments_viewMap : EntityTypeConfiguration<departments_view>
    {
        public departments_viewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.name, t.id_parent, t.id_chief, t.hidden });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.id_parent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.parent)
                .HasMaxLength(150);

            this.Property(t => t.id_chief)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.chief)
                .HasMaxLength(100);

            this.Property(t => t.hidden)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("departments_view");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.id_parent).HasColumnName("id_parent");
            this.Property(t => t.parent).HasColumnName("parent");
            this.Property(t => t.id_chief).HasColumnName("id_chief");
            this.Property(t => t.chief).HasColumnName("chief");
            this.Property(t => t.hidden).HasColumnName("hidden");
        }
    }
}
