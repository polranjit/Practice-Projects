using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Design;

namespace Bank.DataAccess
{
   public class AcctHolderDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString = "Data Source=POLRAN-37-05-17\\SQLEXPRESS;Initial Catalog=PracticeDB;User ID=sa;Password=spider@2312";

        public AcctHolderDbContext()
        {
        }

        public AcctHolderDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AcctHolderDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<AccountHolder> AccountHolders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _connectionString;

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var accountHolder = modelBuilder.Entity<AccountHolder>()
                .ToTable("AccountHolderss");
            accountHolder.HasKey(a => a.Id);
            accountHolder.Property(a => a.Name);
            accountHolder.Property(a => a.Address);
            accountHolder.Property(a => a.BirthDate);
            accountHolder.Property(a => a.ContactNo);
            accountHolder.Property(a => a.AnniversaryDate);
            base.OnModelCreating(modelBuilder);
        }
    }

}
