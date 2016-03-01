using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_selection_statesMap : EntityTypeConfiguration<recruit_selection_states>
    {
        public recruit_selection_statesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.sys_name)
                .HasMaxLength(50);

            this.Property(t => t.btn_name)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("recruit_selection_states");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
            this.Property(t => t.order_num).HasColumnName("order_num");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.show_next_state_btn).HasColumnName("show_next_state_btn");
            this.Property(t => t.is_active).HasColumnName("is_active");
            this.Property(t => t.btn_name).HasColumnName("btn_name");
            this.Property(t => t.is_accept).HasColumnName("is_accept");
            this.Property(t => t.is_cancel).HasColumnName("is_cancel");
        }
    }
}
