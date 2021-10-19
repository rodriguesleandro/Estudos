package jsonPlaceHolder;
import org.junit.jupiter.api.Test;

import utils.RestUtils;

import static org.junit.jupiter.api.Assertions.*;

public class jsonPlaceHolderTest {

    @Test
    public void executaPost()
    {
        String json = "{"
            + " \"userId\": 1,"
            + " \"id\": 1,"
            + " \"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\","
            + " \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\""
            + "}";
            
            RestUtils.setBaseUri("https://jsonplaceholder.typicode.com/");
            String endpoint = "posts";

            RestUtils.postRequest(endpoint, json);

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
 */