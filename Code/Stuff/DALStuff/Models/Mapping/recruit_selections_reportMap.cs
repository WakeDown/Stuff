using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class recruit_selections_reportMap : EntityTypeConfiguration<recruit_selections_report>
    {
        public recruit_selections_reportMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_candidate, t.id_vacancy, t.dattim1, t.dattim2, t.enabled, t.creator_sid, t.candidate_display_name, t.candidate_male, t.state_name, t.show_next_state_btn, t.state_is_active, t.state_is_accept, t.candidate_surname, t.candidate_name, t.vacancy_position_name, t.vacancy_department_name, t.vacancy_date_create, t.vacancy_cause_name, t.vacancy_creator_name, t.vacancy_id_branch_office });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_candidate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_vacancy)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            this.Property(t => t.state_changer_sid)
                .HasMaxLength(46);

            this.Property(t => t.candidate_display_name)
                .IsRequired()
                .HasMaxLength(55);

            this.Property(t => t.candidate_phone)
                .HasMaxLength(500);

            this.Property(t => t.candidate_email)
                .HasMaxLength(500);

            this.Property(t => t.state_name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.state_changer_name)
                .HasMaxLength(100);

            this.Property(t => t.next_state_name)
                .HasMaxLength(150);

            this.Property(t => t.next_state_btn_name)
                .HasMaxLength(150);

            this.Property(t => t.candidate_surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.candidate_name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.candidate_patronymic)
                .HasMaxLength(50);

            this.Property(t => t.vacancy_position_name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.vacancy_department_name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.vacancy_personal_manager_name)
                .HasMaxLength(100);

            this.Property(t => t.vacancy_state_name)
                .HasMaxLength(150);

            this.Property(t => t.vacancy_state_changer_name)
                .HasMaxLength(100);

            this.Property(t => t.vacancy_cause_name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.vacancy_creator_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.candidate_file_name)
                .HasMaxLength(500);

            this.Property(t => t.candidate_came_type_name)
                .HasMaxLength(150);

            this.Property(t => t.came_type_name)
                .HasMaxLength(150);

            this.Property(t => t.vacancy_city_name)
                .HasMaxLength(50);

            this.Property(t => t.candidate_came_resource_name)
                .HasMaxLength(50);

            this.Property(t => t.vacancy_id_branch_office)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.branch_office_name)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("recruit_selections_report");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_candidate).HasColumnName("id_candidate");
            this.Property(t => t.id_vacancy).HasColumnName("id_vacancy");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
            this.Property(t => t.id_state).HasColumnName("id_state");
            this.Property(t => t.state_change_date).HasColumnName("state_change_date");
            this.Property(t => t.state_changer_sid).HasColumnName("state_changer_sid");
            this.Property(t => t.state_descr).HasColumnName("state_descr");
            this.Property(t => t.id_came_type).HasColumnName("id_came_type");
            this.Property(t => t.candidate_display_name).HasColumnName("candidate_display_name");
            this.Property(t => t.candidate_birth_date).HasColumnName("candidate_birth_date");
            this.Property(t => t.candidate_phone).HasColumnName("candidate_phone");
            this.Property(t => t.candidate_email).HasColumnName("candidate_email");
            this.Property(t => t.candidate_male).HasColumnName("candidate_male");
            this.Property(t => t.state_name).HasColumnName("state_name");
            this.Property(t => t.state_changer_name).HasColumnName("state_changer_name");
            this.Property(t => t.next_state_id).HasColumnName("next_state_id");
            this.Property(t => t.next_state_name).HasColumnName("next_state_name");
            this.Property(t => t.show_next_state_btn).HasColumnName("show_next_state_btn");
            this.Property(t => t.state_is_active).HasColumnName("state_is_active");
            this.Property(t => t.next_state_btn_name).HasColumnName("next_state_btn_name");
            this.Property(t => t.state_is_accept).HasColumnName("state_is_accept");
            this.Property(t => t.candidate_surname).HasColumnName("candidate_surname");
            this.Property(t => t.candidate_name).HasColumnName("candidate_name");
            this.Property(t => t.candidate_patronymic).HasColumnName("candidate_patronymic");
            this.Property(t => t.vacancy_position_name).HasColumnName("vacancy_position_name");
            this.Property(t => t.vacancy_department_name).HasColumnName("vacancy_department_name");
            this.Property(t => t.vacancy_candidate_total_count).HasColumnName("vacancy_candidate_total_count");
            this.Property(t => t.vacancy_candidate_cancel_count).HasColumnName("vacancy_candidate_cancel_count");
            this.Property(t => t.vacancy_personal_manager_name).HasColumnName("vacancy_personal_manager_name");
            this.Property(t => t.vacancy_date_create).HasColumnName("vacancy_date_create");
            this.Property(t => t.vacancy_state_name).HasColumnName("vacancy_state_name");
            this.Property(t => t.vacancy_state_change_date).HasColumnName("vacancy_state_change_date");
            this.Property(t => t.vacancy_state_changer_name).HasColumnName("vacancy_state_changer_name");
            this.Property(t => t.vacancy_cause_name).HasColumnName("vacancy_cause_name");
            this.Property(t => t.vacancy_creator_name).HasColumnName("vacancy_creator_name");
            this.Property(t => t.candidate_file_name).HasColumnName("candidate_file_name");
            this.Property(t => t.candidate_file_sid).HasColumnName("candidate_file_sid");
            this.Property(t => t.candidate_came_type_name).HasColumnName("candidate_came_type_name");
            this.Property(t => t.came_type_name).HasColumnName("came_type_name");
            this.Property(t => t.vacancy_id_city).HasColumnName("vacancy_id_city");
            this.Property(t => t.vacancy_city_name).HasColumnName("vacancy_city_name");
            this.Property(t => t.candidate_came_resource_name).HasColumnName("candidate_came_resource_name");
            this.Property(t => t.vacancy_id_branch_office).HasColumnName("vacancy_id_branch_office");
            this.Property(t => t.branch_office_name).HasColumnName("branch_office_name");
        }
    }
}
