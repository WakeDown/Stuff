using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_candidate_resume_filesMap : EntityTypeConfiguration<recruit_candidate_resume_files>
    {
        public recruit_candidate_resume_filesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.data)
                .IsRequired();

            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.file_name)
                .HasMaxLength(500);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("recruit_candidate_resume_files");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_candidate).HasColumnName("id_candidate");
            this.Property(t => t.sid).HasColumnName("sid");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.file_name).HasColumnName("file_name");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
        }
    }
}
