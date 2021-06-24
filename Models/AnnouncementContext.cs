using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testCrud.Models
{
    public class AnnouncementContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public AnnouncementContext(DbContextOptions<AnnouncementContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
