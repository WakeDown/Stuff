using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_candidates_viewMap : EntityTypeConfiguration<recruit_candidates_view>
    {
        public recruit_candidates_viewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.surname, t.name, t.display_name, t.male, t.dattim1, t.dattim2, t.enabled, t.creator_sid, t.id_came_resource, t.creator_name });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.patronymic)
                .HasMaxLength(50);

            this.Property(t => t.display_name)
                .IsRequired()
                .HasMaxLength(55);

            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.id_came_resource)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            this.Property(t => t.phone)
                .HasMaxLength(500);

            this.Property(t => t.email)
                .HasMaxLength(500);

            this.Property(t => t.creator_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.came_resource_name)
                .HasMaxLength(50);

            this.Property(t => t.came_type_name)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("recruit_candidates_view");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.surname).HasColumnName("surname");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.patronymic).HasColumnName("patronymic");
            this.Property(t => t.display_name).HasColumnName("display_name");
            this.Property(t => t.male).HasColumnName("male");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.id_came_resource).HasColumnName("id_came_resource");
            this.Property(t => t.birth_date).HasColumnName("birth_date");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
            this.Property(t => t.phone).HasColumnName("phone");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.id_came_type).HasColumnName("id_came_type");
            this.Property(t => t.creator_name).HasColumnName("creator_name");
            this.Property(t => t.came_resource_name).HasColumnName("came_resource_name");
            this.Property(t => t.came_type_name).HasColumnName("came_type_name");
        }
    }
}
