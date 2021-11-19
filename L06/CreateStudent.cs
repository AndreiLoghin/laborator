using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class CreateStudent
    {
        [Function("CreateStudent")]
        public static void Run([QueueTrigger("students-queue", Connection = "azurestoragemiercuri_STORAGE")] string myQueueItem,
            FunctionContext context)
        {
            var logger = context.GetLogger("CreateStudent");
            logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
