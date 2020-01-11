package net.netbythe.supplier.config;

import com.netflix.discovery.EurekaClient;
import java.io.IOException;
import lombok.extern.slf4j.Slf4j;
import net.netbythe.supplier.services.CustomTokenServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.client.ClientHttpResponse;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.oauth2.config.annotation.web.configuration.EnableResourceServer;
import org.springframework.security.oauth2.config.annotation.web.configuration.ResourceServerConfigurerAdapter;
import org.springframework.security.oauth2.config.annotation.web.configurers.ResourceServerSecurityConfigurer;
import org.springframework.security.oauth2.provider.token.RemoteTokenServices;
import org.springframework.web.client.DefaultResponseErrorHandler;
import org.springframework.web.client.RestTemplate;

/**
 * The resource security configuration
 * 
 * @author davitp
 */
@Configuration
@EnableResourceServer
@Slf4j
public class ResourceSecurityConfiguration extends ResourceServerConfigurerAdapter {
    
    /**
     * The client ID
     */
    @Value("${security.oauth2.client.clientId}") 
    private String clientId;
	
    /**
     * The client secret
     */
    @Value("${security.oauth2.client.clientSecret}")
    private String clientSecret;

    /**
     * The token URI
     */
    @Value("${security.oauth2.resource.token-info-uri}")
    private String tokenInfoUri;
        
    /**
     * The eureka client
     */
    @Autowired
    private EurekaClient eurekaClient;
    
    /**
     * List all the paths that are publicly available
     */
    private static final String[] AUTH_WHITELIST = {
            // -- swagger ui
            "/v2/api-docs",
            "/swagger-resources",
            "/swagger-resources/**",
            "/configuration/ui",
            "/configuration/security",
            "/swagger-ui.html",
            "/webjars/**"
            // other public endpoints of your API may be appended to this array
    };


    /**
     * Configure HTTP Security
     * 
     * @param http The HTTP 
     * @throws Exception 
     */
    @Override
    public void configure(HttpSecurity http) throws Exception {
        http
            .authorizeRequests()
            .antMatchers(AUTH_WHITELIST).permitAll()
            .antMatchers("/**").authenticated();
    }
    
    /**
     * Configure the resource server security
     * 
     * @param resources The resources object
     * @throws Exception 
     */
    @Override
    public void configure(ResourceServerSecurityConfigurer resources) throws Exception {
        resources.resourceId("supplier");
//        // token services
//        var tokenServices = new CustomTokenServices(eurekaClient);
//        
//        tokenServices.setClientId(this.clientId);
//        tokenServices.setClientSecret(this.clientSecret);
//        tokenServices.setCheckTokenEndpointUrl(this.tokenInfoUri);
//                
//        resources.tokenServices(tokenServices);
    }
}
