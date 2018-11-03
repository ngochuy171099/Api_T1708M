using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiEAP.Entity;

namespace apiEAP.Models
{
    public class apiEAPContext : DbContext
    {
        public apiEAPContext (DbContextOptions<apiEAPContext> options)
            : base(options)
        {
        }

        public DbSet<apiEAP.Entity.Member> Member { get; set; }

        public DbSet<apiEAP.Entity.ShCredential> ShCredentials { get; set; }

    }
}
