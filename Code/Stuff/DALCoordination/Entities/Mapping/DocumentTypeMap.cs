using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALCoordination.Entities.Mapping
{
    public class DocumentTypeMap : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("DocumentTypes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SchemeId).HasColumnName("SchemeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.WfwScheme)
                .WithMany(t => t.DocumentTypes)
                .HasForeignKey(d => d.SchemeId);
        }
    }
}
