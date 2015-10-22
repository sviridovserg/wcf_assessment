using Microsoft.Practices.Unity;
using RedPill.Interfaces;
using RedPill.Services;
using Unity.Wcf;

namespace RedPill
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
			// register all your components with the container here
            container
               .RegisterType<IRedPill, RedPill>()
               .RegisterType<INumberService, NumberService>(new HierarchicalLifetimeManager())
               .RegisterType<IWordService, WordService>(new HierarchicalLifetimeManager())
               .RegisterType<ITriangleService, TriangleService>(new HierarchicalLifetimeManager());
        }
    }    
}