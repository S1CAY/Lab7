using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_3
{
    public class ConflictLogger
    {
        private List<Operation> operationLog = new List<Operation>();
        private object logLock = new object();

        public void LogOperation(int threadId, string description)
        {
            lock (logLock)
            {
                var operation = new Operation(threadId, description);
                operationLog.Add(operation);

                Console.WriteLine($"Thread {threadId} performed operation: {description} at {operation.Timestamp}");

                DetectConflicts(operation);
            }
        }

        private void DetectConflicts(Operation currentOperation)
        {
            foreach (var operation in operationLog)
            {

                if (operation != currentOperation && operation.Description == currentOperation.Description)
                {
                    Console.WriteLine($"Conflict detected: Thread {operation.ThreadId} and Thread {currentOperation.ThreadId} are modifying the same resource");

                }
            }
        }
    }
}
