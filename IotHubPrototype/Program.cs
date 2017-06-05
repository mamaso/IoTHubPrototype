using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Indexers;

namespace IotHubPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            JobHostConfiguration config = new JobHostConfiguration();
            config.UseDevelopmentSettings();
            config.UseTimers();

            var iot = new IoTHubConfigProvider();
            config.RegisterExtensionConfigProvider(iot);

            var host = new JobHost(config);
            try
            {
                host.RunAndBlock();
            }
            catch (FunctionIndexingException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
