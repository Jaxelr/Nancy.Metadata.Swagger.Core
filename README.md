# Nancy.Metadata.Swagger.AspNetCore
This is a port of an existing Nancy.Metadata.Swagger repository (https://github.com/HackandCraft/Nancy.Metadata.Swagger) but targeted to run on Net Standard 2.0. Most of the modifications have been cosmetical and havent really affected the surface of the API in order to maintain certain backwards compatibility when upgrading to Nancy 2.0.0.

# Introduction

Nancy.Metadata.Swagger is a library that makes it easier to create API documentation for swagger 2.0 (http://swagger.io/) with Nancy metadata modules. This targets exclusively the 2.0 Swagger specification. For a version that targets Open Api 3.0, check the following repo / nuget package (https://github.com/Jaxelr/Nancy.Metadata.OpenApi).

## Dependencies

Nancy.Metadata.Swagger uses Newtonsoft Json.Net (https://www.newtonsoft.com/json) and NJsonSchema for .Net (https://github.com/RSuter/NJsonSchema) to generate objects schema. 
Also it uses some of Nancy stuff, so it should be installed to.

# Gettings started

First you need to install Nancy.Metadata.Swagger.AspNetCore and Nancy.Metadata.Modules nuget packages by:

	PM> Install-Package Nancy.Metadata.Swagger.AspNetCore
	PM> Install-Package Nancy.Metadata.Modules

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
Example metadata module (for ``%modulename%Module`` it should be named ``%modulename%MetadataModule``):
**IMPORTANT: Metadata module file should be placed in the same namespace with module**

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

## Adding the docs module

You also need to create one additional module that will return you json documentation. Here is the sample:

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

## Adding swagger UI:

Now you are able to add swagger UI (you can download it from http://swagger.io/swagger-ui/) and point it to your docs module.
In index.html file you can set default url where ui should get json documentation file. You can also clone this repo and check the Demo App to see an usage example.
