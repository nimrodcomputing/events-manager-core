using System.Collections.Generic;
using System.Linq;
using EventsManager.Data;
using EventsManager.Models.Entities;
using EventsManager.Models.Resources;
using EventsManager.Repositories;
using EventsManager.Services.Base;
using Mapster;

namespace EventsManager.Services
{
    public interface IEventsService
    {
        IList<EventResource> Query();

        EventResource Add(Event input);
    }

    public class EventsService : ServicesBase, IEventsService
    {
        private readonly IEventsRepository _repository;

//
//        public EventsService(EventsDb db)
//            : this(db, db.Events)
//        {}

        public EventsService(EventsDb db)
         : base(db)
        {
            _repository = new EventsRepository(db, db.Events);
        }

        public IList<EventResource> Query()
        {
            return _repository.Dataset.Adapt<IList<EventResource>>();
        }

        public EventResource Add(Event input)
        {
            var entity = _repository.Add(input);
            SaveChanges();
            return entity.Adapt<EventResource>();
        }


    }
}