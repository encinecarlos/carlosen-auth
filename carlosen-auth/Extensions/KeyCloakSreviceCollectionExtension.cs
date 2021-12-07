using carlosen_auth.Clients;
using carlosen_auth.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carlosen_auth.Extensions
{
    public static class KeyCloakSreviceCollectionExtension
    {
        public static IServiceCollection AddKeyCloak(this IServiceCollection services, IConfiguration configuration)
        {
            var keyloakSettings = new KeyCloakConfig
            {
                Uri = configuration["KeyCloak:uri"],
                Authority = configuration["KeyCloak:authority"],
                Authorization = configuration["KeyCloak:authorization"],
                UserInfo = configuration["Keycloak:userInfo"]
            };

            services.AddSingleton(Options.Create(keyloakSettings));
            services.AddScoped<IKeyCloakClient, KeyCloakClient>();

            return services;
        }
    }
}
