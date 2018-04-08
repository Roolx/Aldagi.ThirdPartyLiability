using Aldagi.ThirdPartyLiability.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars;
        public DbSet<Manufacturer> Manufacturers;
        public DbSet<Client> Clients;
        public DbSet<ClientDetails> ClientDetails;
        public DbSet<IdentityUser> IdentityUsers;
        public DbSet<TPLDetails> TPLDetails;
        public DbSet<TPLTerm> TPLTerms;

    }
}
