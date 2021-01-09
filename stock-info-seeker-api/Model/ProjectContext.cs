using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_info_seeker_api.Model
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SeekFor> seekFor { get; set; }
        public DbSet<Occurence> occurence { get; set; }

    }
}
