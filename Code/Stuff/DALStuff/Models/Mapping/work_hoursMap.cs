using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class work_hoursMap : EntityTypeConfiguration<work_hours>
    {
        public work_hoursMap()
        {
            // Primary Key
            this.HasKey(t => t.id_time);

            // Properties
            this.Property(t => t.sys_name)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("work_hours");
            this.Property(t => t.id_time).HasColumnName("id_time");
            this.Property(t => t.time).HasColumnName("time");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
        }
    }
}
