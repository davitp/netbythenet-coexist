package net.netbythe.supplier.services;

import com.google.gson.GsonBuilder;
import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;
import lombok.extern.slf4j.Slf4j;
import net.netbythe.supplier.domain.People;
import org.springframework.core.io.ClassPathResource;
import org.springframework.core.io.Resource;
import org.springframework.stereotype.Service;
import org.springframework.util.FileCopyUtils;

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

          Resource resource = new ClassPathResource("classpath:" + fileName);
            InputStream inputStream = resource.getInputStream();
            byte[] bdata = FileCopyUtils.copyToByteArray(inputStream);
            return new String(bdata, StandardCharsets.UTF_8);
           
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
