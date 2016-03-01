using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class rest_holidaysMap : EntityTypeConfiguration<rest_holidays>
    {
        public rest_holidaysMap()
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

            this.Property(t => t.can_edit_creator_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("rest_holidays");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.employee_sid).HasColumnName("employee_sid");
            this.Property(t => t.start_date).HasColumnName("start_date");
            this.Property(t => t.end_date).HasColumnName("end_date");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.can_edit).HasColumnName("can_edit");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.year).HasColumnName("year");
            this.Property(t => t.confirmed).HasColumnName("confirmed");
            this.Property(t => t.confirmator_sid).HasColumnName("confirmator_sid");
            this.Property(t => t.can_edit_creator_sid).HasColumnName("can_edit_creator_sid");
        }
    }
}
