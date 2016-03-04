using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class requestMap : EntityTypeConfiguration<request>
    {
        public requestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("requests");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.IdPosition).HasColumnName("id_position");
            this.Property(t => t.IdReason).HasColumnName("id_reason");
            this.Property(t => t.Aim).HasColumnName("aim");
            this.Property(t => t.SidManager).HasColumnName("sid_manager");
            this.Property(t => t.SidTeacher).HasColumnName("sid_teacher");
            this.Property(t => t.IdDepartment).HasColumnName("id_department");
            this.Property(t => t.IsSubordinates).HasColumnName("is_subordinates");
            this.Property(t => t.Subordinates).HasColumnName("subordinates");
            this.Property(t => t.Functions).HasColumnName("functions");
            this.Property(t => t.Interactions).HasColumnName("interactions");
            this.Property(t => t.IsInstructions).HasColumnName("is_instructions");
            this.Property(t => t.SuccessRates).HasColumnName("success_rates");
            this.Property(t => t.PlanToTest).HasColumnName("plan_to_test");
            this.Property(t => t.PlanAfterTest).HasColumnName("plan_after_test");
            this.Property(t => t.WorkPlace).HasColumnName("work_place");
            this.Property(t => t.WorkMode).HasColumnName("work_mode");
            this.Property(t => t.Holiday).HasColumnName("holiday");
            this.Property(t => t.Hospital).HasColumnName("hospital");
            this.Property(t => t.BusinessTrip).HasColumnName("business_trip");
            this.Property(t => t.OvertimeWork).HasColumnName("overtime_work");
            this.Property(t => t.Compensations).HasColumnName("compensations");
            this.Property(t => t.Probation).HasColumnName("probation");
            this.Property(t => t.SalaryToTest).HasColumnName("salary_to_test");
            this.Property(t => t.SalaryAfterTest).HasColumnName("salary_after_test");
            this.Property(t => t.Bonuses).HasColumnName("bonuses");
            this.Property(t => t.Sex).HasColumnName("sex");
            this.Property(t => t.AgeFrom).HasColumnName("age_from");
            this.Property(t => t.AgeTo).HasColumnName("age_to");
            this.Property(t => t.Education).HasColumnName("education");
            this.Property(t => t.LastWork).HasColumnName("last_work");
            this.Property(t => t.Requirements).HasColumnName("requirements");
            this.Property(t => t.Knowledge).HasColumnName("knowledge");
            this.Property(t => t.Suggestions).HasColumnName("suggestions");
            //this.Property(t => t.Workplace).HasColumnName("workplace");
            this.Property(t => t.IsFurniture).HasColumnName("is_furniture");
            this.Property(t => t.Furniture).HasColumnName("furniture");
            this.Property(t => t.IsPc).HasColumnName("is_pc");
            this.Property(t => t.IsTelephone).HasColumnName("is_telephone");
            this.Property(t => t.IsEthalon).HasColumnName("is_ethalon");
            this.Property(t => t.CreateDatetime).HasColumnName("create_datetime");
            this.Property(t => t.LastChangeDatetime).HasColumnName("last_change_datetime");
            this.Property(t => t.SidContactPerson).HasColumnName("sid_contact_person");
            this.Property(t => t.SidResponsiblePerson).HasColumnName("sid_responsible_person");
            this.Property(t => t.IdStatus).HasColumnName("id_status").IsRequired();
            this.Property(t => t.HaveCoordination).HasColumnName("HaveCoordination");
            this.Property(t => t.CoordinationPaused).HasColumnName("CoordinationPaused");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasOptional(t => t.Department)
                .WithMany(t => t.requests)
                .HasForeignKey(d => d.IdDepartment);
            this.HasOptional(t => t.ContactPerson)
                .WithMany(t => t.RequestsFromContactPersonRole)
                .HasForeignKey(d => d.SidContactPerson);
            this.HasOptional(t => t.ManagerPersom)
                .WithMany(t => t.RequestsFromManagerRole)
                .HasForeignKey(d => d.SidManager);
            this.HasOptional(t => t.ResponsiblePerson)
                .WithMany(t => t.RequestsFromResponsibleRole)
                .HasForeignKey(d => d.SidResponsiblePerson);
            this.HasOptional(t => t.TeacherPerson)
                .WithMany(t => t.RequestsFromTeacherRole)
                .HasForeignKey(d => d.SidTeacher);
            this.HasOptional(t => t.Position)
                .WithMany(t => t.requests)
                .HasForeignKey(d => d.IdPosition);
            this.HasOptional(t => t.RequestReason)
                .WithMany(t => t.Requests)
                .HasForeignKey(d => d.IdReason);
            this.HasRequired(t => t.RequestStatus)
                .WithMany(t => t.requests)
                .HasForeignKey(d => d.IdStatus);
        }
    }
}
