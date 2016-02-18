using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_selectionsMap : EntityTypeConfiguration<recruit_selections>
    {
        public recruit_selectionsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            this.Property(t => t.state_changer_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("recruit_selections");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_candidate).HasColumnName("id_candidate");
            this.Property(t => t.id_vacancy).HasColumnName("id_vacancy");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
            this.Property(t => t.id_state).HasColumnName("id_state");
            this.Property(t => t.state_change_date).HasColumnName("state_change_date");
            this.Property(t => t.state_changer_sid).HasColumnName("state_changer_sid");
            this.Property(t => t.state_descr).HasColumnName("state_descr");
            this.Property(t => t.id_came_type).HasColumnName("id_came_type");
        }
    }
}
