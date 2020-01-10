package net.netbythe.supplier;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;

/**
 * The supplier management application
 * 
 * @author davitp
 */
@SpringBootApplication
@EnableEurekaClient
@EnableDiscoveryClient
public class SupplierApplication {

    /**
     * The entry point for "Supplier Application"
     * 
     * @param args The arguments
     */
    public static void main(String[] args) {
        // create an application
        SpringApplication.run(SupplierApplication.class, args);
    }
}