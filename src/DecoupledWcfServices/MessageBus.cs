using System;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace DecoupledWcfServices
{

    /// <summary>
    /// Service 1 and Service 2 are in the same namespace in this project
    /// </summary>
    public class MessageBus
    {
        public async Task<string> CallOtherWcfService(string url, object content, NameValueCollection headers)
        {
            // How do I call the web service here?
            try
            {
                var serviceContractType = typeof(IService2);
                var genericChannelFactoryType = typeof(CustomWebChannelFactory<>).MakeGenericType(serviceContractType);
                //var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var binding = new WebHttpBinding();

                // How do we make the call with the Uri?
                var serviceUri = GetServiceUri(url);

                // Making the call directoy without the Uri
                var channelFactory = Activator.CreateInstance(genericChannelFactoryType, binding, serviceUri) as CustomWebChannelFactory<IService2>;
                var method = channelFactory.GetType().GetMethods().FirstOrDefault(m => m.Name == "CreateChannel" && m.GetParameters().Length == 0);
                var proxy = method.Invoke(channelFactory, null);
                Task task = null;
                using (new OperationContextScope((IContextChannel)proxy))
                {
                    var httpHeaders = new HttpRequestMessageProperty();
                    httpHeaders.Headers["D"] = "E";
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpHeaders;
                    var proxyMethod = proxy.GetType().GetMethod("GetData");
                    task = proxyMethod.Invoke(proxy, new[] { "some data" }) as Task;
                }
                await task;
                return task.GetType().GetProperty("Result").GetValue(task) as string;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Uri GetServiceUri(string url)
        {
            var index = url.IndexOf(".svc") + 4;
            return new Uri(url.Substring(0, index));
        }
    }
}