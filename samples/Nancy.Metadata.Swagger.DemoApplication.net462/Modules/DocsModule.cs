using Nancy.Metadata.Swagger.Modules;
using Nancy.Routing;
using System.Threading.Tasks;

namespace Nancy.Metadata.Swagger.DemoApplication.Modules
{
    public class DocsModule : SwaggerDocsModuleBase
    {
        public DocsModule(IRouteCacheProvider routeCacheProvider)
            : base(routeCacheProvider, "/api/docs/swagger.json", "Sample API documentation", "v1.0", "localhost:53053", "/api", "http")
        {
            Get["/", true]  = async (_, __) =>
                await Task.Run(() => Response.AsRedirect("/Content/index.html"))
                .ConfigureAwait(false);
        }
    }
}
