using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_vacancies_viewMap : EntityTypeConfiguration<recruit_vacancies_view>
    {
        public recruit_vacancies_viewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.dattim1, t.dattim2, t.enabled, t.creator_sid, t.id_position, t.id_department, t.id_cause, t.id_branch_office, t.creator_name, t.position_name, t.department_name, t.cause_name });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.author_sid)
                .HasMaxLength(46);

            this.Property(t => t.id_position)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_department)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.chief_sid)
                .HasMaxLength(46);

            this.Property(t => t.id_cause)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.matcher_sid)
                .HasMaxLength(46);

            this.Property(t => t.personal_manager_sid)
                .HasMaxLength(46);

            this.Property(t => t.state_changer_sid)
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            this.Property(t => t.id_branch_office)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.creator_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.author_name)
                .HasMaxLength(100);

            this.Property(t => t.chief_name)
                .HasMaxLength(100);

            this.Property(t => t.matcher_name)
                .HasMaxLength(100);

            this.Property(t => t.personal_manager_name)
                .HasMaxLength(100);

            this.Property(t => t.state_changer_name)
                .HasMaxLength(100);

            this.Property(t => t.position_name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.department_name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.cause_name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.state_name)
                .HasMaxLength(150);

            this.Property(t => t.state_background_color)
                .HasMaxLength(50);

            this.Property(t => t.city_name)
                .HasMaxLength(50);

            this.Property(t => t.branch_office_name)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("recruit_vacancies_view");
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
            this.Property(t => t.creator_name).HasColumnName("creator_name");
            this.Property(t => t.author_name).HasColumnName("author_name");
            this.Property(t => t.chief_name).HasColumnName("chief_name");
            this.Property(t => t.matcher_name).HasColumnName("matcher_name");
            this.Property(t => t.personal_manager_name).HasColumnName("personal_manager_name");
            this.Property(t => t.state_changer_name).HasColumnName("state_changer_name");
            this.Property(t => t.position_name).HasColumnName("position_name");
            this.Property(t => t.department_name).HasColumnName("department_name");
            this.Property(t => t.cause_name).HasColumnName("cause_name");
            this.Property(t => t.state_name).HasColumnName("state_name");
            this.Property(t => t.candidate_total_count).HasColumnName("candidate_total_count");
            this.Property(t => t.state_is_active).HasColumnName("state_is_active");
            this.Property(t => t.candidate_cancel_count).HasColumnName("candidate_cancel_count");
            this.Property(t => t.state_background_color).HasColumnName("state_background_color");
            this.Property(t => t.city_name).HasColumnName("city_name");
            this.Property(t => t.branch_office_name).HasColumnName("branch_office_name");
        }
    }
}
