using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "net.local://localhost/Service1";

            // Start the client
            ChannelFactory<IService1> channelFactory
                = new ChannelFactory<IService1>(new NetNamedPipeBinding(), baseAddress);
            IService1 proxy = channelFactory.CreateChannel();
            var data = proxy.GetData().Result;
        }
    }
}
