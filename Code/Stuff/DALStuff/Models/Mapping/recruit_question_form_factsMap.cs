using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_question_form_factsMap : EntityTypeConfiguration<recruit_question_form_facts>
    {
        public recruit_question_form_factsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("recruit_question_form_facts");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_question_form).HasColumnName("id_question_form");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.rate).HasColumnName("rate");
        }
    }
}
