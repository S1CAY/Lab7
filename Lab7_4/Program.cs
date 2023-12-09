using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;


namespace Lab7_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            EventSystem eventSystem = new EventSystem(1);

            
            Node node1 = new Node(1, eventSystem);
            Node node2 = new Node(2, eventSystem);
            Node node3 = new Node(3, eventSystem);

            
            node1.SendEvent("Hello from Node 1!");
            node2.SendEvent("Greetings from Node 2!");

            
            Thread.Sleep(1000);

            
            node3.SendEvent("Hi from Node 3!");

            
            Thread.Sleep(1000);

            
            eventSystem.OnEvent -= node2.HandleEvent;
            Console.WriteLine("Node 2 has left the system.");

            
            node1.SendEvent("Event after Node 2 left.");

            Console.ReadLine();
        }
    }


}
