using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestMultiEEntity.Models;
using TestMultiEEntity.Enum;

namespace TestMultiEEntity
{
    internal class TestDbContext : DbContext
    {
        public virtual DbSet<TestForme> TestFormes { get; set; }
        public virtual DbSet<TestType> TestTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\LocalTestDb;Initial Catalog=master;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<TestForme>(en =>
            {
                //Notez que je ne map même pas le label, les conventions c'est de la balle
                en.ToTable("TestMultiEntity");
                en.Property(e => e.Id).ValueGeneratedOnAdd();
                en.HasKey(e => e.Id);

                //Table split
                en.HasOne(e => e.Type).WithOne(e => e.Forme)
                    .HasPrincipalKey<TestForme>(e => e.Id)
                    .HasForeignKey<TestType>(e => e.Id);

                //Héritage
                en.HasDiscriminator(e => e.Forme)
                    .HasValue<AccordCadre>(FormEnum.AccordCadre)
                    .HasValue<Marche>(FormEnum.Marche);
            });

            mb.Entity<TestType>(en =>
            {
                en.ToTable("TestMultiEntity");
                en.Property(e => e.Id).ValueGeneratedOnAdd();
                en.HasKey(e => e.Id);
            });



        }
    }
}
