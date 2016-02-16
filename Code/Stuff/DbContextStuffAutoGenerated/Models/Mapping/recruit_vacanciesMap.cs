using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DbContextStuffAutoGenerated.Models.Mapping
{
    public class recruit_vacanciesMap : EntityTypeConfiguration<recruit_vacancies>
    {
        public recruit_vacanciesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.author_sid)
                .HasMaxLength(46);

            this.Property(t => t.chief_sid)
                .HasMaxLength(46);

            this.Property(t => t.matcher_sid)
                .HasMaxLength(46);

            this.Property(t => t.personal_manager_sid)
                .HasMaxLength(46);

            this.Property(t => t.state_changer_sid)
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("recruit_vacancies");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.author_sid).HasColumnName("author_sid");
            this.Property(t => t.id_position).HasColumnName("id_position");
            this.Property(t => t.id_department).HasColumnName("id_department");
            this.Property(t => t.chief_sid).HasColumnName("chief_sid");
            this.Property(t => t.id_cause).HasColumnName("id_cause");
            this.Property(t => t.matcher_sid).HasColumnName("matcher_sid");
            this.Property(t => t.personal_manager_sid).HasColumnName("personal_manager_sid");
            this.Property(t => t.deadline_date).HasColumnName("deadline_date");
            this.Property(t => t.end_date).HasColumnName("end_date");
            this.Property(t => t.id_state).HasColumnName("id_state");
            this.Property(t => t.state_change_date).HasColumnName("state_change_date");
            this.Property(t => t.state_changer_sid).HasColumnName("state_changer_sid");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
            this.Property(t => t.order_end_date).HasColumnName("order_end_date");
            this.Property(t => t.claim_end_date).HasColumnName("claim_end_date");
            this.Property(t => t.id_city).HasColumnName("id_city");
            this.Property(t => t.id_branch_office).HasColumnName("id_branch_office");
        }
    }
}
