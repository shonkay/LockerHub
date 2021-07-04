using LockerHubCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Context
{
    public class HubContext : DbContext
    {
        public HubContext(DbContextOptions<HubContext> options) : base(options)
        {

        }
        public virtual DbSet<Locker> Lockers { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
