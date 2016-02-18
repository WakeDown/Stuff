using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class requestMap : EntityTypeConfiguration<request>
    {
        public requestMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("requests");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_position).HasColumnName("id_position");
            this.Property(t => t.id_reason).HasColumnName("id_reason");
            this.Property(t => t.aim).HasColumnName("aim");
            this.Property(t => t.id_manager).HasColumnName("id_manager");
            this.Property(t => t.id_teacher).HasColumnName("id_teacher");
            this.Property(t => t.id_department).HasColumnName("id_department");
            this.Property(t => t.is_subordinates).HasColumnName("is_subordinates");
            this.Property(t => t.subordinates).HasColumnName("subordinates");
            this.Property(t => t.functions).HasColumnName("functions");
            this.Property(t => t.interactions).HasColumnName("interactions");
            this.Property(t => t.is_instructions).HasColumnName("is_instructions");
            this.Property(t => t.success_rates).HasColumnName("success_rates");
            this.Property(t => t.plan_to_test).HasColumnName("plan_to_test");
            this.Property(t => t.plan_after_test).HasColumnName("plan_after_test");
            this.Property(t => t.work_place).HasColumnName("work_place");
            this.Property(t => t.work_mode).HasColumnName("work_mode");
            this.Property(t => t.holiday).HasColumnName("holiday");
            this.Property(t => t.hospital).HasColumnName("hospital");
            this.Property(t => t.business_trip).HasColumnName("business_trip");
            this.Property(t => t.overtime_work).HasColumnName("overtime_work");
            this.Property(t => t.compensations).HasColumnName("compensations");
            this.Property(t => t.probation).HasColumnName("probation");
            this.Property(t => t.salary_to_test).HasColumnName("salary_to_test");
            this.Property(t => t.salary_after_test).HasColumnName("salary_after_test");
            this.Property(t => t.bonuses).HasColumnName("bonuses");
            this.Property(t => t.sex).HasColumnName("sex");
            this.Property(t => t.age_from).HasColumnName("age_from");
            this.Property(t => t.age_to).HasColumnName("age_to");
            this.Property(t => t.education).HasColumnName("education");
            this.Property(t => t.last_work).HasColumnName("last_work");
            this.Property(t => t.requirements).HasColumnName("requirements");
            this.Property(t => t.knowledge).HasColumnName("knowledge");
            this.Property(t => t.suggestions).HasColumnName("suggestions");
            this.Property(t => t.workplace).HasColumnName("workplace");
            this.Property(t => t.is_furniture).HasColumnName("is_furniture");
            this.Property(t => t.furniture).HasColumnName("furniture");
            this.Property(t => t.is_pc).HasColumnName("is_pc");
            this.Property(t => t.is_telephone).HasColumnName("is_telephone");
            this.Property(t => t.is_ethalon).HasColumnName("is_ethalon");
            this.Property(t => t.appearance).HasColumnName("appearance");
            this.Property(t => t.id_contact_person).HasColumnName("id_contact_person");
            this.Property(t => t.id_responsible_person).HasColumnName("id_responsible_person");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasOptional(t => t.department)
                .WithMany(t => t.requests)
                .HasForeignKey(d => d.id_department);
            this.HasOptional(t => t.contact_person)
                .WithMany(t => t.requests)
                .HasForeignKey(d => d.id_contact_person);
            this.HasOptional(t => t.manager)
                .WithMany(t => t.requests1)
                .HasForeignKey(d => d.id_manager);
            this.HasOptional(t => t.responsible_person)
                .WithMany(t => t.requests2)
                .HasForeignKey(d => d.id_responsible_person);
            this.HasOptional(t => t.employee3)
                .WithMany(t => t.requests3)
                .HasForeignKey(d => d.id_teacher);
            this.HasOptional(t => t.position)
                .WithMany(t => t.requests)
                .HasForeignKey(d => d.id_position);
            this.HasOptional(t => t.request_reasons)
                .WithMany(t => t.requests)
                .HasForeignKey(d => d.id_reason);

        }
    }
}
