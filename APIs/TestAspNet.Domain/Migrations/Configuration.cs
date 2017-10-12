using System;
using System.Data.Entity.Migrations;
using TestAspNet.Domain.Contexts;
using TestAspNet.Domain.Entities;

namespace TestAspNet.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(EntityContext context)
        {
            context.Customers.AddOrUpdate(
                c => c.Id,
                new Customer { Id = Guid.Parse("19725A11-6309-492C-A04C-2E246763EA17"), Name = "Customer 0", Email = "customer0@testaspnet.com" },
                new Customer { Id = Guid.Parse("C9F33381-E841-4FEE-8BFD-68D7A6FB7625"), Name = "Customer 1", Email = "customer1@testaspnet.com" },
                new Customer { Id = Guid.Parse("8C36A5EB-584A-48A5-A015-F5408BDBF971"), Name = "Customer 2", Email = "customer2@testaspnet.com" },
                new Customer { Id = Guid.Parse("A20FE08B-CEDD-4204-892E-745DF556071C"), Name = "Customer 3", Email = "customer3@testaspnet.com" },
                new Customer { Id = Guid.Parse("D8163A1C-453E-421C-88BF-C3C860939F02"), Name = "Customer 4", Email = "customer4@testaspnet.com" },
                new Customer { Id = Guid.Parse("2EDBAEB2-4B51-4207-85CC-E87BE5CCCDA1"), Name = "Customer 5", Email = "customer5@testaspnet.com" },
                new Customer { Id = Guid.Parse("DD137CA7-7AF2-4477-9111-11308FDB7C4A"), Name = "Customer 6", Email = "customer6@testaspnet.com" },
                new Customer { Id = Guid.Parse("52664FDA-E7D8-4325-8305-914763CA0D53"), Name = "Customer 7", Email = "customer7@testaspnet.com" },
                new Customer { Id = Guid.Parse("58D3FD81-0974-4F4F-92B1-5FF98B45D1FF"), Name = "Customer 8", Email = "customer8@testaspnet.com" },
                new Customer { Id = Guid.Parse("6EF40B4D-3CB3-4590-B75B-44280C220EE5"), Name = "Customer 9", Email = "customer9@testaspnet.com" });
        }
    }
}
