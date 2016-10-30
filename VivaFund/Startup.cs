using Microsoft.Owin;
using Owin;
using System.IdentityModel.Claims;

[assembly: OwinStartup(typeof(VivaFund.Startup))]
namespace VivaFund
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
