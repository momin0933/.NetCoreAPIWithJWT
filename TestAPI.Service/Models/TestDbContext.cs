using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Core.Models.Common;
using TestAPI.Core.Models;
using TestAPI.Core.Service;

namespace TestAPI.Core.Models
{
    public partial class TestDbContext : DbContext
    {
        private readonly string _connectionString;
        SQLConnectionString _connectionStringService = new SQLConnectionString();


        public TestDbContext()
        {
            // _connectionString = cnString;
            _connectionString = _connectionStringService.GetConnectionString("default");
        }
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
            _connectionString = _connectionStringService.GetConnectionString("default");
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                //optionsBuilder.UseSqlServer("Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NNGAccounts;Uid = sa; Password = aA@01737918236;");
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().ToTable("tbl_UserAccount");
            modelBuilder.Entity<UserProfile>().ToTable("tbl_UserProfile");
        }
        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is EntityBase entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.EntryDt = now;
                            entity.UpdateDt = now;
                            entity.IsActive = true;
                            //entity.CreatedBy = CurrentUser.GetUsername();
                            //entity.UpdatedBy = CurrentUser.GetUsername();
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.EntryBy).IsModified = false;
                            Entry(entity).Property(x => x.EntryDt).IsModified = false;
                            entity.UpdateDt = now;
                            entity.IsActive = true;
                            //entity.UpdatedBy = CurrentUser.GetUsername();
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
