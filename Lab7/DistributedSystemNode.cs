using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class DistributedSystemNode
    {
        private string nodeId;
        private bool isActive;

        public DistributedSystemNode(string nodeId)
        {
            this.nodeId = nodeId;
            this.isActive = true;
        }

        public async Task SendMessageAsync(DistributedSystemNode destinationNode, string message)
        {
            Console.WriteLine($"Node {nodeId} sending message to Node {destinationNode.nodeId}: {message}");


            await Task.Delay(1000);


            destinationNode.ReceiveMessage($"{nodeId} sent: {message}");
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"Node {nodeId} received message: {message}");
        }

        public async Task NotifyStatusAsync(DistributedSystemNode otherNode)
        {
            Console.WriteLine($"Node {nodeId} notifying status to Node {otherNode.nodeId}");


            await Task.Delay(500);


            otherNode.UpdateStatus($"{nodeId} is {(isActive ? "active" : "inactive")}");
        }

        public void UpdateStatus(string status)
        {
            Console.WriteLine($"Node {nodeId} updated status: {status}");
        }

        public async Task SimulateActivityAsync()
        {
            while (isActive)
            {
                Console.WriteLine($"Node {nodeId} is active");
                await Task.Delay(2000);
            }
        }

        public void DeactivateNode()
        {
            Console.WriteLine($"Node {nodeId} is deactivated");
            isActive = false;
        }
    }
}
