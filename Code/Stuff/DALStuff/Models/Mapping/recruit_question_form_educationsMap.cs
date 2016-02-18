using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_question_form_educationsMap : EntityTypeConfiguration<recruit_question_form_educations>
    {
        public recruit_question_form_educationsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.place)
                .HasMaxLength(2000);

            this.Property(t => t.study_type)
                .HasMaxLength(50);

            this.Property(t => t.faculty)
                .HasMaxLength(500);

            this.Property(t => t.speciality)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("recruit_question_form_educations");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_question_form).HasColumnName("id_question_form");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.year_start).HasColumnName("year_start");
            this.Property(t => t.year_end).HasColumnName("year_end");
            this.Property(t => t.place).HasColumnName("place");
            this.Property(t => t.study_type).HasColumnName("study_type");
            this.Property(t => t.faculty).HasColumnName("faculty");
            this.Property(t => t.speciality).HasColumnName("speciality");
        }
    }
}
