using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DALStuff.Models.Mapping
{
    public class organizationMap : EntityTypeConfiguration<organization>
    {
        public organizationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.full_name)
                .HasMaxLength(500);

            this.Property(t => t.creator_sid)
                .HasMaxLength(46);

            this.Property(t => t.address_ur)
                .HasMaxLength(500);

            this.Property(t => t.address_fact)
                .HasMaxLength(500);

            this.Property(t => t.phone)
                .HasMaxLength(50);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.inn)
                .HasMaxLength(12);

            this.Property(t => t.kpp)
                .HasMaxLength(20);

            this.Property(t => t.ogrn)
                .HasMaxLength(20);

            this.Property(t => t.rs)
                .HasMaxLength(50);

            this.Property(t => t.bank)
                .HasMaxLength(500);

            this.Property(t => t.ks)
                .HasMaxLength(50);

            this.Property(t => t.bik)
                .HasMaxLength(50);

            this.Property(t => t.okpo)
                .HasMaxLength(50);

            this.Property(t => t.okved)
                .HasMaxLength(50);

            this.Property(t => t.manager_name)
                .HasMaxLength(150);

            this.Property(t => t.manager_name_dat)
                .HasMaxLength(150);

            this.Property(t => t.manager_position)
                .HasMaxLength(250);

            this.Property(t => t.manager_position_dat)
                .HasMaxLength(250);

            this.Property(t => t.site)
                .HasMaxLength(50);

            this.Property(t => t.director_sid)
                .HasMaxLength(46);

            this.Property(t => t.sys_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("organizations");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.dattim1).HasColumnName("dattim1");
            this.Property(t => t.dattim2).HasColumnName("dattim2");
            this.Property(t => t.display_in_list).HasColumnName("display_in_list");
            this.Property(t => t.full_name).HasColumnName("full_name");
            this.Property(t => t.order_num).HasColumnName("order_num");
            this.Property(t => t.creator_sid).HasColumnName("creator_sid");
            this.Property(t => t.address_ur).HasColumnName("address_ur");
            this.Property(t => t.address_fact).HasColumnName("address_fact");
            this.Property(t => t.phone).HasColumnName("phone");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.inn).HasColumnName("inn");
            this.Property(t => t.kpp).HasColumnName("kpp");
            this.Property(t => t.ogrn).HasColumnName("ogrn");
            this.Property(t => t.rs).HasColumnName("rs");
            this.Property(t => t.bank).HasColumnName("bank");
            this.Property(t => t.ks).HasColumnName("ks");
            this.Property(t => t.bik).HasColumnName("bik");
            this.Property(t => t.okpo).HasColumnName("okpo");
            this.Property(t => t.okved).HasColumnName("okved");
            this.Property(t => t.manager_name).HasColumnName("manager_name");
            this.Property(t => t.manager_name_dat).HasColumnName("manager_name_dat");
            this.Property(t => t.manager_position).HasColumnName("manager_position");
            this.Property(t => t.manager_position_dat).HasColumnName("manager_position_dat");
            this.Property(t => t.site).HasColumnName("site");
            this.Property(t => t.director_sid).HasColumnName("director_sid");
            this.Property(t => t.sys_name).HasColumnName("sys_name");
            this.Property(t => t.id_director).HasColumnName("id_director");
        }
    }
}
