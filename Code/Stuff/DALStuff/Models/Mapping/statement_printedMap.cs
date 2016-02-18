using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class statement_printedMap : EntityTypeConfiguration<statement_printed>
    {
        public statement_printedMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.employee_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            this.Property(t => t.confirmator_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("statement_printed");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_statement_type).HasColumnName("id_statement_type");
            this.Property(t => t.employee_sid).HasColumnName("employee_sid");
            this.Property(t => t.date_begin).HasColumnName("date_begin");
            this.Property(t => t.date_end).HasColumnName("date_end");
            this.Property(t => t.duration_hours).HasColumnName("duration_hours");
            this.Property(t => t.duration_days).HasColumnName("duration_days");
            this.Property(t => t.cause).HasColumnName("cause");
            this.Property(t => t.id_department).HasColumnName("id_department");
            this.Property(t => t.id_organization).HasColumnName("id_organization");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
            this.Property(t => t.confirmed).HasColumnName("confirmed");
            this.Property(t => t.date_confirm).HasColumnName("date_confirm");
            this.Property(t => t.confirmator_sid).HasColumnName("confirmator_sid");
        }
    }
}
