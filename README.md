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

Ou se preferir pode executar via Docker seguindo as instruções abaixo.

Digite o comando:
```
docker compose up
```

Agora abra seu navegador e informe a url `http://localhost:8080/swagger/index.html`