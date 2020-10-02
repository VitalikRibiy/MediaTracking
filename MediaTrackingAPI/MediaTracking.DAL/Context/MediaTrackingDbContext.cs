using MediaTracking.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaTracking.DAL.Context
{
    public class MediaTrackingDbContext : DbContext
    {
        public MediaTrackingDbContext(DbContextOptions<MediaTrackingDbContext> opt) : base(opt)
        {
            
        }
    }
}