using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_question_form_languagesMap : EntityTypeConfiguration<recruit_question_form_languages>
    {
        public recruit_question_form_languagesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(150);

            this.Property(t => t.comment)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("recruit_question_form_languages");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.expirence).HasColumnName("expirence");
            this.Property(t => t.comment).HasColumnName("comment");
            this.Property(t => t.id_question_form).HasColumnName("id_question_form");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
        }
    }
}
