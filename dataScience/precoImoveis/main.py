# Carregar o conjunto de dados kc_house_data.csv para a memoria
import pandas as pd
data = pd.read_csv('datasets/kc_house_data.csv')

## Mostre as 5 primeiras linhas do dataset
#print(data.head())

## Mostre o numero de coluna e linhaslinhas do dataset
#print(data.shape)

##Mostre o nome das colunas
#print(data.columns)

##Mostre o dataset ordenado pelo preco
#print(data[['id', 'price']].sort_values('price'))


##Mostre o dataset ordenado descrecente pelo preco
#print(data[['id', 'price']].sort_values('price', ascending=False))

def print_perguntas_respostas(pergunta, resposta):
    # Use a breakpoint in the code line below to debug your script.
    print(f'{pergunta} \n R.:{resposta}')  # Press Ctrl+F8 to toggle the breakpoint.


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print_perguntas_respostas('1. Quantas casas estão disponíveis para compra?', data.shape)
    print_perguntas_respostas('2.  Quantos atributos as casas possuem?', data.shape)
    print_perguntas_respostas('3.  Quais são os atributos das casas?', data.columns)
    print_perguntas_respostas('4.  Qual a casa mais cara (com maior valor de venda)?', '')
    print_perguntas_respostas('5.  Qual a casa com maior número de quartos?', '')
    print_perguntas_respostas('6.  Qual a soma total de quartos do conjunto de dados?', '')
    print_perguntas_respostas('7.  Quantas casas possuem 2 banheiros?', '')
    print_perguntas_respostas('8.  Quantas Qual o preço médio de todas as casas do conjunto de dados?', '')
    print_perguntas_respostas('9.  Qual o preço médio de casas com 2 banheiros?', '')
    print_perguntas_respostas('10. Qual o preço minimo entre casas com 3 quartos?', '')
    print_perguntas_respostas('11. Quantas casas possume mais de 300 metros quadrados?', '')
    print_perguntas_respostas('12. Quantas casas tem mais de 2 andares?', '')
    print_perguntas_respostas('13. Quantas casas tem vista para o mar?', '')
    print_perguntas_respostas('14. Das casas com vista para o mar, quantas tem 3 quartos?', '')











# See PyCharm help at https://www.jetbrains.com/help/pycharm/

#Levante Hipóteses sobre o Comportamento do Negócio.
#Casas com garagens são mais caras? Porque?
#Casas com muitos quartos são mais caras? Porque? A partir de quantos quartos o preço aumenta? Qual o incremento de preço por cada quarto adicionado?
#As casas mais caras estão no centro? Qual a região? Existe alguma coisa na região que tem correlação com valor de venda da casa? Shoppings? Montanhas? Pessoas Famosas?

# WARNING: The scripts f2py, f2py3 and f2py3.8 are installed in '/home/katarto/.local/bin' which is not on PATH.
# Consider adding this directory to PATH or, if you prefer to suppress this warning, use --no-warn-script-location.
