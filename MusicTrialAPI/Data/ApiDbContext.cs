using Microsoft.EntityFrameworkCore;
using MusicTrialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTrialAPI.Data
{
    public class ApiDbContext : DbContext
    {
        // Going slow on connection string...eventually this will form a base repo 
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }
        public DbSet<Song> Song { get; set; }
    }
}
