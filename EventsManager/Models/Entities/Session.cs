using System;
using System.Collections.Generic;
using EventsManager.Models.Records;

namespace EventsManager.Models.Entities
{
    public class Session : SessionRecord
    {

        public Event Event { get; set; }

    }
}
