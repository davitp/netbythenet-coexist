package net.netbythe.supplier.domain;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 * The set of web resources
 * 
 * @author davitp
 */
@AllArgsConstructor
@NoArgsConstructor
@Data
public class People {
    
    /**
     * The ID
     */
    private Integer id;
    
    /**
     * The first name
     */
    private String firstName;
    
    /**
     * The last name
     */
    private String lastName;
    
    /**
     * The email
     */
    private String email;
    
    /**
     * The gender
     */
    private String gender;
    
    /**
     * The IP Address
     */
    private String ipAddress;
}
