using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab7_4.EventSystem;

namespace Lab7_4
{
    public class Node
    {
        private int nodeId;
        private EventSystem eventSystem;

        public Node(int nodeId, EventSystem eventSystem)
        {
            this.nodeId = nodeId;
            this.eventSystem = eventSystem;


            eventSystem.OnEvent += HandleEvent;

            Console.WriteLine($"Node {nodeId} has joined the system.");
        }


        public void HandleEvent(Event e)
        {
            Console.WriteLine($"Node {nodeId} received event: {e.Message} (SequenceNumber: {e.SequenceNumber})");
        }


        public void SendEvent(string message)
        {
            eventSystem.SendEvent(message);
        }
    }

}
