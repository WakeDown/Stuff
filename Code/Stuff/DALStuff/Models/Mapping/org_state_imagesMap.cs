using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class org_state_imagesMap : EntityTypeConfiguration<org_state_images>
    {
        public org_state_imagesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.data)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("org_state_images");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_organization).HasColumnName("id_organization");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.data_sid).HasColumnName("data_sid");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
        }
    }
}
