using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_candidate_came_typesMap : EntityTypeConfiguration<recruit_candidate_came_types>
    {
        public recruit_candidate_came_typesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.sys_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("recruit_candidate_came_types");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
            this.Property(t => t.order_num).HasColumnName("order_num");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.visible).HasColumnName("visible");
        }
    }
}
