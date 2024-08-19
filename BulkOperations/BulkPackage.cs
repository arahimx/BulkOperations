using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BulkOperations
{
    public static class BulkPackage
    {
        public static BulkOperationResult BulkInsert<T>(this DbContext context, IEnumerable<T> entities) where T : class
        {
            try
            {
                if (entities == null || !entities.Any())
                    return BulkOperationResult.ErrorResult("No entities provided for insertion.");

                context.Set<T>().AddRange(entities);
                int affectedRecords = context.SaveChanges();

                return BulkOperationResult.SuccessResult(affectedRecords);
            }
            catch (Exception ex)
            {
                return BulkOperationResult.ErrorResult($"Bulk insert failed: {ex.Message}");
            }
        }

        public static BulkOperationResult BulkUpdate<T>(this DbContext context, IEnumerable<T> entities) where T : class
        {
            try
            {
                if (entities == null || !entities.Any())
                    return BulkOperationResult.ErrorResult("No entities provided for update.");

                context.Set<T>().UpdateRange(entities);
                int affectedRecords = context.SaveChanges();

                return BulkOperationResult.SuccessResult(affectedRecords);
            }
            catch (Exception ex)
            {
                return BulkOperationResult.ErrorResult($"Bulk update failed: {ex.Message}");
            }
        }

        public static BulkOperationResult BulkDelete<T>(this DbContext context, IEnumerable<T> entities) where T : class
        {
            try
            {
                if (entities == null || !entities.Any())
                    return BulkOperationResult.ErrorResult("No entities provided for deletion.");

                context.Set<T>().RemoveRange(entities);
                int affectedRecords = context.SaveChanges();

                return BulkOperationResult.SuccessResult(affectedRecords);
            }
            catch (Exception ex)
            {
                return BulkOperationResult.ErrorResult($"Bulk delete failed: {ex.Message}");
            }
        }
    }
}