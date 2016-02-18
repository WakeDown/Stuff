using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class TestResultMap : EntityTypeConfiguration<TestResult>
    {
        public TestResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Class)
                .IsRequired();

            this.Property(t => t.TestCase)
                .IsRequired();

            this.Property(t => t.Name)
                .HasMaxLength(517);

            this.Property(t => t.TranName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TestResult", "tSQLt");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Class).HasColumnName("Class");
            this.Property(t => t.TestCase).HasColumnName("TestCase");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TranName).HasColumnName("TranName");
            this.Property(t => t.Result).HasColumnName("Result");
            this.Property(t => t.Msg).HasColumnName("Msg");
        }
    }
}
