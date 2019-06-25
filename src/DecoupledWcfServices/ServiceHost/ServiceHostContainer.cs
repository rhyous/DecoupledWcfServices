using System;
using System.Collections.Concurrent;

namespace DecoupledWcfServices
{
    public class ServiceHostContainer
    {
        #region Singleton
        private static readonly Lazy<ServiceHostContainer> Lazy = new Lazy<ServiceHostContainer>(() => new ServiceHostContainer());
        public static ServiceHostContainer Instance { get { return Lazy.Value; } }
        internal ServiceHostContainer() { }
        #endregion

        public ConcurrentDictionary<string, RestWebServiceHost> RestServiceHosts = new ConcurrentDictionary<string, RestWebServiceHost>();
    }

}