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
            //Open the configuration file using the dll location
            Configuration dllConfig = ConfigurationManager.OpenExeConfiguration(typeof(IoC).Assembly.Location);
            // Get the unity section
            ConfigurationSection unitySecion = dllConfig.GetSection("unity");
            Default = new UnityContainer();
            Default.LoadConfiguration(unitySecion as UnityConfigurationSection);
        }

        public static T Resolve<T>()
        {
            return IoC.Default.Resolve<T>();
        }
    }
}
