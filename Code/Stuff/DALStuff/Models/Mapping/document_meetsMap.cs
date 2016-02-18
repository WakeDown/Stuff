using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class document_meetsMap : EntityTypeConfiguration<document_meets>
    {
        public document_meetsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.employee_sid)
                .IsRequired()
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("document_meets");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_doc_meet_link).HasColumnName("id_doc_meet_link");
            this.Property(t => t.employee_sid).HasColumnName("employee_sid");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
        }
    }
}
