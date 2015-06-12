using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Threading;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncPump.Run(MainAsync);
        }

        static async Task MainAsync()
        {

            //string eventHubName = "iotzumotesthub";
            ////string eventHubConnectionString = "Endpoint=sb://iotzumotesthub-ns.servicebus.windows.net/;SharedAccessKeyName=SendRule;SharedAccessKey=CYDZ6eaorXLHQYCyBbxdeDA7xKqhjQPV9X8epjNLXuM=";
            //string eventHubConnectionString =
            //    "Endpoint=sb://iotzumotesthub-ns.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=HoDUg7ejkFsq412YnTLEDRWdBcoRKFRdtyGBbpF3MDQ=";

            string eventHubName = "iotzumotestoutput";
            //string eventHubConnectionString = "Endpoint=sb://iotzumotesthub-ns.servicebus.windows.net/;SharedAccessKeyName=SendRule;SharedAccessKey=CYDZ6eaorXLHQYCyBbxdeDA7xKqhjQPV9X8epjNLXuM=";
            string eventHubConnectionString = "removedFromSauce";
            
            
            string storageAccountName = "iotzumoteststorage";

            string storageAccountKey = "abc123";
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                storageAccountName, storageAccountKey);

            string eventProcessorHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventProcessorHostName, eventHubName, EventHubConsumerGroup.DefaultGroupName, eventHubConnectionString, storageConnectionString);
            await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
        }
    }
}
