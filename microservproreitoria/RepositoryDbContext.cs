using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using microservproreitoria.src.CourseCreation.Entities;
using microservproreitoria.src.LabsCreation.Entities;
using microservproreitoria.src.SubjectCreation.Entities;
using microservproreitoria.src.Teacherppliction.Entities;

namespace microservproreitoria
{
    public class RepositoryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public RepositoryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseCosmos(
                connectionString: _configuration["CosmosDBURL"],
                databaseName: _configuration["CosmosDBDBName"],
                cosmosOptionsAction: options =>
                {
                    options.ConnectionMode(ConnectionMode.Gateway);
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

            modelBuilder.Entity<Lab>()
                .ToContainer("lab")
                .HasPartitionKey(p => p.id)
                .HasAutoscaleThroughput(400)
                .HasNoDiscriminator()
                .Property(p => p.id)
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired(true);

            modelBuilder.Entity<Subject>()
                .ToContainer("subject")
                .HasPartitionKey(p => p.id)
                .HasAutoscaleThroughput(400)
                .HasNoDiscriminator()
                .Property(p => p.id)
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired(true);

            modelBuilder.Entity<Teacher>()
                .ToContainer("teacher")
                .HasPartitionKey(p => p.id)
                .HasAutoscaleThroughput(400)
                .HasNoDiscriminator()
                .Property(p => p.id)
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired(true);


        }
        
    }
}