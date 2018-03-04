using System.Data.Entity;

namespace ApiAnnouncements.Models
{
    public class ApiAnnouncementsDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx



        public ApiAnnouncementsDbContext() : base("name=ApiAnnouncementsDbContext")
        {
        }

        public System.Data.Entity.DbSet<ApiAnnouncements.Models.Announcement> Announcements { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
