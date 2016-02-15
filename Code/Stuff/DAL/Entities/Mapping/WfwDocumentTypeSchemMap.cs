using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities.Models;

namespace DAL.Entities.Mapping
{
    public class WfwDocumentTypeSchemMap : EntityTypeConfiguration<WfwDocumentTypeSchem>
    {
        public WfwDocumentTypeSchemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("WfwDocumentTypesSchems");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DocumentTypeId).HasColumnName("DocumentTypeId");
            this.Property(t => t.SchemeId).HasColumnName("SchemeId");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            // Relationships
            this.HasRequired(t => t.DocumentType)
                .WithMany(t => t.WfwDocumentTypesSchems)
                .HasForeignKey(d => d.DocumentTypeId);
            this.HasRequired(t => t.WfwScheme)
                .WithMany(t => t.WfwDocumentTypesSchems)
                .HasForeignKey(d => d.SchemeId);

        }
    }
}
