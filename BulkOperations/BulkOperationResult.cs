namespace BulkOperations
{
    public class BulkOperationResult
    {
        public bool Success { get; set; }
        public int AffectedRecords { get; set; }
        public string ErrorMessage { get; set; }

        public static BulkOperationResult SuccessResult(int affectedRecords)
        {
            return new BulkOperationResult
            {
                Success = true,
                AffectedRecords = affectedRecords
            };
        }

        public static BulkOperationResult ErrorResult(string errorMessage)
        {
            return new BulkOperationResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
