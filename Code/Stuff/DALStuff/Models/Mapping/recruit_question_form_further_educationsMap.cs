using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_question_form_further_educationsMap : EntityTypeConfiguration<recruit_question_form_further_educations>
    {
        public recruit_question_form_further_educationsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.date_start)
                .HasMaxLength(50);

            this.Property(t => t.duration)
                .HasMaxLength(50);

            this.Property(t => t.place)
                .HasMaxLength(500);

            this.Property(t => t.cource_name)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("recruit_question_form_further_educations");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.date_start).HasColumnName("date_start");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.place).HasColumnName("place");
            this.Property(t => t.cource_name).HasColumnName("cource_name");
            this.Property(t => t.id_question_form).HasColumnName("id_question_form");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
        }
    }
}
