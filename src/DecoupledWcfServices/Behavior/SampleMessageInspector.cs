using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace DecoupledWcfServices.Behavior
{
    public class SampleMessageInspector : IDispatchMessageInspector
    {
        public static int i = 0;
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)

        {
            var urlParams = request.Headers?.To.Query;
            var headers = WebOperationContext.Current?.IncomingRequest?.Headers;
            i++; // Put a breakpoint here to verify this was called.
            return null; 
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}