using System;
using System.Collections.Generic;
using EventsManager.Models.Records;

namespace EventsManager.Models.Entities
{
    public class Event : EventRecord
    {

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

        

    }
}
