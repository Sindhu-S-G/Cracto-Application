using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Doctors_Information_System.Startup))]
namespace Doctors_Information_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
         
        }
    }
}
