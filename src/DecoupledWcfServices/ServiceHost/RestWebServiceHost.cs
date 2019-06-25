using System;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace DecoupledWcfServices
{
    public class RestWebServiceHost : WebServiceHost
    {
        public Type _ServiceType;

        public RestWebServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {
            _ServiceType = serviceType;
        }

        protected override void OnOpening()
        {
            base.OnOpening();
        }

        public override void AddServiceEndpoint(ServiceEndpoint endpoint)
        {            
            endpoint.EndpointBehaviors.Clear();
            base.AddServiceEndpoint(endpoint);
        }        
    }
}
