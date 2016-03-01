using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.AdSid);

            // Properties
            this.Property(t => t.AdSid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Patronymic)
                .HasMaxLength(50);

            this.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(150);

            this.Property(t => t.WorkNum)
                .HasMaxLength(50);

            this.Property(t => t.MobilNum)
                .HasMaxLength(50);

            this.Property(t => t.CreatorSid)
                .HasMaxLength(46);

            this.Property(t => t.AdLogin)
                .HasMaxLength(50);

            this.Property(t => t.FullNameDat)
                .HasMaxLength(150);

            this.Property(t => t.FullNameRod)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Employees");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.AdSid).HasColumnName("ad_sid");
            this.Property(t => t.IdManager).HasColumnName("id_manager");
            this.Property(t => t.Surname).HasColumnName("surname");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.Patronymic).HasColumnName("patronymic");
            this.Property(t => t.FullName).HasColumnName("full_name");
            this.Property(t => t.DisplayName).HasColumnName("display_name");
            this.Property(t => t.IdPosition).HasColumnName("id_position");
            this.Property(t => t.IdOrganization).HasColumnName("id_organization");
            this.Property(t => t.Email).HasColumnName("email");
            this.Property(t => t.WorkNum).HasColumnName("work_num");
            this.Property(t => t.MobilNum).HasColumnName("mobil_num");
            this.Property(t => t.IdEmpState).HasColumnName("id_emp_state");
            this.Property(t => t.IdDepartment).HasColumnName("id_department");
            this.Property(t => t.IdCity).HasColumnName("id_city");
            this.Property(t => t.Enabled).HasColumnName("enabled");
            this.Property(t => t.Dattim1).HasColumnName("dattim1");
            this.Property(t => t.Dattim2).HasColumnName("dattim2");
            this.Property(t => t.DateCame).HasColumnName("date_came");
            this.Property(t => t.BirthDate).HasColumnName("birth_date");
            this.Property(t => t.Male).HasColumnName("male");
            this.Property(t => t.IdPositionOrg).HasColumnName("id_position_org");
            this.Property(t => t.HasAdAccount).HasColumnName("has_ad_account");
            this.Property(t => t.CreatorSid).HasColumnName("creator_sid");
            this.Property(t => t.AdLogin).HasColumnName("ad_login");
            this.Property(t => t.DateFired).HasColumnName("date_fired");
            this.Property(t => t.FullNameDat).HasColumnName("full_name_dat");
            this.Property(t => t.FullNameRod).HasColumnName("full_name_rod");
            this.Property(t => t.NewvbieDelivery).HasColumnName("newvbie_delivery");
            this.Property(t => t.IdBudget).HasColumnName("id_budget");
        }
    }
}
