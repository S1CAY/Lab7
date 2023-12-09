using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab7_4
{
    public class EventSystem
    {

        public struct Event
        {
            public int NodeId;
            public int SequenceNumber;
            public string Message;
        }


        public delegate void EventHandler(Event e);


        public event EventHandler OnEvent;

        private int nodeId;
        private int sequenceNumber;
        private ConcurrentQueue<Event> eventQueue = new ConcurrentQueue<Event>();

        public EventSystem(int nodeId)
        {
            this.nodeId = nodeId;
            this.sequenceNumber = 0;


            Thread eventProcessingThread = new Thread(ProcessEvents);
            eventProcessingThread.Start();
        }


        public void SendEvent(string message)
        {
            Event newEvent = new Event
            {
                NodeId = nodeId,
                SequenceNumber = Interlocked.Increment(ref sequenceNumber),
                Message = message
            };

            eventQueue.Enqueue(newEvent);
        }


        private void ProcessEvents()
        {
            while (true)
            {
                if (eventQueue.TryDequeue(out Event nextEvent))
                {

                    OnEvent?.Invoke(nextEvent);
                }

                Thread.Sleep(100);
            }
        }
    }

}
