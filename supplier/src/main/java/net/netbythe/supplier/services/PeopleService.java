package net.netbythe.supplier.services;

import com.google.gson.GsonBuilder;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;
import lombok.extern.slf4j.Slf4j;
import net.netbythe.supplier.domain.People;
import org.springframework.stereotype.Service;

/**
 * The web resources service
 * 
 * @author davitp
 */
@Service
@Slf4j
public class PeopleService {
    
    /**
     * The hardcoded data
     */
    private static final String DATA_HARDCODED = getResourceFileAsString("data.json", "[]");
    
    /**
    * Reads given resource file as a string.
    *
    * @param fileName path to the resource file
    * @return the file's contents
    * @throws IOException if read fails for any reason
    */
    private static String getResourceFileAsString(String fileName, String defaultValue) {
        try {
            ClassLoader classLoader = ClassLoader.getSystemClassLoader();
            try (InputStream is = classLoader.getResourceAsStream(fileName)) {
                if (is == null) return null;
                try (InputStreamReader isr = new InputStreamReader(is);
                    BufferedReader reader = new BufferedReader(isr)) {
                    return reader.lines().collect(Collectors.joining(System.lineSeparator()));
                }
            }
        }
        catch(Throwable e){
            return defaultValue;
        }
    }
  
    /**
     * Get all people from hardcoded data
     * @return 
     */
    public List<People> getAll(){
        return Arrays.asList(new GsonBuilder().create().fromJson(DATA_HARDCODED, People[].class));
    }
}
