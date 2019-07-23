using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace DecoupledWcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Task<string> GetData(string data);
    }
}
