
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("supplier", "A .Net Core Application") {
                    Scopes = new List<Scope> {new Scope("supplier")}
                }
            };
        }
        
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "internal_client",
        
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("internal_client_secret".Sha256())
                    },
        
                    AllowedScopes = { 
                        "supplier" 
                    }
                }
            };
        }
    }
}