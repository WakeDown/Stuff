using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class TestClassMap : EntityTypeConfiguration<TestClass>
    {
        public TestClassMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Name, t.SchemaId });

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.SchemaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TestClasses", "tSQLt");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SchemaId).HasColumnName("SchemaId");
        }
    }
}
