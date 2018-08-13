using System;
using System.ComponentModel.DataAnnotations;

namespace EventsManager.Models
{
    public class SessionModel : Model
    {

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public string Abstract { get; set; }

        public DateTime? StartTime { get; set; }

        public int? Duration { get; set; }

        [StringLength(50)]
        public string Speaker { get; set; }

        [StringLength(50)]
        public string Moderator { get; set; }

        public Guid EventId { get; set; }

    }
}
