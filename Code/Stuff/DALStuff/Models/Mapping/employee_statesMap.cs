using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class employee_statesMap : EntityTypeConfiguration<employee_states>
    {
        public employee_statesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.sys_name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("employee_states");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.display_in_list).HasColumnName("display_in_list");
            this.Property(t => t.order_num).HasColumnName("order_num");
        }
    }
}
