using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class position_importMap : EntityTypeConfiguration<position_import>
    {
        public position_importMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name_dat)
                .HasMaxLength(500);

            this.Property(t => t.name_rod)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("position_import");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name_dat).HasColumnName("name_dat");
            this.Property(t => t.name_rod).HasColumnName("name_rod");
        }
    }
}
