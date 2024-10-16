# TesteCaixa

API para determinar quais caixas utilizar para cada produto de acordo com suas dimensões.

## Executando via dotnet cli

Clone o repositorio para sua maquina em seguida degite o seguinte comando para buildar o projeto:
```
dotnet build .\TesteCaixa.Api\
```

Para executar digite:
```
dotnet watch run --project .\TesteCaixa.Api\
```

Para rodar os testes unitários digite:
```
dotnet test .\TesteCaixa.Tests\
```

Para cobertura de teste digite:
```
dotnet test .\TesteCaixa.Tests\ --collect:"XPlat Code Coverage"
```

E acesse a paste `TesteCaixa.Tests` e digite o comando:
```
reportgenerator -reports:"TestResults\coloque-GUID-gerado-aqui\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

O relatório da cobertura de teste vai estar na pasta `coveragereport`, basta abrir o arquivo `index.html` no navegador.

>[!NOTE]
> Se a ferramenta de report de cobertura de teste não for encontrada pode instalar digitando o comando `dotnet tool install -g dotnet-reportgenerator-globaltool` assim vai ser possivel gerar os relatórios.

Outra opção é executar o projeto via Docker seguindo as instruções. Digite o comando:
```
docker compose up
```

Agora abra seu navegador e informe a url `http://localhost:8080/swagger/index.html`

Após executar a aplicação informe esta apikey abaixo usando o botão de Authorize do swagger para consumir o endpoint:
```
en7RdTeVJctQzkrADmhTvDJsFcB5MkBGuK3HutbpgzKffNFuKiyQ3CGK5qauwvAETsUTSyWes4T9KRuVnm4JmS1wafJB01VxL7mEiuwzm975CsnxcZvlPQ9AluP1GJ4l
```

Caso estiver usando outro cliente para consumir a requisição é só informar a Apikey no Header 
```
Header {"x-api-key": "en7RdTeVJctQzkrADmhTvDJsFcB5MkBGuK3HutbpgzKffNFuKiyQ3CGK5qauwvAETsUTSyWes4T9KRuVnm4JmS1wafJB01VxL7mEiuwzm975CsnxcZvlPQ9AluP1GJ4l"}
```
