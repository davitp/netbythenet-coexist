
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
                    Scopes = new List<Scope> {new Scope("read"), new Scope("write")}
                }
            };
        }
        
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
        
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("client_secret".Sha256())
                    },
        
                    AlwaysSendClientClaims = true,
                    AllowedScopes = { 
                        "read", "write" 
                    }
                },

                new Client
                {
                    ClientId = "supplier_client",
        
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("supplier_client_secret".Sha256())
                    },
        
                    AlwaysSendClientClaims = true,
                    AllowedScopes = { 
                        "read", "write" 
                    }
                }
            };
        }
    }
}