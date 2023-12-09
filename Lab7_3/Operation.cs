using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_3
{
    public class Operation
    {
        public DateTime Timestamp { get; private set; }
        public int ThreadId { get; private set; }
        public string Description { get; private set; }

        public Operation(int threadId, string description)
        {
            Timestamp = DateTime.Now;
            ThreadId = threadId;
            Description = description;
        }
    }

}
