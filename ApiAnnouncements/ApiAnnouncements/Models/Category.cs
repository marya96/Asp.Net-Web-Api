using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAnnouncements.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<Announcement> Announcements { get; set; }
    }
}