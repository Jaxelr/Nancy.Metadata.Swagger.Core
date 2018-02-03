[![Build status](https://ci.appveyor.com/api/projects/status/aa0pljkj6db02696/branch/master?svg=true)](https://ci.appveyor.com/project/Jaxelr/nancy-metadata-swagger-aspnetcore/branch/master)

# Nancy.Metadata.Swagger.AspNetCore
This is a port of an existing Nancy.Metadata.Swagger repository (https://github.com/HackandCraft/Nancy.Metadata.Swagger) but targeted to run on Net Standard 2.0. Most of the modifications have been minor tweaks and havent really affected the surface of the API in order to maintain certain backwards compatibility when upgrading to Nancy 2.0.0.

# Introduction

Nancy.Metadata.Swagger is a library that makes it easier to create API documentation for swagger 2.0 (http://swagger.io/) with Nancy metadata modules. This targets exclusively the 2.0 Swagger specification. For a version that targets Open Api 3.0, check the following repo / nuget package (https://github.com/Jaxelr/Nancy.Metadata.OpenApi).

## Dependencies

Nancy.Metadata.Swagger uses Newtonsoft Json.Net (https://www.newtonsoft.com/json) and NJsonSchema for .Net (https://github.com/RSuter/NJsonSchema) to generate objects schema. 
Also it uses some of Nancy stuff, so it should be installed to.

## Gettings started

First you need to install Nancy.Metadata.Swagger.AspNetCore and Nancy.Metadata.Modules nuget packages by:

	PM> Install-Package Nancy.Metadata.Swagger.AspNetCore
	PM> Install-Package Nancy.Metadata.Modules

Once this is done, you must locate your module implementations and generate a metadataModule with the descriptions.

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
**IMPORTANT: Metadata module file should be placed in the same namespace within the module for discovering purposes**

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

After doing this for each module as needed, proceed to configure the endpoint that will serve the documents described. 

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

Now (this is completely optional and its for discovery purposes) you are able to add Swagger-UI (you can download it from http://swagger.io/swagger-ui/ or check the github [repository here](https://github.com/swagger-api/swagger-ui)) and point it to your document module. At the index.html file you can set the default url where swagger-ui should get the json documentation file. This repo contains a Demo App to see an usage example.
