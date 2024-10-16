# TesteCaixa

O que é?

API para determinar quais caixas utilizar para cada produto de acordo com suas dimensões.

## Execução

### Dotnet CLI

Clone o repositorio para sua maquina em seguida degite o seguinte comando para buildar o projeto:
```
dotnet build .\TesteCaixa.Api\
```

Para executar digite:
```
dotnet watch run --project .\TesteCaixa.Api\
```

### Docker Compose

Para xecutar o projeto via Docker seguindo as instruções. Digite o comando:
```
docker compose up
```

Agora abra seu navegador e informe a url `http://localhost:8080/swagger/index.html`

## Testes

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

## Uso

Após executar a aplicação informe esta apikey abaixo usando o botão de Authorize do swagger para consumir o endpoint:
```
en7RdTeVJctQzkrADmhTvDJsFcB5MkBGuK3HutbpgzKffNFuKiyQ3CGK5qauwvAETsUTSyWes4T9KRuVnm4JmS1wafJB01VxL7mEiuwzm975CsnxcZvlPQ9AluP1GJ4l
```

Caso estiver usando outro cliente para consumir a requisição é só informar a Apikey no Header 
```
Header {"x-api-key": "en7RdTeVJctQzkrADmhTvDJsFcB5MkBGuK3HutbpgzKffNFuKiyQ3CGK5qauwvAETsUTSyWes4T9KRuVnm4JmS1wafJB01VxL7mEiuwzm975CsnxcZvlPQ9AluP1GJ4l"}
```

Em seguida basta consumir a rota orders, veja abaixo um exemplo:

```http
POST /api/v1/orders HTTP/1.1
Content-Type: application/json
User-Agent: insomnia/2023.5.8
X-Api-Key: en7RdTeVJctQzkrADmhTvDJsFcB5MkBGuK3HutbpgzKffNFuKiyQ3CGK5qauwvAETsUTSyWes4T9KRuVnm4JmS1wafJB01VxL7mEiuwzm975CsnxcZvlPQ9AluP1GJ4l
Host: localhost:7163
Content-Length: 1533

{
  "orders": [
    {
      "orderId": 85,
      "products": [
        {
          "productId": "mouse",          
          "dimensions": {
            "height": 5,
            "width": 10,
            "length": 7
          }
        },
		{
          "productId": "Teclado",          
          "dimensions": {
            "height": 20,
            "width": 10,
            "length": 10
          }
        },
		{
          "productId": "Cadeira gamer",          
          "dimensions": {
            "height": 220,
            "width": 101,
            "length": 50
          }
        }
      ]
    },
	{
      "orderId": 10,
      "products": [
        {
          "productId": "Tenis",          
          "dimensions": {
            "height": 10,
            "width": 10,
            "length": 7
          }
        },
		{
          "productId": "Mesa Gamer",          
          "dimensions": {
            "height": 100,
            "width": 150,
            "length": 80
          }
        },
		{
          "productId": "Pendriver",          
          "dimensions": {
            "height": 8,
            "width":4,
            "length": 2
          }
        },
		{
          "productId": "Monitor",          
          "dimensions": {
            "height": 50,
            "width":60,
            "length": 20
          }
        },
		{
          "productId": "PS5",          
          "dimensions": {
            "height": 40,
            "width":10,
            "length": 25
          }
        }
      ]
    }
  ]
}
```
