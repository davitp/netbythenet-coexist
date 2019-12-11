
using System.Collections.Generic;
using IdentityServer4.Models;

public class Config
{
   public static IEnumerable<ApiResource> GetApiResources()
   {
       return new List<ApiResource>
       {
           new ApiResource("supplier", "A .Net Core Application")
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
 
               AllowedScopes = { "read_supplier" }
           }
       };
   }
}