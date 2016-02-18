using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class Private_RenamedObjectLogMap : EntityTypeConfiguration<Private_RenamedObjectLog>
    {
        public Private_RenamedObjectLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OriginalName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Private_RenamedObjectLog", "tSQLt");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ObjectId).HasColumnName("ObjectId");
            this.Property(t => t.OriginalName).HasColumnName("OriginalName");
        }
    }
}
