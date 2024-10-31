using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace microservproreitoria.src.coursesCreation.entities
{
    public class RepositoryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public RepositoryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseCosmos(
                connectionString: _configuration["CosmosDBURL"],
                databaseName: _configuration["CosmosDBDBName"],
                cosmosOptionsAction: options =>
                {
                    options.ConnectionMode(ConnectionMode.Gateway);
                    options.HttpClientFactory(() => new HttpClient(new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    }));
                }

            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .ToContainer("course")
                .HasPartitionKey(p => p.id)
                .HasAutoscaleThroughput(400)
                .HasNoDiscriminator()
                .Property(p => p.id)
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired(true);

        }

    }
}