using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBillPay.Startup))]
namespace OnlineBillPay
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
