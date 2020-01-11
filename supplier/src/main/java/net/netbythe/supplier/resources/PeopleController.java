package net.netbythe.supplier.resources;

import net.netbythe.supplier.services.PeopleService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * The Web Resources  controller
 * 
 * @author davitp
 */
@RestController
@RequestMapping("/api/v1/people")
public class PeopleController {
    
    /**
     * The people service
     */
    @Autowired
    private PeopleService peopleService;
    
    /**
     * Gets all people objects
     * 
     * @return Returns set of people objects
     */
    @GetMapping(path = "")
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<?> getAll(){
        return ResponseEntity.ok(this.peopleService.getAll());
    }
}
