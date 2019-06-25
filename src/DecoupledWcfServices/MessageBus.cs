using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace DecoupledWcfServices
{
    /// <summary>
    /// Service 1 and Service 2 are in the same namespace in this project
    /// </summary>
    public class MessageBus
    {
        public string CallOtherWcfService(string url, object content, NameValueCollection headers)
        {
            var service = GetServiceName(url);

            // How do I call the web service here?
            try
            {
                var netPipeUrl = "net.pipe://localhost/Service1/Service1.svc";
                var method = "GetData";
                var serviceContractType = typeof(IService2);
                var genericChannelFactoryType = typeof(ChannelFactory<>).MakeGenericType(serviceContractType);
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                dynamic channelFactory = Activator.CreateInstance(genericChannelFactoryType);
                var proxy = channelFactory.CreateChannel();
                var data = proxy.GetData().Result;
                return data; // Serialized JSON
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal string GetServiceName(string url)
        {
            var index = url.IndexOf(".svc");
            var sub = url.Substring(0, index);
            index = sub.LastIndexOf("/") + 1;
            var sub2 = url.Substring(index, sub.Length - index);
            return sub2;
        }
    }
}