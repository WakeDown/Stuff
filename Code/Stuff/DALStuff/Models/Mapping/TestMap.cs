using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class TestMap : EntityTypeConfiguration<Test>
    {
        public TestMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SchemaId, t.TestClassName, t.ObjectId, t.Name });

            // Properties
            this.Property(t => t.SchemaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TestClassName)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ObjectId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Tests", "tSQLt");
            this.Property(t => t.SchemaId).HasColumnName("SchemaId");
            this.Property(t => t.TestClassName).HasColumnName("TestClassName");
            this.Property(t => t.ObjectId).HasColumnName("ObjectId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
