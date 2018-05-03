[![Build status][build-svg]][build] [![NuGet][nuget-svg]][nuget] [![MyGet][myget-img]][myget] [![Mit License][mit-img]][mit]

# Nancy.Metadata.Swagger.Core 
This is a port of an existing Nancy.Metadata.Swagger repository (https://github.com/HackandCraft/Nancy.Metadata.Swagger) but updated to target to run on the latest version of NancyFx and also on Net Standard 1.6. Most of the modifications have been minor tweaks and havent really affected the surface of the API in order to maintain certain backwards compatibility when targeting Nancy 1.+ and 2.+.

# Introduction

Nancy.Metadata.Swagger is a library that makes it easier to create API documentation for swagger 2.0 (http://swagger.io/) with Nancy metadata modules. This targets exclusively the 2.0 Swagger specification. For a version that targets Open Api 3.0.0, check the following [library](https://github.com/Jaxelr/Nancy.Metadata.OpenApi).

## Dependencies

Nancy.Metadata.Swagger uses Newtonsoft Json.Net (https://www.newtonsoft.com/json) and NJsonSchema for .Net (https://github.com/RSuter/NJsonSchema) to generate objects schema. 
Also it uses some of Nancy libs, so it should be installed to.

## Gettings started

First you need to install Nancy.Metadata.Swagger.Core and Nancy.Metadata.Modules nuget packages by:

	PM> Install-Package Nancy.Metadata.Modules 
    PM> Install-Package Nancy.Metadata.Swagger.Core

*Keep in mind this library works with the prerelease version 2.0 of Nancy, but you must specify the -Version option. 

Once this is done, locate your module implementations and generate a MetadataModule with the descriptions.

This is a sample implementation of of a Nancy Module:

```c#
public class RootModule : NancyModule
{
	public RootModule() : base("/api")
	{
	    Get["SimpleRequestWithParameter", "/hello/{name}"] = r => Hello(r.name);
	}
}
```
The example metadata module (for ``%modulename%Module`` should be named ``%modulename%MetadataModule``):

```c#
public class RootMetadataModule : MetadataModule<SwaggerRouteMetadata>
{
    public RootMetadataModule()
    {
        Describe["SimpleRequestWithParameter"] = desc => new SwaggerRouteMetadata(desc)
            .With(i => i.WithResponseModel("200", typeof(SimpleResponseModel), "Sample response")
                        .WithRequestParameter("name"));
    }
}
```

** !IMPORTANT: Metadata module file should be placed in the same namespace within the module for discovering purposes**

After doing this for each module as needed, we must proceed to configure the endpoint that will serve the documents described. 

## Adding the docs module

This module  will return your json documentation. The key is the inheritance from SwaggerDocsModuleBase.

Here's a sample module:

```c#
public class DocsModule : SwaggerDocsModuleBase
{
    public DocsModule(IRouteCacheProvider routeCacheProvider) 
        : base(routeCacheProvider, 
          "/api/docs", 					// where module should be located
          "Sample API documentation",   // title
          "v1.0", 						// api version
          "localhost:5000",             // host
          "/api", 						// api base url (ie /dev, /api)
          "http")						// schemes
    {
    }
}
```

Default values are provided, but I strongly suggest you configure yours obtaning them from config files or environment vars.

### Adding swagger UI:

Now (this is completely optional and its mostly for discovery purposes) you are able to add Swagger-UI (you can download it from http://swagger.io/swagger-ui/ or check the github [repository here](https://github.com/swagger-api/swagger-ui) or heck use [npm](https://www.npmjs.com/package/swagger-ui)) and point it to your document module. At the index.html file you can set the default url where swagger-ui should get the json documentation file. This repo contains a Demo App to see an usage example.

### Missing Swagger features

Since Swagger's latest standard is for OpenApi (Version 3.+), i would not be putting any type of effort into adding enhancements to this library, since the functionality mostly covers my current needs. I will probably just take care of bumps to the release version of netcore for Nancy, Swagger-UI and any bugs found. By all means, Feel free to Clone and PR away if you would like to add any new features.


[mit-img]: http://img.shields.io/badge/License-MIT-blue.svg
[mit]: https://github.com/Jaxelr/Nancy.Metadata.Swagger.Core/blob/master/LICENSE
[build]: https://ci.appveyor.com/project/Jaxelr/nancy-metadata-swagger-core/branch/master
[build-svg]: https://ci.appveyor.com/api/projects/status/gkqlkxk28ig0r443/branch/master?svg=true
[nuget]: https://www.nuget.org/packages/Nancy.Metadata.Swagger.Core
[nuget-svg]: https://img.shields.io/nuget/v/Nancy.Metadata.Swagger.Core.svg
[myget-img]: https://img.shields.io/myget/nancy-metadata-swagger/v/Nancy.Metadata.Swagger.Core.svg
[myget]: https://www.myget.org/feed/nancy-metadata-swagger/package/nuget/Nancy.Metadata.Swagger.Core
