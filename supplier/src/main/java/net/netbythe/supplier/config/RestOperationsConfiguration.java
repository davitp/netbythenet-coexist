package net.netbythe.supplier.config;

import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.client.RestTemplate;

/**
 * Configure rest operations
 * 
 * @author davitp
 */
@Configuration
public class RestOperationsConfiguration {
    
    /**
     * The load balanced rest template client
     * 
     * @return The load balanced rest template
     */
    @LoadBalanced
    @Bean
    public RestTemplate loadBalancedRestTemplate(){
        return new RestTemplate();
    } 
}
