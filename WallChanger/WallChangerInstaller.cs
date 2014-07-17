using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WallChanger
{
    [RunInstaller(true)]
    public class WallChangerInstaller : Installer
    {
        public WallChangerInstaller()
        {
            var processInstaller = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};
            var serviceInstaller = new ServiceInstaller {DisplayName = "Wallpaper Changer", StartType = ServiceStartMode.Automatic, ServiceName = "WallChanger" };
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
