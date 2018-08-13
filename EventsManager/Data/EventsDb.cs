using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventsManager.Entities;
using EventsManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsManager.Data
{
    public class EventsDb : DbContext
    {
        public EventsDb(DbContextOptions<EventsDb> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Session> Sessions { get; set; }


        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(opt =>
            {
                opt.Property(e => e.Description).HasColumnType("ntext");
                opt.Property(e => e.Abstract).HasColumnType("ntext");

                opt.Property(e => e.StartDate).HasColumnType("date");
                opt.Property(e => e.EndDate).HasColumnType("date");
            });
        }

        public override int SaveChanges()
        {
            Validate();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            Validate();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            Validate();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            Validate();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void Validate()
        {
            var entities = ChangeTracker.Entries().
                Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).
                Select(e => e.Entity);
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            }
        }

        #endregion

    }
}