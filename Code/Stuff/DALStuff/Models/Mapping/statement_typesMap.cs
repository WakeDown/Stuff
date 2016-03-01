using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class statement_typesMap : EntityTypeConfiguration<statement_types>
    {
        public statement_typesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.sys_name)
                .HasMaxLength(50);

            this.Property(t => t.group_sys_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("statement_types");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
            this.Property(t => t.order_num).HasColumnName("order_num");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.group_sys_name).HasColumnName("group_sys_name");
            this.Property(t => t.descr).HasColumnName("descr");
        }
    }
}
