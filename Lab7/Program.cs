using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
   
    class Program
    {
        static async Task Main(string[] args)
        {
            DistributedSystemNode node1 = new DistributedSystemNode("Node 1");
            DistributedSystemNode node2 = new DistributedSystemNode("Node 2");

            
            var sendMessageTask = node1.SendMessageAsync(node2, "Hello from Node 1");
            var notifyStatusTask = node2.NotifyStatusAsync(node1);

            
            var node1ActivityTask = node1.SimulateActivityAsync();
            var node2ActivityTask = node2.SimulateActivityAsync();

            
            await Task.WhenAll(sendMessageTask, notifyStatusTask, node1ActivityTask, node2ActivityTask);

            
            node1.DeactivateNode();

            
            await node1ActivityTask;

            Console.ReadLine();
        }
    }

}
