using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class employees_reportMap : EntityTypeConfiguration<employees_report>
    {
        public employees_reportMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.ad_sid, t.id_manager, t.surname, t.name, t.full_name, t.display_name, t.id_position, t.id_organization, t.id_emp_state, t.id_department, t.id_city, t.emp_state, t.emp_state_sys_name, t.position, t.organization, t.city, t.department, t.male, t.id_position_org, t.position_org, t.has_ad_account, t.date_create });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ad_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.id_manager)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.patronymic)
                .HasMaxLength(50);

            this.Property(t => t.full_name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.display_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.id_position)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_organization)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.email)
                .HasMaxLength(150);

            this.Property(t => t.work_num)
                .HasMaxLength(50);

            this.Property(t => t.mobil_num)
                .HasMaxLength(50);

            this.Property(t => t.id_emp_state)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_department)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_city)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.manager)
                .HasMaxLength(100);

            this.Property(t => t.manager_email)
                .HasMaxLength(150);

            this.Property(t => t.emp_state)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.emp_state_sys_name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.position)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.organization)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.city)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.department)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.male)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_position_org)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.position_org)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.has_ad_account)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ad_login)
                .HasMaxLength(50);

            this.Property(t => t.logon_name)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("employees_report");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.ad_sid).HasColumnName("ad_sid");
            this.Property(t => t.id_manager).HasColumnName("id_manager");
            this.Property(t => t.surname).HasColumnName("surname");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.patronymic).HasColumnName("patronymic");
            this.Property(t => t.full_name).HasColumnName("full_name");
            this.Property(t => t.display_name).HasColumnName("display_name");
            this.Property(t => t.id_position).HasColumnName("id_position");
            this.Property(t => t.id_organization).HasColumnName("id_organization");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.work_num).HasColumnName("work_num");
            this.Property(t => t.mobil_num).HasColumnName("mobil_num");
            this.Property(t => t.id_emp_state).HasColumnName("id_emp_state");
            this.Property(t => t.id_department).HasColumnName("id_department");
            this.Property(t => t.id_city).HasColumnName("id_city");
            this.Property(t => t.date_came).HasColumnName("date_came");
            this.Property(t => t.birth_date).HasColumnName("birth_date");
            this.Property(t => t.manager).HasColumnName("manager");
            this.Property(t => t.manager_email).HasColumnName("manager_email");
            this.Property(t => t.emp_state).HasColumnName("emp_state");
            this.Property(t => t.emp_state_sys_name).HasColumnName("emp_state_sys_name");
            this.Property(t => t.position).HasColumnName("position");
            this.Property(t => t.organization).HasColumnName("organization");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.department).HasColumnName("department");
            this.Property(t => t.male).HasColumnName("male");
            this.Property(t => t.id_position_org).HasColumnName("id_position_org");
            this.Property(t => t.position_org).HasColumnName("position_org");
            this.Property(t => t.has_ad_account).HasColumnName("has_ad_account");
            this.Property(t => t.ad_login).HasColumnName("ad_login");
            this.Property(t => t.date_create).HasColumnName("date_create");
            this.Property(t => t.logon_name).HasColumnName("logon_name");
        }
    }
}
