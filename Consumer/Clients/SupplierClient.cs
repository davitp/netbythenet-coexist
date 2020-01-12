using System.Collections.Generic;
using System.Net.Http;
using Consumer.Model;
using Steeltoe.Common.Discovery;
using Steeltoe.Common.Http.LoadBalancer;
using Steeltoe.Common.LoadBalancer;

namespace Consumer.Clients
{
    public class SupplierClient
    {
        private readonly string service;
        private readonly IDiscoveryClient discoveryClient;

        public SupplierClient(IDiscoveryClient discoveryClient){
            this.service = "supplier";
         
            this.discoveryClient = discoveryClient;
        } 

        public List<People> GetAll(string token){
            var loadBalancer = new RandomLoadBalancer(discoveryClient);
            var handler = new LoadBalancerHttpClientHandler(loadBalancer);
            
            var httpClient = new HttpClient(handler);

            httpClient.SetBearerToken(token);

            var response = httpClient.GetAsync("http://supplier/api/v1/people").Result;

            var result = response.Content.ReadAsAsync<List<People>>().Result;
            
            httpClient.Dispose();
            return result;
        }
        
    }
}