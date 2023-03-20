using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public bool? FeaturedSubject { get; set; }
    }

}
