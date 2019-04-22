using System;
using System.ComponentModel.DataAnnotations;

namespace Amoozeshgah.Domain.Entities
{
    public class PageTrack
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime? TimeAccessed { get; set; } 
    }
}
