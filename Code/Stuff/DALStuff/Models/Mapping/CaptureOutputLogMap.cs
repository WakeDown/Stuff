using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class CaptureOutputLogMap : EntityTypeConfiguration<CaptureOutputLog>
    {
        public CaptureOutputLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CaptureOutputLog", "tSQLt");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OutputText).HasColumnName("OutputText");
        }
    }
}
