using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace App.Repositories.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviors = new()
        {
            { EntityState.Added, AddBehavior },
            { EntityState.Modified, ModifiedBehavior }
        };


        private static void AddBehavior(DbContext context, IAuditEntity auditEntity)
        {
            auditEntity.Created = DateTime.Now;
            context.Entry(auditEntity).Property(x => x.Updated).IsModified = false;
        }

        private static void ModifiedBehavior(DbContext context, IAuditEntity auditEntity)
        {
            context.Entry(auditEntity).Property(x => x.Created).IsModified = false;
            auditEntity.Updated = DateTime.Now;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
            {
                if (entityEntry.Entity is not IAuditEntity auditEntity) continue;


                if (entityEntry.State is not (EntityState.Added or EntityState.Modified)) continue;


                Behaviors[entityEntry.State](eventData.Context, auditEntity);

                #region 1.way

                //switch (entityEntry.State)
                //{
                //    case EntityState.Added:


                //        AddBehavior(eventData.Context, auditEntity);


                //        break;

                //    case EntityState.Modified:


                //        ModifiedBehavior(eventData.Context, auditEntity);


                //        break;
                //}

                #endregion
            }


            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}