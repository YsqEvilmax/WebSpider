using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Services.Downloaders;
using TechHome.Services.Tasks;

namespace TechHome.Services
{
    public class IoC
    {
        public static IUnityContainer Default { get; private set; }
        static IoC()
        {
            Default = new UnityContainer();
            Default.LoadConfiguration();
        }

        public static T Resolve<T>()
        {
            return IoC.Default.Resolve<T>();
        }
    }
}
