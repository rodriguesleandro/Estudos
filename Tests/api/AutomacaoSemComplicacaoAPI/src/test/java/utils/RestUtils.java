package utils;

import io.restassured.http.ContentType;
import io.restassured.response.Response;

import static io.restassured.RestAssured.*;

import java.util.LinkedHashMap;

public class RestUtils {

    static Response response;
    public static void setBaseUri(String uri){
        baseURI = uri;        
    }
    public static String GetBaseUri(){
        return baseURI;
    }

    public static void getRequest(String endpoint) {
		response = given()
				.relaxedHTTPSValidation()
				.get(endpoint)
				.then()
				.extract()
				.response();
	}

    public static void getRequest(String endpoint, LinkedHashMap<String, String> header) {
		response = given()
				.relaxedHTTPSValidation()
                .headers(header)
				.get(endpoint)
				.then()
				.extract()
				.response();
	}

    public static void getRequest(String endpoint, LinkedHashMap<String, String> header, LinkedHashMap<String, String> params) {
		response = given()
				.relaxedHTTPSValidation()
                .headers(header)
                .params(params)
				.get(endpoint)
				.then()
				.extract()
				.response();
	}

    public static Object getResponse(String key) {
		return response.getBody().jsonPath().get(key);
	}

    public static String getBody()
	{
		return response.getBody().asString();
	}

    public static void validaStatusCode(int status, String endpoint) {
		given()
		.relaxedHTTPSValidation()
		.when()
		.get(endpoint)
		.then()
		.statusCode(status);
	}

    public static void postRequest(String endpoint, Object body) {
		response = given()
				.relaxedHTTPSValidation()
                .body(body)
                .contentType(ContentType.JSON)
				.post(endpoint)
				.then()
				.extract()
				.response();
	}

    public static void postRequest(String endpoint, LinkedHashMap<String, String> header, Object body) {
		response = given()
				.relaxedHTTPSValidation()
                .body(body)
                .headers(header)
				.post(endpoint)
				.then()
				.extract()
				.response();
	}
}
//1h11 aula 5

