using System.Collections.Generic;
using EventsManager.Models;

namespace EventsManager.Entities
{
    public class Event : EventModel
    {

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

        

    }
}
