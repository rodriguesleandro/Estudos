#!/bin/bash

resposta_http=$(curl --write-out %{http_code} --silent --output /dev/null http://localhost)

if [ $resposta_http -ne 200 ]
then
mail -s "Problema no servidor" [e-mail de envio]<<del
Houve um problema no servidor e os usuários pararam de ter acesso ao conteúdo web.
del
    systemctl restart apache2
fi
