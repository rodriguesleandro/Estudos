package jsonPlaceHolder;
//import org.apache.http.entity.ContentType;
import org.junit.jupiter.api.Test;

import utils.RestUtils;
import Entidades.*;

import static org.junit.jupiter.api.Assertions.*;

import java.util.LinkedHashMap;

public class jsonPlaceHolderTest {

    String json = "{" //ou lê um arquivo
            + " \"userId\": 1,"
            + " \"id\": 1,"
            + " \"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\","
            + " \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\""
            + "}";
    
    String token = "";

           
    @Test
    public void executaPost()
    {
        
            RestUtils.setBaseUri("https://jsonplaceholder.typicode.com/");
            String endpoint = "posts";

            RestUtils.postRequest(endpoint, json);

            assertEquals("sunt aut facere repellat provident occaecati excepturi optio reprehenderit", RestUtils.getResponse("title"));
    }

    @Test
    public void executaLogin()
    {
        String jsonWithToken = "{" //token colocado aki para simulação de catar no retorno
        + " \"userId\": 1,"
        + " \"senha\": \"abcdefg\","
        + "\"token\": \"538692fe-40a7-4359-9048-a5eaacfa4c44\""
        + "}";

        RestUtils.setBaseUri("https://jsonplaceholder.typicode.com/");
            String endpoint = "posts";
        
        RestUtils.postRequest(endpoint, jsonWithToken);

        assertEquals(201, RestUtils.getStatusCode());

        token = "Bearer " + RestUtils.getResponse("token");
        //executaPostLogado();

    }

    @Test
    public void executaLoginMap()
    {
        LinkedHashMap<String, Object> jsonMap = new LinkedHashMap<>();
        jsonMap.put("userId", 1);
        jsonMap.put("senha", "abcdefg");
        jsonMap.put("token", "538692fe-40a7-4359-9048-a5eaacfa4c44");


        RestUtils.setBaseUri("https://jsonplaceholder.typicode.com/");
            String endpoint = "posts";
        
         RestUtils.postRequest(endpoint, jsonMap);

         assertEquals(201, RestUtils.getStatusCode());

        //token = "Bearer " + RestUtils.getResponse("token");
        //executaPostLogado();
    }

    @Test
    public void executaLoginClasse()
    {
        Login jsonClasse = new Login(1, "abcdefg", "538692fe-40a7-4359-9048-a5eaacfa4c44");
        

        RestUtils.setBaseUri("https://jsonplaceholder.typicode.com/");
            String endpoint = "posts";
        
         RestUtils.postRequest(endpoint, jsonClasse);

         assertEquals(201, RestUtils.getStatusCode());

        token = "Bearer " + RestUtils.getResponse("token");
        //executaPostLogado();
    }

    @Test
    public void executaPostLogado()
    {
        RestUtils.setBaseUri("https://jsonplaceholder.typicode.com/");
            String endpoint = "posts";

        LinkedHashMap<String, String> header = new LinkedHashMap<>();
        header.put("Authentication", token);
        //header.put("Content Type", ContentType.APPLICATION_JSON.toString());

        RestUtils.postRequest(endpoint, header, json);

        assertEquals("sunt aut facere repellat provident occaecati excepturi optio reprehenderit", RestUtils.getResponse("title"));
    }


    @Test
    public void executaPostLogadoClasse()
    {
        Post jsonPost = new Post(1, 1, "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", "quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto" );

        

        RestUtils.setBaseUri("https://jsonplaceholder.typicode.com/");
            String endpoint = "posts";

        LinkedHashMap<String, String> header = new LinkedHashMap<>();
        header.put("Authentication", token);
        //header.put("Content Type", ContentType.APPLICATION_JSON.toString());

        RestUtils.postRequest(endpoint, header, jsonPost);

        assertEquals("sunt aut facere repellat provident occaecati excepturi optio reprehenderit", RestUtils.getResponse("title"));
    }


    
}
/*
https://jsonplaceholder.typicode.com/posts
{
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
}

{538692fe-40a7-4359-9048-a5eaacfa4c44}
 */