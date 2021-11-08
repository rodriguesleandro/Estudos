#language:pt
@GetCep
Funcionalidade: Get CEP
Descricao Realizar um Get no CEP

Cenario: Valida CEP
Dado que seja recebido um cep valido com o valor "04055041"
Quando for realizado uma requisicao do tipo Get
Entao o sistema devolve o campo "logradouro" com o valor "Rua Mauro"
