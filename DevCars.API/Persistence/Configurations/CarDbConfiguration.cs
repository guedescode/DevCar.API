using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCars.API.Persistence.Configurations
{
    public class CarDbConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasKey(c => c.Id);

            //Configurar propriedade
            builder
                .Property(c => c.Brand)
                .HasDefaultValue("MARCA PADRÃO")
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder
                .Property(c => c.ProductionDate)
                .HasDefaultValueSql("getdate()");

            // Nomeando a tabela no banco
            //modelBuilder.Entity<Car>()
            //    .ToTable("tb_cars");
        }
    }
}
