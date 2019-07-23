using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace DecoupledWcfServices
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Task<string> GetData();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Task<string> GetRelatedData();
    }
}
