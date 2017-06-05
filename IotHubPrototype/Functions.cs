using Microsoft.Azure.Devices;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotHubPrototype
{
    public class Functions
    {
        public static void TimerIoT(
            [TimerTrigger("*/5 * * * * *", RunOnStartup = true, UseMonitor = false)] TimerInfo timer,
            [IoTHubInput] ServiceClient client,
            [IoTHub("myDevice")] out string output,
            [IoTHub("myDevice")] out byte[] arr,
            [IoTHub("myDevice")] ICollector<string> coll,
            [IoTHub("myDevice")] out JObject jobj)
        {
            Console.WriteLine("timer");
            client.SendAsync("myDevice", new Message(Encoding.UTF8.GetBytes("client"))).GetAwaiter().GetResult();
            output = "string";
            arr = Encoding.UTF8.GetBytes("array");
            coll.Add("collstring");
            var message = new Message();
            jobj = JObject.Parse("{ \"to\": \"something\", \"body\": \"body\", \"properties\": { \"a\": \"b\"} }");
        }
    }
}
