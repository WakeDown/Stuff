using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_question_linksMap : EntityTypeConfiguration<recruit_question_links>
    {
        public recruit_question_linksMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("recruit_question_links");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_selection).HasColumnName("id_selection");
            this.Property(t => t.sid).HasColumnName("sid");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
        }
    }
}
