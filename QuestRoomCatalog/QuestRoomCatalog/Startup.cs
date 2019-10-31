using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuestRoomCatalog.Web.Startup))]
namespace QuestRoomCatalog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
