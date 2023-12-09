using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7_2
{
    class Resource
    {
        public string Name { get; private set; }
        public Semaphore Semaphore { get; private set; }

        public Resource(string name, int capacity)
        {
            Name = name;
            Semaphore = new Semaphore(capacity, capacity);
        }
    }

}
