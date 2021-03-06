﻿using System;
using System.Collections.Generic;
using EventsManager.Models.Records;

namespace EventsManager.Models.Entities
{
    public class Event : EventRecord
    {
        public byte[] Image { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
