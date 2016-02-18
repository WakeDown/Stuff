using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_question_form_relativesMap : EntityTypeConfiguration<recruit_question_form_relatives>
    {
        public recruit_question_form_relativesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.relation_degree)
                .HasMaxLength(50);

            this.Property(t => t.name)
                .HasMaxLength(250);

            this.Property(t => t.birth_place)
                .HasMaxLength(500);

            this.Property(t => t.work_place)
                .HasMaxLength(500);

            this.Property(t => t.address)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("recruit_question_form_relatives");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_question_form).HasColumnName("id_question_form");
            this.Property(t => t.relation_degree).HasColumnName("relation_degree");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.birth_date).HasColumnName("birth_date");
            this.Property(t => t.birth_place).HasColumnName("birth_place");
            this.Property(t => t.work_place).HasColumnName("work_place");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
        }
    }
}
