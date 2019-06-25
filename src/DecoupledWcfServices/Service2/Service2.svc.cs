using System.ServiceModel;
using System.Threading.Tasks;

namespace DecoupledWcfServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service2 : IService2
    {
        public Task<string> GetData()
        {
            return Task.FromResult("Service 2 data");
        }
    }
}
