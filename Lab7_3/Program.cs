using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab7_3
{
    class Program
    {
        static ConflictLogger conflictLogger = new ConflictLogger();

        static void Main(string[] args)
        {
            
            Thread thread1 = new Thread(() => PerformOperation(1, "Modify Resource A"));
            Thread thread2 = new Thread(() => PerformOperation(2, "Modify Resource A"));
            Thread thread3 = new Thread(() => PerformOperation(3, "Modify Resource B"));

           
            thread1.Start();
            thread2.Start();
            thread3.Start();

            
            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.ReadLine();
        }

        static void PerformOperation(int threadId, string description)
        {
            conflictLogger.LogOperation(threadId, description);

            
            Thread.Sleep(1000);

            
        }
    }

}
