using System.Data.Entity;
using TestAspNet.Domain.Entities;

namespace TestAspNet.Domain.Contexts
{
    public class EntityContext : DbContext
    {
        public EntityContext()
            : base ("DefaultConnection")
            => Configure();

        public EntityContext(string connectionString)
            : base(connectionString)
            => Configure();

        private void Configure()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(t => t.IsUnicode(false));

            var customerConfiguration = modelBuilder.Entity<Customer>();
            customerConfiguration
                .ToTable("Customers")
                .HasKey(c => c.Id);

            customerConfiguration
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            customerConfiguration
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(254);

            base.OnModelCreating(modelBuilder);
        }
    }
}