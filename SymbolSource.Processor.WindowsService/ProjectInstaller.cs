using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SymbolSource.Processor.WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            this.BeforeInstall += ProjectInstaller_BeforeInstall;
            this.BeforeUninstall += ProjectInstaller_BeforeUninstall;
        }

        private void ProjectInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            SetServiceName();
            SetDisplayName();
        }

        private void ProjectInstaller_BeforeInstall(object sender, InstallEventArgs e)
        {
            SetServiceName();
            SetDisplayName();
            SetUserNamePassword();
        }

        private void SetDisplayName()
        {
            if (Context.Parameters.ContainsKey("DisplayName"))
            {
                serviceInstaller1.DisplayName = Context.Parameters["DisplayName"];
            }
            else
            {
                serviceInstaller1.DisplayName = "Symbol Source Processor";
            }
        }

        private void SetServiceName()
        {
            if (Context.Parameters.ContainsKey("ServiceName"))
            {
                serviceInstaller1.ServiceName = Context.Parameters["ServiceName"];
            }
            else
            {
                serviceInstaller1.ServiceName = "Symbol Source Processor";
            }
        }

        private void SetUserNamePassword()
        {
            if (Context.Parameters.ContainsKey("UserName") && Context.Parameters.ContainsKey("Password"))
            {
                this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.User;
                this.serviceProcessInstaller1.Username = Context.Parameters["UserName"];
                this.serviceProcessInstaller1.Password = Context.Parameters["Password"];
            }
        }
    }
}
