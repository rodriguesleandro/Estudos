package Entidades;

import java.util.LinkedHashMap;

public class Header {
    private LinkedHashMap<String, String> header = new LinkedHashMap<>();

    public Header()
    {
        
    }

    public LinkedHashMap<String,String> getHeader()
    {
        return header;
    }

    public void setHeader(String key, String value)
    {
        header.put(key, value);
    }
    public void removeKey(String key)
    {
        header.remove(key);
    }
    
}
