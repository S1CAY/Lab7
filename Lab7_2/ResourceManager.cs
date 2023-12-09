using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7_2
{
    class ResourceManager
    {
        private List<Resource> resources = new List<Resource>();
        private Mutex resourceMutex = new Mutex();
        private Dictionary<int, int> threadPriorities = new Dictionary<int, int>();

        public void AddResource(Resource resource)
        {
            resources.Add(resource);
        }

        public void SetThreadPriority(int threadId, int priority)
        {
            threadPriorities[threadId] = priority;
        }

        public void RequestResource(int threadId, string resourceName)
        {
            resourceMutex.WaitOne();

            var resource = resources.Find(r => r.Name == resourceName);
            if (resource != null)
            {
                Console.WriteLine($"Thread {threadId} is requesting resource {resourceName}");


                if (threadPriorities.TryGetValue(threadId, out int priority))
                {

                    Console.WriteLine($"Thread {threadId} has priority {priority}");
                    resource.Semaphore.WaitOne(priority);
                }
                else
                {

                    resource.Semaphore.WaitOne();
                }

                Console.WriteLine($"Thread {threadId} obtained resource {resourceName}");
            }
            else
            {
                Console.WriteLine($"Resource {resourceName} not found.");
            }

            resourceMutex.ReleaseMutex();
        }

        public void ReleaseResource(int threadId, string resourceName)
        {
            resourceMutex.WaitOne();

            var resource = resources.Find(r => r.Name == resourceName);
            if (resource != null)
            {
                Console.WriteLine($"Thread {threadId} is releasing resource {resourceName}");
                resource.Semaphore.Release();
            }
            else
            {
                Console.WriteLine($"Resource {resourceName} not found.");
            }

            resourceMutex.ReleaseMutex();
        }
    }
}
