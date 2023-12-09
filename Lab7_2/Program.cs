using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceManager resourceManager = new ResourceManager();

           
            Resource cpu = new Resource("CPU", 2);
            Resource ram = new Resource("RAM", 3);
            Resource disk = new Resource("Disk", 1);

            resourceManager.AddResource(cpu);
            resourceManager.AddResource(ram);
            resourceManager.AddResource(disk);

            
            resourceManager.SetThreadPriority(Thread.CurrentThread.ManagedThreadId, 2);
            resourceManager.SetThreadPriority(Thread.CurrentThread.ManagedThreadId + 1, 1);

            
            Thread thread1 = new Thread(() => AccessResource(resourceManager, Thread.CurrentThread.ManagedThreadId, "CPU"));
            Thread thread2 = new Thread(() => AccessResource(resourceManager, Thread.CurrentThread.ManagedThreadId, "RAM"));
            Thread thread3 = new Thread(() => AccessResource(resourceManager, Thread.CurrentThread.ManagedThreadId, "Disk"));

            
            thread1.Start();
            thread2.Start();
            thread3.Start();

            
            thread1.Join();
            thread2.Join();
            thread3.Join();
        }

        static void AccessResource(ResourceManager resourceManager, int threadId, string resourceName)
        {
            resourceManager.RequestResource(threadId, resourceName);

            
            Thread.Sleep(2000);

            resourceManager.ReleaseResource(threadId, resourceName);
        }
    }

}
