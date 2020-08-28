using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Design;

namespace Bank.DataAccessLayer
{
    class AcctHolderDbContext : DbContext
    

       
        
     
     {
        private readonly IConfiguration _configuration;
    private readonly string _connectionString = "Data Source=SLPUN-LT-0129\\SQLEXPRESS;Initial Catalog=PracticeDB;User ID=sa;Password=spider@2312";

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
            .ToTable("AccountHolders");
        accountHolder.HasKey(a => a.Id);
        accountHolder.Property(a => a.Name).HasMaxLength(50);
        accountHolder.Property(a => a.Address).HasMaxLength(100);
        accountHolder.Property(a => a.BirthDate).HasColumnType("dd-MM-yyyy");
        accountHolder.Property(a => a.ContactNo).HasMaxLength(10);
        base.OnModelCreating(modelBuilder);
    }
}

}
