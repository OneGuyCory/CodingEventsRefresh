using CodingEventsRefresh.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsRefresh.Data

{
    public class EventDbContext : DbContext
    {
       public DbSet<Event> Events { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }
    }
}
