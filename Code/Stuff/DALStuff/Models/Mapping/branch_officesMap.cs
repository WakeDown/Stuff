using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class branch_officesMap : EntityTypeConfiguration<branch_offices>
    {
        public branch_officesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("branch_offices");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.order_num).HasColumnName("order_num");
        }
    }
}
