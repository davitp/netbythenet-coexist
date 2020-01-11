
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
                    Scopes = new List<Scope> {new Scope("supplier"), new Scope("read"), new Scope("write")},
                    ApiSecrets = { new Secret("supplier_secret".Sha256()) }
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
                        "supplier", "read", "write" 
                    }
                },

                new Client
                {
                    ClientId = "supplier",
                    
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("supplier_secret".Sha256())
                    },
        
                    AlwaysSendClientClaims = true,
                    AllowedScopes = { 
                        "supplier", "read", "write" 
                    }
                }
            };
        }
    }
}