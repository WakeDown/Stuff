using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_vacancy_state_historyMap : EntityTypeConfiguration<recruit_vacancy_state_history>
    {
        public recruit_vacancy_state_historyMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("recruit_vacancy_state_history");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_vacancy).HasColumnName("id_vacancy");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.id_state).HasColumnName("id_state");
            this.Property(t => t.descr).HasColumnName("descr");
        }
    }
}
