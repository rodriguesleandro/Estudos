package viaCep;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeAll;

import utils.*;


public class ViaCepGetTest {

	static String url = "http://viacep.com.br/ws/";
	
	static String endpoint;
	
	@BeforeAll
	public static void setResponse() {
		RestUtils.setBaseUri(url); 
		String cep = "11704520";
		String formatoResponse = "json";
		endpoint = cep + "/" + formatoResponse; 
	}
	
	@Test
	public void validacodigoStatusGet() {
		
		RestUtils.validaStatusCode(200, endpoint);

	}	
	
	@Test
	public void validaDadosGet()
	{		
		RestUtils.getRequest(endpoint);
		
		assertEquals("Rua Carlos Vanderlinde", RestUtils.getResponse("logradouro"));
		assertEquals("Ocian", RestUtils.getResponse("bairro"));
	}
	
	
	
	
	
	
	
	
}
