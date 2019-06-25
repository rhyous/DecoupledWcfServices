using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace DecoupledWcfServices
{
    public class RestWebServiceHostFactory : WebServiceHostFactory
    {
        public static List<ServiceHostBase> NamedPipeServiceHosts = new List<ServiceHostBase>();

        public RestWebServiceHostFactory()
        {
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            //var httpUrl = baseAddresses[0].AbsoluteUri;
            //var netLocalUrl = httpUrl.Replace("http", "net.local");
            //var addresses = new Uri[baseAddresses.Length + 1];
            //Array.Copy(baseAddresses, addresses, baseAddresses.Length);
            //addresses[addresses.Length - 1] = new Uri(netLocalUrl);
            var restWebServiceHost = new RestWebServiceHost(serviceType, baseAddresses);
            ServiceHostContainer.Instance.RestServiceHosts.GetOrAdd(serviceType.Name, restWebServiceHost);
            //restWebServiceHost.AddServiceEndpoint(typeof(IService1), new LocalBinding(), "");
            return restWebServiceHost;
        }
    }
}