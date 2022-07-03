using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestMultiEEntity.Models;

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
                en.ToTable("TestMultiEntity");
                en.Property(e => e.Id).ValueGeneratedOnAdd();
                en.HasKey(e => e.Id);

                en.HasOne(e => e.Type).WithOne(e => e.Forme)
                    .HasPrincipalKey<TestForme>(e => e.Id)
                    .HasForeignKey<TestType>(e => e.Id);
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
