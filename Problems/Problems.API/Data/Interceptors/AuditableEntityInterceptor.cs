//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using NetTopologySuite.Geometries.Utilities;
//using Problems.API.Domain.Abstraction;

//namespace Problems.API.Data.Interceptors;

//public class AuditableEntityInterceptor : SaveChangesInterceptor
//{
//    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
//    {
//        UpdateEntities(eventData.Context);

//        return base.SavedChanges(eventData, result);
//    }

//    public void UpdateEntities(DbContext? context)
//    {
//        if (context == null)
//        {
//            return;
//        }

//        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
//        {
//            if (entry.State == EntityState.Added)
//            {
//                entry.Entity.CreatedAt = DateTime.UtcNow;
//                entry.Entity.CreatedBy = "Chanchal";//TODO: Get UserName/Id of actual user
//            }

//            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnEntities())
//            {
//                entry.Entity.LastModified = DateTime.UtcNow;
//                entry.Entity.LastModifiedBy = "Chanchal";//TODO: Get UserName/Id of actual user
//            }
//        }
//    }

//}

//public static class Extensions
//{

//    public static bool HasChangedOwnEntities(this EntityEntry entry) => entry.References.Any(r =>
//    r.TargetEntry != null &&
//    r.TargetEntry.Metadata.IsOwned() &&
//    (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));

//}


