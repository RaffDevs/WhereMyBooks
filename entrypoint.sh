#!/bin/bash
set -e

# Define o diretório de trabalho para onde o projeto está localizado
cd /app/WhereMyBooks/WhereMyBooks.Api

# Aplica as migrações
dotnet ef database update --connection "Host=$DB_SERVER;Port=$DB_PORT;Pooling=true;Database=$DB_DATABASE;User Id=$DB_USER;Password=$DB_PASSWORD;"
cd /app
# Inicia a aplicação
#exec dotnet WhereMyBooks.Api.dll
