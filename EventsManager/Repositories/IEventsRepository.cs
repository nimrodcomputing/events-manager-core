using System;
using System.Collections.Generic;
using EventsManager.Models.Entities;
using EventsManager.Repositories.Base;

namespace EventsManager.Repositories
{
    public interface IEventsRepository : IRepository<Event>
    {
    }
}