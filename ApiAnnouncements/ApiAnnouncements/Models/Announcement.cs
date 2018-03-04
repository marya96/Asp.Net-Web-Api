using System;
using System.ComponentModel.DataAnnotations;

namespace ApiAnnouncements.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}