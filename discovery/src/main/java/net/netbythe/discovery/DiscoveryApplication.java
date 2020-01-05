package net.netbythe.discovery;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;



/**
 * The Discovery Application
 * 
 * @author davitp
 */
@SpringBootApplication
@EnableEurekaServer
public class DiscoveryApplication {

    /**
     * The entry point for "Discovery Application"
     * 
     * @param args The arguments
     */
    public static void main(String[] args) {
        // create an application
        SpringApplication.run(DiscoveryApplication.class, args);
    }
}
