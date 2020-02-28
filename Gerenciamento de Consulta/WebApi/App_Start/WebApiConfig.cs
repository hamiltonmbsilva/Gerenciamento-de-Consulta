using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter); // (IPC) Utilizado pra remover o retorno xlm do serviço passando a utilizar o Json

            var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None; // (IPC) Utilizando "None", para remover os "$Id" adicionados pelo Entity Framework, retornando assim comente o resultado real do banco
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // remove o loop da serialização do json
            serializerSettings.ContractResolver = new DefaultContractResolver() // remove os "k__BackingField" que vem nas propriedades do json
            {
                IgnoreSerializableAttribute = true
            };

            // Configuração do Cors
            var corsAttr = new EnableCorsAttribute("http://localhost:8080", "*", "*");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();      

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }                
            );
        }
    }
}
