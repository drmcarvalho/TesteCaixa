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
reportgenerator -reports:"TestResults\d4d85a3c-b861-489c-8ef9-df1ba8ed1f01\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

O relatorio da cobertura de teste vai estar na pasta `coveragereport` e basta abrir o `index.html` no navegador.

>[!NOTE]
> Se a ferramenta de report de cobertura de teste não for encontrada pode instalar digitando o comando `dotnet tool install -g dotnet-reportgenerator-globaltool` assim vai ser possivel gerar os relatórios.

Ou se preferir pode executar via Docker seguindo as instruções abaixo.

Digite o comando:
```
docker compose up
```

Agora abra seu navegador e informe a url `http://localhost:8080/swagger/index.html`