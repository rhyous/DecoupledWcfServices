using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DecoupledWcfServices
{

    // In this sample app, Service1 and Service2 are int the same dll.
    // However, in another production application, Service1 and Service2
    // are plugins and would never reference each other.
    // Based on some configuration, how could Service1 call Service2 without
    // using HttpClient
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        public async Task<string> GetData()
        {
            return "This is from local data.";
        }

        public async Task<string> GetRelatedData()
        {
            var url = "http://localhost:54412/Service2/Service2.svc/GetData?y=1";

            // Using HttpClient - What I have working

            // Comment this out and get the MessageBus working

            //var httpclient = new HttpClient();
            //var httpResponseMessage = await httpclient.GetAsync(url);
            //return await httpResponseMessage.Content.ReadAsStringAsync();

            // Using Bus - What I want to get working
            return await new MessageBus().CallOtherWcfService(url, null, null);
        }

    }
}
