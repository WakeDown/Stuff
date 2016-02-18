using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class documentMap : EntityTypeConfiguration<document>
    {
        public documentMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.creator_sid)
                .IsRequired()
                .HasMaxLength(46);

            this.Property(t => t.deleter_sid)
                .HasMaxLength(46);

            // Table & Column Mappings
            this.ToTable("documents");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.data_sid).HasColumnName("data_sid");
            this.Property(t => t.summary).HasColumnName("summary");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.deleter_sid).HasColumnName("deleter_sid");
        }
    }
}
