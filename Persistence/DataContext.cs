using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        { 
            // no implementation
        }
        
        public  DbSet<Activity> Activities {get; set;}
        
    }
}