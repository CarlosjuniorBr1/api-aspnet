# API Loja do Seu Manoel

API para otimização de embalagem de produtos em pedidos online.

## Pré-requisitos

- Docker
- Docker Compose

## Como executar

1. Clone o repositório
2. Navegue até a pasta do projeto
3. Execute o comando:

```bash
docker-compose up --build
```

4. Aguarde os containers subirem
5. Acesse o Swagger em: http://localhost:5000/swagger

## Endpoints Disponíveis

### POST /api/embalagem/processar-pedidos
Processa uma lista de pedidos e retorna como embalar cada um.

### GET /api/embalagem/caixas-disponiveis
Retorna as caixas disponíveis para embalagem.

### GET /api/embalagem/pedidos
Lista todos os pedidos processados.

### GET /api/embalagem/pedidos/{id}
Obtém um pedido específico por ID.

## Caixas Disponíveis

- **Caixa 1**: 30 x 40 x 80 cm
- **Caixa 2**: 80 x 50 x 40 cm  
- **Caixa 3**: 50 x 80 x 60 cm

## Exemplo de Entrada (JSON)

```json
{
  "pedidos": [
    {
      "produtos": [
        {
          "id": "produto1",
          "altura": 10,
          "largura": 15,
          "comprimento": 20
        },
        {
          "id": "produto2",
          "altura": 5,
          "largura": 10,
          "comprimento": 8
        }
      ]
    },
    {
      "produtos": [
        {
          "id": "produto3",
          "altura": 25,
          "largura": 35,
          "comprimento": 45
        }
      ]
    }
  ]
}
```

## Exemplo de Saída (JSON)

```json
{
  "resultados": [
    {
      "pedidoId": 1,
      "caixasUsadas": [
        {
          "caixaId": "Caixa1",
          "produtosIds": ["produto1", "produto2"]
        }
      ]
    },
    {
      "pedidoId": 2,
      "caixasUsadas": [
        {
          "caixaId": "Caixa2",
          "produtosIds": ["produto3"]
        }
      ]
    }
  ]
}
```

## Algoritmo de Otimização

A API utiliza um algoritmo que:

1. **Ordena produtos por volume** (do maior para o menor)
2. **Testa todas as orientações possíveis** do produto na caixa
3. **Maximiza a eficiência** do uso do espaço em cada caixa
4. **Minimiza o número de caixas** necessárias por pedido

## Arquitetura

O projeto segue uma arquitetura em camadas:

- **Controllers**: Responsáveis pelos endpoints da API
- **Services**: Contém a lógica de negócio (algoritmo de embalagem)
- **Repositories**: Acesso aos dados (Entity Framework)
- **DTOs**: Objetos de transferência de dados
- **Models**: Entidades do domínio

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Docker
- Swagger/OpenAPI

## Estrutura do Banco de Dados

### Tabela Pedidos
- Id (long, PK, auto-increment)

### Tabela Produtos  
- Id (string, PK)
- Altura (double)
- Largura (double)
- Comprimento (double)
- Volume (double)
- PedidoId (long, FK)

## Testando com Swagger

1. Acesse http://localhost:5000/swagger
2. Expanda o endpoint `POST /api/embalagem/processar-pedidos`
3. Clique em "Try it out"
4. Cole o JSON de exemplo na área de texto
5. Clique em "Execute"

## Parar a Aplicação

```bash
docker-compose down
```

## Logs

Para ver os logs da aplicação:

```bash
docker-compose logs api
```

Para ver os logs do SQL Server:

```bash
docker-compose logs sqlserver
```
