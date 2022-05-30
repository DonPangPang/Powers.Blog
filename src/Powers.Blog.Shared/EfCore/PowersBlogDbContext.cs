using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Powers.Blog.Shared.EfCore
{
    public class PowersBlogDbContext : DbContext
    {
        public PowersBlogDbContext(DbContextOptions<PowersBlogDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = typeof(IEntity).Assembly.GetTypes().AsEnumerable()
                .Where(t => !t.IsAbstract && !t.IsInterface && t.IsSubclassOf(typeof(IEntity)));

            foreach (var type in types)
            {
                if (modelBuilder.Model.FindEntityType(type) is null)
                {
                    modelBuilder.Model.AddEntityType(type);
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        private void AutoSetChangedEntities()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries<EntityBase<Guid>>())
            {
                var baseentity = dbEntityEntry.Entity;
                switch (dbEntityEntry.State)
                {
                    case EntityState.Added:
                        //baseentity.TenantId = session.TenantId;
                        //if (string.IsNullOrEmpty(baseentity.Domain))
                        //{
                        //    //业务未赋值，则自动赋值
                        //    baseentity.Domain = session.Domain;
                        //}

                        //if (string.IsNullOrEmpty(baseentity.CreatedBy))
                        //{
                        //    baseentity.CreatedBy = session.UserId == null ? "" : session.UserId;
                        //}
                        //baseentity.CreatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        //baseentity.ModifiedOn = DateTime.Now;
                        //if (string.IsNullOrEmpty(baseentity.ModifiedBy))
                        //{
                        //    baseentity.ModifiedBy = session.UserId == null ? "" : session.UserId;
                        //}
                        break;
                }
            }
        }

        public override int SaveChanges()
        {
            try
            {
                AutoSetChangedEntities();
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                LogDbEntityValidationException(ex);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                AutoSetChangedEntities();
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                LogDbEntityValidationException(ex);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void LogDbEntityValidationException(DbUpdateException exception)
        {
            //var sb = new StringBuilder();
            //sb.AppendLine("There are some validation errors while saving changes in EntityFramework:");
            //foreach (var exceptionEntityValidationError in exception.Entries)
            //{
            //    sb.AppendLine($"\t{exceptionEntityValidationError.Entity.GetType().Name}");
            //    foreach (var dbValidationError in exceptionEntityValidationError.)
            //    {
            //        sb.AppendLine("\t\t" + dbValidationError.PropertyName + ": " + dbValidationError.ErrorMessage);
            //    }
            //}
            //Logging.Logger.Error(sb.ToString());
        }
    }
}