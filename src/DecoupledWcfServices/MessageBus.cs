using System;
using System.Collections.Specialized;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

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
                //var netPipeUrl = $"net.pipe://localhost/{service}/{service}.svc";
                var netPipeUrl = $"http://localhost:54412/{service}/{service}.svc";
                var serviceContractType = typeof(IService2);
                var genericChannelFactoryType = typeof(WebChannelFactory<>).MakeGenericType(serviceContractType);
                //var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var binding = new WebHttpBinding();

                // How do we make the call with the Uri?

                // Making the call directoy without the Uri
                var channelFactory = Activator.CreateInstance(genericChannelFactoryType, binding, new Uri(netPipeUrl)) as WebChannelFactory<IService2>;
                var proxy = channelFactory.CreateChannel() as IService2;
                using (new OperationContextScope((IContextChannel)proxy))
                {
                    var task = proxy.GetData("some data");
                    task.Wait();
                    return task.Result; // Serialized JSON
                }
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