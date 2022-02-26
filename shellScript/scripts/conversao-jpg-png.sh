#!/bin/bash

converte_imagens(){
    cd ~/Downloads/imagens-livros

    if [ ! -d png ]
    then
        mkdir png
    fi

    for imagem in *.jpg
    do
        local imagem_sem_extensao=$(ls $imagem | awk -F. '{ print $1 }')
        convert $imagem_sem_extensao.jpg png/$imagem_sem_extensao.png
    done
}

converte_imagens 2>erro.txt

if [ $? -eq 0 ]
then
    echo "Conversao realizada com sucesso"
else
    echo "Houve Falha no processo de conversao"
fi