#!/bin/bash

PATH_IMAGENS=~/Downloads/imagens-livros

for imagem in $@
do
    convert $PATH_IMAGENS/$imagem.jpg $PATH_IMAGENS/$imagem.png
done
