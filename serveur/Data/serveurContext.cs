using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using serveur.Models;

namespace serveur.Data
{
    public class serveurContext : DbContext
    {
        public serveurContext (DbContextOptions<serveurContext> options)
            : base(options)
        {
        }

        public DbSet<serveur.Models.Dépense> Dépense { get; set; } = default!;
        public DbSet<serveur.Models.Investissement> Investissement { get; set; } = default!;
        public DbSet<serveur.Models.Revenu> Revenu { get; set; } = default!;
    }
}
