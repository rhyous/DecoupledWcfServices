using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace DecoupledWcfServices
{
    public class CustomWebChannelFactory<T> : WebChannelFactory<T>
        where T : class
    {
        public CustomWebChannelFactory()
        {
        }

        public CustomWebChannelFactory(Binding binding) : base(binding)
        {
        }

        public CustomWebChannelFactory(ServiceEndpoint endpoint) : base(endpoint)
        {
        }

        public CustomWebChannelFactory(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public CustomWebChannelFactory(Type channelType) : base(channelType)
        {
        }

        public CustomWebChannelFactory(Uri remoteAddress) : base(remoteAddress)
        {
        }

        public CustomWebChannelFactory(Binding binding, Uri remoteAddress) : base(binding, remoteAddress)
        {
        }

        public CustomWebChannelFactory(string endpointConfigurationName, Uri remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        protected override void OnOpening()
        {
            base.OnOpening();
        }
    }
}