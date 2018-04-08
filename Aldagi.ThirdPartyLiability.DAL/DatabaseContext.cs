using Aldagi.ThirdPartyLiability.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientDetails> ClientDetails { get; set; }
        public DbSet<InternalUser> InternalUsers { get; set; }
        public DbSet<TPLDetails> TPLDetails { get; set; }
        public DbSet<TPLTerm> TPLTerms { get; set; }

    }
}
