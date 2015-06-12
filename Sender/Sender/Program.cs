using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.ServiceBus.Messaging;

namespace Sender
{
    class Program
    {

        static string eventHubName = "iotzumotesthub";
        static string connectionString = "Endpoint=pathremoved;SharedAccessKeyName=SendRule;SharedAccessKey=KeyRemoved=";

        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl-C to stop the sender process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();
            SendingRandomMessages();

        }
    

        static void SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
            while (true)
            {
                try
                {
                    var rnd = new Random();
                    var sensTest = new SensorData() { EventTime = DateTime.Now,  SensorName = "Magnometer", YVal = rnd.Next(0, 255), XVal = rnd.Next(0, 255), ZVal = rnd.Next(0, 255) };
                    var data = sensTest.ToString();
                    
                    //File.WriteAllText(@"C:\Test\sample.json",data);


                    Console.WriteLine("{0} > Sending message. Press any key: {1}", DateTime.Now, data);
        

                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(sensTest.ToString())));

                
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

                Thread.Sleep(200);
            }
        }
    }
}