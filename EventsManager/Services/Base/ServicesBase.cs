using System.Threading.Tasks;
using EventsManager.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EventsManager.Services.Base
{
    public class ServicesBase
    {
        private readonly EventsDb _db;

        public ServicesBase(EventsDb db)
        {
            _db = db;
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        public virtual int SaveChanges()
        {
            return _db.SaveChanges();
        }

    }

    public static class ServicesStartup
    {

        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IEventsService, EventsService>();
        }

    }
}