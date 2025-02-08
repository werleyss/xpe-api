# xpe-api

## Descrição
O **xpe-api** é um projeto de API REST desenvolvido em **.NET**, seguindo o padrão arquitetural **MVC**. A API tem como objetivo gerenciar produtos, permitindo operações CRUD (Create, Read, Update, Delete) e outras funcionalidades adicionais.

A API pode ser configurada para utilizar **SQLite** ou um banco de dados em **memória**, dependendo da necessidade do ambiente.

## Tecnologias Utilizadas
- **.NET 8+** (C#)
- **Entity Framework Core**
- **SQLite** / Banco em Memória
- **Swagger** (para documentação e testes da API)
- **FluentValidation** (para validação de dados)

## Instalação e Configuração

### Requisitos
- .NET 8+ instalado
- SQLite instalado (se utilizar banco persistente)

### Como Rodar o Projeto

1. Clone o repositório:
   ```sh
   git clone https://github.com/werleyss/xpe-api.git
   cd xpe-api
   ```
2. Restaure as dependências:
   ```sh
   dotnet restore
   ```
3. Execute a aplicação:
   ```sh
   dotnet run
   ```
4. A API estará disponível em `http://localhost:5100`

## Endpoints da API
Abaixo estão os principais endpoints da API de **Produtos**.

### Criar um Produto
- **POST** `/api/v1/products`
- **Body:**
  ```json
  {
    "name": "Produto A",
    "description": "Descrição do Produto A",
    "price": 100.50,
    "sku": "890699994874"
  }
  ```

### Obter Todos os Produtos
- **GET** `/api/v1/products`

### Obter um Produto por ID
- **GET** `/api/v1/products/{id}`

### Atualizar um Produto
- **PUT** `/api/v1/products/{id}`
- **Body:**
  ```json
  {
    "name": "Produto Atualizado",
    "description": "Nova descrição",
    "price": 150.00,
    "sku": "789003123334",
    "active": true
  }
  ```

### Deletar um Produto
- **DELETE** `/api/v1/produts/{id}`

## Testando a API
Para testar a API, você pode utilizar:
- **Swagger**: Acesse `http://localhost:5100/swagger`
- **Postman** ou **Insomnia** para chamadas HTTP

## Licença
Este projeto está sob a licença MIT.

