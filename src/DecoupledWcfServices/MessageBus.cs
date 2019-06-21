using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace DecoupledWcfServices
{
    /// <summary>
    /// Service 1 and Service 2 are in the same namespace in this project
    /// </summary>
    public class MessageBus
    {
        public void CallOtherWcfService(string url, object content, NameValueCollection headers)
        {

        }
    }
}