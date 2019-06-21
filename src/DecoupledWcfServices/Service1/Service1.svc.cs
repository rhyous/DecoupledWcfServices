using System.Net.Http;
using System.Threading.Tasks;

namespace DecoupledWcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public async Task<string> GetData()
        {
            // Using HttpClient
            var httpclient = new HttpClient();
            var url = "http://localhost:54412/Service2/Service2.svc/GetData";
            var httpResponseMessage = await httpclient.GetAsync(url);
            return await httpResponseMessage.Content.ReadAsStringAsync();

            // Using Bus
            // return new MessageBus().CallOtherWcfService(url, null, null);
        }

    }
}
