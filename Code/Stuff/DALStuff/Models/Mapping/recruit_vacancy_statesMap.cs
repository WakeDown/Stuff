using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_vacancy_statesMap : EntityTypeConfiguration<recruit_vacancy_states>
    {
        public recruit_vacancy_statesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.sys_name)
                .HasMaxLength(50);

            this.Property(t => t.background_color)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("recruit_vacancy_states");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
            this.Property(t => t.order_num).HasColumnName("order_num");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.is_active).HasColumnName("is_active");
            this.Property(t => t.is_end).HasColumnName("is_end");
            this.Property(t => t.background_color).HasColumnName("background_color");
        }
    }
}
