package net.netbythe.gateway;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;

/**
 * The web gateway application
 * 
 * @author davitp
 */
@EnableEurekaClient
@EnableDiscoveryClient
@SpringBootApplication
public class GatewayApplication {

    /**
     * The entry point for "WebGtw Application"
     * 
     * @param args The arguments
     */
    public static void main(String[] args) {
        SpringApplication.run(GatewayApplication.class, args);
    }
}
